CREATE TABLE activity (
    activity_id INTEGER PRIMARY KEY
    ,name VARCHAR(255) NOT NULL UNIQUE
    ,description TEXT
    ,parent_activity_id INTEGER
    ,FOREIGN KEY (parent_activity_id) 
    REFERENCES activity(activity_id)
    ON DELETE SET NULL
);

CREATE TABLE tip (
    tip_id INTEGER PRIMARY KEY
    ,name VARCHAR(255) NOT NULL UNIQUE
    ,tip_type VARCHAR(50) NOT NULL
    ,activity_id INTEGER
    ,summary TEXT
    ,reference_url VARCHAR(2000)
    ,FOREIGN KEY (activity_id) 
    REFERENCES activity(activity_id) 
    ON DELETE SET NULL
);

CREATE TABLE tip_relation (
    source_tip_id INTEGER
    ,target_tip_id INTEGER
    ,relation_type VARCHAR(50) NOT NULL
    ,PRIMARY KEY (source_tip_id, target_tip_id)
    ,FOREIGN KEY (source_tip_id) REFERENCES tip(tip_id) ON DELETE CASCADE
    ,FOREIGN KEY (target_tip_id) REFERENCES tip(tip_id) ON DELETE CASCADE
);