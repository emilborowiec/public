package net.ponderingprogrammer.map2d;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotEquals;

public class CoordTest {
    @Test
    @DisplayName("Coord equality test")
    public void testEquality() {
        var c1 = new Coord(2, 2);
        var c2 = new Coord(2, 2);
        var c3 = new Coord();
        var c4 = new Coord();
        assertEquals(c1, c2);
        assertEquals(c3, c4);
        assertNotEquals(c1, c3);
    }
}
