package net.ponderingprogrammer.map2d;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Optional;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public abstract class FixedSquareMap2d<T> extends AbstractMap2d<T> {
    private final int width;
    private final int height;
    private final ArrayList<Cell<T>> cells; // flat list of cells, row-major
    private final Bounds bounds;

    public FixedSquareMap2d(int width, int height) {
        if (width < 1 || height < 1)
            throw new IllegalArgumentException(String.format("Zero or negative size is illegal (width: %d, height: %d)", width, height));

        this.width = width;
        this.height = height;

        cells = new ArrayList<>(width * height);
        for (int y = 0; y < height; y++) {  // rows
            for (int x = 0; x < width; x++) {   // cols
                cells.add(new Cell<>(new Coord(x, y), null));
            }
        }

        bounds = new Bounds(0, 0, width, height);
    }

    @Override
    public boolean hasCell(int x, int y) {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    @Override
    public Optional<Cell<T>> getCell(int x, int y) {
        return hasCell(x, y) ? Optional.of(cells.get(coordToIndex(x, y))) : Optional.empty();
    }

    @Override
    public Optional<T> getValue(int x, int y) {
        return getCell(x, y).map(Cell::getValue);
    }

    @Override
    public Collection<Cell<T>> getCells() {
        return Collections.unmodifiableList(cells);
    }

    @Override
    public Collection<Cell<T>> getCellsRowMajor() {
        return Collections.unmodifiableList(cells);
    }

    @Override
    public Optional<Bounds> getBounds() {
        return Optional.of(bounds);
    }

    @Override
    public Collection<Cell<T>> findCells(Predicate<T> predicate) {
        return cells.stream().filter(cell -> predicate.test(cell.getValue())).collect(Collectors.toCollection(ArrayList::new));
    }

    protected int coordToIndex(int x, int y) {
        return (y * width) + x;
    }
}
