package net.ponderingprogrammer.map2d;

import java.util.HashSet;

public class CellGraph<T> {
    private HashSet<Cell<T>> nodes = new HashSet<>();
    private HashSet<CellGraphEdge<T>> edges = new HashSet<>();

    public HashSet<Cell<T>> getNodes() {
        return nodes;
    }

    public HashSet<CellGraphEdge<T>> getEdges() {
        return edges;
    }
}
