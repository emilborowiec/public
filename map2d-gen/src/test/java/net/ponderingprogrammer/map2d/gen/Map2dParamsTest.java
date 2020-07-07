package net.ponderingprogrammer.map2d.gen;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class Map2dParamsTest {

    @Test
    void isValid() {
        var params = new Map2dParams(3, 3, 5);
        assertTrue(params.isValid());
        params = new Map2dParams(1, 3, 5);
        assertFalse(params.isValid());
        params = new Map2dParams(3, 1, 5);
        assertFalse(params.isValid());
        params = new Map2dParams(3, 3, 10);
        assertFalse(params.isValid());
    }

    @Test
    void getViolations() {
        var params = new Map2dParams(3, 3, 5);
        assertTrue(params.getViolations().isEmpty());
        params = new Map2dParams(1, 0, 10);
        assertEquals(3, params.getViolations().size());
    }
}