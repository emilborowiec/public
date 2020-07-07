package net.ponderingprogrammer.map2d.gen;

import java.util.ArrayList;
import java.util.Collection;

public class Map2dParams implements GenerationParams {
    private int width;
    private int height;
    private int desiredCellCount;

    public Map2dParams() {
    }

    public Map2dParams(int width, int height, int desiredCellCount) {
        this.width = width;
        this.height = height;
        this.desiredCellCount = desiredCellCount;
    }

    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    public int getDesiredCellCount() {
        return desiredCellCount;
    }

    public void setDesiredCellCount(int desiredCellCount) {
        this.desiredCellCount = desiredCellCount;
    }

    public int getArea() {
        return width * height;
    }

    @Override
    public boolean isValid() {
        return width > 1 && height > 1 && desiredCellCount < getArea();
    }

    @Override
    public Collection<String> getViolations() {
        var list = new ArrayList<String>();
        if (width < 2) list.add("width must be greater than 1");
        if (height < 2) list.add("height must be greater than 1");
        if (desiredCellCount >= getArea()) list.add("desiredCellCount cannot be greater than total area");
        return list;
    }
}
