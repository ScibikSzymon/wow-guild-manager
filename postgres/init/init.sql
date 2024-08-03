-- Create the Guild table
CREATE TABLE Guild (
    guild_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    creation_date DATE NOT NULL
);

-- Create the Member table
CREATE TABLE Member (
    member_id SERIAL PRIMARY KEY,
    guild_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    join_date DATE NOT NULL,
    role VARCHAR(50),
    FOREIGN KEY (guild_id) REFERENCES Guild (guild_id) ON DELETE CASCADE
);

-- Create the Character table
CREATE TABLE Character (
    character_id SERIAL PRIMARY KEY,
    member_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    class VARCHAR(50),
    FOREIGN KEY (member_id) REFERENCES Member (member_id) ON DELETE CASCADE
);