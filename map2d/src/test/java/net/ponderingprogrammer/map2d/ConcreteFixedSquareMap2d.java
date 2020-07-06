package net.ponderingprogrammer.map2d;

import java.util.Collection;

/**
 * For testing FixedSquareMap2d
 */
public class ConcreteFixedSquareMap2d extends FixedSquareMap2d<Integer> {
    public ConcreteFixedSquareMap2d(int width, int height) {
        super(width, height);
    }

    @Override
    public Collection<Cell<Integer>> findAdjacentCells(int x, int y) {
        return null;
    }

    @Override
    public CellGraph<Integer> toCellGraph() {
        return null;
    }

}
