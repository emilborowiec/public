package net.ponderingprogrammer.map2d.gen;

import java.util.Random;

public class RandomEx {
    private static final Random random = new Random();

    public static int randRange(int minInclusive, int maxInclusive) {
        if (minInclusive > maxInclusive) {
            throw new IllegalArgumentException("max must be greater or equal than min");
        }
        return minInclusive + random.nextInt(maxInclusive - minInclusive + 1);
    }

    public static float randRange(float minInclusive, float maxExclusive) {
        if (minInclusive >= maxExclusive) {
            throw new IllegalArgumentException("max must be greater than min");
        }
        return minInclusive + random.nextFloat() * (maxExclusive - minInclusive);
    }

    public static double randRange(double minInclusive, double maxExclusive) {
        if (minInclusive >= maxExclusive) {
            throw new IllegalArgumentException("max must be greater than min");
        }
        return minInclusive + random.nextFloat() * (maxExclusive - minInclusive);
    }
}
