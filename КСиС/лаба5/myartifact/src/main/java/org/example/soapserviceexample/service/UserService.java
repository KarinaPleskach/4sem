package org.example.soapserviceexample.service;

import org.example.soapservice.GetUserRequest;
import org.example.soapservice.GetUserResponse;
import org.springframework.stereotype.Service;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

//эта аннотация говорит Spring'у создать соответствующий объект
@Service
public class UserService {

    private Set<String> globalUsers = new HashSet<>();

    private String countNumberOfWords(String name) {
        if ((name == null) || (name.isEmpty())) {
            return null;
        }
        String[] words = name.split("\\s+");
        return String.valueOf(words.length);
    }
    public GetUserResponse getUserData(GetUserRequest text) {
        GetUserResponse getUserResponse = new GetUserResponse();
        List<String> stringList = text.getName();
        for (int i = 0; i < stringList.size(); ++i) {
            globalUsers.add(stringList.get(i));
            getUserResponse.getWords().add(countNumberOfWords(stringList.get(i)));
        }
        return getUserResponse;
    }
}
