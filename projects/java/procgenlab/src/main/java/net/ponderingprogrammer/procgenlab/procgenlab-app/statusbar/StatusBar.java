package net.ponderingprogrammer.procgenlab.statusbar;

import javafx.geometry.Pos;
import javafx.scene.control.Label;
import javafx.scene.layout.HBox;

public class StatusBar extends HBox {

    private Label statusLabel;

    public StatusBar() {
//        setBorder(new Border());

        statusLabel = new Label("status");
        statusLabel.setAlignment(Pos.BASELINE_LEFT);

        getChildren().add(statusLabel);
    }

}
