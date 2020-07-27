package net.ponderingprogrammer.procgenlab.services;

import org.locationtech.jts.geom.*;
import org.locationtech.jts.triangulate.DelaunayTriangulationBuilder;

import java.util.Collection;
import java.util.stream.Collectors;

public class DelaunayTriangulator implements Triangulator {

    @Override
    public GeometryCollection triangulate(Collection<Point> points) {
        var triangulationBuilder = new DelaunayTriangulationBuilder();
        triangulationBuilder.setSites(points.stream().map(Point::getCoordinate).collect(Collectors.toList()));
        return (GeometryCollection)triangulationBuilder.getTriangles(new GeometryFactory());
    }
}
