package net.ponderingprogrammer.map2d;

import java.util.Objects;

public class CellGraphEdge<T> {
    private final Cell<T> c1;
    private final Cell<T> c2;
    private final boolean directional;
    private double weight = 1d;

    public CellGraphEdge(Cell<T> c1, Cell<T> c2) {
        if (c1 == c2)
            throw new IllegalArgumentException("Edges pointing to the same cell are illegal in this graph");
        this.c1 = c1;
        this.c2 = c2;
        directional = false;
    }

    public CellGraphEdge(Cell<T> c1, Cell<T> c2, boolean directional) {
        if (c1 == c2)
            throw new IllegalArgumentException("Edges pointing to the same cell are illegal in this graph");
        this.c1 = c1;
        this.c2 = c2;
        this.directional = directional;
    }

    public CellGraphEdge(Cell<T> c1, Cell<T> c2, boolean directional, double weight) {
        this.c1 = c1;
        this.c2 = c2;
        this.directional = directional;
        this.weight = weight;
    }

    public Cell<T> getC1() {
        return c1;
    }

    public Cell<T> getC2() {
        return c2;
    }

    public boolean isDirectional() {
        return directional;
    }

    public double getWeight() {
        return weight;
    }

    public void setWeight(double weight) {
        this.weight = weight;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        CellGraphEdge<?> that = (CellGraphEdge<?>) o;
        if (directional != that.directional) return false;
        boolean sameSame = c1.equals(that.c1) && c2.equals(that.c2);
        boolean sameReverse = c1.equals(that.c2) && c2.equals(that.c1);
        if (directional) {
            return sameSame;
        }
        return sameSame || sameReverse;
    }

    @Override
    public int hashCode() {
        return directional ? Objects.hash(c1, c2) : Objects.hashCode(c1) + Objects.hashCode(c2);
    }
}
