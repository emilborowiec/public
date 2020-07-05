package net.ponderingprogrammer.fxsamples;

import javafx.scene.layout.Pane;
import javafx.scene.layout.StackPane;
import net.ponderingprogrammer.fxsamples.samples.*;

import java.util.HashMap;
import java.util.Map;

public class ContentPanel extends StackPane {
    private Map<Sample, Pane> samplePaneMap = new HashMap<>();

    public ContentPanel() {
        samplePaneMap.put(Sample.FLOW, new FlowSample());
        samplePaneMap.put(Sample.HBOX, new HBoxSample());
        samplePaneMap.put(Sample.VBOX, new VBoxSample());
        samplePaneMap.put(Sample.GRID, new GridSample());
        samplePaneMap.put(Sample.ABSOLUTE, new AbsoluteSample());
        samplePaneMap.put(Sample.ANCHOR, new AnchorSample());
        samplePaneMap.put(Sample.BORDER, new SelfSample());
        samplePaneMap.put(Sample.STACK, new SelfSample());
        samplePaneMap.put(Sample.TILE, new TileSample());
        samplePaneMap.put(Sample.MIG, new MigSample());
        samplePaneMap.put(Sample.TABLE, new TableSample());
    }

    public void showSample(Sample sample) {
        getChildren().clear();
        getChildren().add(samplePaneMap.get(sample));
    }
}
