import javax.mail.*;
import javax.swing.*;
import java.util.*;

public class PopupAuthentication {

    public static StringTokenizer getPasswordAuthentication() {

        String result = JOptionPane
                .showInputDialog("Enter 'username,password'");

        return new StringTokenizer(result, ",");
    }
}