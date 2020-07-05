package net.ponderingprogrammer.procgenlab.services;

import java.util.*;

public class GeneratorUtils {

    public static int randRange(Random random, int min, int max) {

        if (min >= max) {
            throw new IllegalArgumentException("max must be greater than min");
        }

        return min + random.nextInt((max - min) + 1);
    }

    public static float randRange(Random random, float min, float max) {

        if (min >= max) {
            throw new IllegalArgumentException("max must be greater than min");
        }

        return min + random.nextFloat() * (max - min);
    }

    public static double randRange(Random random, double min, double max) {

        if (min >= max) {
            throw new IllegalArgumentException("max must be greater than min");
        }

        return min + random.nextFloat() * (max - min);
    }
}
