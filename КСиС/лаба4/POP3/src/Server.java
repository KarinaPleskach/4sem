import javax.mail.*;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Properties;
import java.util.StringTokenizer;

public class Server {

    public Message[] messages;
    public Folder emailFolder;
    public Store store;

    private static String host = "pop.mail.ru";
    private static String mailStoreType = "pop3";

    public String check(String host, String storeType, String user,
                      String password)
    {
        String result = "";
        try {

            //create properties field
            Properties properties = new Properties();

            properties.put("mail.pop3.host", host);
            properties.put("mail.pop3.port", "995");
            properties.put("mail.pop3.starttls.enable", "true");

            Session emailSession = Session.getDefaultInstance(properties);

            //create the POP3 store object and connect with the pop server
            store = emailSession.getStore("pop3s");

            store.connect(host, user, password);
            result += ("+OK " + user + " is a real hoopy frood " );
            //create the folder object and open it
            emailFolder = store.getFolder("INBOX");
            emailFolder.open(Folder.READ_WRITE);

            // retrieve the messages from the folder in an array and print it
            messages = emailFolder.getMessages();

        } catch (NoSuchProviderException e) {
            result += ("-ERR sorry, i don't have connection ");
        } catch (MessagingException e) {
            result += ("-ERR sorry, something wrong with your login and password" );
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            return result;
        }
    }

    public String stat() {
        String result = "";
        result += ("+ОК "+ messages.length + " ");

        int size = 0;
        for (int i = 0, n = messages.length; i < n; i++) {
            Message message = messages[i];
            try {
                size += message.getSize();
            } catch (MessagingException e) {
                e.printStackTrace();
            }

        }
        result += (size);
        return result;
    }

    public String list() {
        String result = "";
        result += ("+ОК "+ messages.length + " messages ");

        int size = 0;
        for (int i = 0, n = messages.length; i < n; i++) {
            Message message = messages[i];
            try {
                size += message.getSize();
            } catch (MessagingException e) {
                e.printStackTrace();
            }

        }
        result += ("(" + size+ " octets)" + " -> ");
        for (int i = 0, n = messages.length; i < n; i++) {
            Message message = messages[i];
            try {
                result += ((i+1)+" "+message.getSize() + " ");
            } catch (MessagingException e) {
                e.printStackTrace();
            }

        }
        return result;
    }

    public String retr(int i) {
        String result = "";
        i--;
        if (i > messages.length) {
            result += ("-ERR message " + (i+1)+" doesn't exist ");
        } else {
            Message message = messages[i];
            try {
                result += ("Text: " + message.getContent().toString());
            } catch (MessagingException | IOException e) {
                e.printStackTrace();
            }
        }
        return result;
    }

    public String dele(int i) {
        String result = "";
        i--;
        if (i > messages.length) {
            result += ("-ERR message " + (i+1)+" doesn't exist ");
        } else if (messages[i].isExpunged()) {
            result += ("-ERR message " + (i+1)+" already deleted ");
        } else {
            Message message = messages[i];
            try {
                messages[i].setFlag(Flags.Flag.DELETED, true);
                result += ("+ОК " + (i+1)+" deleted ");
            } catch (MessagingException e) {
                e.printStackTrace();
            }
        }
        return result;
    }

    public String quit(){
        String result = "";
        try {
            emailFolder.close(false);
            store.close();
            result += ("+ОК dewey POP3 server signing off" + "\n");
        } catch (MessagingException e) {
            e.printStackTrace();
        }
        return result;
    }

    private static Socket clientSocket; //сокет для общения
    private static ServerSocket server; // серверсокет
    private static BufferedReader in; // поток чтения из сокета
    private static BufferedWriter out; // поток записи в сокет

    public static void main(String[] args) {
        try {
            try {
                Server s = new Server();
                server = new ServerSocket(4004); // серверсокет прослушивает порт 4004
                System.out.println("Сервер запущен!"); // хорошо бы серверу
                //   объявить о своем запуске
                clientSocket = server.accept(); // accept() будет ждать пока
                //кто-нибудь не захочет подключиться
                try { // установив связь и воссоздав сокет для общения с клиентом можно перейти
                    // к созданию потоков ввода/вывода.
                    // теперь мы можем принимать сообщения
                    in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
                    // и отправлять
                    out = new BufferedWriter(new OutputStreamWriter(clientSocket.getOutputStream()));

                    out.write("+OK РОР3 server ready " + "\n");
                    out.flush();

                    while(true) {
                        String word = in.readLine(); // ждём пока клиент что-нибудь нам напишет
                        StringTokenizer str = new StringTokenizer(word, ",");

                        String firstToken = str.nextToken();

                        if (firstToken.equals("check")) {
                            out.write(s.check(host, mailStoreType, str.nextToken(), str.nextToken()) + "\n");
                            out.flush();
                        } else if (firstToken.equals("stat")) {
                            out.write(s.stat() + "\n");
                            out.flush();
                        } else if (firstToken.equals("list")) {
                            out.write(s.list() + "\n");
                            out.flush();
                        } else if (firstToken.equals("retr")) {
                            out.write(s.retr(Integer.parseInt(str.nextToken())) + "\n");
                            out.flush();
                        } else if (firstToken.equals("dele")) {
                            out.write(s.dele(Integer.parseInt(str.nextToken())) + "\n");
                            out.flush();
                        } else if (firstToken.equals("quit")) {
                            out.write(s.quit() + "\n");
                            out.flush();
                            break;
                        }
                    }
                } finally { // в любом случае сокет будет закрыт

                    clientSocket.close();
                    // потоки тоже хорошо бы закрыть
                    in.close();
                    out.close();
                }
            } finally {
                System.out.println("Сервер закрыт!");
                server.close();
            }
        } catch (IOException e) {
            System.err.println(e);
        }
    }
}