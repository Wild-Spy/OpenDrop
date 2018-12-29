/*
 * M_RTC.c
 *
 *  Created on: 27/05/2010
 *      Author: Matthew Cochrane
 *
 *  Real Time Clock module for use with Phillips RTC's such as the M41T81.
 *
 */

#include "M_RTC.h"

extern char s[80];

unsigned char RTC_get (unsigned char pos ) {
	unsigned char f;

	i2c_start_wait(RTC_CHIP+I2C_WRITE);
	i2c_write(pos);
	i2c_start(RTC_CHIP+I2C_READ);
	f=i2c_readNak();
	i2c_stop();

	return f;
}

unsigned char RTC_getflags (void) {
	unsigned char f;

	i2c_start_wait(RTC_CHIP+I2C_WRITE);
	i2c_write(0x0F);
	i2c_start(RTC_CHIP+I2C_READ);
	f=i2c_readNak();
	i2c_stop();

	return f;
}

void RTC_set (unsigned char pos, unsigned char val ) {
	i2c_start_wait(RTC_CHIP+I2C_WRITE);
	i2c_write(pos);
	i2c_write(val);
	i2c_stop();
}

void RTC_set_msk (unsigned char pos, unsigned char val, unsigned char bMsk) {
	//bMsk -> 0 means no change, 1 means change
	unsigned char p = RTC_get(pos)&(~bMsk);
	val &= bMsk;
	RTC_set(pos,p|val);
}

void RTC_EnableAlarm() {
	//Reset the flags
	RTC_get(0x0F);
	RTC_get(0x0F);

	//enable the alarm (and in battery mode) AE, ABE
	RTC_set(0x0A, (0xA0|RTC_get(0x0A))&(~0x40));
}

void RTC_GetAlarm (struct RTCTime* Alarm) {
	//Disable the Halt Bit -> Update the external registers that we can see from
	//the internal clock registers
	//RTC_set( 0x0C,  RTC_get(0x0C) & (~0x40) );

	Alarm->Month = BCDToInt(RTC_get(0x0A)&(~0xE0));
	Alarm->Day = BCDToInt(RTC_get(0x0B)&(~0xC0));
	Alarm->Hour = BCDToInt(RTC_get(0x0C)&(~0xC0));
	Alarm->Minute = BCDToInt(RTC_get(0x0D)&(~0x80));
	Alarm->Second = BCDToInt(RTC_get(0x0E)&(~0x80));
	Alarm->Year = 0;

	RTC_get(0x01);
}

void RTC_GetTime (struct RTCTime* Time) {
	//Disable the Halt Bit -> Update the external registers that we can see from
	//the internal clock registers
	RTC_set( 0x0C,  RTC_get(0x0C) & (~0x40) );

	i2c_start_wait(RTC_CHIP+I2C_WRITE);
	//Start at address 0x01
	i2c_write(0x01);
	i2c_start(RTC_CHIP+I2C_READ);

	Time->Second = BCDToInt(i2c_readAck()&(~0x80));
	Time->Minute = BCDToInt(i2c_readAck());
	Time->Hour = BCDToInt(i2c_readAck()&(~0xC0));
	i2c_readAck();//day of week
	Time->Day = BCDToInt(i2c_readAck());
	Time->Month = BCDToInt(i2c_readAck());
	Time->Year = BCDToInt(i2c_readAck());
	i2c_stop();
	RTC_get(0x01);

}

void RTC_SetAlarm (struct RTCTime* Alarm) {

	//Set the alarm in battery backup mode enable flag (AFE)
	//clear other flags (SQWE, ABE)
	RTC_set(0x0A, 0xA0|IntToBCD(Alarm->Month));
	RTC_set(0x0B, IntToBCD(Alarm->Day)    & 0b00111111);
	RTC_set(0x0C, IntToBCD(Alarm->Hour)   & 0b00111111);
	RTC_set(0x0D, IntToBCD(Alarm->Minute) & 0b01111111);
	RTC_set(0x0E, IntToBCD(Alarm->Second) & 0b01111111);
	RTC_get(0x0F);
	RTC_get(0x01);

}

void RTC_SetTime (struct RTCTime* Time) {
	RTC_set(7,IntToBCD(Time->Year));
	RTC_set(6,IntToBCD(Time->Month));
	RTC_set(5,IntToBCD(Time->Day));
	RTC_set_msk(3,IntToBCD(Time->Hour), 0b00111111);
	RTC_set(2,IntToBCD(Time->Minute));
	//This line below will always disable the stop bit on the RTC!
	RTC_set(1,IntToBCD(Time->Second)&0b01111111);
}

void PrintTime (struct RTCTime *pTime, char* lbl) {
	sprintf_P(s,PSTR("%s: %02d-%02d-%02d %02d:%02d:%02d\r\n")
				, lbl
				, pTime->Year
				, pTime->Month
				, pTime->Day
				, pTime->Hour
				, pTime->Minute
				, pTime->Second);
	USART_tx_String(s);
}

uint8_t IntToBCD (uint8_t val) {
	if (val > 99) return 99;
	uint8_t a = val/10;
	return (a<<4)|(val-(a*10));
}

uint8_t BCDToInt (uint8_t val) {
	if (val > 0x99) return 99;
	return (val&0x0F)+10*(val>>4);
}

void CopyTime (struct RTCTime* SrcTime, struct RTCTime* DstTime) {
	for (uint8_t i = 0; i < 6; i++)
		*(((uint8_t*)DstTime)+i) = *(((uint8_t*)SrcTime)+i);
}

void ClearTime (struct RTCTime* Time1) {
	Time1->Year = 0;
	Time1->Month = 0;
	Time1->Day = 0;
	Time1->Hour = 0;
	Time1->Minute = 0;
	Time1->Second = 0;
}

#ifdef COMPTIMES
uint8_t CompareTimes (struct RTCTime* Time1, struct RTCTime* Time2) {
	//if Time1 = Time2 then return 1
	//else return 0
	if ((Time1->Year == Time2->Year) && (Time1->Month == Time2->Month)
			&& (Time1->Day == Time2->Day) && (Time1->Hour == Time2->Hour)
			&& (Time1->Minute == Time2->Minute) && (Time1->Second == Time2->Second))
		return 1;
	else
		return 0;
}
#endif

uint8_t FirstTimeGreater (struct RTCTime* Time1, struct RTCTime* Time2) {
	//It is assumed that times are VALID!

	//if Time1 >= Time2 then TRUE
	//if Time1 < Time2  then FALSE

	//if Time1 > Time2 then 1
	//if Time2 > Time1 then 0
	//if Time1 = Time2 then 2

	if (Time2->Year > Time1->Year) {
		return 0;
	} else if (Time2->Year < Time1->Year) {
		return 1;
	} else {
		if (Time2->Month > Time1->Month) {
			return 0;
		} else if (Time2->Month < Time1->Month) {
			return 1;
		} else {
			if (Time2->Day > Time1->Day) {
				return 0;
			} else if (Time2->Day < Time1->Day) {
				return 1;
			} else {
				if (Time2->Hour > Time1->Hour) {
					return 0;
				} else if (Time2->Hour < Time1->Hour) {
					return 1;
				} else {
					if (Time2->Minute > Time1->Minute) {
						return 0;
					} else if (Time2->Minute < Time1->Minute) {
						return 1;
					} else {
						if (Time2->Second > Time1->Second) {
							return 0;
						} else if (Time2->Second < Time1->Second) {
							return 1;
						} else {
							return 2;
						}
					}
				}
			}
		}
	}

}

uint8_t ValidDateTime(struct RTCTime* DT) {
	uint8_t days;
	if (DT->Second > 59 || DT->Minute > 59 || DT->Hour > 23)
		return 0;

	if (DT->Day == 0 || DT->Month == 0 || DT->Month > 12)
		return 0;

	days = DaysInMonth(DT->Month, DT->Year);

	if (DT->Day > days)
		return 0;

	//If we got here.. it's a valid date!
	return 1;
}

void AddTimes (struct RTCTime* DateTime, struct RTCTime* AddTime) {
	//DateTime = DateTime + AddTime
	//AddTime can be a specific number of days month minutes etc.
	//DateTime MUST BE A PROPER DATETIME!
	//Double overflows are supported
	//Overflows added from small time through to large time
	//(ie. secs then mins then hours then days etc.)

	uint8_t a;
	uint8_t YearsAddedInMonth = 0;

	DateTime->Second += AddTime->Second;
	while (DateTime->Second > 59) {
		DateTime->Second -= 60;
		DateTime->Minute++;
	}
	DateTime->Minute += AddTime->Minute;

	while (DateTime->Minute > 59) {
		DateTime->Minute -= 60;
		DateTime->Hour++;
	}
	DateTime->Hour += AddTime->Hour;
	while (DateTime->Hour > 23) {
		DateTime->Hour -= 24;
		DateTime->Day++;
	}
	DateTime->Day += AddTime->Day;

	while (DateTime->Day > (a = DaysInMonth(DateTime->Month, DateTime->Year))) {
		DateTime->Day -= a;
		DateTime->Month++;
		if (DateTime->Month > 12) {
			DateTime->Month -= 12;
			DateTime->Year++;
			YearsAddedInMonth++;
		}
	}
	
	DateTime->Month += AddTime->Month;
	while (DateTime->Month > 12) {
		DateTime->Month -= 12;
		DateTime->Year++;
	}
	
	DateTime->Year += AddTime->Year;
	//while (DateTime->Year > 99) {
	//	DateTime->Year -= 100;
	//}
}

uint8_t DaysInMonth(uint8_t Month, uint8_t Year) {
	switch (Month) {
		//31 day months
		case 1://Jan
		case 3://Mar
		case 5://May
		case 7://July
		case 8://Aug
		case 10://Oct
		case 12://Dec
			return 31;
			break;
		//30 day months
		case 4://April
		case 6://June
		case 9://Sep
		case 11://Nov
			return 30;
			break;
		//The dreaded February!!!
		case 2://Feb
			//Is it a leap year??
			if(((Year + 2000) % 4 == 0 && (Year + 2000) % 100 != 0) || (Year + 2000) % 400 == 0)
				return 29;//Yes
			else
				return 28;//No
			break;
		default:
			return 0;
		}
}

// void AddTimes (struct RTCTime* DateTime, struct RTCTime* AddTime) {
// 	//DateTime = DateTime + AddTime
// 	//AddTime can be a specific number of days month minutes etc.
// 	//DateTime MUST BE A PROPER DATETIME!
// 	//Double overflows are supported
// 	//Overflows added from small time through to large time
// 	//(ie. secs then mins then hours then days etc.)
// 
// 	uint8_t a;
// 	uint8_t YearsAddedInMonth = 0;
// 
// 	DateTime->Second += AddTime->Second;
// 	while (DateTime->Second > 59) {
// 		DateTime->Second -= 60;
// 		DateTime->Minute++;
// 	}
// 	DateTime->Minute += AddTime->Minute;
// 
// 	while (DateTime->Minute > 59) {
// 		DateTime->Minute -= 60;
// 		DateTime->Hour++;
// 	}
// 	DateTime->Hour += AddTime->Hour;
// 	while (DateTime->Hour > 23) {
// 		DateTime->Hour -= 24;
// 		DateTime->Day++;
// 	}
// 	DateTime->Day += AddTime->Day;
// 
// 	while (DateTime->Day > (a = DaysInMonth(DateTime->Month, DateTime->Year))) {
// 		DateTime->Day -= a;
// 		DateTime->Month++;
// 	}
// 	
// 	DateTime->Month += AddTime->Month;
// 	while (DateTime->Month > 12) {
// 		DateTime->Month -= 12;
// 		DateTime->Year++;
// 	}
// 	DateTime->Year += AddTime->Year;
// 	//while (DateTime->Year > 99) {
// 	//	DateTime->Year -= 100;
// 	//}
// }