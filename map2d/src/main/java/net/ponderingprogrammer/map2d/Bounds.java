package net.ponderingprogrammer.map2d;

public class Bounds {
    private int minX;
    private int minY;
    private int width;
    private int height;

    public Bounds(int minX, int minY, int width, int height) {
        if (width < 1 || height < 1)
            throw new IllegalArgumentException(String.format("Zero or negative size is illegal (width: %d, height: %d)", width, height));
        this.minX = minX;
        this.minY = minY;
        this.width = width;
        this.height = height;
    }

    public int getMinX() {
        return minX;
    }

    public void setMinX(int minX) {
        this.minX = minX;
    }

    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public int getMinY() {
        return minY;
    }

    public void setMinY(int minY) {
        this.minY = minY;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    public int getMaxX() {
        return minX + width - 1;
    }

    public int getMaxY() {
        return minY + height - 1;
    }
}
