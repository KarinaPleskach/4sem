import java.awt.*;
import java.io.IOException;
import java.util.Properties;
import java.util.StringTokenizer;

import javax.mail.*;
import javax.swing.*;

public class CheckingMails extends JFrame {

    public Message[] messages;
    public Folder emailFolder;
    public Store store;

    private static final int WIDTH = 600;
    private static final int HEIGHT = 400;

    public static final JTextArea log = new JTextArea();

    public CheckingMails() {
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

    public void check(String host, String storeType, String user,
                             String password)
    {
        try {

            //create properties field
            Properties properties = new Properties();

            properties.put("mail.pop3.host", host);
            properties.put("mail.pop3.port", "995");
            properties.put("mail.pop3.starttls.enable", "true");

            Session emailSession = Session.getDefaultInstance(properties);

            //create the POP3 store object and connect with the pop server
            store = emailSession.getStore("pop3s");

            log.append("+OK РОР3 server ready " + "\n");
            log.append("USER " + user + "\n");
            log.append("PASS " + password + "\n");
            store.connect(host, user, password);
            log.append("+OK " + user + " is a real hoopy frood " + "\n");
            //create the folder object and open it
            emailFolder = store.getFolder("INBOX");
            emailFolder.open(Folder.READ_WRITE);

            // retrieve the messages from the folder in an array and print it
            messages = emailFolder.getMessages();

        } catch (NoSuchProviderException e) {
            log.append("-ERR sorry, i don't have connection " + "\n");
        } catch (MessagingException e) {
            log.append("-ERR sorry, something wrong with your login and password" + "\n");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void stat() {
        log.append("STAT " + "\n");
        log.append("+ОК "+ messages.length + " ");

        int size = 0;
        for (int i = 0, n = messages.length; i < n; i++) {
            Message message = messages[i];
            try {
                size += message.getSize();
            } catch (MessagingException e) {
                e.printStackTrace();
            }

        }
        log.append(size + "\n");
    }
    public void list() {
        log.append("LIST " + "\n");
        log.append("+ОК "+ messages.length + " messages ");

        int size = 0;
        for (int i = 0, n = messages.length; i < n; i++) {
            Message message = messages[i];
            try {
                size += message.getSize();
            } catch (MessagingException e) {
                e.printStackTrace();
            }

        }
        log.append("(" + size+ " octets)" + "\n");
        for (int i = 0, n = messages.length; i < n; i++) {
            Message message = messages[i];
            try {
                log.append((i+1)+" "+message.getSize() + "\n");
            } catch (MessagingException e) {
                e.printStackTrace();
            }

        }
    }

    public void retr(int i) {
        log.append("RETR " +(i) +"\n");
        i--;
        if (i > messages.length) {
            log.append("-ERR message " + (i+1)+" doesn't exist " + "\n");
        } else {
            Message message = messages[i];
            try {
                log.append("+ОК " +message.getSize() +" octets"+ "\n");
                log.append("Subject: " + message.getSubject().toString()+ "\n");
                log.append("From: " + message.getFrom()[0].toString()+ "\n");
                log.append("Date: " + message.getSentDate()+ "\n");
                log.append("Text: " + message.getContent().toString()+ "\n");
            } catch (MessagingException | IOException e) {
                e.printStackTrace();
            }
        }
    }

    public void dele(int i) {
        log.append("DELE " +(i) +"\n");
        i--;
        if (i > messages.length) {
            log.append("-ERR message " + (i+1)+" doesn't exist " + "\n");
        } else if (messages[i].isExpunged()) {
            log.append("-ERR message " + (i+1)+" already deleted " + "\n");
        } else {
            Message message = messages[i];
            try {
                log.append("Subject: " + message.getSubject().toString()+ "\n");
                log.append("From: " + message.getFrom()[0].toString()+ "\n");
                log.append("Date: " + message.getSentDate()+ "\n");
                log.append("Text: " + message.getContent().toString()+ "\n");
                messages[i].setFlag(Flags.Flag.DELETED, true);
                log.append("+ОК " + (i+1)+" deleted " + "\n");
            } catch (MessagingException | IOException e) {
                e.printStackTrace();
            }
        }
    }


    public void quit(){
        try {
            log.append("QUIT" + "\n");
            emailFolder.close(true);
            store.close();
            log.append("+ОК dewey POP3 server signing off" + "\n");
        } catch (MessagingException e) {
            e.printStackTrace();
        }

    }

    public static void main(String[] args) {

//        CheckingMails window = new CheckingMails();

        String host = "pop.mail.ru";
        String mailStoreType = "pop3";

        String username;
        String password;
        StringTokenizer st = PopupAuthentication.getPasswordAuthentication();
        username = st.nextToken();
        password = st.nextToken();
        CheckingMails window = new CheckingMails();
        window.check(host, mailStoreType, username, password);
        window.stat();
        window.list();
        window.retr(5);
        window.dele(97);
        window.quit();

    }

}