/*
 * MX_SerComms.c
 *
 * Created: 17/08/2011 1:57:56 PM
 *  Author: MC
 */ 

#include "MX_SerComms.h"

extern char s[80];
extern unsigned char ICRR;
extern unsigned char OCRR;
extern unsigned char DropTime;
extern unsigned char DevArmed;
extern unsigned char Wakeups;
extern RTC_Time_t aTime;
extern RTC_Time_t wTime;
extern unsigned char BGRefV[5];
extern uint32_t Device_ID;

/************************************************************************/
/*                     Top Segment Starts here                          */
/************************************************************************/


//Serial Command Handler Prototypes:
SerCom_err_t Ser_CMD_Get_DevTypeID();
SerCom_err_t Ser_CMD_Get_DevID();
SerCom_err_t Ser_CMD_Set_DevID();
SerCom_err_t Ser_CMD_Get_RTCTime();
SerCom_err_t Ser_CMD_Set_RTCTime();
SerCom_err_t Ser_CMD_Get_AlarmTime();
SerCom_err_t Ser_CMD_Set_AlarmTime();
SerCom_err_t Ser_CMD_Get_NextWakeupTime();
SerCom_err_t Ser_CMD_Get_DropActPeriod();
SerCom_err_t Ser_CMD_Set_DropActPeriod();
SerCom_err_t Ser_CMD_Get_LowBatV();
SerCom_err_t Ser_CMD_Set_LowBatV();
SerCom_err_t Ser_CMD_Get_CritBatV();
SerCom_err_t Ser_CMD_Set_CritBatV();
SerCom_err_t Ser_CMD_Get_BatConvFact();
SerCom_err_t Ser_CMD_Set_BatConvFact();
SerCom_err_t Ser_CMD_Get_ChargePumpTop();
SerCom_err_t Ser_CMD_Set_ChargePumpTop();
SerCom_err_t Ser_CMD_Get_ChargePumpReset();
SerCom_err_t Ser_CMD_Set_ChargePumpReset();
SerCom_err_t Ser_CMD_Get_Armed();
SerCom_err_t Ser_CMD_Set_Armed();
SerCom_err_t Ser_CMD_Get_RFVersion();
SerCom_err_t Ser_CMD_Cmd_TestDropoff();
SerCom_err_t Ser_CMD_Get_BatVolt();
SerCom_err_t Ser_CMD_Get_LogEntries();
SerCom_err_t Ser_CMD_Cmd_ClearLogEntries();
SerCom_err_t Ser_CMD_Get_Activations();
SerCom_err_t Ser_CMD_Get_Version();


//Serial Command Handler Array Defs:
Ser_CMD_Handler Ser_CMDAry[] PROGMEM =	{{0x00, Ser_CMD_Get_DevTypeID},
										 {0x01, Ser_CMD_Get_DevID},
										 {0x02, Ser_CMD_Set_DevID},
										 {0x03, Ser_CMD_Get_RTCTime},
										 {0x04, Ser_CMD_Set_RTCTime},
										 {0x05, Ser_CMD_Get_AlarmTime},
										 {0x06, Ser_CMD_Set_AlarmTime},
										 {0x07, Ser_CMD_Get_NextWakeupTime},
										 {0x08, Ser_CMD_Get_DropActPeriod},
										 {0x09, Ser_CMD_Set_DropActPeriod},
										 {0x0A, Ser_CMD_Get_LowBatV},
										 {0x0B, Ser_CMD_Set_LowBatV},
										 {0x0C, Ser_CMD_Get_CritBatV},
										 {0x0D, Ser_CMD_Set_CritBatV},
										 {0x0E, Ser_CMD_Get_BatConvFact},
										 {0x0F, Ser_CMD_Set_BatConvFact},
										 {0x10, Ser_CMD_Get_ChargePumpTop},
										 {0x11, Ser_CMD_Set_ChargePumpTop},
										 {0x12, Ser_CMD_Get_ChargePumpReset},
										 {0x13, Ser_CMD_Set_ChargePumpReset},
										 {0x14, Ser_CMD_Get_Armed},
										 {0x15, Ser_CMD_Set_Armed},
										 {0x16, Ser_CMD_Get_RFVersion},
										 {0x17, Ser_CMD_Cmd_TestDropoff},
										 {0x18, Ser_CMD_Get_BatVolt},
										 {0x19, Ser_CMD_Get_LogEntries},
										 {0x1A, Ser_CMD_Cmd_ClearLogEntries},
										 {0x1B, Ser_CMD_Get_Activations},
										 {0x1C, Ser_CMD_Get_Version}};


#define SERCOM_NUMCMDS		0x1D
		
/************************************************************************/
/*                       Top Segment Ends here                          */
/************************************************************************/

SerCom_err_t Ser_CMDHandler() {
	uint8_t CMDByte;
	SerCom_err_t tmpSerComErr;
	uint8_t i;
	CMD_Handler_t CMD_Handler;
		
	//Receive Command Byte
	tmpSerComErr = Ser_RxSeg(1, &CMDByte, 5);
	if (tmpSerComErr < 0) 
		return tmpSerComErr;
	
	tmpSerComErr = SerCom_err_NoKnownCmd;
	//Lookup Command in table and execute handler function
	for (i = 0; i < SERCOM_NUMCMDS; i++) {
		if (pgm_read_byte(&Ser_CMDAry[i].CMDByte) == CMDByte) {
			
			CMD_Handler = (CMD_Handler_t)pgm_read_word(&Ser_CMDAry[i].Handler);
			if ((tmpSerComErr = CMD_Handler()) < 0) {
				return tmpSerComErr;
			}
			//Only execute one function!
			break;
		}
	}
	
	tmpSerComErr = SerCom_FinishSeg();
	
	return tmpSerComErr;
	
}

//Rx from PC (to device)
//Should not be used with large 'len' or will run out of memory.
SerCom_err_t Ser_RxSeg(uint16_t len, uint8_t* DataDest, uint8_t Attempts) {
	uint8_t tmpBuf[len+2];
	uint8_t tmpByte;
	SerCom_err_t tmpSerComErr;
	USART_err_t tmpUSARTErr;
	uint16_t i;
	uint16_t* RxChkSum;
	uint16_t CalcChkSum = 0;
	
	//uint16_t len1 = len;
	
	RxChkSum = (uint16_t*)(&tmpBuf[len]);			//TODO[ ]: Check that this line works!!
	
	//(1) Transmit Rx Segment identifier and listen for Ack
	USART_tx_Byte(SERCOM_RXSEG_ID);
	if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
	
	//(3) Transmit Segment length (2 bytes) and listen for Ack
	USART_tx_Byte(ByteNO(&len,0));
	USART_tx_Byte(ByteNO(&len,1));
	if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
	
	do {
		//Receive (5)data + (6)checksum
		for (i = 0; i < len+2; i++) {
			
			//If there was an error code returned from the USART_rx function, abort
			if ((tmpUSARTErr = USART_rx_Byte(SERCOM_TIMEOUT, &tmpByte)) < 0) return SerCom_err_Timeout;
			
			//Add to buffer
			tmpBuf[i] = tmpByte;
		}
	
		//(7) Calculate our version of checksum
		CalcChkSum = 0;
		for (i = 0; i < len; i++) {
			CalcChkSum = _crc16_update(CalcChkSum, tmpBuf[i]);
		}
		
		//(7) Compare checksums
		if (CalcChkSum == *RxChkSum) {
			//checksums match... success!
			//TODO[ ]: Maybe have an option here to disable interrupts on copy? eg. a cli() before then sei() after.
			for (i = 0; i < len; i++) {
				DataDest[i] = tmpBuf[i];
			}				
			Attempts = 0;
		} else {
			//Invalid checksum, retry/abort
			Attempts--;
			if (Attempts) {
				//Still attempts left, ask to resend
				USART_tx_Byte(SERCOM_RESP_RESEND);
				if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
			} else {
				//Sent 'Attempt's times.. abort!
				USART_tx_Byte(SERCOM_RESP_ABORT);
				if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
				return SerCom_err_Abort;
			}
		}
	} while (Attempts);
	
	USART_tx_Byte(SERCOM_RESP_OK);
	if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
	
	return SerCom_err_Success;
}

//Tx from device to PC
SerCom_err_t Ser_TxSeg(uint16_t len, uint8_t* DataSrc, uint8_t Attempts) {
	SerCom_err_t tmpSerComErr;
	USART_err_t tmpUSARTErr;
	uint16_t i;
	uint16_t RxChkSum;
	uint16_t CalcChkSum = 0;
	uint8_t tmpByte;
	
	//(1) Transmit Tx Segment identifier and listen for Ack
	USART_tx_Byte(SERCOM_TXSEG_ID);
	if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
	
	//(3) Transmit Segment length (2 bytes) and listen for Ack
	USART_tx_Byte(ByteNO(&len,0));
	USART_tx_Byte(ByteNO(&len,1));
	if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
	
	do {
		
		//(5) Transmit data
		CalcChkSum = 0;
		for (i = 0; i < len; i++) {			
			USART_tx_Byte(DataSrc[i]);
			CalcChkSum = _crc16_update(CalcChkSum, DataSrc[i]);
		}
	
		//(6) Receive checksum
		if ((tmpUSARTErr = USART_rx_Byte(SERCOM_TIMEOUT, &tmpByte)) < 0) return SerCom_err_Timeout;
		ByteNO(&RxChkSum, 0) = tmpByte;
		if ((tmpUSARTErr = USART_rx_Byte(SERCOM_TIMEOUT, &tmpByte)) < 0) return SerCom_err_Timeout;
		ByteNO(&RxChkSum, 1) = tmpByte;
		
		//(7) Compare checksums
		if (CalcChkSum == RxChkSum) {
			//checksums match... success!
			Attempts = 0;
		} else {
			//Invalid checksum, retry/abort
			Attempts--;
			if (Attempts) {
				//Still attempts left, ask to resend
				USART_tx_Byte(SERCOM_RESP_RESEND);
				if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
			} else {
				//Sent 'Attempt's times.. abort!
				USART_tx_Byte(SERCOM_RESP_ABORT);
				if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
				return SerCom_err_Abort;
			}
		}
	} while (Attempts);
	
	USART_tx_Byte(SERCOM_RESP_OK);
	if ((tmpSerComErr = SerCom_RxAck()) < 0) return tmpSerComErr;
	
	return SerCom_err_Success;
}

SerCom_err_t SerCom_FinishSeg() {
	//(1) Transmit Finish Segment identifier and listen for Ack
	USART_tx_Byte(SERCOM_FINSEG_ID);
	return SerCom_RxAck();
}	

SerCom_err_t SerCom_RxAck() {
	uint8_t tmpByte;
	USART_err_t tmpUSARTErr;
	
	//If there was an error code returned or we did not receive an ACK, abort!
	if ((tmpUSARTErr = USART_rx_Byte(SERCOM_TIMEOUT, &tmpByte)) < 0) {
		return SerCom_err_Timeout;
	} else if (tmpByte != SERCOM_PC_ACK) {
		return SerCom_err_Nak;
	}
	
	return SerCom_err_Success;
}

/************************************************************************/
/*			 	  Device Serial CMD functions go here!					*/
/*                          (bottom part)								*/
/************************************************************************/

SerCom_err_t Ser_CMD_Get_DevTypeID() {
	uint16_t DevTypeID = DEVTYPE_ID;
	
	return Ser_TxSeg(2, (uint8_t*)&DevTypeID, 5);
}

SerCom_err_t Ser_CMD_Get_DevID() {
	return Ser_TxSeg(4, (uint8_t*)&Device_ID, 5);
}

SerCom_err_t Ser_CMD_Set_DevID() {
	SerCom_err_t tmpSerComErr;
	
	tmpSerComErr = Ser_RxSeg(4, (uint8_t*)&Device_ID, 5);
	WriteEEPROM((uint8_t*)&Device_ID, 4,DEVIDADD);
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_RTCTime() {
	RTC_Time_t mTime1;
	
	RTC_GetTime(&mTime1);
	
	return Ser_TxSeg(6, (uint8_t*)&mTime1, 5);
}

SerCom_err_t Ser_CMD_Set_RTCTime() {
	RTC_Time_t mTime1, mTime2;
	SerCom_err_t tmpSerComErr;
	
	tmpSerComErr = Ser_RxSeg(6, (uint8_t*)&mTime1, 5);
	
	if (DevArmed != ARM_SHELF) {
		if (ValidDateTime(&mTime1)) {
			RTC_SetTime(&mTime1);
			//USART_tx_String_P(PSTR("TSET \r\n"));
			WriteTimeEEPROM(&mTime1, LASTWAKEADD);
			ClearTime(&mTime2);
			mTime2.Second = 10;
			AddTimes(&mTime1,&mTime2);
			RTC_SetAlarm(&mTime1);
			CopyTime(&mTime1, &wTime);
		} else {
			//USART_tx_String_P(PSTR("Invalid Time \r\n"));
		}
		eeprom_write_byte((uint8_t*)ACTIVATIONS, 0);
	}		
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_AlarmTime() {
	return Ser_TxSeg(6, (uint8_t*)&aTime, 5);
}

SerCom_err_t Ser_CMD_Set_AlarmTime() {
	SerCom_err_t tmpSerComErr;
	
	tmpSerComErr = Ser_RxSeg(6, (uint8_t*)&aTime, 5);
	WriteTimeEEPROM(&aTime, ALARMTADD);
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_NextWakeupTime() {
	return Ser_TxSeg(6, (uint8_t*)&wTime, 5);
}

SerCom_err_t Ser_CMD_Get_DropActPeriod() {
	DropTime = eeprom_read_byte((uint8_t*)DROPTIMEADD);
	return Ser_TxSeg(1, (uint8_t*)&DropTime, 5);
}

SerCom_err_t Ser_CMD_Set_DropActPeriod() {
	SerCom_err_t tmpSerComErr;
	
	tmpSerComErr = Ser_RxSeg(1, (uint8_t*)&DropTime, 5);
	eeprom_write_byte((uint8_t*)DROPTIMEADD, DropTime);
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_LowBatV() {
	uint16_t LowBatV = eeprom_read_word((uint16_t*)BATLOWADD);
	
	return Ser_TxSeg(2, (uint8_t*)&LowBatV, 5);
}

SerCom_err_t Ser_CMD_Set_LowBatV() {
	SerCom_err_t tmpSerComErr;
	uint16_t LowBatV;
	
	tmpSerComErr = Ser_RxSeg(2, (uint8_t*)&LowBatV, 5);
	
	eeprom_write_word((uint16_t*)BATLOWADD, LowBatV);
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_CritBatV() {
	uint16_t CritBatV = eeprom_read_word((uint16_t*)BATCRITADD);
	
	return Ser_TxSeg(2, (uint8_t*)&CritBatV, 5);
}

SerCom_err_t Ser_CMD_Set_CritBatV() {
	SerCom_err_t tmpSerComErr;
	uint16_t CritBatV;
	
	tmpSerComErr = Ser_RxSeg(2, (uint8_t*)&CritBatV, 5);
	
	eeprom_write_word((uint16_t*)BATCRITADD, CritBatV);
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_BatConvFact() {
	return Ser_TxSeg(4, (uint8_t*)&BGRefV, 5);
}

SerCom_err_t Ser_CMD_Set_BatConvFact() {
	SerCom_err_t tmpSerComErr;
	
	tmpSerComErr = Ser_RxSeg(4, (uint8_t*)&BGRefV, 5);
	WriteEEPROM(BGRefV, 4, CONVFACTADD);
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_ChargePumpTop() {
	return Ser_TxSeg(1, (uint8_t*)&ICRR, 5);
}

SerCom_err_t Ser_CMD_Set_ChargePumpTop() {
	SerCom_err_t tmpSerComErr;
	
	tmpSerComErr = Ser_RxSeg(1, (uint8_t*)&ICRR, 5);
	
	eeprom_write_byte((uint8_t*)TOPADD, ICRR);
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_ChargePumpReset() {
	return Ser_TxSeg(1, (uint8_t*)&OCRR, 5);
}

SerCom_err_t Ser_CMD_Set_ChargePumpReset() {
	SerCom_err_t tmpSerComErr;
	
	tmpSerComErr = Ser_RxSeg(1, (uint8_t*)&OCRR, 5);
	
	eeprom_write_byte((uint8_t*)RESETADD, OCRR);
	
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_Armed() {
	return Ser_TxSeg(1, (uint8_t*)&DevArmed, 5);
}

SerCom_err_t Ser_CMD_Set_Armed() {
	SerCom_err_t tmpSerComErr;
	uint8_t TestByte = 0;
	
	tmpSerComErr = Ser_RxSeg(1, (uint8_t*)&TestByte, 5);
	if (tmpSerComErr < 0) return tmpSerComErr;
	
	if (TestByte == 0xE6) {	
		tmpSerComErr = Ser_RxSeg(1, (uint8_t*)&DevArmed, 5);
		eeprom_write_byte((uint8_t*)DEVARMEDADD, DevArmed);
	} else {
		//dummy
		tmpSerComErr = Ser_RxSeg(1, (uint8_t*)&TestByte, 5);
	}		
	return tmpSerComErr;
}

SerCom_err_t Ser_CMD_Get_RFVersion() {
	uint8_t RfVersion = 0;
	return Ser_TxSeg(1, (uint8_t*)&RfVersion, 5);
}

SerCom_err_t Ser_CMD_Cmd_TestDropoff() {
	//TODO[ ]: Make this asynchronous?
	DropOff();
	return SerCom_err_Success;
}

SerCom_err_t Ser_CMD_Get_BatVolt() {
	uint16_t batV = GetBatVoltage();
	//???skipPrintRTC = 1;
	
	return Ser_TxSeg(2, (uint8_t*)&batV, 5);
}

SerCom_err_t Ser_CMD_Get_LogEntries() {
	SerCom_err_t tmpSerComErr;
	RTC_Time_t mTime1;
	uint8_t i, tmpByte;
	uint8_t Entries = eeprom_read_byte((uint8_t*)RECENTRIES);
	
	tmpSerComErr = Ser_TxSeg(1, (uint8_t*)&Entries, 5);
	if (tmpSerComErr < 0) return tmpSerComErr;
	
 	for (i = 0; i < Entries; i++) {
 		ReadTimeEEPROM(&mTime1, RECSTART+i*7);
		tmpByte = eeprom_read_byte((uint8_t*)RECSTART+i*7+6);
		 
		tmpSerComErr = Ser_TxSeg(1, (uint8_t*)&tmpByte, 5);
		if (tmpSerComErr < 0) return tmpSerComErr;
		tmpSerComErr = Ser_TxSeg(6, (uint8_t*)&mTime1, 5);
		if (tmpSerComErr < 0) return tmpSerComErr;
 	}
	
	return SerCom_err_Success;
}

SerCom_err_t Ser_CMD_Cmd_ClearLogEntries() {
	eeprom_write_byte((uint8_t*)RECENTRIES, 0);
	return SerCom_err_Success;
}

SerCom_err_t Ser_CMD_Get_Activations() {
	uint8_t mActs = eeprom_read_byte((uint8_t*)ACTIVATIONS);
	return Ser_TxSeg(1, (uint8_t*)&mActs, 5);
}

SerCom_err_t Ser_CMD_Get_Version() {
	char ss[100];
	char s1[20];
	char s2[20];
	
	stringCopyP(PSTR_PRODUCT_N, s1);
	stringCopyP(PSTR_CODE_V, s2);
	sprintf_P(ss, PSTR("%s - %s"), s1, s2);
	return Ser_TxSeg(100, (uint8_t*)ss, 5);
}

