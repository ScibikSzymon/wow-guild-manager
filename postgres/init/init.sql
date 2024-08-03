-- Create the Guild table
CREATE TABLE Guild (
    GuildId SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    CreateDate DATE NOT NULL
);

-- Create the Member table
CREATE TABLE Member (
    MemberId SERIAL PRIMARY KEY,
    GuildId INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    JoinDate DATE NOT NULL,
    Role VARCHAR(50),
    FOREIGN KEY (GuildId) REFERENCES Guild (GuildId) ON DELETE CASCADE
);

-- Create the Character table
CREATE TABLE Character (
    CharacterId SERIAL PRIMARY KEY,
    MemberId INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Class VARCHAR(50),
    FOREIGN KEY (MemberId) REFERENCES Member (MemberId) ON DELETE CASCADE
);

CREATE TABLE RaidAttendance(
    RaidAttendanceId SERIAL PRIMARY KEY,
    MemberId INT NOT NULL,
    CharacterId INT NOT NULL,
    Status BOOLEAN DEFAULT NULL
);
