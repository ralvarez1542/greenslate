CREATE DATABASE [CodingChallenge]
GO
USE [CodingChallenge]
GO

--Create User table
CREATE TABLE [dbo].[User](
    [Id] INT NOT NULL IDENTITY (1, 1),
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    CONSTRAINT PK_User PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

--Create Project table
CREATE TABLE [dbo].[Project](
    [Id] INT NOT NULL IDENTITY (1, 1),
    [StartDate] DATETIME NOT NULL,
    [EndDate] DATETIME NOT NULL,
    [Credits] INT NOT NULL,
    CONSTRAINT PK_Project PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

--Create relation between User and Project
CREATE TABLE [dbo].[UserProject](
    [UserId] INT NOT NULL,
    [ProjectId] INT NOT NULL,
    [IsActive] BIT NOT NULL,
    [AssignedDate] DATETIME NOT NULL,
    CONSTRAINT PK_UserProject PRIMARY KEY CLUSTERED([UserId] ASC, [ProjectId] ASC),
	CONSTRAINT FK_UserProject_User FOREIGN KEY([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT FK_UserProject_Project FOREIGN KEY([ProjectId]) REFERENCES [Project]([Id]),
);
GO
