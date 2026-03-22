CREATE TABLE IF NOT EXISTS users (
    userId INT PRIMARY KEY AUTO_INCREMENT,
    fullname VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    );

CREATE TABLE IF NOT EXISTS events (
    eventId INT PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(100) NOT NULL,
    date DATE NOT NULL,
    time TIME NOT NULL,
    organiser VARCHAR(100) NOT NULL,
    createdAt DATETIME DEFAULT NOW(),
    UNIQUE KEY unique_day_time (date, time)
    );
