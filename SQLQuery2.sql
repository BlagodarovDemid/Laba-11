CREATE TABLE [dbo].[LoginTable1]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] NVARCHAR(50) NULL, 
    [password] NVARCHAR(50) NULL,
    [firstname] NVARCHAR(75) NULL,
    [lastname] NVARCHAR(100) NULL,
    [birthday] DATE NULL,
    [email] NVARCHAR(100) NULL,
    [phone] NVARCHAR(50) NULL,
    [department] NVARCHAR(100) NULL,
    [level] NVARCHAR(100) NULL,
    [data] DATE NULL
)