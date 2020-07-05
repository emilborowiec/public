package net.ponderingprogrammer.procgenlab.services;

import org.locationtech.jts.geom.Envelope;
import org.locationtech.jts.geom.Point;

import java.util.Collection;

public interface PointsGenerator {
    Collection<Point> generatePointsInCircle(int count, Point center, double radius);
    Collection<Point> generatePointsInEnvelope(int count, Envelope envelope);
}
