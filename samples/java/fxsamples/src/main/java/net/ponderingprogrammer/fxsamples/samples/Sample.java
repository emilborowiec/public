package net.ponderingprogrammer.fxsamples.samples;

public enum Sample {
    FLOW("Flow pane"),
    HBOX("Horizontal box"),
    VBOX("Vertical box"),
    ANCHOR("Anchor pane"),
    BORDER("Border pane"),
    STACK("Stack pane"),
    TILE("Tile pane"),
    GRID("Grid pane"),
    MIG("Mig pane"),
    ABSOLUTE("Absolute layout"),
    TABLE("Table");

    private String name;

    Sample(String name) {
        this.name = name;
    }

    public String getDisplayName() {
        return name;
    }
}
