package com.ponderingprogrammer;

import java.util.InputMismatchException;
import java.util.Scanner;

import static java.lang.System.out;

public class Main {

    public static void main(String[] args) {
        out.println("When were you born?");
        var in = new Scanner(System.in);
        var year = inputInt(in, "Year: ", 1800, 3000);
        var month = inputInt(in, "Month: ", 1, 12);
        var day = inputInt(in, "Day: " ,1, 31);

    }

    public static int inputInt(Scanner in, String message, int min, int max) {
        try {
            out.print(message);
            var value = in.nextInt();
            if (min > value || max < value) {
                out.println("Expecting number from " + min + " to " + max);
                return inputInt(in, message, min, max);
            }
            return value;
        } catch (InputMismatchException e) {
            out.println("That's not a number");
            in.next(); // discard input
            return inputInt(in, message, min, max);
        }
    }
}
