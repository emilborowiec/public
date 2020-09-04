CREATE TABLE activity (
    activity_id INT IDENTITY(1,1) PRIMARY KEY
    ,name VARCHAR(255) NOT NULL
    ,description TEXT
    ,parent_activity_id INT
    ,FOREIGN KEY (parent_activity_id) 
    REFERENCES activity(activity_id)
    ON DELETE SET NULL
);

CREATE TABLE tip_set (
    tip_set_id INT IDENTITY(1,1) PRIMARY KEY
    ,name VARCHAR(255) NOT NULL
    ,summary TEXT
    ,reference_url VARCHAR(2000)
);

CREATE TABLE tip_type (
    tip_type_id INT IDENTITY(1,1) PRIMARY KEY 
    ,name VARCHAR(255) not null unique
);

CREATE TABLE tip (
    tip_id INT IDENTITY(1,1) PRIMARY KEY
    ,title VARCHAR(255) NOT NULL UNIQUE
    ,tip_type_id INT NOT NULL
    ,activity_id INT
    ,summary TEXT
    ,reference_url VARCHAR(2000)
    ,FOREIGN KEY (tip_type_id) REFERENCES tip_type(tip_type_id)
    ,FOREIGN KEY (activity_id) REFERENCES activity(activity_id)
);

CREATE TABLE tip_grouping (
    tip_id INT
    ,tip_set_id INT
    ,PRIMARY KEY (tip_id, tip_set_id)
    ,FOREIGN KEY (tip_id) REFERENCES tip(tip_id) ON DELETE CASCADE
    ,FOREIGN KEY (tip_set_id) REFERENCES tip_set(tip_set_id) ON DELETE CASCADE
)