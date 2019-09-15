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
	NCB ncb;//��� ����� ��������� �������� ������������ �����. ��� ���� ��������� NCB. ��� �������� ������ � �������, ����� ��� ��������� � ��� �����.
	//��� ��� �� ������ ���� ��������� ������������ ������� � ����������� NetBios.
	//NetBIOS (Network Basic Input/Output System) � �������� ��� ������ � ��������� ����� �� ������������ ��� 
	UCHAR uRetCode;//unsigned char//��������� ���������� ������� ������������ � ����������, ������� ����� ��������.
	char NetName[50];

	memset( &ncb, 0, sizeof(ncb) ); //������ ��� ��� ��������� ��� ���� �������� ������//������� ��������� ���� ������ ��������, ���������� ��� ����� � ������.//���������� ����, ������� ���������� ��������� ��������� ��������.
	
	ncb.ncb_command = NCBRESET;//� ��� ������ �������� � ��������� ������� NCBRESET. ��� ������� ������� ����� � ������ �����. ����������� ������������� �������.
	ncb.ncb_lana_num = 0;//������ � ��������� ����� ���������� ���������� ����� LAN.//����� NetBIOS LANA �������������� ������������ ��������, ������� ������� ����� � �������, ������� ����� ��������������, ����� ������� � �������� ������ NetBIOS. ��� ����� ���������� ���������� � ��������� NCB ����� �������� ������ NetBIOS//������������ IBM NetBIOS 3.0 ������������ ������ ��� ����� LANA, ��������� NetBEUI ��� ������������� ������������ ����������, �������������� NetBIOS, � ��������� ��� �� ��������� ������ ��� ������� ��������.0 - ������ �������;1 - ������ �������

	uRetCode = Netbios((NCB*) &ncb );

	memset( &ncb, 0, sizeof(ncb) );//��������
	ncb.ncb_command = NCBASTAT;//��� ��������� ������ ������������ ������� NCBASTAT � ���������� - "*".������ ����� ����������� ����� ����� ��� ��������.
	ncb.ncb_lana_num = 0;
	strcpy( (char *) ncb.ncb_callname, "*	" );//ncb.ncb_callname - ��� �������.

	ncb.ncb_buffer = (unsigned char *) &Adapter;//������, ��� ����� ��� ��������� �������� � ������ �����
	ncb.ncb_length = sizeof(Adapter);
	
	uRetCode = Netbios( (NCB*)&ncb );
if(uRetCode==0){//��� �������� ������ ���� 0 ��� ���������� ���������� �������//� ������, ���� ��� ���������, �� ���� ��� �������� � ����� ���������� ����� ��������:

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