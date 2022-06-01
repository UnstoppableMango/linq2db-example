CREATE SCHEMA dbo;
GO

CREATE TABLE dbo.Test(
    Message VARCHAR(50)
)
GO

CREATE PROC  dbo.GetStuff
AS
BEGIN
  SELECT * FROM dbo.Test
END
GO

INSERT INTO dbo.Test (Message)
VALUES
    ("Test")
    ("Test1")
    ("Test2")
GO