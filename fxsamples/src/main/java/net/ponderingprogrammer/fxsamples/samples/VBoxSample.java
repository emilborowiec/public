package net.ponderingprogrammer.fxsamples.samples;

import javafx.geometry.Insets;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;

public class VBoxSample extends VBox {
    public VBoxSample() {
        super(4);
        setPadding(new Insets(4, 4, 4, 4));

        Label usernameLabel = new Label("Username:");
        TextField usernameField = new TextField();
        Label passwordLabel = new Label("Password:");
        PasswordField passwordField = new PasswordField();
        var loginButton = new Button("Log in");

        getChildren().addAll(usernameLabel, usernameField, passwordLabel, passwordField, loginButton);
    }
}
