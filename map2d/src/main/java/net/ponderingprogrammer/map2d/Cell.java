package net.ponderingprogrammer.map2d;

public class Cell<T> {
    private Coord coord;
    private T value;

    public Cell(Coord coord, T value) {
        this.coord = coord;
        this.value = value;
    }

    public Coord getCoord() {
        return coord;
    }

    public T getValue() {
        return value;
    }

    public void setValue(T value) {
        this.value = value;
    }
}
