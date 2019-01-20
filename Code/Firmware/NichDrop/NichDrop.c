/*
 * NichDrop.c
 *
 *		  Name: MOSFET Trigged Timer Based Dropoff
 *  Created on: 03/02/2010
 *      Author: Matthew Cochrane
 *  	   MCU: ATMEGA168(PV)
 *   Fuse Bits:
 *   	High - 0xDF
 *   	 Low - 0x62
 *
 */

#include "NichDrop.h"

char s[80];
char s1[80];
volatile unsigned char patience;
uint8_t wakeSource = WAKEUP_SOURCE_NONE;
unsigned char ICRR;
unsigned char OCRR;
unsigned char DropTime;
unsigned char DevArmed;
unsigned char Wakeups;
unsigned char wtick;
uint32_t Device_ID;
RTC_Time_t aTime;
RTC_Time_t wTime;
unsigned char BGRefV[5];	//char 5 for '\0'
volatile uint16_t timer10ms = 0;
uint8_t WakeDecision = WAKEUP_ACT_WASRESET;

ISR(TIMER0_OVF_vect) {
	USART_UpdateTimers();
}

ISR(PCINT2_vect) {
	wakeSource = WAKEUP_SOURCE_UART;
}

ISR(PCINT1_vect) {
	wakeSource = WAKEUP_SOURCE_RTC;
}

int main(void) {

	RTC_Time_t mTime1, mTime2, mTime3;

	PCMSK1 |= (1<<PCINT9); 	// for the RTC alarm
	PCMSK2 |= (1<<PCINT16); // for RS232/UART

	//0 - LED, 3 - RTCVCC, 4 - SDA, 5 - SCL
	DDRC = (1<<0)|(1<<3)|(1<<4)|(1<<5);
	//USART Tx
	DDRD = (1<<1);
	//0 - NichON, 2 - NichPWM (Charge Pump)
	DDRB = (1<<2)|(1<<0);

	// Enable pullups
	PORTC = 0b00111001;
	PORTD = 0b11111111;

	//Load in values from EEPROM:
	ReadEEPROM(BGRefV, 4, CONVFACTADD);
	ReadEEPROM((uint8_t*)&Device_ID, 4, DEVIDADD);
	ReadEEPROM(&DevArmed, 1, DEVARMEDADD);
	ReadEEPROM(&DropTime, 1, DROPTIMEADD);
	ReadEEPROM(&OCRR, 1, TOPADD);
	ReadEEPROM(&ICRR, 1, RESETADD);
	ReadTimeEEPROM(&aTime, ALARMTADD);

	BGRefV[4] = '\0';

	if (!ValidDateTime(&aTime)) {
		ReadTimeEEPROM(&aTime, DALARMTADD);
	}

	if (DevArmed == ARM_SHELF) {
		RTCProgOn;
		//Enable the stop bit on the RTC
		RTC_set_msk(0x01,0, 0b10000000);
	} else {

		ReadTimeEEPROM(&mTime1, LASTWAKEADD);

		//If the RTC time is no longer valid then
		//set the RTC to the last time we woke up..
		//In case of a power failure.
		RTCProgOn;
		RTC_GetTime(&mTime2);

		//Generate a time 1 day after the last wakeup
		ClearTime(&mTime3);
		mTime3.Day = 1;
		mTime3.Hour = 1;
		AddTimes(&mTime3, &mTime1);

		if (ValidDateTime(&mTime2) && FirstTimeGreater(&mTime2,&mTime1) && !(FirstTimeGreater(&mTime2, &mTime3))) {
			//TODO[x]:  If the RTC time is set to some random garbage date on reset that happens to be valid
			//			and also after the last wakeup, we're in trouble.  Check to see that the RTC time is no
			//			more than one day after the last wakeup time (as it shouldn't be).
			//RTC Time is valid, after the last wakeup time but not by more than one day.
			//Leave the RTC time as is and set the last wakeup time to now.
			WriteTimeEEPROM(&mTime2, LASTWAKEADD);

			//wake up in 10 seconds
			ClearTime(&mTime3);
			mTime3.Second = 10;
			AddTimes(&mTime2, &mTime3);
			CopyTime(&mTime2,&wTime);
			RTC_SetAlarm(&mTime2);

			//make sure the timer is running
			if (RTC_get(0x01)&0b10000000)
				RTC_set_msk(0x01,0, 0b10000000);
		} else {
			if (!ValidDateTime(&mTime1)) {
				//For initial time after programming.. or if time becomes invalid
				ReadTimeEEPROM(&mTime1, DTIMEADD);
				//stop the timer
				RTC_set_msk(0x01,0b10000000, 0b10000000);
			} else {
				//Time is valid
				//wake up in 3 seconds
				RTC_SetTime(&mTime1);
				ClearTime(&mTime2);
				mTime2.Second = 3;
				AddTimes(&mTime1, &mTime2);
				CopyTime(&mTime1,&wTime);
				RTC_SetAlarm(&mTime1);
			}
		}
	}

	//enable interrupts
	sei();

	set_sleep_mode(SLEEP_MODE_PWR_DOWN);
	_delay_ms(1000);
	BacktoSleep(1);

	while (1) {

		if (wakeSource == WAKEUP_SOURCE_UART) {
			PORTC |= (1<<0); // turn on LED
			PCICR &=~((1<<PCIE2));//|(1<<PCIE1)); // Disable  interrupts
			PRR &= ~((1<<PRUSART0)|(1<<PRTWI)|(1<<PRSPI)); // Turn ON the USART, TWI and SPI

			//Setup USART for 9600bps
			USART_Setup(UBRRVAL,1);

			_delay_ms(10);
			Wakeups++;
			//sprintf_P(s1, PSTR("Waking up... (%d)\r\n"),Wakeups);
			//USART_tx_String(s1);
			//while ( UCSR0A & (1<<RXC0)) wtick = UDR0;
			//USART_tx_String_P(PSTR("UART woke me up\r\n"));

			RTCProgOn;

			//Handle serial comms
			do {
				while ( UCSR0A & (1<<RXC0)) wtick = UDR0;
			} while (Ser_CMDHandler() != SerCom_err_Timeout);

			if (DevArmed == ARM_SHELF) {
				//Enable the RTC Stop Bit
				RTC_set_msk(0x01,0b10000000, 0b10000000);
			} else {
				//Just in case we were interrupted by the RTC while awake (i.e. we missed that RTC
				//wake up), run through all the RTCWakeup code.  If we missed one and we don't do this
				//the RTC will never wake us up again and we'll be stuck asleep forever!
				RTCFullWakeup();
			}
			BacktoSleep(0);

		} else if (wakeSource==WAKEUP_SOURCE_RTC) {
			if (DevArmed == ARM_SHELF) {
				RTCProgOn;
				//Enable the RTC Stop Bit
				RTC_set_msk(0x01,0b10000000, 0b10000000);
			} else {
				RTCFullWakeup();
				BacktoSleep(0);
			}
		} else
			BacktoSleep(1);
	}

	return 0;
}

void SetNextWakeupIn(uint8_t months, uint8_t days, uint8_t hrs, uint8_t mins, uint8_t secs) {
	RTC_Time_t mTime1, mTime2;
	
	RTC_GetTime(&mTime1);
	ClearTime(&mTime2);
	mTime2.Month = months;
	mTime2.Day = days;
	mTime2.Hour = hrs;
	mTime2.Minute = mins;
	mTime2.Second = secs;
	AddTimes(&mTime1,&mTime2);
	CopyTime(&mTime1, &wTime);
	RTC_SetAlarm(&wTime);
}

#ifdef DEBUGWAKESAVE
void SaveWakeupInfo() {
	//First just save the time...
	//First byte is no. of entries.
	RTC_Time_t mTime1;
	uint8_t mIndex;
	uint16_t EEPAdd;

	if (DevArmed == ARM_SHELF)
		return;

	//if we didn't dropoff then don't save any info.
	if (WakeDecision != WAKEUP_ACT_NONE || wakeSource == WAKEUP_SOURCE_UART) {
		mIndex = eeprom_read_byte((uint8_t*)RECENTRIES);

		EEPAdd = RECSTART+7*mIndex;

		if (EEPAdd >= RECSTART && EEPAdd < 506) {

			PRR &= ~((1<<PRTWI)); // Turn ON the TWI
			//Setup I2C (TWI)
			RTCProgOn;
			//Get the current RTC time
			RTC_GetTime(&mTime1);

			WriteTimeEEPROM(&mTime1, EEPAdd);
			eeprom_write_byte((uint8_t*)(EEPAdd+6), WakeDecision | wakeSource<<4);
			//increment the index:
			eeprom_write_byte((uint8_t*)RECENTRIES, mIndex + 1);
		}
	}
}
#endif


void DropOff () {
	uint16_t tmpDropTime = ((unsigned int)eeprom_read_byte((uint8_t*)DROPTIMEADD))*1000;
	PORTC |= (1<<0);
	uint8_t Acts;
	Acts = eeprom_read_byte((uint8_t*)ACTIVATIONS);
	if (Acts < 6) {
		if (DevArmed == ARM_ON) {
			//Device is armed - DROPOFF!!!
			Release(tmpDropTime);
		} else {
			delay_ms(tmpDropTime);
		}
		eeprom_write_byte((uint8_t*)ACTIVATIONS, Acts + 1);
	}
}

void Release ( unsigned int ms ) {

	unsigned char step = 0;

	ICRR = eeprom_read_byte((uint8_t*)TOPADD);
	OCRR = eeprom_read_byte((uint8_t*)RESETADD);

	step = (ICRR-OCRR)/10;

	OCRR = ICRR;

	PRR &= ~(1<<PRTIM1);		//enable Timer1
	ICR1 = ICRR;				//count to ??
	OCR1BL = OCRR;   			//duty ratio = ??
	OCR1BH = 0;
	TCNT1 = 0;

	PORTB |= (1<<0);			//enable the charge pump
	TCCR1A = 0b11110000;		//Setting up Timer 1
	//TCCR1B = 0b00010001;		//f = fCPU
	TCCR1B = 0b00010010;		//f = fCPU/8 - 1MHz

	delay_ms(ms);

	TCCR1A = 0;					//Turn off the timer
	PRR |= (1<<PRTIM1);			//disbale the timer
	PORTB &= ~(1<<0);			//Turn off the charge pump
	delay_ms(1);
}

//void ShowMenu () {

// 	unsigned char p;
// 	uint8_t i;
// 	char skipPrintRTC = 0;
// 	RTC_Time_t mTime1, mTime2;
// 	uint16_t bV;
// 
// 	USART_tx_String_P(PSTR( "Nichrome dropoff\r\n"
// 							"Version 1.0.0\r\n"
// 							"\r\n>"));
// 							/*
// 							"              g : Test the dropoff\r\n"
// 							"         ARMEDX : Set device arm status (0,1,2) \r\n"
// 							//"              h : Calibrate charge pump\r\n"
// 							//"            r## : Set release time (secs)\r\n"
// 							"              b : Show battery voltage (4-byte Hex)\r\n"
// 							//"          vXXXX : Set low battery voltage (4-byte Hex)\r\n"
// 							//"          cXXXX : Set critical battery voltage (4-byte Hex)\r\n"
// 							//"      IXXXXXXXX : Set Device ID\r\n"
// 							"  tYYMMDDHHMMSS : Set time\r\n"
// 							"    aYYMMDDHHMM : Set alarm\r\n"
// 							"              ? : Read out constants\r\n"
// 							"              * : Set constants\r\n"
// 							"              T : Get test Info\r\n"
// 							"              C : Clear entries\r\n"
// 							"          ENTER : Show current time/alarm\r\n"
// 							"\r\n> "));*/
// 
// 	p = USART_rx_String(s,TIMEOUT);
// 	if (p > 0) {
// 		p = 18;
// 		while (p) { s[p]=s[p] - '0'; p--; }
// 		if (s[0] == 't') {
// 			mTime1.Year = BCDToInt((s[1]<<4)|s[2]);
// 			mTime1.Month = BCDToInt((s[3]<<4)|s[4]);
// 			mTime1.Day = BCDToInt((s[5]<<4)|s[6]);
// 			mTime1.Hour = BCDToInt((s[7]<<4)|s[8]);
// 			mTime1.Minute = BCDToInt((s[9]<<4)|s[10]);
// 			mTime1.Second = BCDToInt((s[11]<<4)|s[12]);
// 			if (DevArmed != ARM_SHELF) {
// 				if (ValidDateTime(&mTime1)) {
// 					RTC_SetTime(&mTime1);
// 					USART_tx_String_P(PSTR("TSET \r\n"));
// 					WriteTimeEEPROM(&mTime1, LASTWAKEADD);
// 					ClearTime(&mTime2);
// 					mTime2.Second = 10;
// 					AddTimes(&mTime1,&mTime2);
// 					RTC_SetAlarm(&mTime1);
// 					CopyTime(&mTime1, &wTime);
// 				} else {
// 					USART_tx_String_P(PSTR("Invalid Time \r\n"));
// 				}
// 				eeprom_write_byte((uint8_t*)ACTIVATIONS, 0);
// 			}
// 		} else if (s[0] == 'a') {
// 			mTime1.Year = BCDToInt((s[1]<<4)|s[2]);
// 			mTime1.Month = BCDToInt((s[3]<<4)|s[4]);
// 			mTime1.Day = BCDToInt((s[5]<<4)|s[6]);
// 			mTime1.Hour = BCDToInt((s[7]<<4)|s[8]);
// 			mTime1.Minute = BCDToInt((s[9]<<4)|s[10]);
// 			mTime1.Second = 0;
// 			if (ValidDateTime(&mTime1)) {
// 				CopyTime(&mTime1, &aTime);
// 				//Set the alarm to go off in 10 seconds
// 				RTC_GetTime(&mTime1);
// 				WriteTimeEEPROM(&mTime1, LASTWAKEADD);
// 				ClearTime(&mTime2);
// 				mTime2.Second = 10;
// 				AddTimes(&mTime1,&mTime2);
// 				RTC_SetAlarm(&mTime1);
// 				CopyTime(&mTime1, &wTime);
// 				USART_tx_String_P(PSTR("ASET \r\n"));
// 				WriteTimeEEPROM(&aTime,ALARMTADD);
// 			} else {
// 				USART_tx_String_P(PSTR("Invalid Alarm \r\n"));
// 			}
// 		} else if (s[0] == 'g') {
// 			WakeDecision = WAKEUP_ACT_USARTTESTDROP;
// 			USART_tx_String_P(PSTR("Dropoff Test...\n"));
// 			DropOff();
// 		} else if (s[0] == 'A') {
// 			if (s[1] == 'R'-'0' && s[2] == 'M'-'0' && s[3] == 'E'-'0' && s[4] == 'D'-'0') {
// 				//TODO[ ]: Test this altered code.
// 				DevArmed = s[5];
// 				switch (DevArmed) {
// 					case ARM_OFF:
// 						USART_tx_String_P(PSTR("Disarmed mode\r\n"));
// 						break;
// 					case ARM_DEBUG:
// 						USART_tx_String_P(PSTR("Disarmed debug mode\r\n"));
// 						break;
// 					case ARM_ON:
// 						USART_tx_String_P(PSTR("DEVICE ARMED\r\n"));
// 						break;
// 					case ARM_SHELF:
// 						USART_tx_String_P(PSTR("Shelf Mode\r\n"));
// 						break;
// 					default:
// 						DevArmed = ARM_DEBUG;
// 				}
// 				WriteEEPROM(&DevArmed,1,DEVARMEDADD);
// 			}
// 		//} else if (s[0] == 'h') {
// 			//ChargePumpCal();
// 		} else if (s[0] == 'b') {
// 			sprintf_P(s,PSTR("Battery voltage: %04X\r\n"), GetBatVoltage());
// 			USART_tx_String(s);
// 			skipPrintRTC = 1;
// 		} else if (s[0] == 'T') {
// 			uint8_t Entries = eeprom_read_byte((uint8_t*)RECENTRIES);
// 			for (i = 0; i < Entries; i++) {
// 				ReadTimeEEPROM(&mTime1, RECSTART+i*7);
// 				sprintf_P(s,PSTR("Entry %u (bytes = 0x%02X):\r\n"), i, eeprom_read_byte((uint8_t*)RECSTART+i*7+6));
// 				USART_tx_String(s);
// 				PrintTime(&mTime1,"");
// 			}
// 		} else if (s[0] == 'C') {
// 			eeprom_write_byte((uint8_t*)RECENTRIES, 0);
// 		} else if (s[0] == '?') {
// 			//DEV_ID
// 			sprintf_P(s,PSTR("DEV_ID:%08lX\r\n"), Device_ID);
// 			USART_tx_String(s);
// 			//BATLOW
// 			sprintf_P(s,PSTR("BATLOW:%04X\r\n"), eeprom_read_word((uint16_t*)BATLOWADD));
// 			USART_tx_String(s);
// 			//BATCRIT
// 			sprintf_P(s,PSTR("BATCRIT:%04X\r\n"), eeprom_read_word((uint16_t*)BATCRITADD));
// 			USART_tx_String(s);
// 			//BGRefV
// 			ReadEEPROM(BGRefV,4,CONVFACTADD);
// 			sprintf_P(s,PSTR("BGRefV: %s\r\n"), BGRefV);
// 			USART_tx_String(s);
// 			//TOP
// 			sprintf_P(s,PSTR("TOP:%u\r\n"), eeprom_read_byte((uint8_t*)TOPADD));
// 			USART_tx_String(s);
// 			//RESET
// 			sprintf_P(s,PSTR("RESET:%u\r\n"), eeprom_read_byte((uint8_t*)RESETADD));
// 			USART_tx_String(s);
// 			//DROPTIME
// 			sprintf_P(s,PSTR("DROPTIME:%u\r\n"), eeprom_read_byte((uint8_t*)DROPTIMEADD));
// 			USART_tx_String(s);
// 			//ARMED
// 			sprintf_P(s,PSTR("DEVARMED:%u\r\n"), eeprom_read_byte((uint8_t*)DEVARMEDADD));
// 			USART_tx_String(s);
// 			//ACTIVATIONS
// 			sprintf_P(s,PSTR("ACTS:%u\r\n"), eeprom_read_byte((uint8_t*)ACTIVATIONS));
// 			USART_tx_String(s);
// 			//RFVERSION
// 			sprintf_P(s,PSTR("RFVERSION:0\r\n"));
// 			USART_tx_String(s);
// 		} else if (s[0] == '*') {
// 			//DEV_ID
// 			s[0] = 's';
// 			USART_tx_String_P(PSTR("DEV_ID (XXXXXXXX):\r\n"));
// 			USART_rx_String(s,TIMEOUT);
// 			if (s[0] != 's') {
// 				Device_ID = (uint32_t)strtoul(s, (char **)NULL,16);
// 				WriteEEPROM((uint8_t*)&Device_ID, 4,DEVIDADD);
// 			}
// 			//BATLOW
// 			s[0] = 's';
// 			USART_tx_String_P(PSTR("BATLOW (XXXX):\r\n"));
// 			USART_rx_String(s,TIMEOUT);
// 			if (s[0] != 's') {
// 				bV = (uint16_t)strtoul(s, (char **)NULL,16);
// 				eeprom_write_word((uint16_t*)BATLOWADD, bV);
// 			}
// 			//BATCRIT
// 			s[0] = 's';
// 			USART_tx_String_P(PSTR("BATCRIT (XXXX):\r\n"));
// 			USART_rx_String(s,TIMEOUT);
// 			if (s[0] != 's') {
// 				bV = (uint16_t)strtoul(s, (char **)NULL,16);
// 				eeprom_write_word((uint16_t*)BATCRITADD, bV);
// 			}
// 			//BGRefV
// 			s[0] = 's';
// 			USART_tx_String_P(PSTR("BGRefV (#.##):\r\n"));
// 			USART_rx_String(s,TIMEOUT);
// 			if (s[0] != 's') {
// 				for (i = 0; i < 4; i++)
// 					BGRefV[i] = s[i];
// 				WriteEEPROM(BGRefV,4,CONVFACTADD);
// 			}
// 			//TOP
// 			s[0] = 's';
// 			USART_tx_String_P(PSTR("TOP (###):\r\n"));
// 			USART_rx_String(s,TIMEOUT);
// 			if (s[0] != 's') {
// 				ICRR = 100*(s[0]-'0')  + 10*(s[1]-'0') + (s[2]-'0');
// 				eeprom_write_byte((uint8_t*)TOPADD,ICRR);
// 			}
// 			//RESET
// 			s[0] = 's';
// 			USART_tx_String_P(PSTR("RESET (###):\r\n"));
// 			USART_rx_String(s,TIMEOUT);
// 			if (s[0] != 's') {
// 				OCRR = 100*(s[0]-'0')  + 10*(s[1]-'0') + (s[2]-'0');
// 				eeprom_write_byte((uint8_t*)RESETADD,OCRR);
// 			}
// 			//DROPTIME
// 			s[0] = 's';
// 			USART_tx_String_P(PSTR("DROPTIME (##):\r\n"));
// 			USART_rx_String(s,TIMEOUT);
// 			if (s[0] != 's') {
// 				DropTime = 10*(s[0]-'0') + (s[1]-'0');
// 				eeprom_write_byte((unsigned char*)DROPTIMEADD, DropTime);
// 			}
// 		}
// 
// 		if (eeprom_read_byte((uint8_t*)ACTIVATIONS) != 0)
// 			eeprom_write_byte((uint8_t*)ACTIVATIONS, 0);
// 
// 		if (!skipPrintRTC) PrintRTC();
// 
// 		RTC_EnableAlarm();
// 
// 	}
//}

void RTCFullWakeup() {
	RTC_Time_t mTime1, mTime2;

	PORTC |= (1<<0); // turn on LED
	PCICR &=~((1<<PCIE2)|(1<<PCIE1)); // Disable  interrupts
	PRR &= ~((1<<PRUSART0)|(1<<PRTWI)); // Turn ON the USART

	RTCProgOn;

	//Setup USART for 9600bps
	USART_Setup(UBRRVAL,1);

	if (wakeSource == WAKEUP_SOURCE_RTC) {
		//Notify of wakeup..
		_delay_ms(150);
		Wakeups++;
		sprintf_P(s1, PSTR("Waking up... (%d)\r\n"),Wakeups);
		USART_tx_String(s1);
		USART_tx_String_P(PSTR("RTC woke me up\r\n"));
	}
	//Check to see that it's the right date.
	RTC_GetTime(&mTime1);

	//Check if it's time to wake up and check for dropoff/Batt check
	//if (FirstTimeGreater(&mTime1,&wTime)) {

		WriteTimeEEPROM(&mTime1, LASTWAKEADD);

		//TODO[ ]: Remove the USART_tx's they'll just waste energy... or don't...
		if (FirstTimeGreater(&mTime1,&aTime) && ValidDateTime(&aTime)) {
			//It is the right date!!
			WakeDecision = WAKEUP_ACT_RIGHTTIMEDROP;					//************************************
			USART_tx_String_P(PSTR("Correct Time -> Dropoff.\r\n"));
			DropOff();
			//Device will re-trigger every minute (5 times)
			ClearTime(&mTime2);
			mTime2.Minute = 1;
			AddTimes(&mTime1,&mTime2);
			CopyTime(&mTime1, &wTime);
			RTC_SetAlarm(&wTime);
		} else {
			uint16_t bVol = GetBatVoltage();
			if (bVol > eeprom_read_word((uint16_t*)BATLOWADD)) {
				if (bVol > eeprom_read_word((uint16_t*)BATCRITADD)) {
					//Battery voltage is critical!!! Activate Dropoff!
					WakeDecision = WAKEUP_ACT_CRITVOLTDROP;					//************************************
					USART_tx_String_P(PSTR("Battery Critical -> Dropoff.\r\n"));
					DropOff();
					//Device will re-trigger every minute (5 times)
					ClearTime(&mTime2);
					mTime2.Minute = 1;
					AddTimes(&mTime1,&mTime2);
					CopyTime(&mTime1, &wTime);
					RTC_SetAlarm(&wTime);
				} else {
					if (DevArmed == ARM_DEBUG)
						USART_tx_String_P(PSTR("Battery Low\r\n"));
					//Battery is low -> Start checking every day!
					ClearTime(&mTime2);
					LOWBAT_WAKE_PERIOD_TO_ADD;
					AddTimes(&mTime1,&mTime2);
					if (FirstTimeGreater(&mTime1, &aTime)) {
						//If 4 hours from now will be after the alarm time, just wake up
						//at the actual alarm time
						RTC_SetAlarm(&aTime);
						CopyTime(&aTime, &wTime);
					} else {
						//Otherwise set the next wake up for 4 hours from now
						RTC_SetAlarm(&mTime1);
						CopyTime(&mTime1, &wTime);
					}
				}
			} else {
				//Battery normal -> check again in 1 day.
				ClearTime(&mTime2);
				NORM_WAKE_PERIOD_TO_ADD;
				AddTimes(&mTime1,&mTime2);
				if (FirstTimeGreater(&mTime1, &aTime)) {
					//If 1 day from now will be after the alarm time, just wake up
					//at the actual alarm time
					RTC_SetAlarm(&aTime);
					CopyTime(&aTime, &wTime);
				} else {
					//Otherwise set the next wake up for 1 day from now
					RTC_SetAlarm(&mTime1);
					CopyTime(&mTime1, &wTime);
				}
			}
		}
		PrintRTC();

		RTC_EnableAlarm();
	//}
}

void WriteTimeEEPROM(RTC_Time_t* mTime, uint16_t Address) {
	WriteEEPROM((uint8_t*)mTime, 6, Address);
}

void ReadTimeEEPROM(RTC_Time_t* mTime, uint16_t Address) {
	ReadEEPROM((uint8_t*)mTime, 6, Address);
}

void ReadEEPROM(uint8_t* Data, uint8_t Length, uint16_t Address) {
	for (int i = 0; i < Length; i++)
		*Data++ = eeprom_read_byte((uint8_t*)Address++);
}

void WriteEEPROM(uint8_t* Data, uint8_t Length, uint16_t Address) {
	for (int i = 0; i < Length; i++)
		eeprom_write_byte((uint8_t*)Address++, *Data++);
}

uint16_t GetBatVoltage ( ) {

	uint32_t Sums = 0;
	uint8_t i;

	ADC_Setup();

	//Ignore the value from the first conversion
	ADC_Read();

	//Add 8 samples
	for (i = 0; i < 8; i++) {
		Sums += ADC_Read();
	}

	//Divide by 8
	Sums = Sums >> 3;

	ADC_Stop();

	return (uint16_t)Sums;

}

void ADC_Setup ( ) {

	PRR &= ~(1<<PRADC);

	//Analog reference - AVCC with external capacitor at AREF pin
	ADMUX = (1<<REFS0);

	// ADC Enabled
	// Auto Trigger Enabled
	// ADC Clock Speed = 62.5kHz
	ADCSRA = (1<<ADEN)|(1<<ADATE)|(1<<ADPS2);

	//ADC Digital Inputs Disabled:
	DIDR0 = 0;

	//ADC Compare Input - 1.1V (VBG)
	ADMUX |= (1<<MUX3)|(1<<MUX2)|(1<<MUX1);

	//80us for the Bandgap reference to stabilise
	_delay_us(80);
}

uint16_t ADC_Read ( ) {

	PRR &= (1<<PRADC);
	//Start  a single conversion
	ADCSRA |= (1<<ADSC);

	//Wait for conversion to finish
	while(!(ADCSRA & (1<<ADIF)));

	//Clear interrupt flag (done by setting to 1, see datasheet)
	ADCSRA |= (1<<ADIF);

	return ADC;
}

void ADC_Stop ( ) {
	//Analog reference - AVCC with external capacitor at AREF pin
	ADMUX = 0;

	// ADC Enabled
	// ADC Clock Speed = 62.5kHz
	ADCSRA = 0;

	PRR |= (1<<PRADC);

}

void BacktoSleep (uint8_t skip_SleepMSG) {
#ifdef DEBUGWAKESAVE
	SaveWakeupInfo();
#endif
	if (!skip_SleepMSG) {
		USART_tx_String_P(PSTR("\r\nGoing to sleep.\r\n"));
		_delay_ms(400);
	}
	UCSR0B &= ~((1 << RXEN0)|(1 << TXEN0));
	PRR |= (1<<PRUSART0)|(1<<PRTWI)|(1<<PRTIM2)|(1<<PRTIM0)|(1<<PRTIM1)|(1<<PRSPI)|(1<<PRADC);
	PCICR |= (1<<PCIE2)|(1<<PCIE1); // Enable the interrupts
	wakeSource = WAKEUP_SOURCE_NONE;
	WakeDecision = WAKEUP_ACT_NONE;
	NichromeOff;
	RTCProgOff;
	//disable BOD
	uint8_t ta = MCUCR|((1<<BODS)|(1<<BODSE));
	uint8_t tb = ta&(~(1<<BODSE));
	MCUCR = ta;
	MCUCR = tb;
	PORTC &= ~(1<<0); 				// turn OFF LED.
	sleep_mode();        			// Go to sleep
}

void PrintRTC () {
	RTC_Time_t mTime;

	USART_tx_String_P(PSTR("Reading RTC:\r\n"));

	PrintTime(&aTime, "      Alarm");

	RTC_GetTime(&mTime);
	PrintTime(&mTime, "       Time");

	//RTC_GetAlarm(&mTime);
	//mTime.Year = aTime.Year;	//eeprom_read_byte((unsigned char*)YEARADD);
	PrintTime(&wTime, "Next Wakeup");
}

static void delay_ms(uint16_t ms) {
  do {
    _delay_ms(1);
  } while (--ms != 0);
}

/*
void ChargePumpCal () {

	unsigned char p;
	unsigned char keeploop;
	unsigned needupdate;
	unsigned char t[3];
	unsigned char ii;

	ICRR = eeprom_read_byte((uint8_t*)TOPADD);
	OCRR = eeprom_read_byte((uint8_t*)RESETADD);

	//Default Values:
	//ICRR = 130;
	//OCRR = 80;

	USART_tx_String_P(PSTR( "Charge pump test mode:\r\n"
							"\r\n"
							"          q : Turn On\r\n"
							"          w : Turn Off\r\n"
							"       t### : Set timer TOP\r\n"
							"       r### : Set timer reset\r\n"
							"          + : Increment TOP\r\n"
							"          - : Decrement TOP\r\n"
							"          9 : Increment reset\r\n"
							"          6 : Decrement reset\r\n"
							"          m : Show this screen\r\n"
							"          s : Save values to EEPROM\r\n"
							"          x : Exit\r\n"
							"\r\n> "
							));

	sprintf_P(s,PSTR(" Read from EEPROM: \r\n TOP = %02d\r\n reset = %02d\r\n"),ICRR, OCRR);
	USART_tx_String(s);

	keeploop = 1;
	while (keeploop) {
		needupdate = 0;
		p = USART_rx_Byte(TIMEOUT);
		if (p == '+') {
			ICRR++;
			sprintf_P(s,PSTR(" TOP: %02d\r\n"),ICRR);
			USART_tx_String(s);
			needupdate = 1;

		} else if (p == '-') {
			ICRR--;
			sprintf_P(s,PSTR(" TOP: %02d\r\n"),ICRR);
			USART_tx_String(s);
			needupdate = 1;

		} else if (p == '9') {
			OCRR++;
			sprintf_P(s,PSTR(" reset: %02d\r\n"),OCRR);
			USART_tx_String(s);
			needupdate = 1;

		} else if (p == '6') {
			OCRR--;
			sprintf_P(s,PSTR(" reset: %02d\r\n"),OCRR);
			USART_tx_String(s);
			needupdate = 1;

		} else if (p == 'w') {
			TCCR1A = 0;					//Turn off the timer
			PRR |= (1<<PRTIM1);			//disbale the timer
			PORTB &= ~(1 << 0);			//Turn off the charge pump

		} else if (p == 'q') {
			PORTB |= (1 << 0);			//enable the charge pump
			PRR &= ~(1<<PRTIM1);		//enable Timer1
			TCCR1A = 0b10110000;		//Setting up Timer 1
			TCCR1B = 0b00010001;		//f = 500Hz
			needupdate = 1;

		} else if (p == 't') {

			for (ii = 0; ii < 3; ii++) {
				t[ii] = USART_rx_Byte(TIMEOUT);
			}

			ICRR = 100*(t[0]-'0')  + 10*(t[1]-'0') + (t[2]-'0');

			sprintf_P(s,PSTR(" TOP: %02d\r\n"),ICRR);
			USART_tx_String(s);
			needupdate = 1;

		} else if (p == 'r') {

			for (ii = 0; ii < 3; ii++) {
				t[ii] = USART_rx_Byte(TIMEOUT);
			}

			OCRR = 100*(t[0]-'0')  + 10*(t[1]-'0') + (t[2]-'0');

			sprintf_P(s,PSTR(" reset: %02d\r\n"),OCRR);
			USART_tx_String(s);
			needupdate = 1;

		} else if (p =='s') {

				eeprom_write_byte((uint8_t*)TOPADD,ICRR);
				eeprom_write_byte((uint8_t*)RESETADD,OCRR);
				sprintf_P(s,PSTR(" Written to EEPROM: \r\n TOP = %02d\r\n reset = %02d\r\n"),ICRR, OCRR);
				USART_tx_String(s);


		} else if (p == 'x') {
			keeploop = 0;
		}

		if (needupdate == 1) {
			ICR1 = ICRR;				//count up to
			OCR1BL = OCRR;   			//sets duty ratio
			OCR1BH = 0;
		}

	}

	TCCR1A = 0;					//Turn off the timer
	PRR |= (1<<PRTIM1);			//disbale the timer
	PORTB &= ~(1 << 0);			//Turn off the charge pump

}*/

