package com.techprimers.springbootsoapexample.service;

import com.techprimers.spring_boot_soap_example.GetUserRequest;
import com.techprimers.spring_boot_soap_example.GetUserResponse;
import com.techprimers.spring_boot_soap_example.User;
import org.springframework.stereotype.Service;

import javax.annotation.PostConstruct;
import java.util.*;

@Service
public class UserService {

    //private static final Map<String, User> users = new HashMap<>();
    private    Set<String> globalUsers = new HashSet<>();
   // private static final List<long>


    private  String countNumberOfWords(String s){

        if((s==null) || (s.isEmpty())){
            return null;
        }
        String[] words =s.split("\\s+");
        return String.valueOf(words.length);
    }

    public GetUserResponse getUsersData(GetUserRequest text) {
        GetUserResponse getUserResponse = new GetUserResponse();
        List<String> ls = text.getText();
        for (int i=0;i < text.getText().size();i++)
        {
            globalUsers.add(ls.get(i));
            getUserResponse.getWords().add(countNumberOfWords(ls.get(i)));
        }
        return getUserResponse;


    }
}
