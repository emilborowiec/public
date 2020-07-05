package net.ponderingprogrammer.procgenlab.services;

import org.locationtech.jts.algorithm.Angle;
import org.locationtech.jts.geom.*;
import org.locationtech.jts.math.Vector2D;

import java.util.Collection;
import java.util.HashSet;
import java.util.Random;

/**
 * Generates random points in given area.
 * Guarantees each point to have distinct coordinates of double precision,
 * as a tradeoff it does not guarantee to generate given amount of points.
 */
public class RandomPointsGenerator implements PointsGenerator {
    private final Random random;
    private final GeometryFactory factory;

    public RandomPointsGenerator() {
        random = new Random();
        factory = new GeometryFactory();
    }

    @Override
    public Collection<Point> generatePointsInCircle(int count, Point center, double radius) {
        var set = new HashSet<Point>();
        for (int i = 0; i < count; i++) {
            var r = GeneratorUtils.randRange(random, 0d, radius);
            var theta = GeneratorUtils.randRange(random, 0d, Angle.PI_TIMES_2);
            var v = new Vector2D(0d, r);
            v.rotate(theta);
            set.add(factory.createPoint(new Coordinate(v.getX(), v.getY())));
        }
        return set;
    }

    @Override
    public Collection<Point> generatePointsInEnvelope(int count, Envelope envelope) {
        var set = new HashSet<Point>();
        for (int i = 0; i < count; i++) {
            var x = GeneratorUtils.randRange(random, envelope.getMinX(), envelope.getMaxX());
            var y = GeneratorUtils.randRange(random, envelope.getMinY(), envelope.getMaxY());
            set.add(factory.createPoint(new Coordinate(x, y)));
        }
        return set;
    }
}
