CREATE TABLE Restaurants (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
);
CREATE TABLE Ratings (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    RestaurantId INT NOT NULL,
    Score FLOAT NOT NULL CHECK (Score >= 0.0 AND Score <= 5.0),
);
ALTER TABLE Ratings ADD FOREIGN KEY (RestaurantId) REFERENCES Restaurants(Id);
INSERT INTO Restaurants
    (Name, Location)
VALUES
    ('The Bistro', '12175 Visionary Way'),
    ('India Garden', '207 N Delaware St'),
    ('McDonald''s', '8907 E 116th Street');
    INSERT INTO Ratings
    (RestaurantId, Score)
VALUES
    (1, 5), (1, 3), (1, 4), (1, 5),
    (2, 5), (2, 4), (2, 5),
    (3, 5), (3, 3), (3, 4);
