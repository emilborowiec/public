package net.ponderingprogrammer.map2d;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.*;

class FixedSquareMap2dTest {
    private ConcreteFixedSquareMap2d map;

    @BeforeEach
    void setUp() {
        map = new ConcreteFixedSquareMap2d(6, 4);
    }

    @ParameterizedTest
    @CsvSource({ "0, 0", "2, 2", "5, 0", "0, 3" })
    void hasCellPositive(int x, int y) {
        assertTrue(map.hasCell(x, y));
        assertFalse(map.hasCell(-1, 0));
        assertFalse(map.hasCell(-1, 0));
        assertFalse(map.hasCell(6, 0));
        assertFalse(map.hasCell(0, 4));
        assertFalse(map.hasCell(10, 10));
    }

    @ParameterizedTest
    @CsvSource({ "-1, 0", "0, -1", "6, 0", "0, 4", "10, 10" })
    void hasCellNegative(int x, int y) {
        assertFalse(map.hasCell(x, y));
    }

    @Test
    void getCell() {
        var coord = new Coord(1, 1);
        var optional = map.getCell(coord);
        assertTrue(optional.isPresent());
        optional.ifPresent(cell -> assertEquals(coord, cell.getCoord()));
        assertFalse(map.getCell(10, 10).isPresent());
    }

    @Test
    void getCells() {
        var cells = map.getCells();
        assertEquals(6 * 4, cells.size());
    }

    @Test
    void getCellsRowMajor() {
        var cells = map.getCellsRowMajor();
        var it = cells.iterator();
        var c1 = it.next();
        var c2 = it.next();
        assertEquals(new Coord(0, 0), c1.getCoord());
        assertEquals(new Coord(1, 0), c2.getCoord());
    }

    @Test
    void getBounds() {
        assertTrue(map.getBounds().isPresent());
        var bounds = map.getBounds().get();
        assertEquals(6, bounds.getWidth());
        assertEquals(4, bounds.getHeight());
        assertEquals(0, bounds.getMinX());
        assertEquals(0, bounds.getMinY());
        assertEquals(5, bounds.getMaxX());
        assertEquals(3, bounds.getMaxY());
    }

    @ParameterizedTest
    @CsvSource({
            "0, 0, 0",
            "1, 0, 1",
            "0, 1, 6"
    })
    void coordToIndex(int x, int y, int index) {
        assertEquals(index, map.coordToIndex(x, y));
    }
}