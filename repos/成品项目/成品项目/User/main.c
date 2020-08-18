#include "stm32f10x.h"
#include "bsp_usart.h"
#include "bsp_adc.h"

#include "bsp_ili9341_lcd.h"
#include "bsp_spi_flash.h"
#include "bsp_SysTick.h"
#include "bsp_dht11.h"
#include "bsp_esp8266.h"
#include "test.h"
#include "bsp_beep.h"
#include "bsp_usart5.h"
// ADC1转换的电压值通过MDA方式传到SRAM
// 局部变量，用于保存转换计算后的电压值 	 
//float ADC_ConvertedValueLocal[NOFCHANEL]; 
//extern __IO uint16_t ADC_ConvertedValue[NOFCHANEL];

// 局部变量，用于保存转换计算后的电压值 	 
        

// 软件延时
void Delay(__IO uint32_t nCount)
{
  for(; nCount != 0; nCount--);
} 
extern void USART_Config5(void);
extern void Fan_Init(void);
int main(void)
{		
	//char dispBuff[100];
  //float  dens;
	
	//DHT11_Data_TypeDef DHT11_Data;
	DHT11_Init ();
//	ESP8266_Init (); 
	ILI9341_Init ();
	SysTick_Init ();                                                               //配置 SysTick 为 1ms 中断一次 
	ESP8266_Init ();
	// 配置串口
	USART_Config();
	USART_Config5();
	Beep_Init();
	// ADC 初始化
	ADCx_Init();
	Fan_Init();
	 /*其中0、3、5、6 模式适合从左至右显示文字，*/
	ILI9341_GramScan ( 6 ); 
  LCD_SetFont(&Font8x16);
	LCD_SetColors(BLACK,BLACK);
  ILI9341_Clear(0,0,LCD_X_LENGTH,LCD_Y_LENGTH);	/* 清屏，显示全黑 */
	
	LCD_SetTextColor(RED);  
  ILI9341_DispStringLine_EN_CH(LINE(0),"当前温度值:");
  ILI9341_DispStringLine_EN_CH(LINE(1),"当前湿度值:");
  ILI9341_DispStringLine_EN_CH(LINE(2),"当前可燃气体浓度值:");
  ILI9341_DispStringLine_EN_CH(LINE(3),"当前甲醛浓度值:"); 
  ILI9341_DispStringLine_EN_CH(LINE(4),"当前灰尘浓度值:"); 
  LCD_SetTextColor(YELLOW);  
	//printf("\r\n ----这是一个ADC多通道采集实验----\r\n");
	
	ESP8266_StaTcpClient_UnvarnishTest();
	while (1)
	{
//		if( DHT11_Read_TempAndHumidity ( & DHT11_Data ) == SUCCESS)
//		{
//			sprintf(dispBuff,"%d.%d",DHT11_Data.temp_int, DHT11_Data.temp_deci);
//			ILI9341_DispString_EN_CH(170,0,dispBuff );
//			sprintf(dispBuff,"%d.%d%%RH ",DHT11_Data.humi_int, DHT11_Data.humi_deci);
//			ILI9341_DispString_EN_CH(170,16,dispBuff );
//		}
//			sprintf(dispBuff,"%d",ADC_ConvertedValue[4]);
//			ILI9341_DispString_EN_CH(170,48,dispBuff );
//			sprintf(dispBuff,"%d",ADC_ConvertedValue[5]);
//			ILI9341_DispString_EN_CH(170,32,dispBuff );
//			ADC_ConvertedValueLocal[4] =(float) ADC_ConvertedValue[4]/4096*3.3;
//			ADC_ConvertedValueLocal[5] =(float) ADC_ConvertedValue[5]/4096*3.3;
//			
//			printf("\r\n CH4 value = %f V \r\n",ADC_ConvertedValueLocal[4]);
//			printf("\r\n CH5 value = %f V \r\n",ADC_ConvertedValueLocal[5]);
//		
//			printf("\r\n\r\n");
		
	}
}
/*********************************************END OF FILE**********************/

