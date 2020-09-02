CREATE TABLE principle (
    principle_id INT IDENTITY(1,1) PRIMARY KEY
    ,name VARCHAR(50) NOT NULL UNIQUE
    ,short_description VARCHAR(255)
    ,url VARCHAR(255)
)