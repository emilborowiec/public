package net.ponderingprogrammer.map2d;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

class ChebyshevFixedSquareMap2dTest {

    @Test
    void findAdjacentCells() {
        var map = new ChebyshevFixedSquareMap2d<Integer>(9, 9);

        Assertions.assertEquals(8, map.findAdjacentCells(1, 1).size());
        Assertions.assertEquals(3, map.findAdjacentCells(0, 0).size());
        Assertions.assertEquals(5, map.findAdjacentCells(1, 0).size());
    }

    @Test
    void toGraph() {
        var map = new ChebyshevFixedSquareMap2d<Integer>(2, 2);
        var graph = map.toCellGraph();

        Assertions.assertEquals(4, graph.getNodes().size());
        Assertions.assertEquals(6, graph.getEdges().size());
    }

}