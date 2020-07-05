package com.ponderingprogrammer;

import java.util.*;

public class WordCounter {

    HashMap<String, Integer> wordCountMap = new HashMap<>();

    public void addWord(String word) {
        var value = wordCountMap.putIfAbsent(word, 1);
        if (value != null) {
            wordCountMap.put(word, value + 1);
        }
    }

    public int getUniqueWordCount() {
        return wordCountMap.size();
    }

    public int getTotalWordCount() {
        return wordCountMap.values().stream().reduce(0, Integer::sum);
    }

    public Collection<String> getUniqueWords() {
        return wordCountMap.keySet();
    }

    public LinkedHashMap<String, Integer> getSortedWordCountMap() {
        var list = new ArrayList<>(wordCountMap.entrySet());
        list.sort((entry1, entry2) -> entry2.getValue().compareTo(entry1.getValue()));
        var linkedMap = new LinkedHashMap<String, Integer>();
        for(Map.Entry<String, Integer> entry : list) {
            linkedMap.put(entry.getKey(), entry.getValue());
        }
        return linkedMap;
    }
}
