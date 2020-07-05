package com.ponderingprogrammer;

public class Main {

    public static void main(String[] args) {
        if (args.length != 1) {
            printUsage();
            return;
        }

        var arg = args[0];
        if ("--help".equals(arg) || "-h".equals(arg)) {
            printUsage();
            return;
        }

        var value = 0;
        try {
            value = Integer.parseInt(arg);
        } catch (NumberFormatException e) {
            System.out.println("Argument must be an integer number");
            return;
        }

        showBinaryBreakdown(value);
        showHexBreakdown(value);
    }

    private static void showBinaryBreakdown(int value) {
        var binaryString = Integer.toBinaryString(value);
        var bitValues = new int[binaryString.length()];
        for (int i = binaryString.length() - 1; i >= 0; i--) {
            bitValues[i] = Integer.parseInt(binaryString.substring(i, i+1)) * (int)Math.pow(2, binaryString.length() - 1 - i);
        }
        var bitLineBuilder =    new StringBuilder("Bits:   ");
        var valuesLineBuilder = new StringBuilder("Values: ");
        for (int i = 0; i < binaryString.length(); i++) {
            bitLineBuilder
                    .append(binaryString.charAt(i))
                    .append(" ".repeat(String.valueOf(bitValues[i]).length()));
            valuesLineBuilder.append(bitValues[i]);
            if ( i < binaryString.length() - 1) {
                valuesLineBuilder.append("+");
            }
        }
        valuesLineBuilder.append(" = ").append(value);
        System.out.println("Binary: " + binaryString);
        System.out.println(bitLineBuilder.toString());
        String valuesLine = valuesLineBuilder.toString();
        System.out.println(valuesLine);
        System.out.println("-".repeat(valuesLine.length()));
    }

    private static void showHexBreakdown(int value) {
        var hexString = Integer.toHexString(value);
        var hexValues = new int[hexString.length()];
        for (int i = hexString.length() - 1; i >= 0; i--) {
            hexValues[i] = Integer.parseInt(hexString.substring(i, i+1), 16) * (int)Math.pow(16, hexString.length() - 1 - i);
        }
        var hexLineBuilder =   new StringBuilder("Hex:    ");
        var valuesLineBuilder = new StringBuilder("Values: ");
        for (int i = 0; i < hexString.length(); i++) {
            hexLineBuilder
                    .append(hexString.charAt(i))
                    .append(" ".repeat(String.valueOf(hexValues[i]).length()));
            valuesLineBuilder.append(hexValues[i]);
            if ( i < hexString.length() - 1) {
                valuesLineBuilder.append("+");
            }
        }
        valuesLineBuilder.append(" = ").append(value);
        System.out.println("Hex: " + hexString);
        System.out.println(hexLineBuilder.toString());
        String valuesLine = valuesLineBuilder.toString();
        System.out.println(valuesLine);
        System.out.println("-".repeat(valuesLine.length()));
    }

    private static void printUsage() {
        System.out.println("Usage: showbits <integer>");
    }
}
