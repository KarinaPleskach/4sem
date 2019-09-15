#include <windows.h>

#include <wincon.h>

#include <stdlib.h>

#include <stdio.h>

#include <time.h>
#include "NB30.h"
#pragma comment(lib, "Netapi32.lib")


typedef struct _ASTAT_ {
	ADAPTER_STATUS adapt;
	NAME_BUFFER NameBuff [30];
}ASTAT, *PASTAT;

ASTAT Adapter;

int main(int argc, char * argv[])
{
	char *buffer;
   //code
	NCB ncb;//Нам нужна структура сетевого управляющего блока. Имя этой структуры NCB. Она содержит данные о каманде, буфер для сообщений и так далее.
	//Так как на основе этой структуры производится общение с интерфейсом NetBios.
	//NetBIOS (Network Basic Input/Output System) — протокол для работы в локальных сетях на персональных ЭВМ 
	UCHAR uRetCode;//unsigned char//Результат выполнения команды возвращается в переменную, которую нужно объявить.
	char NetName[50];

	memset( &ncb, 0, sizeof(ncb) ); //Дальше под эту структуру нам надо выделить память//функция заполняет блок памяти символом, преобразуя это число в символ.//Количество байт, которые необходимо заполнить указанным символом.
	
	ncb.ncb_command = NCBRESET;//А вот теперь поместим в структуру команду NCBRESET. Эта команда очищает имена и сеансы связи. Заканчивает невыполненные команды.
	ncb.ncb_lana_num = 0;//Теперь в структуре нужно определить адаптерный номер LAN.//Число NetBIOS LANA идентифицирует транспортный протокол, драйвер сетевой карты и адаптер, который будет использоваться, чтобы послать и получить пакеты NetBIOS. Это число необходимо определять в структуре NCB перед запуском команд NetBIOS//Спецификация IBM NetBIOS 3.0 поддерживает только два числа LANA, поскольку NetBEUI был первоначально единственным протоколом, поддерживающим NetBIOS, и компьютер мог бы содержать только два сетевых адаптера.0 - первый адаптер;1 - второй адаптер

	uRetCode = Netbios((NCB*) &ncb );

	memset( &ncb, 0, sizeof(ncb) );//обнулить
	ncb.ncb_command = NCBASTAT;//Для получения адреса используется команда NCBASTAT с параметром - "*".Только перед заполнением блока лучше его обнулить.
	ncb.ncb_lana_num = 0;
	strcpy( (char *) ncb.ncb_callname, "*	" );//ncb.ncb_callname - имя клиента.

	ncb.ncb_buffer = (unsigned char *) &Adapter;//Скажем, что буфер это структура адаптера и укажем длину
	ncb.ncb_length = sizeof(Adapter);
	
	uRetCode = Netbios( (NCB*)&ncb );
if(uRetCode==0){//Код возврата должен быть 0 при нормальном выполнении команды//И теперь, если все нормально, то есть код возврата и можно посмотреть адрес адаптера:

printf("The MAC is: %02x%02x%02x%02x%02x%02x\n",
	Adapter.adapt.adapter_address[0],
	Adapter.adapt.adapter_address[1],
	Adapter.adapt.adapter_address[2],
	Adapter.adapt.adapter_address[3],
	Adapter.adapt.adapter_address[4],
	Adapter.adapt.adapter_address[5]);
}
	system("pause");
	return 0;
}