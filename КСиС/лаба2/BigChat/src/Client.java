/**
 * создание клиента со всеми необходимыми утилитами, точка входа в программу в классе Client
 */

public class Client {

    public static String ipAddr = "localhost";
    public static int port = 8081;

    /**
     * создание клиент-соединения с узананными адресом и номером порта
     * @param args
     */

    public static void main(String[] args) {
        new ClientSomthing(ipAddr, port);
    }
}