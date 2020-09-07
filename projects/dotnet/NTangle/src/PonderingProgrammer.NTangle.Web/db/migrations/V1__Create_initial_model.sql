CREATE TABLE activity (
    activity_id INTEGER PRIMARY KEY
    ,name VARCHAR(255) NOT NULL UNIQUE
    ,description TEXT
    ,parent_activity_id INTEGER
    ,FOREIGN KEY (parent_activity_id) 
    REFERENCES activity(activity_id)
    ON DELETE SET NULL
);

CREATE TABLE tip_set (
    tip_set_id INTEGER PRIMARY KEY
    ,name VARCHAR(255) NOT NULL UNIQUE
    ,summary TEXT
    ,reference_url VARCHAR(2000)
);

CREATE TABLE tip_type (
    tip_type_id INTEGER PRIMARY KEY 
    ,name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE tip (
    tip_id INTEGER PRIMARY KEY
    ,title VARCHAR(255) NOT NULL UNIQUE
    ,tip_type_id INTEGER NOT NULL
    ,activity_id INTEGER
    ,summary TEXT
    ,reference_url VARCHAR(2000)
    ,FOREIGN KEY (tip_type_id) REFERENCES tip_type(tip_type_id)
    ,FOREIGN KEY (activity_id) REFERENCES activity(activity_id)
);

CREATE TABLE tip_grouping (
    tip_id INTEGER
    ,tip_set_id INTEGER
    ,PRIMARY KEY (tip_id, tip_set_id)
    ,FOREIGN KEY (tip_id) REFERENCES tip(tip_id) ON DELETE CASCADE
    ,FOREIGN KEY (tip_set_id) REFERENCES tip_set(tip_set_id) ON DELETE CASCADE
)