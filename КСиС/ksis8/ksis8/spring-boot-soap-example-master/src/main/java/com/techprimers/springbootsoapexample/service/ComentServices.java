package com.techprimers.springbootsoapexample.service;
import java.util.HashSet;
import java.util.Set;

public class ComentServices {

    Set<String> globalUsers = new HashSet<>();


    String countNumberOfLines(String s) {
        if ((s == null) || (s.isEmpty())) {
            return null;
        }
        String[] lines = s.split("\r\n|\r|\n");
        return  ("\nThe Number Of Lines is :"+lines.length+"\n"+"The Number Of Words :"+countNumberOfWords(s)+"\n");
    }

    private  String countNumberOfWords(String s){

        if((s==null) || (s.isEmpty())){
            return null;
        }
        String[] words =s.split("\\s+");
        return String.valueOf(words.length);
    }

}


