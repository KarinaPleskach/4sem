#include <stdio.h>
#include <winsock2.h>
#include <iphlpapi.h>

#pragma comment(lib, "iphlpapi.lib")

// выводит 6 байт, начиная с addr в консоль
void PrintMACaddress (BYTE *addr) {
   for (int i = 0; i < 6; ++i) {
       printf("%02x%c", *addr++, (i < 5) ? '-' : '\n');
   }
}

// печатаем МАК адреса всех адаптеров
static void GetMACaddress() {
   IP_ADAPTER_INFO AdapterInfo[16];       // информация о 16 адаптерах макс
   DWORD dwBufLen = sizeof (AdapterInfo); // кол-во байт в буффере

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
