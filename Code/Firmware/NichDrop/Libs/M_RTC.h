/*
 * M_RTC.h
 *
 *  Created on: 27/05/2010
 *      Author: Matthew Cochrane
 *
 *      Real Time Clock module for use with Phillips RTC's such as the M41T81.
 *
 */

#ifndef M_RTC_H_
#define M_RTC_H_

#include <stdlib.h>
#include <stdio.h>
#include <avr/io.h>
#include "i2c.h"
#include "M_USART.h"
#include <avr/pgmspace.h>

//Macros
#define RTCProgOn PORTC |= (1<<3); i2c_init()
#define RTCProgOff PORTC &= ~(1<<3)
#define RTC_CHIP 0xD0 // I2C ID of the timer chip

//Structs
typedef struct RTCTime {
	uint8_t Second;
	uint8_t Minute;
	uint8_t Hour;

	uint8_t Day;
	uint8_t Month;
	uint8_t Year;
} RTC_Time_t;

//Function Prototypes
unsigned char RTC_get(unsigned char);
unsigned char RTC_getflags(void);
void RTC_set(unsigned char , unsigned char);
void RTC_set_msk(unsigned char , unsigned char , unsigned char );
void RTC_EnableAlarm(void);
void PrintTime(struct RTCTime* , char*);
void RTC_GetTime(struct RTCTime*);
void RTC_GetAlarm(struct RTCTime*);
void RTC_SetTime(struct RTCTime*);
void RTC_SetAlarm(struct RTCTime*);
uint8_t IntToBCD(uint8_t);
uint8_t BCDToInt(uint8_t);
void CopyTime (struct RTCTime*, struct RTCTime*);
void AddTimes(struct RTCTime*, struct RTCTime*);
void ClearTime(struct RTCTime*);
uint8_t CompareTimes (struct RTCTime* , struct RTCTime* );
uint8_t FirstTimeGreater (struct RTCTime* , struct RTCTime* );
uint8_t ValidDateTime(struct RTCTime*);
uint8_t DaysInMonth(uint8_t , uint8_t );

#endif /* RTC_H_ */
