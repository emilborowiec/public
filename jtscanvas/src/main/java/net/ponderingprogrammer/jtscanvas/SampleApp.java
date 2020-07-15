package net.ponderingprogrammer.jtscanvas;

import javafx.application.Application;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

public class SampleApp extends Application {

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage stage) throws Exception {
        JtsCanvas jtsCanvas = new JtsCanvas();

        BorderPane borderPane = new BorderPane();
        borderPane.setCenter(jtsCanvas);

        Scene scene = new Scene(borderPane);
        stage.setWidth(800);
        stage.setHeight(600);
        stage.setScene(scene);
        stage.show();
    }
}
