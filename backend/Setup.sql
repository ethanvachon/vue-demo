use firstdatabase123;


-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE posts
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255),
--   body VARCHAR(255),

--   PRIMARY KEY (id),

--   FOREIGN KEY(creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )
CREATE TABLE following
(
  id INT NOT NULL AUTO_INCREMENT,
  followingId VARCHAR(255) NOT NULL,
  followerId VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,

  PRIMARY KEY (id),

  FOREIGN KEY(followingId)
    REFERENCES profiles(id)
    ON DELETE CASCADE,

  FOREIGN KEY(followerId)
    REFERENCES profiles(id)
    ON DELETE CASCADE,

  FOREIGN KEY(creatorId)
    REFERENCES profiles(id)
    ON DELETE CASCADE

)