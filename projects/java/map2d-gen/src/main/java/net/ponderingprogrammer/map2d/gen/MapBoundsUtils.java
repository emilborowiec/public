package net.ponderingprogrammer.map2d.gen;

import net.ponderingprogrammer.map2d.Bounds;
import net.ponderingprogrammer.map2d.Map2d;

public class MapBoundsUtils {

    public static MapBoundsCategory aspectToBoundsCategory(int width, int height) {
        if (width == height) return MapBoundsCategory.SQUARE;
        var aspect = (float)width / height;
        if (aspect < 0.5) return MapBoundsCategory.LONG_VERTICAL;
        if (aspect < 1.0) return MapBoundsCategory.PORTAIT;
        if (aspect < 2.0) return MapBoundsCategory.LANDSCAPE;
        return MapBoundsCategory.LONG_HORIZONTAL;
    }

    public static <T> void setInBounds(Map2d<T> map, T value, Bounds bounds) {
        for (int x = bounds.getMinX(); x <= bounds.getMaxX(); x++) {
            for (int y = bounds.getMinY(); y <= bounds.getMaxY(); y++) {
                map.getCell(x, y).ifPresent(c -> c.setValue(value));
            }
        }
    }
}
