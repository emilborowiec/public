package net.ponderingprogrammer.map.bool;

import java.util.Collection;

public interface BoolMap {
    boolean getValue(int x, int y);
    Collection<Cell> getPositiveCells();
}
