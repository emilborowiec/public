INSERT INTO activity (name, description) VALUES ('Functional Design', 'Making decisions on what the software does.');
INSERT INTO activity (name, description) VALUES ('UX Design', 'Making decisions on how the software should look and feel');
INSERT INTO activity (name, description) VALUES ('Technical Design', 'Making decisions on how the software is built.');
INSERT INTO activity (name, description) VALUES ('Programming', 'Writing application code.');

INSERT INTO tip (name, tip_type, activity_id) VALUES ('SOLID', 'Principle', 3);
INSERT INTO tip (name, tip_type, activity_id) VALUES ('Single Responsibility Principle', 'Principle', 3);
INSERT INTO tip (name, tip_type, activity_id) VALUES ('Open-Closed Principle', 'Principle', 3);
INSERT INTO tip (name, tip_type, activity_id) VALUES ('Liskov Substitution Principle', 'Principle', 3);
INSERT INTO tip (name, tip_type, activity_id) VALUES ('Interface Segregation Principle', 'Principle', 3);
INSERT INTO tip (name, tip_type, activity_id) VALUES ('Dependency Inversion Principle', 'Principle', 3);

INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (2, 1, 'IsMemberOf');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (3, 1, 'IsMemberOf');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (4, 1, 'IsMemberOf');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (5, 1, 'IsMemberOf');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (6, 1, 'IsMemberOf');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (1, 2, 'Groups');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (1, 3, 'Groups');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (1, 4, 'Groups');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (1, 5, 'Groups');
INSERT INTO tip_relation (source_tip_id, target_tip_id, relation_type) VALUES (1, 6, 'Groups');
