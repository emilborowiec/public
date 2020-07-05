package net.ponderingprogrammer.fxsamples;

import javafx.scene.control.ToggleButton;
import javafx.scene.control.ToggleGroup;
import javafx.scene.layout.VBox;
import net.ponderingprogrammer.fxsamples.samples.Sample;

import java.util.function.Consumer;

public class MenuPanel extends VBox {
    private Consumer<Sample> sampleConsumer;

    public MenuPanel() {
        super();

        initUi();
    }

    public void setSampleConsumer(Consumer<Sample> sampleConsumer) {
        this.sampleConsumer = sampleConsumer;
    }

    private void initUi() {
        var toggleGroup = new ToggleGroup();
        for (Sample sample : Sample.values()) {
            var button = new ToggleButton(sample.getDisplayName());
            button.setOnAction(e -> onSampleSelected(sample));
            button.setToggleGroup(toggleGroup);
            getChildren().add(button);
        }
    }

    private void onSampleSelected(Sample sample) {
        if (sampleConsumer != null) {
            sampleConsumer.accept(sample);
        }
    }
}
