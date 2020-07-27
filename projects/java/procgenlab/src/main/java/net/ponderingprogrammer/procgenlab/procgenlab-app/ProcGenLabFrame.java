package net.ponderingprogrammer.procgenlab;

import net.ponderingprogrammer.procgenlab.procgenoptions.ProcGenOptionsPanel;
import net.ponderingprogrammer.procgenlab.services.PointsGenerator;
import net.ponderingprogrammer.procgenlab.services.Triangulator;
import net.ponderingprogrammer.procgenlab.statusbar.StatusBar;


public class ProcGenLabFrame {

//    private final PointsGenerator pointsGenerator;
//    private final Triangulator triangulator;
//
//    private ScenePanel scenePanel;
//
//    public ProcGenLabFrame(PointsGenerator pointsGenerator, Triangulator triangulator) {
//        this.pointsGenerator = pointsGenerator;
//        this.triangulator = triangulator;
//
//        setDefaultCloseOperation(EXIT_ON_CLOSE);
//
//        initUI();
//    }
//
//    private void initUI() {
//        setTitle("Procedural generation lab");
//        setSize(1200, 800);
//
//        var pane = getContentPane();
//
//        // ProcGenOptions component
//        var procGenOptionsPanel = new ProcGenOptionsPanel();
//        procGenOptionsPanel.setSizeSliderValueConsumer(this::onSizeSliderValue);
//        procGenOptionsPanel.setGenerateActionHandler(this::onGenerateAction);
//        pane.add(procGenOptionsPanel, BorderLayout.WEST);
//
//        // Scene component
//        scenePanel = new ScenePanel();
//        pane.add(scenePanel, BorderLayout.CENTER);
//
//        // Status component
//        var statusPanel = new StatusBar();
//        add(statusPanel, BorderLayout.SOUTH);
//    }
//
//    private void onGenerateAction() {
////        var envelope = new Envelope(-options.getSize()/2d, options.getSize()/2d, -options.getSize()/2d, options.getSize()/2d);
////        var points = pointsGenerator.generatePointsInEnvelope(options.getPointCount(), envelope);
////        scenePanel.setPoints(points);
////
////        var triangles = triangulator.triangulate(points);
////        scenePanel.setTriangles(triangles);
//    }
//
//    private void onSizeSliderValue(Integer value) {
//        scenePanel.setBounds(value);
//    }
//
//    private Rectangle2D createRectBounds(int size) {
//        return new Rectangle2D.Double(-size/2d, -size/2d, size, size);
//    }
}
