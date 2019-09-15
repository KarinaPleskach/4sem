package com.techprimers.springbootsoapexample.service;

import java.io.*;

public class FileHandler {
    private final String filePath = "D:/";
    String fileName;
    String text;
    int offset;

    public String FileHandler(String contents) throws IOException {
        getData(contents);
        return getFromFile();
    }

    private void getData(String contents) {
        String[] arr = contents.split("\r\n|\r|\n");
        this.fileName = arr[0];
        String s = arr[1];
        this.offset = Integer.valueOf(s);
        this.text = arr[2];


    }

    private String getFromFile() throws IOException {
        File file = new File(filePath + fileName + ".txt");
        long l = file.length();
        StringBuilder sb = getStringFromFile();
        int begin = offset;
        int end = begin+(Integer.valueOf(text));
        if ((l>offset)&&(l>end)) {
            return (sb.toString()).substring(begin,end);
        }else {
            return  "File Size is :"+l;
        }
    }

    private StringBuilder getStringFromFile() throws IOException {
        InputStream is = new FileInputStream(filePath+fileName+".txt");
        BufferedReader buf = new BufferedReader(new InputStreamReader(is));
        String line = buf.readLine();
        StringBuilder sb = new StringBuilder();
        while (line != null) {
            sb.append(line).append("\n");
            line = buf.readLine();
        }
        is.close();
        buf.close();

        return new StringBuilder(sb.toString());

    }

}
