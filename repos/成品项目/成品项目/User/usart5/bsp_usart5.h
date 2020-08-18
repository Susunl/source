#ifndef __USART_H
#define	__USART_H


#include "stm32f10x.h"
#include <stdio.h>

/** 
  * 串口宏定义，不同的串口挂载的总线不一样，移植时需要修改这几个宏
  */
// 串口5-UART5
#define  DEBUG_USARTx5                   UART5
#define  DEBUG_USART_CLK5                RCC_APB1Periph_UART5
#define  DEBUG_USART_APBxClkCmd5         RCC_APB1PeriphClockCmd
#define  DEBUG_USART_BAUDRATE5           2400

// USART GPIO 引脚宏定义
#define  DEBUG_USART_GPIO_CLK5           (RCC_APB2Periph_GPIOC|RCC_APB2Periph_GPIOD)
#define  DEBUG_USART_GPIO_APBxClkCmd5    RCC_APB2PeriphClockCmd
    
#define  DEBUG_USART_TX_GPIO_PORT5       GPIOC   
#define  DEBUG_USART_TX_GPIO_PIN5        GPIO_Pin_12
#define  DEBUG_USART_RX_GPIO_PORT5       GPIOD
#define  DEBUG_USART_RX_GPIO_PIN5        GPIO_Pin_2

#define  DEBUG_USART_IRQ5                UART5_IRQn
#define  DEBUG_USART_IRQHandler5         UART5_IRQHandler

void USART_Config5(void);
void Usart_SendByte( USART_TypeDef * pUSARTx, uint8_t ch);
void Usart_SendString( USART_TypeDef * pUSARTx, char *str);
void Usart_SendHalfWord( USART_TypeDef * pUSARTx, uint16_t ch);

#endif /* __USART_H */
