package com.ponderingprogrammer;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.Map;

public class Main {

    public static final int TOP_WORDS_COUNT = 50;

    public static void main(String[] args) {
        if (args.length < 1) {
            printUsage();
            return;
        }

        var filename = args[0];
        var file = new File(filename);
        if (!file.exists() || file.isDirectory()) {
            System.out.println("File not found");
        }

        if (!file.canRead()) {
            System.out.println("Cannot read file");
        }

        WordCounter counter = new WordCounter();

        try (var reader = new FileReader(file, StandardCharsets.UTF_8)) {
            var wordEnumerator = new WordEnumerator(reader);
            while(wordEnumerator.hasNext()) {
                var word = wordEnumerator.next();
                if (!word.isEmpty()) {
                    counter.addWord(word);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        printResults(counter);
    }

    private static void printResults(WordCounter counter) {
        System.out.println("Total words: " + counter.getTotalWordCount());
        System.out.println("Unique words: " + counter.getUniqueWordCount());
        System.out.println("Most common words: ");
        var displayed = 0;
        for(Map.Entry<String, Integer> entry : counter.getSortedWordCountMap().entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue());
            displayed++;
            if (displayed >= TOP_WORDS_COUNT)
                break;
        }
    }

    public static void printUsage() {
        System.out.println("Usage: wordcount <filename>");
    }
}
