package net.ponderingprogrammer.map2d;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

class ManhattanFixedSquareMap2dTest {

    @Test
    void findAdjacentCells() {
        var map = new ManhattanFixedSquareMap2d<Integer>(9, 9);

        Assertions.assertEquals(4, map.findAdjacentCells(1, 1).size());
        Assertions.assertEquals(2, map.findAdjacentCells(0, 0).size());
        Assertions.assertEquals(3, map.findAdjacentCells(1, 0).size());
    }

    @Test
    void toGraph() {
        var map = new ManhattanFixedSquareMap2d<Integer>(2, 2);
        var graph = map.toCellGraph();

        Assertions.assertEquals(4, graph.getNodes().size());
        Assertions.assertEquals(4, graph.getEdges().size());
    }
}