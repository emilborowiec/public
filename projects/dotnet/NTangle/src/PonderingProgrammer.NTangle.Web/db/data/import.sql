INSERT INTO activity (name, description) VALUES ('Functional Design', 'Making decisions on what the software does.');
INSERT INTO activity (name, description) VALUES ('UX Design', 'Making decisions on how the software should look and feel');
INSERT INTO activity (name, description) VALUES ('Technical Design', 'Making decisions on how the software is built.');
INSERT INTO activity (name, description) VALUES ('Programming', 'Writing application code.');

INSERT INTO tip_type (name) VALUES ('Principle');
INSERT INTO tip_type (name) VALUES ('Practice');
INSERT INTO tip_type (name) VALUES ('Pattern');
INSERT INTO tip_type (name) VALUES ('Warning');

INSERT INTO tip_set (name, summary) VALUES ('SOLID', 'A group of principles of good Object Oriented Design.');

INSERT INTO tip (title, tip_type_id, activity_id) VALUES ('Single Responsibility Principle', 1, 3);
INSERT INTO tip (title, tip_type_id, activity_id) VALUES ('Open-Closed Principle', 1, 3);
INSERT INTO tip (title, tip_type_id, activity_id) VALUES ('Liskov Substitution Principle', 1, 3);
INSERT INTO tip (title, tip_type_id, activity_id) VALUES ('Interface Segregation Principle', 1, 3);
INSERT INTO tip (title, tip_type_id, activity_id) VALUES ('Dependency Inversion Principle', 1, 3);

INSERT INTO tip_grouping (tip_id, tip_set_id) VALUES (1, 1);
INSERT INTO tip_grouping (tip_id, tip_set_id) VALUES (2, 1);
INSERT INTO tip_grouping (tip_id, tip_set_id) VALUES (3, 1);
INSERT INTO tip_grouping (tip_id, tip_set_id) VALUES (4, 1);
INSERT INTO tip_grouping (tip_id, tip_set_id) VALUES (5, 1);