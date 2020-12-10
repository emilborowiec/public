package com.ponderingprogrammer;

import static java.lang.System.out;

import java.util.*;

public class Main {

    private static final int COLLECTION_SIZE = 100000;

    public static void main(String[] args) {
        var arrayList = new ArrayList<Integer>();
        var linkedList = new LinkedList<Integer>();
        var arrayDeque = new ArrayDeque<Integer>();
        var priorityQueue = new PriorityQueue<Integer>();
        var hashSet = new HashSet<Integer>();
        var treeSet = new TreeSet<Integer>();
        var linkedHashSet = new LinkedHashSet<Integer>();

        var initializationTimeMap = new HashMap<Object, Long>();
        initializationTimeMap.put(arrayList, initializeWithRandomNumbers(arrayList));
        initializationTimeMap.put(linkedList, initializeWithRandomNumbers(linkedList));
        initializationTimeMap.put(arrayDeque, initializeWithRandomNumbers(arrayDeque));
        initializationTimeMap.put(priorityQueue, initializeWithRandomNumbers(priorityQueue));
        initializationTimeMap.put(hashSet, initializeWithRandomNumbers(hashSet));
        initializationTimeMap.put(treeSet, initializeWithRandomNumbers(treeSet));
        initializationTimeMap.put(linkedHashSet, initializeWithRandomNumbers(linkedHashSet));

        var list = new ArrayList<>(initializationTimeMap.entrySet());
        list.sort(Map.Entry.comparingByValue());
        var linkedMap = new LinkedHashMap<Object, Long>();
        list.forEach(entry -> linkedMap.put(entry.getKey(), entry.getValue()));

        out.println("Initialization time for " + COLLECTION_SIZE + " elemenets:");
        linkedMap.forEach((key, value) -> out.printf("%-30s - %d ns%n", key.getClass().getName(), value));
    }

    public static <T extends Collection<Integer>> long initializeWithRandomNumbers(T collection) {
        var start = System.nanoTime();
        var rand = new Random();
        rand.ints(COLLECTION_SIZE).forEach(collection::add);
        return System.nanoTime() - start;
    }
}
