package com.techprimers.springbootsoapexample.service;

import com.techprimers.spring_boot_soap_example.GetUserRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.IOException;

@Service
public class ServiceService {
    @Autowired
    private UserService userService;

    public void getServiceData(GetUserRequest text) throws IOException {
        System.out.println("Service Of Service Called !!!");
        if (text.getText()>0) {
            text.setText(text.getText()-1);
            userService.CreateHTTPPost(text);
        }
    }
}
