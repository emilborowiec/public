package net.ponderingprogrammer.map2d.gen;

import net.ponderingprogrammer.map2d.Bounds;
import org.locationtech.jts.geom.Coordinate;
import org.locationtech.jts.geom.Envelope;

import java.util.List;

import static net.ponderingprogrammer.map2d.gen.RandomEx.randRange;

public class EnvelopeEx {

    public static Envelope fromBounds(Bounds bounds) {
        return new Envelope(bounds.getMinX(), bounds.getMaxX(), bounds.getMinY(), bounds.getMaxY());
    }

    public static Envelope randomEnvelope(int minSize, int maxSize) {
        if (minSize < 1) throw new IllegalArgumentException("size must be > 1");
        if (maxSize >= minSize) throw new IllegalArgumentException("maxSize must be >= minSize");
        return new Envelope(0, randRange(minSize, maxSize), 0, randRange(minSize, maxSize));
    }

    public static Envelope randomEnvelopeWithinEnvelope(Envelope envelope, int minSize, int maxSize) {
        if (minSize < 1) throw new IllegalArgumentException("size must be > 1");
        if (maxSize >= minSize) throw new IllegalArgumentException("maxSize must be >= minSize");
        if (maxSize > envelope.getWidth()) throw new IllegalArgumentException("maxSize greater than envelope width");
        if (maxSize > envelope.getHeight()) throw new IllegalArgumentException("maxSize greater than envelope height");

        int width = randRange(minSize, maxSize);
        int height = randRange(minSize, maxSize);

        int minX = randRange((int)envelope.getMinX(), (int)envelope.getMaxX() - width);
        int minY = randRange((int)envelope.getMinY(), (int)envelope.getMaxY() - height);

        return new Envelope(minX, minX + width, minY, minY + height);
    }

    public static Envelope createSubEnvelope(Envelope superEnvelope, Alignment alignment, float widthFraction, float heightFraction) {
        int width = (int)(superEnvelope.getWidth() * widthFraction);
        int height = (int)(superEnvelope.getHeight() * heightFraction);
        if (width < 1 || height < 1) throw new IllegalArgumentException("resulting width or height is < 1");
        int minX = 0;
        int minY = 0;
        switch (alignment) {
            case CENTER -> {
                minX = (int) (superEnvelope.centre().x - (width / 2));
                minY = (int) (superEnvelope.centre().y - (height / 2));
            }
            case TOP -> {
                minX = (int) (superEnvelope.centre().x - (width / 2));
                minY = (int) superEnvelope.getMinY();
            }
            case TOP_RIGHT -> {
                minX = (int) (superEnvelope.getMaxX() - width);
                minY = (int) superEnvelope.getMinY();
            }
            case RIGHT -> {
                minX = (int) (superEnvelope.getMaxX() - width);
                minY = (int) (superEnvelope.centre().y - (height / 2));
            }
            case BOTTOM_RIGHT -> {
                minX = (int) (superEnvelope.getMaxX() - width);
                minY = (int) (superEnvelope.getMaxY() - height);
            }
            case BOTTOM -> {
                minX = (int) (superEnvelope.centre().x - (width / 2));
                minY = (int) (superEnvelope.getMaxY() - height);
            }
            case BOTTOM_LEFT -> {
                minX = (int) (superEnvelope.getMinX());
                minY = (int) (superEnvelope.getMaxY() - height);
            }
            case LEFT -> {
                minX = (int) (superEnvelope.getMinX());
                minY = (int) (superEnvelope.centre().y - (height / 2));
            }
            case TOP_LEFT -> {
                minX = (int) (superEnvelope.getMinX());
                minY = (int) superEnvelope.getMinY();
            }
        }
        return new Envelope(minX, minX + width, minY, minY + height);
    }

    public static List<Coordinate> getCorners(Envelope envelope) {
        return List.of(
                new Coordinate(envelope.getMinX(), envelope.getMinY()),
                new Coordinate(envelope.getMaxX(), envelope.getMinY()),
                new Coordinate(envelope.getMaxX(), envelope.getMaxY()),
                new Coordinate(envelope.getMinX(), envelope.getMaxY()));
    }

    public static Bounds toBounds(Envelope envelope) {
        return new Bounds((int)envelope.getMinX(), (int)envelope.getMinY(), (int)envelope.getWidth(), (int)envelope.getHeight());
    }
}
