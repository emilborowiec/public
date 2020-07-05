package net.ponderingprogrammer.fxsamples;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

public class Main extends Application {

    public static void main(String... args) {
        launch(args);
    }

    @Override
    public void start(Stage stage) throws Exception {
        stage.setTitle("PonderingProgrammer - JavaFx samples");

        var contentPanel = new ContentPanel();
        var menuPanel = new MenuPanel();
        menuPanel.setSampleConsumer(contentPanel::showSample);

        var root = new BorderPane();
        root.setLeft(menuPanel);
        root.setCenter(contentPanel);

        var scene = new Scene(root, 600, 400);

        stage.setScene(scene);

        stage.show();
    }
}
