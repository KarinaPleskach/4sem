#include <stdio.h>
#include <winsock2.h>
#include <iphlpapi.h>

#pragma comment(lib, "iphlpapi.lib")

// ������� 6 ����, ������� � addr � �������
void PrintMACaddress (BYTE *addr) {
   for (int i = 0; i < 6; ++i) {
       printf("%02x%c", *addr++, (i < 5) ? '-' : '\n');
   }
}

// �������� ��� ������ ���� ���������
static void GetMACaddress() {
   IP_ADAPTER_INFO AdapterInfo[16];       // ���������� � 16 ��������� ����
   DWORD dwBufLen = sizeof (AdapterInfo); // ���-�� ���� � �������

   DWORD dwStatus = GetAdaptersInfo(AdapterInfo, &dwBufLen);
   if (dwStatus != ERROR_SUCCESS) {
      printf("GetAdaptersInfo failed. err=%d\n", GetLastError());
      return;
  }

  PIP_ADAPTER_INFO pAdapterInfo = AdapterInfo;
    while (pAdapterInfo) {
        if (pAdapterInfo->Type == MIB_IF_TYPE_ETHERNET) {
            PrintMACaddress(pAdapterInfo->Address);
            break;
        }
        pAdapterInfo = pAdapterInfo->Next;
    }
}
 void main(){

    GetMACaddress();
 }
