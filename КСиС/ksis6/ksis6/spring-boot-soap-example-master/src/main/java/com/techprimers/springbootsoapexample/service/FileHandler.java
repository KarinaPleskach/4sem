package com.techprimers.springbootsoapexample.service;

import java.io.*;

public class FileHandler {
    private final String filePath = "D:/";
    String fileName;
    String text;
    byte offset;

    public FileHandler(String contents) throws IOException {
        getData(contents);
        addFile();
    }

    private void getData(String contents) {
        String[] arr = contents.split("\r\n|\r|\n");
        this.fileName = arr[0];
        this.offset = Byte.valueOf(arr[1]);
        this.text = "";
        for (int i = 2; i < arr.length; i++) {
            this.text = this.text.concat(arr[i]);
        }

    }

    private void addFile() throws IOException {
        File file = new File(filePath + fileName + ".txt");
        long l = file.length();
        StringBuilder sb = getStringFromFile();
        FileWriter writer = new FileWriter(file);
        @SuppressWarnings("resource")
        BufferedWriter bufferedWriter = new BufferedWriter(writer);

        if ((file.exists()) && (l > offset)) {
            sb.insert(offset, text);
            bufferedWriter.write(sb.toString());
        } else {
            bufferedWriter.write(text);
        }
        bufferedWriter.flush();
        bufferedWriter.close();
        writer.close();
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
