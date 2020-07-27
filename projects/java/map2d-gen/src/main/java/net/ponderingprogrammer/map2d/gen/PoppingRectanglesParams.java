package net.ponderingprogrammer.map2d.gen;

import java.util.Collection;

public class PoppingRectanglesParams extends Map2dParams {
    private int rectCount;
    private int minRectSize;
    private int maxRectSize;

    public int getRectCount() {
        return rectCount;
    }

    public void setRectCount(int rectCount) {
        this.rectCount = rectCount;
    }

    public int getMinRectSize() {
        return minRectSize;
    }

    public void setMinRectSize(int minRectSize) {
        this.minRectSize = minRectSize;
    }

    public int getMaxRectSize() {
        return maxRectSize;
    }

    public void setMaxRectSize(int maxRectSize) {
        this.maxRectSize = maxRectSize;
    }

    @Override
    public boolean isValid() {
        return super.isValid()
                && (rectCount * minRectSize) < getArea()
                && maxRectSize <= getWidth()
                && maxRectSize <= getHeight()
                && minRectSize <= maxRectSize;
    }

    @Override
    public Collection<String> getViolations() {
        var list = super.getViolations();
        if (rectCount * minRectSize >= getArea()) list.add("Rectangles won't fit into the area");
        if (maxRectSize > getWidth()) list.add("maxRectSize cannot be greater than area width");
        if (maxRectSize > getHeight()) list.add("maxRectSize cannot be greater than area height");
        if (maxRectSize < minRectSize) list.add("maxRectSize cannot be lower than minRectSize");
        return list;
    }
}
