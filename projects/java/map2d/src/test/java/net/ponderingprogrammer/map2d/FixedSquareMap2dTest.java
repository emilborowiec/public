package net.ponderingprogrammer.map2d;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

class FixedSquareMap2dTest {
    private ConcreteFixedSquareMap2d map;

    @BeforeEach
    void setUp() {
        map = new ConcreteFixedSquareMap2d(6, 4);
    }

    @ParameterizedTest
    @CsvSource({ "0, 0", "2, 2", "5, 0", "0, 3" })
    void hasCellPositive(int x, int y) {
        Assertions.assertTrue(map.hasCell(x, y));
        Assertions.assertFalse(map.hasCell(-1, 0));
        Assertions.assertFalse(map.hasCell(-1, 0));
        Assertions.assertFalse(map.hasCell(6, 0));
        Assertions.assertFalse(map.hasCell(0, 4));
        Assertions.assertFalse(map.hasCell(10, 10));
    }

    @ParameterizedTest
    @CsvSource({ "-1, 0", "0, -1", "6, 0", "0, 4", "10, 10" })
    void hasCellNegative(int x, int y) {
        Assertions.assertFalse(map.hasCell(x, y));
    }

    @Test
    void getCell() {
        var coord = new Coord(1, 1);
        var optional = map.getCell(coord);
        Assertions.assertTrue(optional.isPresent());
        optional.ifPresent(cell -> Assertions.assertEquals(coord, cell.getCoord()));
        Assertions.assertFalse(map.getCell(10, 10).isPresent());
    }

    @Test
    void getCells() {
        var cells = map.getCells();
        Assertions.assertEquals(6 * 4, cells.size());
    }

    @Test
    void getCellsRowMajor() {
        var cells = map.getCellsRowMajor();
        var it = cells.iterator();
        var c1 = it.next();
        var c2 = it.next();
        Assertions.assertEquals(new Coord(0, 0), c1.getCoord());
        Assertions.assertEquals(new Coord(1, 0), c2.getCoord());
    }

    @Test
    void getBounds() {
        Assertions.assertTrue(map.getBounds().isPresent());
        var bounds = map.getBounds().get();
        Assertions.assertEquals(6, bounds.getWidth());
        Assertions.assertEquals(4, bounds.getHeight());
        Assertions.assertEquals(0, bounds.getMinX());
        Assertions.assertEquals(0, bounds.getMinY());
        Assertions.assertEquals(5, bounds.getMaxX());
        Assertions.assertEquals(3, bounds.getMaxY());
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