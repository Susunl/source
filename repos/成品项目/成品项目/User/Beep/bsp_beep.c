#include "bsp_beep.h"

void Beep_GPIO_Config(void)
{		
	/*����һ��GPIO_InitTypeDef���͵Ľṹ��*/
	GPIO_InitTypeDef GPIO_InitStructure;
	
	/*�������ӷ�������GPIO������ʱ��*/
	BEEP_GPIO_APBxClock_FUN(BEEP_GPIO_CLK, ENABLE);
	/*ѡ��Ҫ���Ƶ�GPIO����*/															   
	GPIO_InitStructure.GPIO_Pin = BEEP_PIN;
	/*��������ģʽΪͨ���������*/
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	/*������������Ϊ50MHz */   
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	/*���ÿ⺯������ʼ��GPIO*/
	GPIO_Init(BEEP_PORT, & GPIO_InitStructure);

	/* Ĭ�Ϲرշ�����*/
	BEEP_OFF ();	
}

void Beep_Init(void)
{		
	Beep_GPIO_Config ();
	
	/* Ĭ�Ϲرշ�����*/
	BEEP_OFF ();
}

void relay_init(void)
{
GPIO_InitTypeDef  GPIO_InitStructure;
BEEP_GPIO_APBxClock_FUN(RCC_APB2Periph_GPIOC,ENABLE);
GPIO_InitStructure.GPIO_Pin = GPIO_Pin_7;
GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;//���
GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
GPIO_Init(GPIOC, &GPIO_InitStructure);
}
void Fan_Init(void)
{		
	relay_init ();
	
	/* Ĭ�Ϲرշ�����*/
	Fan_Off();
}
//relay on PB7
void Fan_Off(void)
{
  GPIO_SetBits(GPIOC,GPIO_Pin_7);
}
//relay off PB7
void Fan_On(void)
{
  GPIO_ResetBits(GPIOC,GPIO_Pin_7);
}

