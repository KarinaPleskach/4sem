package com.techprimers.springbootsoapexample.service;
import com.techprimers.spring_boot_soap_example.GetUserRequest;
import com.techprimers.spring_boot_soap_example.GetUserResponse;

import org.springframework.stereotype.Service;

@Service
public class UserService extends ComentServices {



    public GetUserResponse getUsersData(GetUserRequest text) {
        GetUserResponse getUserResponse = new GetUserResponse();
        globalUsers.add(text.toString());
        getUserResponse.setWords(countNumberOfLines(text.getText()));

        return getUserResponse;
    }


    public void serverHandleMessage(GetUserRequest text,Client client) {
        client.sendToServer(text);
    }


}
