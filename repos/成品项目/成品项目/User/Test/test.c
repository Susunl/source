#include "test.h"
#include "bsp_esp8266.h"
#include "bsp_SysTick.h"
#include <stdio.h>  
#include <string.h>  
#include <stdbool.h>
#include "bsp_dht11.h"
#include "bsp_ili9341_lcd.h"
#include "bsp_adc.h"
#include "bsp_beep.h"
#include "bsp_usart5.h"
volatile uint8_t ucTcpClosedFlag = 0;
float ADC_ConvertedValueLocal[NOFCHANEL]; 
extern __IO uint16_t ADC_ConvertedValue[NOFCHANEL];
 __IO uint8_t incomeByte[7] = {0};

/**
  * @brief  ESP8266 （Sta Tcp Client）透传
  * @param  无
  * @retval 无
  */
void ESP8266_StaTcpClient_UnvarnishTest ( void )
{
	uint8_t ucStatus;
	char dispBuff[100];
	float c=0;
	char cStr1 [ 300 ] = { 0 };
	
	char cStr2 [ 100 ] = { 0 };
	DHT11_Data_TypeDef DHT11_Data;
  printf ( "\r\n正在配置 ESP8266 ......\r\n" );

	macESP8266_CH_ENABLE();
	
	ESP8266_AT_Test ();
	
	ESP8266_Net_Mode_Choose ( STA );

  while ( ! ESP8266_JoinAP ( macUser_ESP8266_ApSsid, macUser_ESP8266_ApPwd ) );	
	
	ESP8266_Enable_MultipleId ( DISABLE );
	
	while ( !	ESP8266_Link_Server ( enumTCP, macUser_ESP8266_TcpServer_IP, macUser_ESP8266_TcpServer_Port, Single_ID_0 ) );
	
	while ( ! ESP8266_UnvarnishSend () );
	
	printf ( "\r\n配置 ESP8266 完毕\r\n" );
	
	
	while ( 1 )
	{
		c=ReadPM10();
		if( DHT11_Read_TempAndHumidity ( & DHT11_Data ) == SUCCESS)
		{
			sprintf(dispBuff,"%d.%d℃ ",DHT11_Data.temp_int, DHT11_Data.temp_deci);
			ILI9341_DispString_EN_CH(160,0,dispBuff );
			sprintf(dispBuff,"%d.%d%%RH ",DHT11_Data.humi_int, DHT11_Data.humi_deci);
			ILI9341_DispString_EN_CH(160,16,dispBuff );
		}
			if(ADC_ConvertedValue[4]<2000)
			{	
				sprintf(dispBuff,"%dppm ",ADC_ConvertedValue[4]);
				ILI9341_DispString_EN_CH(160,48,dispBuff );
				LCD_ClearLine(LINE(7));
			}
			else
			{
				sprintf(dispBuff,"%dppm ",ADC_ConvertedValue[4]);
				ILI9341_DispString_EN_CH(160,48,dispBuff );
				sprintf ( cStr2, "甲醛浓度超标" );
				LCD_ClearLine(LINE(7));
				ILI9341_DispStringLine_EN_CH(LINE(7),cStr2);
			}
			if(ADC_ConvertedValue[5]<2000)
			{	
				sprintf(dispBuff,"%dppm ",ADC_ConvertedValue[5]);
				ILI9341_DispString_EN_CH(160,32,dispBuff );
				LCD_ClearLine(LINE(6));
			}
			else
			{
				sprintf(dispBuff,"%dppm ",ADC_ConvertedValue[5]);
				ILI9341_DispString_EN_CH(160,32,dispBuff );
				sprintf ( cStr2, "可燃气体浓度超标" );
				LCD_ClearLine(LINE(6));
				ILI9341_DispStringLine_EN_CH(LINE(6),cStr2);
			}
			if(ADC_ConvertedValue[4]<2000&&ADC_ConvertedValue[5]<2000&&c <200)
			{
				Fan_Off();
				BEEP_OFF();
			}
			else
			{
				Fan_On();
				BEEP_ON();
			}
			ADC_ConvertedValueLocal[4] =(float) ADC_ConvertedValue[4]/4096*3.3;
			ADC_ConvertedValueLocal[5] =(float) ADC_ConvertedValue[5]/4096*3.3;
			printf("\r\n CH4 value = %f V \r\n",ADC_ConvertedValueLocal[4]);
			printf("\r\n CH5 value = %f V \r\n",ADC_ConvertedValueLocal[5]);
			printf("\r\n\r\n");
			sprintf ( cStr1, "\r\n湿度为%d.%d ％RH ，温度为 %d.%d℃ \r\nCO浓度值为 %d \r\n甲醛浓度值为%d\r\nPM2.5浓度值为%4.2f\r\n", 
								DHT11_Data.humi_int, DHT11_Data.humi_deci, DHT11_Data .temp_int, DHT11_Data.temp_deci,ADC_ConvertedValue[5],ADC_ConvertedValue[4],c);
				
		

		printf ( "%s", cStr1 );                                             //打印读取 DHT11 温湿度信息

	
		ESP8266_SendString ( ENABLE, cStr1, 0, Single_ID_0 );               //发送 DHT11 温湿度信息到网络调试助手
		
		Delay_ms ( 5000 );
		
		if ( ucTcpClosedFlag )                                             //检测是否失去连接
		{
			ESP8266_ExitUnvarnishSend ();                                    //退出透传模式
			
			do ucStatus = ESP8266_Get_LinkStatus ();                         //获取连接状态
			while ( ! ucStatus );
			
			if ( ucStatus == 4 )                                             //确认失去连接后重连
			{
				printf ( "\r\n正在重连热点和服务器 ......\r\n" );
				
				while ( ! ESP8266_JoinAP ( macUser_ESP8266_ApSsid, macUser_ESP8266_ApPwd ) );
				
				while ( !	ESP8266_Link_Server ( enumTCP, macUser_ESP8266_TcpServer_IP, macUser_ESP8266_TcpServer_Port, Single_ID_0 ) );
				
				printf ( "\r\n重连热点和服务器成功\r\n" );

			}
			
			while ( ! ESP8266_UnvarnishSend () );		
			
		}

	}
	
		
}
float ReadPM10()
{
	uint8_t incomeByte[7];
	uint8_t data;
	uint8_t z=0;
	uint32_t sum;
	char cStr2 [ 100 ] = { 0 };
	float c = 0;
	while(1)
	{
		data=getchar();
		if(data==170)
		{
			z=0;
			incomeByte[z]=data;
		}
		else
		{
			z++;
			incomeByte[z]=data;
		}
		if(z==6)
		{
			z=0;
			break;
		}
	}
	sum = incomeByte[1]+ incomeByte[2]+ incomeByte[3] + incomeByte[4];
	if(incomeByte[5]==sum)
	{
		float vo=(incomeByte[1]*256.0+incomeByte[2])/1024.0*5.00;
		c=vo*200;
		if(c <200)
			{	
				sprintf(cStr2,"%4.2fug/m3 ",c);
				ILI9341_DispString_EN_CH(160,64,cStr2 );
				LCD_ClearLine(LINE(8));
			}
			else
			{
				sprintf(cStr2,"%4.2fug/m3 ",c);
				ILI9341_DispString_EN_CH(160,64,cStr2 );
				sprintf ( cStr2, "PM2.5超标" );
				LCD_ClearLine(LINE(8));
				ILI9341_DispStringLine_EN_CH(LINE(8),cStr2);
			}
	}
	return c;
}


