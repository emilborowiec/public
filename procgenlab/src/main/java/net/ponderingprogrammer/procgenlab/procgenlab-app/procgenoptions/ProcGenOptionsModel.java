package net.ponderingprogrammer.procgenlab.procgenoptions;

import net.ponderingprogrammer.procgenlab.ContentCategory;

public class ProcGenOptionsModel {
    public static final int DEFAULT_SIZE = 500;
    public static final int MIN_SIZE = 500;
    public static final int MAX_SIZE = 4000;
    public static final int DEFAULT_POINT_COUNT = 10;

    private ContentCategory category = ContentCategory.Abstract;

    public ContentCategory getCategory() {
        return category;
    }

    public void setCategory(ContentCategory category) {
        this.category = category;
    }
}
