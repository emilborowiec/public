package net.ponderingprogrammer.procgenlab.procgenoptions;

import javafx.scene.layout.VBox;
import net.ponderingprogrammer.procgenlab.ContentCategory;
import net.ponderingprogrammer.procgenlab.layout.LayoutConsts;
import net.ponderingprogrammer.procgenlab.procgenoptions.abstractoptions.AbstractOptionsPanel;
import net.ponderingprogrammer.procgenlab.procgenoptions.tiledmapoptions.TiledMapOptionsPanel;

import java.util.function.Consumer;

public class ProcGenOptionsPanel extends VBox {

    private final ProcGenOptionsModel options;

    private AbstractOptionsPanel abstractOptionsPanel;
    private TiledMapOptionsPanel tiledMapOptionsPanel;

    private Runnable generateActionHandler;

    public ProcGenOptionsPanel() {
        this.options = new ProcGenOptionsModel();

//        initUI();
    }

//    private void initUI() {
//        setBackground(Color.CYAN);
//        setMinimumSize(new Dimension(LayoutConsts.MIN_SIDEBAR_WIDTH, LayoutConsts.MIN_HEIGHT));
//        setPreferredSize(new Dimension(LayoutConsts.SIDEBAR_WIDTH, LayoutConsts.MIN_HEIGHT));
//
//        setBorder(new EmptyBorder(LayoutConsts.PADDING, LayoutConsts.PADDING, LayoutConsts.PADDING, LayoutConsts.PADDING));
//
//        add(new JLabel("Category:"), new GBC(0, 0));
//        var categorySelector = new JComboBox<>(ContentCategory.values());
//        categorySelector.addItemListener(this::onCategoryItem);
//        add(categorySelector, new GBC(0, 1));
//
//        abstractOptionsPanel = new AbstractOptionsPanel();
//        add(abstractOptionsPanel, new GBC(0, 2));
//        tiledMapOptionsPanel = new TiledMapOptionsPanel();
//        add(tiledMapOptionsPanel, new GBC(0, 2));
//        tiledMapOptionsPanel.setVisible(false);
//
//        var generateButton = new JButton("Generate");
//        generateButton.setAlignmentX(Component.LEFT_ALIGNMENT);
//        generateButton.addActionListener(this::onGenerateActionPerformed);
//        add(generateButton, new GBC(0, 3));
//    }
//
//    public void setSizeSliderValueConsumer(Consumer<Integer> onSizeSliderValue) {
//        abstractOptionsPanel.setSizeConsumer(onSizeSliderValue);
//    }
//
//    public void setGenerateActionHandler(Runnable onGenerateAction) {
////        abstractOptionsPanel.setGenerateActionHandler(onGenerateAction);
//    }
//
//    private void onCategoryItem(ItemEvent e) {
//        if (e.getStateChange() == ItemEvent.SELECTED) {
//            switch ((ContentCategory)e.getItem()) {
//                case Abstract:
//                    hideOptionPanels();
//                    abstractOptionsPanel.setVisible(true);
//                    break;
//                case TiledMapLevel:
//                    hideOptionPanels();
//                    tiledMapOptionsPanel.setVisible(true);
//                    break;
//                default:
//            }
//        }
//    }
//
//    private void hideOptionPanels() {
//        abstractOptionsPanel.setVisible(false);
//        tiledMapOptionsPanel.setVisible(false);
//    }
//
//    private void onGenerateActionPerformed(ActionEvent event) {
//        if (generateActionHandler != null) {
//            generateActionHandler.run();
//        }
//    }
}
