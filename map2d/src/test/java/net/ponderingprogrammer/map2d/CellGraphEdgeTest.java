package net.ponderingprogrammer.map2d;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

class CellGraphEdgeTest {

    @Test
    void testEquals() {
        var c1 = new Cell<>(new Coord(1, 1), 1);
        var c2 = new Cell<>(new Coord(2, 2), 2);

        var c3 = new Cell<>(new Coord(3, 3), 3);
        var c4 = new Cell<>(new Coord(4, 4), 4);

        var c1c2 = new CellGraphEdge<>(c1, c2);
        var c1c2Clone = new CellGraphEdge<>(c1, c2);
        var c1c2Dir = new CellGraphEdge<>(c1, c2, true);
        var c1c2DirClone = new CellGraphEdge<>(c1, c2, true);

        var c2c1 = new CellGraphEdge<>(c2, c1);
        var c2c1Dir = new CellGraphEdge<>(c2, c1, true);

        var c3c4 = new CellGraphEdge<>(c1, c2);
        var c3c4Dir = new CellGraphEdge<>(c1, c2, true);

        Assertions.assertEquals(c1c2, c1c2Clone);
        Assertions.assertEquals(c1c2, c2c1);
        Assertions.assertEquals(c1c2Dir, c1c2DirClone);
        Assertions.assertNotEquals(c1c2, c1c2Dir);
        Assertions.assertNotEquals(c1c2Dir, c2c1Dir);
    }
}