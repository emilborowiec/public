package net.ponderingprogrammer.procgenlab;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;
import net.ponderingprogrammer.procgenlab.procgenoptions.ProcGenOptionsPanel;
import net.ponderingprogrammer.procgenlab.services.DelaunayTriangulator;
import net.ponderingprogrammer.procgenlab.services.PointsGenerator;
import net.ponderingprogrammer.procgenlab.services.RandomPointsGenerator;
import net.ponderingprogrammer.procgenlab.services.Triangulator;
import net.ponderingprogrammer.procgenlab.statusbar.StatusBar;

public class Main extends Application {
    public static void main(String... args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        // Services
        PointsGenerator pointsGenerator = new RandomPointsGenerator();
        Triangulator triangulator = new DelaunayTriangulator();

        primaryStage.setTitle("Procedural Generation Labs");
        var borderPane = new BorderPane();
        var mainScene = new Scene(borderPane, 800, 600);
        primaryStage.setScene(mainScene);

        var procGenOptionsPanel = new ProcGenOptionsPanel();
        borderPane.setLeft(procGenOptionsPanel);

//        var scenePanel = new ScenePanel();
//        borderPane.setCenter(scenePanel);

        var statusBar = new StatusBar();
        borderPane.setBottom(statusBar);

        primaryStage.show();
    }
}
