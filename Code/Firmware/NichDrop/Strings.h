/*
 * Strings.h
 *
 *  Created on: 22/04/2011
 *      Author: Matthew Cochrane
 */

#ifndef STRINGS_H_
#define STRINGS_H_

#include <stdlib.h>
#include <avr/io.h>
#include <avr/pgmspace.h>

#define STR_PRODUCT_N			"NichDrop"
#define STR_CODE_V				"V1.1.1"
#define STR_WILDSPY				"Wild Spy"
#define STR_NEWLINE				"\r\n"
#define DEVTYPE_ID				0x0010

extern char PSTR_PRODUCT_N[];// PROGMEM = STR_PRODUCT_N;
extern char PSTR_CODE_V[];// PROGMEM = STR_CODE_V;
extern char PSTR_WILDSPY[];// PROGMEM = STR_WILDSPY;
extern char PSTR_NEWLINE[];// PROGMEM = STR_NEWLINE;
extern uint16_t P_DEV_ID;// PROGMEM = DEV_ID;

//Function Prototypes:
uint8_t compareStringWithP(char* str, char* Pstr);
int compareStartofStringWithP(char* str, char* Pstr);
int stringCopy(char* srcStr, char* destStr);
int stringCopyP(char* srcStrP, char* destStr);


//yeah
#endif /* STRINGS_H_ */
