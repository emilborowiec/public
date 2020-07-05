package net.ponderingprogrammer.procgenlab.procgenoptions.abstractoptions;

import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Slider;
import net.ponderingprogrammer.procgenlab.AbstractContentType;
import net.ponderingprogrammer.procgenlab.procgenoptions.ProcGenOptionsModel;
import net.ponderingprogrammer.procgenlab.services.BoundsShape;

import java.util.function.Consumer;

public class AbstractOptionsPanel {

    private final AbstractOptionsModel options;

    private ComboBox<BoundsShape> boundsShapeSelector;
    private ComboBox<AbstractContentType> abstractTypeSelector;
    private Slider sizeSlider;

    private Consumer<Integer> sizeConsumer;
    private Consumer<BoundsShape> boundsShapeConsumer;

    public AbstractOptionsPanel() {
        this.options = new AbstractOptionsModel();

//        initUI();
    }

//    private void initUI() {
//
//        getChildren().add(new Label("Object type:"));
//        abstractTypeSelector = new JComboBox<>(AbstractContentType.values());
//        add(abstractTypeSelector, new GBC(0, 1));
//
//        add(new JLabel("Bounds shape:"), new GBC(0, 2));
//        boundsShapeSelector = new JComboBox<>(BoundsShape.values());
//        boundsShapeSelector.addItemListener(this::onBoundsShapeChanged);
//        add(boundsShapeSelector, new GBC(0, 3));
//
//        add(new JLabel("Area size:"), new GBC(0, 4));
//
//        sizeSlider = new JSlider(ProcGenOptionsModel.MIN_SIZE, ProcGenOptionsModel.MAX_SIZE, ProcGenOptionsModel.DEFAULT_SIZE);
//        sizeSlider.setAlignmentX(Component.LEFT_ALIGNMENT);
//        sizeSlider.setMinorTickSpacing(100);
//        sizeSlider.setMajorTickSpacing(500);
//        sizeSlider.setPaintTicks(true);
//        sizeSlider.setPaintLabels(true);
//        sizeSlider.addChangeListener(this::onSizeSliderChanged);
//        add(sizeSlider, new GBC(0, 5));
//    }
//
//    public AbstractContentType getType() {
//        return abstractTypeSelector.getItemAt(abstractTypeSelector.getSelectedIndex());
//    }
//
//    public BoundsShape getShape() {
//        return boundsShapeSelector.getItemAt(boundsShapeSelector.getSelectedIndex());
//    }
//
//    public int getAreaSize() {
//        return sizeSlider.getValue();
//    }
//
//    private void onBoundsShapeChanged(ItemEvent itemEvent) {
//        if (itemEvent.getStateChange() == ItemEvent.SELECTED && boundsShapeConsumer != null) {
//            boundsShapeConsumer.accept(boundsShapeSelector.getItemAt(boundsShapeSelector.getSelectedIndex()));
//        }
//    }
//
//    public void setSizeConsumer(Consumer<Integer> sizeConsumer) {
//        this.sizeConsumer = sizeConsumer;
//    }
//
//    private void onSizeSliderChanged(ChangeEvent e) {
//        var slider = (JSlider)e.getSource();
//        if (!slider.getValueIsAdjusting() && sizeConsumer != null) {
//            options.setSize(slider.getValue());
//            sizeConsumer.accept(slider.getValue());
//        }
//    }
}
