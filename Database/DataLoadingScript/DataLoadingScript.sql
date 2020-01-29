USE [CodingChallenge]
GO

--Insert into User table
INSERT INTO [dbo].[User]([FirstName], [LastName])
VALUES
    ('Alex', 'Ujueta'),
    ('Randald', 'Alvarez'),
    ('Randald', 'Obando');
GO

--Insert into Project table
INSERT INTO [dbo].[Project]([StartDate], [EndDate], [Credits])
VALUES
    ('02/15/2020', '10/20/2020', 10),
    ('05/08/2019', '11/25/2020', 8),
    ('04/23/2020', '08/23/2020', 12),
	('09/15/2019', '09/21/2020', 16),
	('01/15/2020', '04/17/2020', 7);

GO

--Insert into User project
INSERT INTO [dbo].[UserProject]([UserId], [ProjectId], [IsActive], [AssignedDate])
VALUES
    (1, 1, 0, '01/05/2020'),
    (1, 2, 1, '06/10/2020'),
    (1, 3, 1, '03/01/2020'),
	(1, 4, 0, '08/10/2019'),
	(1, 5, 1, '02/15/2020'),

	(2, 1, 1, '04/05/2020'),
    (2, 2, 1, '04/07/2020'),
    (2, 3, 0, '08/10/2019'),
	(2, 4, 0, '02/10/2020'),
	(2, 5, 1, '01/15/2019'),

	(3, 1, 0, '02/25/2020'),
    (3, 2, 0, '04/14/2019'),
    (3, 3, 1, '03/10/2020'),
	(3, 4, 1, '12/10/2019'),
	(3, 5, 1, '02/23/2020');
GO