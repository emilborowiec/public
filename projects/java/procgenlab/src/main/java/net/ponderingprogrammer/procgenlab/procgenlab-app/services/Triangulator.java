package net.ponderingprogrammer.procgenlab.services;

import org.locationtech.jts.geom.GeometryCollection;
import org.locationtech.jts.geom.Point;

import java.util.Collection;

public interface Triangulator {
    GeometryCollection triangulate(Collection<Point> points);
}
