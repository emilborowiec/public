package com.ponderingprogrammer;

import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Iterator;

public class WordEnumerator implements Iterator<String> {

    private InputStreamReader reader;
    private String next;

    public WordEnumerator(InputStreamReader reader) {
        this.reader = reader;
    }

    @Override
    public boolean hasNext() {
        try {
            var character = reader.read();
            if (character == -1) {
                return false;
            }
            var wordBuilder = new StringBuilder();
            while (Character.isLetter(character)) {
                wordBuilder.append(Character.toChars(character));
                character = reader.read();
            }
            next = wordBuilder.toString();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return true;
    }

    @Override
    public String next() {
        return next;
    }
}
