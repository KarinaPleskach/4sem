import java.net.*;
import java.io.*;
import java.util.Scanner;

class Server {

    public static void main(String args[]) throws Exception {
        int c;

        // Создать сокетное соединение с веб-сайтом tcinet.ru

        //internic.net need to autorize
        Socket socket = new Socket("whois.tcinet.ru", 43);

        System.out.println("Write a site name: ");
        Scanner scan = new Scanner(System.in);
        String webSite = scan.next();

        // получить потоки ввода-вывода
        InputStream in = socket.getInputStream();
        OutputStream out = socket.getOutputStream();

        // сформировать строку запроса

        String str = (webSite.length() == 0 ? "pro-java.ru" : webSite) + "\n";

        // преобразовать строку в байты

        byte buf[] = str.getBytes();

        // послать запрос

        out.write(buf);

        // прочитать ответ и вывести его на экран

        while((c = in.read()) != -1) {
            System.out.print((char) c);
        }

        socket.close();
    }
}
