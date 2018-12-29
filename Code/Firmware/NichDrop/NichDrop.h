/*
 * NichDrop.h
 *
 *  Created on: 03/02/2010
 *      Author: Matthew Cochrane
 */

#ifndef NICHDROP_H_
#define NICHDROP_H_

//Includes
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <avr/io.h>
#include <avr/eeprom.h>
#include <avr/interrupt.h>
#include <avr/sleep.h>
#include <avr/wdt.h>
#include <util/delay.h>
#include "Libs/M_RTC.h"
#include "Libs/M_USART.h"
#include "Libs/MX_SerComms.h"
#include "Strings.h"

//Define
#define CPU8MHZ 1
#define DEBUGWAKESAVE 1
//#define CPU1MHZ 1
#ifdef CPU8MHZ
	#define UBRRVAL 		0x0067 	//for 8MHz (Double Speed)
	#define TIMEOUT			16		//approx 500ms			//253		//aprox 8 seconds
	#define NORWAITTIMPRE 	(1<<CS02)
	#define NORWAITTIMOCA 	0x4E
	#define T0WAIT10MSOCA	0x4D
#endif
#ifdef CPU1MHZ
	#define UBRRVAL 		0x000C //for 1MHz (Double Speed)
	#define TIMEOUT			32	//aprox 8 seconds
	#define NORWAITTIMPRE 	(1<<CS01)|(1<<CS00)
	#define NORWAITTIMOCA 	0x26
	#define T0WAIT10MSOCA	0x13
#endif

#define WAKEUP_SOURCE_NONE 0
#define WAKEUP_SOURCE_UART 1
#define WAKEUP_SOURCE_RTC 2
#define WAKEUP_ACT_NONE 0
#define WAKEUP_ACT_RIGHTTIMEDROP 1	//correct time dropoff
#define WAKEUP_ACT_CRITVOLTDROP 2
#define WAKEUP_ACT_WASRESET 3
#define WAKEUP_ACT_RFRX 4
#define WAKEUP_ACT_RFDROP 5
#define WAKEUP_ACT_USARTTESTDROP 6

#define DEVIDADD	0x00	//a 4-byte integer (uint32_t)
#define TOPADD 		0x04	//a 1-byte integer (uint8_t)
#define RESETADD 	0x05	//a 1-byte integer (uint8_t)
#define DROPTIMEADD 0x06	//a 1-byte integer (uint8_t)
#define DEVARMEDADD	0x07	//a 1-byte integer (uint8_t)
#define RFVERSION	0x08	//a 1-byte integer (uint8_t)
#define ACTIVATIONS 0x09	//a 1-byte integer (uint8_t)
#define BATLOWADD	0x10	//a 2-byte integer	(uint16_t)
#define BATCRITADD	0x12	//a 2-byte integer	(uint16_t)
#define CONVFACTADD	0x14	//a 4-byte string	(unsigned char[4])
#define RFIDADD		0x20	//a 5-byte unsigned integer	(uint8_t[5])
#define RFCHANADD	0x25	//a 1-byte unsigned integer	(uint8_t)
#define LASTWAKEADD	0x30	//a 6-byte structure (struct RTCTime)
#define ALARMTADD	0x36	//a 6-byte structure (struct RTCTime)
#define DALARMTADD	0x3C	//a 6-byte structure (struct RTCTime)
#define DTIMEADD	0x42	//a 6-byte structure (struct RTCTime)

#define RECENTRIES	0x50	//a byte
#define RECSTART	0x51	//an array of 6 byte structs

#define ARM_OFF 	0
#define ARM_ON		1
#define ARM_DEBUG	2
#define ARM_SHELF	3

//Macros
#define NORM_WAKE_PERIOD_TO_ADD mTime2.Day = 1
//#define NORM_WAKE_PERIOD_TO_ADD mTime2.Second = 20
#define LOWBAT_WAKE_PERIOD_TO_ADD mTime2.Hour = 4
//#define LOWBAT_WAKE_PERIOD_TO_ADD mTime2.Second = 5

#define NichromeOn PORB |= (1<<0)
#define NichromeOff PORTB &= ~(1<<0)
#define PWMOn PORTB |= (1<<2)
#define PWMOff PORTB &= ~(1<<2)
#define ByteNO(SrcPtr, byteNo)	*(((uint8_t*)SrcPtr)+byteNo)

//Function Prototypes
//void ChargePumpCal(void);
void SaveWakeupInfo(void);
void DropOff (void);
void Release(unsigned int);
void ShowMenu(void);
void RTCFullWakeup(void);
void BacktoSleep(uint8_t);
uint16_t GetBatVoltage(void);
void ADC_Setup(void);
uint16_t ADC_Read();
void ADC_Stop();
void PrintRTC(void);
static void delay_ms(uint16_t);
void WriteTimeEEPROM(RTC_Time_t*, uint16_t);
void ReadTimeEEPROM(RTC_Time_t*, uint16_t);
void ReadEEPROM(uint8_t*, uint8_t, uint16_t);
void WriteEEPROM(uint8_t*, uint8_t, uint16_t);
void SetNextWakeupIn(uint8_t months, uint8_t days, uint8_t hrs, uint8_t mins, uint8_t secs);


#endif /* NICHDROP_H_ */
