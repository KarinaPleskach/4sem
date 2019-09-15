import javax.swing.*;
import java.awt.*;
import java.io.*;
import java.net.Socket;
import java.util.StringTokenizer;

public class Client extends JFrame{

    private static final int WIDTH = 600;
    private static final int HEIGHT = 400;

    public static final JTextArea log = new JTextArea();

    public Client() {
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setSize(WIDTH, HEIGHT);
        setLocationRelativeTo(null);
        setAlwaysOnTop(true);
        log.setEditable(false);
        log.setLineWrap(true);
        JScrollPane sp = new JScrollPane(log);
        add(sp, BorderLayout.CENTER);
        setVisible(true);
    }

    private static Socket clientSocket; //сокет для общения
    private static BufferedReader reader; // нам нужен ридер читающий с консоли, иначе как
    // мы узнаем что хочет сказать клиент?
    private static BufferedReader in; // поток чтения из сокета
    private static BufferedWriter out; // поток записи в сокет

    public static void main(String[] args) {
        try {
            try {
                // адрес - локальный хост, порт - 4004, такой же как у сервера
                clientSocket = new Socket("localhost", 4004); // этой строкой мы запрашиваем
                //  у сервера доступ на соединение
                // читать соообщения с сервера
                in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
                // писать туда же
                out = new BufferedWriter(new OutputStreamWriter(clientSocket.getOutputStream()));

                String username;
                String password;
                StringTokenizer st = PopupAuthentication.getPasswordAuthentication();
                username = st.nextToken();
                password = st.nextToken();

                new Client();

                String serverWord = in.readLine();
                log.append(serverWord + "\n");

                out.write("check,"+username+","+password + "\n"); // отправляем сообщение на сервер
                out.flush();
                serverWord = in.readLine();
                log.append("USER " + username + "\n");
                log.append("PASS " + password + "\n");
                log.append(serverWord + "\n");

                out.write("stat" + "\n");
                out.flush();
                serverWord = in.readLine();
                log.append("stat " + "\n");
                log.append(serverWord + "\n");

                out.write("list" + "\n");
                out.flush();
                serverWord = in.readLine();
                log.append("list " + "\n");
                log.append(serverWord + "\n");

                out.write("retr,5" + "\n");
                out.flush();
                serverWord = in.readLine();
                log.append("RETR " +(5) +"\n");
                log.append(serverWord + "\n");

                out.write("dele,97" + "\n");
                out.flush();
                serverWord = in.readLine();
                log.append("DELE " +(97) +"\n");
                log.append(serverWord + "\n");

                out.write("quit" + "\n");
                out.flush();
                serverWord = in.readLine();
                log.append("QUIT" + "\n");
                log.append(serverWord + "\n");
            } finally { // в любом случае необходимо закрыть сокет и потоки
                clientSocket.close();
                in.close();
                out.close();
            }
        } catch (IOException e) {
            System.err.println(e);
        }

    }
}