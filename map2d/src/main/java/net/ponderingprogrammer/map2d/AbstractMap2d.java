package net.ponderingprogrammer.map2d;

import java.util.Collection;
import java.util.Optional;

public abstract class AbstractMap2d<T> implements Map2d<T> {
    @Override
    public boolean hasCell(Coord coord) {
        return hasCell(coord.getX(), coord.getY());
    }

    @Override
    public Optional<Cell<T>> getCell(Coord coord) {
        return getCell(coord.getX(), coord.getY());
    }

    @Override
    public Optional<T> getValue(Coord coord) {
        return getValue(coord.getX(), coord.getY());
    }

    @Override
    public Collection<Cell<T>> findAdjacentCells(Coord coord) {
        return findAdjacentCells(coord.getX(), coord.getY());
    }
}
