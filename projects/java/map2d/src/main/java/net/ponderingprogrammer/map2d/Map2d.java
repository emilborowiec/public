package net.ponderingprogrammer.map2d;

import java.util.Collection;
import java.util.Optional;
import java.util.function.Predicate;

public interface Map2d<T> {
    boolean hasCell(int x, int y);
    boolean hasCell(Coord coord);

    Optional<Cell<T>> getCell(int x, int y);
    Optional<Cell<T>> getCell(Coord coord);

    Optional<T> getValue(int x, int y);
    Optional<T> getValue(Coord coord);

    Collection<Cell<T>> getCells();
    Collection<Cell<T>> getCellsRowMajor();

    Optional<Bounds> getBounds();

    Collection<Cell<T>> findCells(Predicate<T> predicate);

    Collection<Cell<T>> findAdjacentCells(int x, int y);
    Collection<Cell<T>> findAdjacentCells(Coord coord);

    CellGraph<T> toCellGraph();
}
