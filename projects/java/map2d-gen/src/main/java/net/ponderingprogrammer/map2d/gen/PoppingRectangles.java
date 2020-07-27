package net.ponderingprogrammer.map2d.gen;

import net.ponderingprogrammer.map2d.ManhattanFixedSquareMap2d;
import org.locationtech.jts.geom.Coordinate;
import org.locationtech.jts.geom.Envelope;

import java.util.ArrayList;

public class PoppingRectangles {
    public ManhattanFixedSquareMap2d<Boolean> generate(PoppingRectanglesParams params) {
        if (!params.isValid()) {
            throw new IllegalArgumentException(String.join(";", params.getViolations()));
        }
        var map = generateFixedMap(params.getWidth(), params.getHeight());
        var bounds = map.getBounds().orElseThrow();
        var category = MapBoundsUtils.aspectToBoundsCategory(params.getWidth(), params.getHeight());

        var superEnvelope = EnvelopeEx.fromBounds(bounds);
        var firstRectSite = chooseFirstRectSite(superEnvelope, category);

        var firstRect = EnvelopeEx.randomEnvelopeWithinEnvelope(firstRectSite, params.getMinRectSize(), params.getMaxRectSize());
        MapBoundsUtils.setInBounds(map, true, EnvelopeEx.toBounds(firstRect));
        var corners = new ArrayList<Coordinate>(EnvelopeEx.getCorners(firstRect));
        var rectCount = 1;
        while (rectCount < params.getRectCount()) {
            var coord = corners.remove(RandomEx.randRange(0, corners.size() - 1));
            var newRect = EnvelopeEx.randomEnvelope(params.getMinRectSize(), params.getMaxRectSize());
            newRect.translate(coord.x - newRect.getWidth()/2, coord.y - newRect.getHeight()/2);
            if (superEnvelope.contains(newRect)) {
                corners.addAll(EnvelopeEx.getCorners(newRect));
                MapBoundsUtils.setInBounds(map, true, EnvelopeEx.toBounds(newRect));
                rectCount++;
            }
        }

        return map;
    }

    private Envelope chooseFirstRectSite(Envelope superEnvelope, MapBoundsCategory category) {
        return switch (category) {
            case SQUARE -> EnvelopeEx.createSubEnvelope(superEnvelope, Alignment.CENTER, 0.5f, 0.5f);
            case LANDSCAPE -> EnvelopeEx.createSubEnvelope(superEnvelope, Alignment.BOTTOM_LEFT, 0.3f, 0.5f);
            case PORTAIT -> EnvelopeEx.createSubEnvelope(superEnvelope, Alignment.BOTTOM_LEFT, 0.5f, 0.3f);
            case LONG_HORIZONTAL -> EnvelopeEx.createSubEnvelope(superEnvelope, Alignment.LEFT, 0.2f, 1f);
            case LONG_VERTICAL -> EnvelopeEx.createSubEnvelope(superEnvelope, Alignment.BOTTOM, 1f, 0.2f);
        };
    }

    private ManhattanFixedSquareMap2d<Boolean> generateFixedMap(int width, int height) {
        return new ManhattanFixedSquareMap2d<Boolean>(width, height);
    }
}
