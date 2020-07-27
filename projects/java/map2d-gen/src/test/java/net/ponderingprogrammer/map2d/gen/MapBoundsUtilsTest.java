package net.ponderingprogrammer.map2d.gen;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class MapBoundsUtilsTest {
    @Test
    void aspectToBoundsShapeType() {
        assertEquals(MapBoundsCategory.SQUARE, MapBoundsUtils.aspectToBoundsCategory(100, 100));
        assertEquals(MapBoundsCategory.LANDSCAPE, MapBoundsUtils.aspectToBoundsCategory(140, 100));
        assertEquals(MapBoundsCategory.PORTAIT, MapBoundsUtils.aspectToBoundsCategory(100, 160));
        assertEquals(MapBoundsCategory.LONG_HORIZONTAL, MapBoundsUtils.aspectToBoundsCategory(300, 100));
        assertEquals(MapBoundsCategory.LONG_VERTICAL, MapBoundsUtils.aspectToBoundsCategory(100, 220));
    }

}