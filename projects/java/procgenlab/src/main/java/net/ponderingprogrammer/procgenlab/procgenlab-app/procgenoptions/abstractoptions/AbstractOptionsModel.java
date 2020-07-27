package net.ponderingprogrammer.procgenlab.procgenoptions.abstractoptions;

import net.ponderingprogrammer.procgenlab.AbstractContentType;
import net.ponderingprogrammer.procgenlab.procgenoptions.ProcGenOptionsModel;
import net.ponderingprogrammer.procgenlab.services.BoundsShape;

class AbstractOptionsModel {
    private AbstractContentType type;
    private BoundsShape boundsShape;
    private int size = ProcGenOptionsModel.DEFAULT_SIZE;
    private int pointCount = ProcGenOptionsModel.DEFAULT_POINT_COUNT;

    public int getSize() {
        return size;
    }

    public void setSize(int size) {
        this.size = size;
    }

    public int getPointCount() {
        return pointCount;
    }

    public void setPointCount(int pointCount) {
        this.pointCount = pointCount;
    }
}
