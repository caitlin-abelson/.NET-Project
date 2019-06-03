IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases 
WHERE name = 'slpDB')

BEGIN
	DROP	DATABASE [SLPDB];
	print '' print ' *** Dropping database SLPDB'
	
END
GO

print '' print ' *** Creating Database SLPDB'

GO
CREATE DATABASE [SLPDB]
GO

print '' print ' *** Using Database SLPDB'

GO
USE [SLPDB]
GO



/*

Tables and their insert values, divided into sections


*/


print '' print ' ***Creating SLP Manager Table'
GO
CREATE TABLE [dbo].[Manager] (
	[ManagerID]		[nvarchar](50)			  NOT NULL,
	[FirstName]		[nvarchar](50)			  NOT NULL,
	[LastName]		[nvarchar](100)			  NOT NULL,
	[PasswordHash]	[nvarchar](100)			  NOT NULL DEFAULT
	'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Email]			[nvarchar](250)			  NOT NULL,
	
	CONSTRAINT [pk_ManagerID] PRIMARY KEY([ManagerID] ASC),
	CONSTRAINT [ak_Email] UNIQUE([Email] ASC)
)
GO

print '' print '*** Inserting Person Records for SLP'
GO
INSERT INTO [dbo].[Manager]
		([ManagerID], [FirstName], [LastName], [Email])
	VALUES
		('A15848', 'Jason', 'Bitzer', 'Jason@gmail.com')
GO

--------------------------------------------------------------------------------------------------------

print '' print ' ***Creating SLP Table'
GO
CREATE TABLE [dbo].[SLP] (
	[SLPID]			[nvarchar](50)			  NOT NULL,
	[FirstName]		[nvarchar](50)			  NOT NULL,
	[LastName]		[nvarchar](100)			  NOT NULL,
	[PasswordHash]	[nvarchar](100)			  NOT NULL DEFAULT
	'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Email]			[nvarchar](250)			  NOT NULL,
	[ManagerID]		[nvarchar](50)			  NOT NULL,
	
	CONSTRAINT [pk_SLPID] PRIMARY KEY([SLPID] ASC),
	CONSTRAINT [ak_Email_SLP] UNIQUE([Email] ASC)
)
GO

print '' print '*** Inserting Person Records for SLP'
GO
INSERT INTO [dbo].[SLP]
		([SLPID], [FirstName], [LastName], [Email], [ManagerID], [PasswordHash])
	VALUES
		('C123D456', 'Carrie', 'Davis', 'Carrie@gmail.com', 'A15848', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e'),
		('C436A372', 'Caitlin', 'Abelson', 'Caitlin@gmail.com', 'A15848','9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e')
GO
----------------------------------------------------------------------------------------------------------------

print '' print ' ***Create Teacher Table'
GO
CREATE TABLE [dbo].[Teacher] (
	[TeacherID]		[nvarchar](50)			  NOT NULL,
	[NCESID]		[nvarchar](20)			  NOT NULL,
	[FirstName]		[nvarchar](50)			  NOT NULL,
	[LastName]		[nvarchar](100)			  NOT NULL,
	[Email]			[nvarchar](250)			  NOT NULL,
	[PasswordHash]	[nvarchar](100)			  NOT NULL DEFAULT
	'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[ManagerID]		[nvarchar](50)			  NOT NULL,
	[Active]		[bit]					  NOT NULL DEFAULT 1,
	
	CONSTRAINT [pk_TeacherID] PRIMARY KEY([TeacherID] ASC)
)
GO

print '' print '*** Inserting Person Records for Teacher'
GO
INSERT INTO [dbo].[Teacher]
		([TeacherID], [NCESID], [FirstName], [LastName], [Email], [PasswordHash], [ManagerID], [Active])
	VALUES
		('DeGeneres.Wright', '190654000268', 'Ellen', 'DeGeneres', 'Ellen@school.com', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 'A15848', 1),
		('Turring.Lovely', 'A0301593', 'Alan', 'Turring', 'Alan@school.com', 
		'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 'A15848', 1),
		('Glasgow.Summit', 'T749601', 'Jim', 'Glasgow', 'Jim@school.com', 
		'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 'A15848', 1)
GO

----------------------------------------------------------------------------------------------------------------

print '' print '*** Create Grade Table'
GO
CREATE TABLE [dbo].[Grade] (
	[Grade]			[nvarchar](15)			NOT NULL,
	[Description]	[nvarchar](100)			NOT NULL,		
	
	CONSTRAINT [pk_Grade] PRIMARY KEY([Grade] ASC)
)
GO

print '' print '*** Inserting Person Records for Grade'
GO
INSERT INTO [dbo].[Grade]
		([Grade], [Description])
	VALUES
		('Pre-School', 'Children ages under 5'),
		('Kindergarten', 'Children ages 5-6'),
		('1st', 'Children ages 6-7'),
		('2nd', 'Children ages 7-8'),
		('3rd', 'Children ages 8-9'),
		('4th', 'Children ages 9-10'),
		('5th', 'Children ages 10-11'),
		('6th', 'Children ages 11-12'),
		('7th', 'Children ages 12-13'),
		('8th', 'Children ages 13-14'),
		('9th', 'Children ages 14-15'),
		('10th', 'Children ages 15-16'),
		('11th', 'Children ages 16-17'),
		('12th', 'Children ages 17-18')
GO

-----------------------------------------------------------------------------------------------
print '' print ' ***Create Student Table'
GO
CREATE TABLE [dbo].[Student] (
	[StudentID]		[nvarchar](50)			  NOT NULL,
	[Birthday]		[date]					  NOT NULL,
	[TeacherID]		[nvarchar](50)			  NOT NULL,	
	[NCESID]		[nvarchar](20)			  NOT NULL,
	[Grade]			[nvarchar](15)			  NOT NULL,
	[FirstName]		[nvarchar](50)			  NOT NULL,
	[LastName]		[nvarchar](100)			  NOT NULL,
	[Address]		[nvarchar](30)			  NOT NULL,
	[City]			[nvarchar](30)			  NOT NULL,
	[StateID]		[nvarchar](2)			  NOT NULL,
	[ZipCode]		[nvarchar](7)			  NOT NULL,

	
	CONSTRAINT [pk_StudentID] PRIMARY KEY ([StudentID] ASC)

)
GO

print '' print '*** Inserting Records for Student'
GO
INSERT INTO [dbo].[Student]
		([StudentID], [FirstName], [LastName], [Birthday], [TeacherID], [Grade], [Address], [City], [StateID], 
		[ZipCode], [NCESID])
	VALUES
		('P897G8709', 'Peter', 'Griffin', '05-08-2010', 'DeGeneres.Wright', '1st', '643 Cherry St.', 'Cedar Rapids', 'IA', '52402', '190654000268'),
		('L756S756', 'Lisa', 'Simpson', '09-05-2011','Turring.Lovely', 'Kindergarten', '9365 Lumbard Dr.', 'Cedar Rapids', 'IA', '52407', 'A0301593'),
		('P656P8757', 'Peter', 'Parker', '06-04-2010','Glasgow.Summit', '1st', '5295 Humbald Way', 'Cedar Rapids', 'IA', '52402', 'T749601'),
		('T7687R75', 'Timmy', 'Ransom', '03-24-2010','DeGeneres.Wright', 'Kindergarten', '813 16th St.', 'Cedar Rapids', 'IA', '52407', '190654000268'),
		('M7575M7686', 'Michael', 'Meyers', '09-13-2011','Turring.Lovely', '1st', '6593 Gilbert Dr.', 'Cedar Rapids', 'IA', '52402', 'A0301593'),
		('M769876P78687', 'Mario', 'Plumber', '03-25-2011','Glasgow.Summit', 'Kindergarten', '3764 Howard St.', 'Cedar Rapids', 'IA', '52407', 'T749601'),
		('H65765P97555', 'Harry', 'Potter', '03-08-2009','DeGeneres.Wright', '3rd', '643 Cherry St.', 'Cedar Rapids', 'IA', '52402', '190654000268'),
		('J8587658P78658', 'Jerry', 'Plisher', '09-16-2007','Turring.Lovely', '5th', '9426 KillJoy Dr.', 'Cedar Rapids', 'IA', '52407', 'A0301593'),
		('K876587P897897', 'Karen', 'Peters', '06-21-2010','Glasgow.Summit', '2nd', '497 52nd St.', 'Cedar Rapids', 'IA', '52402', 'T749601'),
		('T87658K575667', 'Thomas', 'Knobs', '03-19-2009','DeGeneres.Wright', '3rd', '4987 Halfway St.', 'Cedar Rapids', 'IA', '52407', '190654000268'),
		('J54765Y4654', 'Janice', 'Yolks', '08-12-2011','Turring.Lovely', '1st', '6693 Gilbert Dr.', 'Cedar Rapids', 'IA', '52402', 'A0301593'),
		('L56476P654764', 'Luigi', 'Plumber', '09-28-2008','Glasgow.Summit', '4th', '3764 Howard St.', 'Cedar Rapids', 'IA', '52407', 'T749601')
GO


-------------------------------------------------------------------------------------------------------------------------

print '' print ' ***Create USState Table'
GO
CREATE TABLE [dbo].[USState] (
	[StateID]			[nvarchar](2)			  NOT NULL,
	[Name]				[nvarchar](25)			  NOT NULL

	CONSTRAINT [pk_StateID] PRIMARY KEY ([StateID] ASC)
)
GO

print '' print '*** Inserting Records for USState'
GO
INSERT INTO [dbo].[USState]
		([StateID], [Name])
	VALUES
		('AK', 'Alaska'),
		('AL', 'Alabama'),
		('AR', 'Arkansas'),
		('AZ', 'Arizona'),
		('CA', 'California'),
		('CO', 'Colorado'),
		('CT', 'Connecticut'),
		('DE', 'Delaware'),
		('FL', 'Florida'),
		('GA', 'Georgia'),
		('HI', 'Hawaii'),
		('IA', 'Iowa'),
		('ID', 'Idaho'),
		('IL', 'Illinois'),
		('IN', 'Indiana'),
		('KS', 'Kansas'),
		('KY', 'Kentucky'),
		('LA', 'Louisiana'),
		('MA', 'Massachusetts'),
		('MD', 'Maryland'),
		('ME', 'Maine'),
		('MI', 'Michigan'),
		('MN', 'Minnesota'),
		('MO', 'Missouri'),
		('MS', 'Mississippi'),
		('MT', 'Montana'),
		('NC', 'North Carolina'),
		('ND', 'North Dakota'),
		('NE', 'Nebraska'),
		('NH', 'New Hampshire'),
		('NJ', 'New Jersey'),
		('NM', 'New Mexico'),
		('NV', 'Nevada'),
		('NY', 'New York'),
		('OH', 'Ohio'),
		('OK', 'Oklahoma'),
		('OR', 'Oregon'),
		('PA', 'Pennsylvania'),
		('RI', 'Rhode Island'),
		('SC', 'South Carolina'),
		('SD', 'South Dakota'),
		('TN', 'Tennessee'),
		('TX', 'Texas'),
		('UT', 'Utah'),
		('VA', 'Virginia'),
		('VT', 'Vermont'),
		('WA', 'Washington'),
		('WI', 'Wisconsin'),
		('WV', 'West Virginia'),
		('WY', 'Wyoming')
GO

-------------------------------------------------------------------------------------------------------------------------

print '' print ' ***Create School Table'
GO
CREATE TABLE [dbo].[School] (
	[NCESID]		[nvarchar](20)			  NOT NULL,
	[Name]			[nvarchar](50)			  NOT NULL,
	[Address]		[nvarchar](30)			  NOT NULL,
	[City]			[nvarchar](30)			  NOT NULL,
	[State]			[nvarchar](2)			  NOT NULL,
	[ZipCode]		[nvarchar](7)			  NOT NULL,
	
	CONSTRAINT [pk_NCESID] PRIMARY KEY ([NCESID] ASC)
)
GO

print '' print '*** Inserting Records for School'
GO
INSERT INTO [dbo].[School]
		([NCESID], [Name], [Address], [City], [State], [ZipCode])
	VALUES
		('190654000268', 'Wright Elementary School', '1524 Hollywood Blvd NE', 'Cedar Rapids', 'IA', '52402' ),
		('A0301593', 'Lovely Lane', '2424 42nd St NE', 'Cedar Rapids', 'IA', '52402'),
		('T749601', 'Summit', '1010 Regent St NE', 'Cedar Rapids', 'IA', '52402')
GO

----------------------------------------------------------------------------------------------------------------------------------------

print '' print ' ***Create GoalType Table'
GO
CREATE TABLE [dbo].[GoalType] (
	[GoalType]		[nvarchar](50)			NOT NULL,
	[Description]	[nvarchar](250)			NOT NULL,
	
	CONSTRAINT [pk_GoalType] PRIMARY KEY ([GoalType] ASC)
)
GO


print '' print '*** Inseting into GoalType'
GO
INSERT INTO [dbo].[GoalType]
		([GoalType], [Description])
	VALUES
		('Articulation', 'This is a goal type.'),
		('Phonology', 'This is a goal type.'),
		('Fluency', 'This is a goal type.'),
		('Intelligibility', 'This is a goal type.'),
		('MLU', 'This is a goal type.'),
		('Vocabulary', 'This is a goal type.'),
		('Grammar/Word order', 'This is a goal type.'),
		('Language', 'This is a goal type.'),
		('Communication', 'This is a goal type.'),
		('Voice', 'This is a goal type.'),
		('WH-Questions', 'This is a goal type.'),
		('Sequencing', 'This is a goal type.'),
		('Listening comprehension', 'This is a goal type.')
GO

----------------------------------------------------------------------------------------------------------------------------

print '' print ' ***Create IEP Table'
GO
CREATE TABLE [dbo].[IEP] (
	[IEPID]					[int]IDENTITY(100000,1)	NOT NULL,
	[StudentID]				[nvarchar](50) 			NOT NULL,
	[SLPID]					[nvarchar](50)			NOT NULL,
	[IEPType]				[nvarchar](50)  		NOT NULL,
	[IEPDate]				[date]					NOT NULL DEFAULT
	'1950-01-01',
	[IEPLeaderFirstName]	[nvarchar](50)			NOT NULL,
	[IEPLeaderLastName]		[nvarchar](50)			NOT NULL,
	[GoalType]				[nvarchar](50)			NOT NULL,
	[IEPNotes]				[nvarchar](4000)		NULL,
	[Active]				[bit]					NOT NULL DEFAULT 1,
	
	
	CONSTRAINT [pk_IEPID] PRIMARY KEY ([IEPID] ASC)
)
GO

print '' print '*** Inserting Records for IEP'
GO
INSERT INTO [dbo].[IEP]
		([StudentID], [SLPID], [IEPType], [IEPDate], [IEPLeaderFirstName], [IEPLeaderLastName], [GoalType], [IEPNotes], [Active])
	VALUES
		('P897G8709', 'C123D456', 'Initial', '03-25-2019', 'Carrie', 'Davis', 'Vocabulary', 'Student has another sibling that is also in speech. Parents are also divorvced so need to call both parents when requesting an IEP meeting date.', 1),
		('L756S756', 'C123D456', 'Review 1', '09-04-2019', 'Hannah', 'Finkle', 'Language', 'Has hearing aids and was in speech at a previous school.', 1),
		('P656P8757', 'C123D456', 'Review 2', '01-12-2019', 'Carrie', 'Carrie', 'Voice', 'Changed speech goal on 3-1-2018. Teacher has concerns about speech in classroom.', 1),
		('T7687R75', 'C436A372', 'Re-Eval', '12-01-2019', 'Hannah', 'Finkle', 'Vocabulary', 'Child has additional eqipment that they use to help them speak. Must use in and outside of the classroom.', 1),
		('M7575M7686', 'C436A372', 'Initial Eval', '05-20-2019', 'Caitlin', 'Abelson', 'Language', 'Child is moving to another school.', 1),
		('M769876P78687', 'C436A372', 'Review 1', '03-25-2019', 'Hannah', 'Finkle', 'Voice', 'Child just moved from another school. Previous SLP was Carrie Davis.', 1),
		('H65765P97555', 'C123D456', 'Review 1', '4-02-2019', 'Carrie', 'Davis', 'Intelligibility', 'Child just moved from another school. Previous SLP was Jane Fhisher.', 1),
		('J8587658P78658', 'C123D456', 'Review 1', '01-12-2019', 'Carrie', 'Davis', 'Phonology', 'Child just moved from another school. Previous SLP was Carrie Davis.', 1),
		('K876587P897897', 'C123D456', 'Review 1', '03-25-2019', 'Hannah', 'Finkle', 'Sequencing', 'Child just moved from another school. Previous SLP was Jane Fhisher.', 1),
		('T87658K575667', 'C123D456', 'Review 1', '09-04-2019', 'Carrie', 'Davis', 'Voice', 'Child just moved from another school. Previous SLP was Carrie Davis.', 1),
		('J54765Y4654', 'C123D456', 'Review 1', '03-25-2019', 'Hannah', 'Finkle', 'Sequencing', 'Child just moved from another school. Previous SLP was Jane Fhisher.', 1),
		('L56476P654764', 'C123D456', 'Review 1', '09-04-2019', 'Carrie', 'Davis', 'Voice', 'Child just moved from another school. Previous SLP was Jane Fhisher.', 1)
GO

----------------------------------------------------------------------------------------------------------------------------------

print '' print ' ***Create IEPType Table'
GO
CREATE TABLE [dbo].[IEPType] (
	[IEPType]			nvarchar(50)		NOT NULL,
	[Description]		nvarchar(1000)		NOT NULL,
	
	CONSTRAINT [pk_IEPType] PRIMARY KEY ([IEPType] ASC)
)
GO

print '' print '*** Inserting Records for IEPType'
GO
INSERT INTO [dbo].[IEPType]
		([IEPType], [Description])
	VALUES	
		('Initial', 'This is an IEP type.'),
		('Review 1', 'This is an IEP type.'),
		('Review 2', 'This is an IEP type.'),
		('Re-Eval', 'This is an IEP type.'),
		('Initial Eval', 'This is an IEP type.')
GO


---------------------------------------------------------------------------------------------------------------------

/*

Foreign key constraints

*/


print '' print '*** Adding foreign key NCESID for Teacher'
ALTER TABLE [dbo].[Teacher] WITH NOCHECK 
	ADD CONSTRAINT [fk_NCESID] FOREIGN KEY([NCESID])
	REFERENCES [dbo].[School]([NCESID])
	ON UPDATE CASCADE
GO


print '' print '*** Adding foreign key ManagerID for SLP'
ALTER TABLE [dbo].[SLP] WITH NOCHECK 
	ADD CONSTRAINT [fk_ManagerID] FOREIGN KEY([ManagerID])
	REFERENCES [dbo].[Manager]([ManagerID])
	ON UPDATE CASCADE
GO

print '' print '*** Adding foreign key Grade for Student'
ALTER TABLE [dbo].[Student] WITH NOCHECK 
	ADD CONSTRAINT [fk_Grade] FOREIGN KEY([Grade])
	REFERENCES [dbo].[Grade]([Grade])
	ON UPDATE CASCADE
GO

print '' print '*** Adding foreign key NCESID for Student'
ALTER TABLE [dbo].[Student] WITH NOCHECK 
	ADD CONSTRAINT [fk_NCESID_student] FOREIGN KEY([NCESID])
	REFERENCES [dbo].[School]([NCESID])
	ON UPDATE CASCADE
GO

print '' print '*** Adding foreign key TeacherID for Student'
ALTER TABLE [dbo].[Student] WITH NOCHECK 
	ADD CONSTRAINT [fk_TeacherID] FOREIGN KEY([TeacherID])
	REFERENCES [dbo].[Teacher]([TeacherID])

GO

print '' print '*** Adding foreign key State for Student'
ALTER TABLE [dbo].[Student] WITH NOCHECK 
	ADD CONSTRAINT [fk_StateID] FOREIGN KEY([StateID])
	REFERENCES [dbo].[USState]([StateID])
	ON UPDATE CASCADE
GO


print '' print '*** Adding Foreign Key StudentID for IEP'
GO
ALTER TABLE [dbo].[IEP] WITH NOCHECK
	ADD CONSTRAINT [fk_StudentID] FOREIGN KEY([StudentID])
	REFERENCES [dbo].[Student]([StudentID])
	ON UPDATE CASCADE
GO

print '' print '*** Adding Foreign Key EmployeeID for IEP'
GO
ALTER TABLE [dbo].[IEP] WITH NOCHECK
	ADD CONSTRAINT [fk_SLPID_IEP] FOREIGN KEY([SLPID])
	REFERENCES [dbo].[SLP]([SLPID])
	ON UPDATE CASCADE
GO


print '' print '*** Adding Foreign Key StudentID for IEP'
GO
ALTER TABLE [dbo].[IEP] WITH NOCHECK
	ADD CONSTRAINT [fk_GoalType] FOREIGN KEY([GoalType])
	REFERENCES [dbo].[GoalType]([GoalType])
	ON UPDATE CASCADE
GO

-------------------------------------------------------------------------------------------------------------------------------
	
/*

Stored procedures

*/



/*

DEACTIVATE/DELETE PROCEDURES

*/

print '' print '*** Creating deactivate_iep_by_id'
GO
CREATE PROCEDURE [deactivate_iep_by_id]
	(
		@IEPID		[int]
	)
AS
	BEGIN
		UPDATE 	[IEP]
		SET		[Active] = 0
		WHERE	[IEPID] = @IEPID
		
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating activate_iep_by_id'
GO
CREATE PROCEDURE [activate_iep_by_id]
	(
		@IEPID		[int]
	)
AS
	BEGIN
		UPDATE 	[IEP]
		SET		[Active] = 1
		WHERE	[IEPID] = @IEPID
		
		RETURN @@ROWCOUNT
	END
GO


print '' print '*** Creating sp_delete_student_by_id'
GO
CREATE PROCEDURE [sp_delete_student_by_id]
	(
		@StudentID		[nvarchar](50)
	)
AS
	BEGIN	
		DELETE 
		FROM	[Student]
		WHERE	[StudentID] = @StudentID	   
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_delete_student_iep_by_id'
GO
CREATE PROCEDURE [sp_delete_student_iep_by_id]
	(
		@StudentID		[nvarchar](50)
	)
AS
	BEGIN	
		DELETE 
		FROM	[IEP]
		WHERE	[StudentID] = @StudentID
		AND		[Active] = 0
		RETURN @@ROWCOUNT
	END
GO



--------------------------------------------------------------------------------------------------------------------------

/*


UPDATE PROCEDURES

*/

print '' print '*** Creating sp_update_iep_by_studentid'
GO
CREATE PROCEDURE [sp_update_iep_by_studentid]
	(
	
		@StudentID					[nvarchar](50),

		@IEPType					[nvarchar](50),
		@IEPDate					[date],
		@IEPLeaderFirstName 		[nvarchar](50),
		@IEPLeaderLastName			[nvarchar](50),
		@GoalType					[nvarchar](50),
		@IEPNotes					[nvarchar](4000),
		

		@OldIEPType					[nvarchar](50),
		@OldIEPDate					[date],
		@OldIEPLeaderFirstName 		[nvarchar](50),
		@OldIEPLeaderLastName		[nvarchar](50),
		@OldGoalType				[nvarchar](50),
		@OldIEPNotes				[nvarchar](4000)
	)
AS
	BEGIN
		UPDATE [IEP]
		SET		[IEPType] = @IEPType,
				[IEPDate] = @IEPDate,
				[IEPLeaderFirstName] = @IEPLeaderFirstName,
				[IEPLeaderLastName] = @IEPLeaderLastName,
				[GoalType] = @GoalType,
				[IEPNotes] = @IEPNotes
		WHERE	[StudentID] = @StudentID
		  AND	[IEPType] = @OldIEPType
		  AND	[IEPDate] = @OldIEPDate
		  AND	[IEPLeaderFirstName] = @OldIEPLeaderFirstName
		  AND	[IEPLeaderLastName] = @OldIEPLeaderLastName
		  AND	[GoalType] = @OldGoalType
		  AND	[IEPNotes] = @OldIEPNotes

		RETURN @@ROWCOUNT
	END
GO



print '' print '*** Creating sp_update_student_by_studentid'
GO
CREATE PROCEDURE [sp_update_student_by_studentid]
	(
		@StudentID					[nvarchar](50),
		
		@Birthday					[date],
		@NCESID						[nvarchar](20),
		@Grade						[date],
		@FirstName 					[nvarchar](50),
		@LastName					[nvarchar](100),
		@Address					[nvarchar](30),
		@City						[nvarchar](30),
		@StateID						[nvarchar](2),
		@ZipCode					[nvarchar](7),
		
		@OldBirthday				[date],
		@OldNCESID					[nvarchar](20),
		@OldGrade					[date],
		@OldFirstName 				[nvarchar](50),
		@OldLastName				[nvarchar](100),
		@OldAddress					[nvarchar](30),
		@OldCity					[nvarchar](30),
		@OldStateID					[nvarchar](2),
		@OldZipCode					[nvarchar](7)
	)
AS
	BEGIN
		UPDATE [Student]
		SET		[Birthday] = @Birthday,
				[NCESID] = @NCESID,
				[Grade] = @Grade,
				[FirstName] = @FirstName,
				[LastName] = @LastName,
				[Address] = @Address,
				[City] = @City,
				[StateID] = @StateID,
				[ZipCode] = @ZipCode
		WHERE	[StudentID] = @StudentID
		  AND	[Birthday] = @OldBirthday
		  AND	[Grade] = @OldGrade
		  AND	[FirstName] = @OldFirstName
		  AND	[LastName] = @OldLastName
		  AND	[Address] = @OldAddress
		  AND	[City] = @OldCity
		  AND	[StateID] = @OldStateID
		  AND	[ZipCode] = @OldZipCode

		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_update_student_iep'
GO
CREATE PROCEDURE [dbo].[sp_update_student_iep]
	(
		@IEPType			[nvarchar](50),
		@IEPDate			[date],
		
		@OldIEPType			[nvarchar](50),
		@OldIEPDate			[date]
	)
AS
	BEGIN
		UPDATE	[IEP]
			SET	[IEPType] = @IEPType,
				[IEPDate] = @IEPDate
			WHERE [IEPType] = @OldIEPType
			AND	[IEPDate] = @OldIEPDate
		RETURN @@ROWCOUNT
	END
GO


print '' print '*** Creating sp_update_password_hash_manager'
GO
CREATE PROCEDURE [dbo].[sp_update_password_hash_manager]
	(
		@Email					[nvarchar](250),
		@NewPasswordHash		[nvarchar](100),
		@OldPasswordHash		[nvarchar](100)
	)
AS
	BEGIN
		IF @NewPasswordHash != @OldPasswordHash
		BEGIN
			UPDATE [Manager]
				SET [PasswordHash] = @NewPasswordHash
				WHERE [Email] = @Email
					AND [PasswordHash] = @OldPasswordHash
				RETURN @@ROWCOUNT
		END
	END
GO


print '' print '*** Creating sp_update_password_hash_slp'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordhash_slp]
	(
		@Email					[nvarchar](250),
		@NewPasswordHash		[nvarchar](100),
		@OldPasswordHash		[nvarchar](100)
	)
AS
	BEGIN
		IF @NewPasswordHash != @OldPasswordHash
		BEGIN
			UPDATE [SLP]
				SET [PasswordHash] = @NewPasswordHash
				WHERE [Email] = @Email
					AND [PasswordHash] = @OldPasswordHash
				RETURN @@ROWCOUNT
		END
	END
GO

print '' print '*** Creating sp_update_password_hash_teacher'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordhash_teacher]
	(
		@Email					[nvarchar](250),
		@NewPasswordHash		[nvarchar](100),
		@OldPasswordHash		[nvarchar](100)
	)
AS
	BEGIN
		IF @NewPasswordHash != @OldPasswordHash
		BEGIN
			UPDATE [Teacher]
				SET [PasswordHash] = @NewPasswordHash
				WHERE [Email] = @Email
					AND [PasswordHash] = @OldPasswordHash
				RETURN @@ROWCOUNT
		END
	END
GO

----------------------------------------------------------------------------------------------------------------------

/*

INSERT PROCEDURES

*/


print '' print '** Creating sp_insert_new_student'
GO
CREATE PROCEDURE [dbo].[sp_insert_student]
	(
		@StudentID		[nvarchar](50),
		@Birthday		[date],
		@TeacherID		[nvarchar](50),
		@NCESID			[nvarchar](20),
		@Grade			[nvarchar](15),
		@FirstName		[nvarchar](50),
		@LastName		[nvarchar](100),
		@Address		[nvarchar](30),
		@City			[nvarchar](30),
		@StateID			[nvarchar](2),
		@ZipCode		[nvarchar](7)
	)
AS
	BEGIN
		/* declare @studentID int; */
		
		INSERT INTO [Student] 
			([StudentID], [FirstName], [LastName], [Birthday], [TeacherID], [Grade], [Address], [City], [StateID],  [ZipCode], [NCESID])
		VALUES (@StudentID, @FirstName, @LastName, @Birthday, @TeacherID, @Grade, @Address, @City, @StateID, @ZipCode, @NCESID)
		
		
		SELECT SCOPE_IDENTITY() as 'StudentID'
		
	END
GO



print '' print '*** Creating sp_insert_new_iep'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_iep]
	(
		@StudentID				[nvarchar](50),
		@SLPID					[int],
		@IEPType				[nvarchar](50),
		@IEPDate				[date],
		@IEPLeaderFirstName		[nvarchar](50),
		@IEPLeaderLastName		[nvarchar](50),
		@GoalType				[nvarchar](50),
		@IEPNotes				[nvarchar](4000),
		@Active					[bit]
	)
AS
	BEGIN	
		INSERT INTO [IEP]
			([StudentID], [SLPID], [IEPType], [IEPDate], [IEPLeaderFirstName], [IEPLeaderLastName], [GoalType], [IEPNotes], [Active])
		VALUES (@StudentID, @SLPID, @IEPType, @IEPDate, @IEPLeaderFirstName, @IEPLeaderLastName, @GoalType, @IEPNotes, @Active)

		RETURN @@ROWCOUNT
	END
GO



---------------------------------------------------------------------------------------------------------------------


/* 

RETRIEVE PROCEDURES

 */

 print '' print '*** Creating sp_retrieve_all_users'
 GO
 CREATE PROCEDURE [dbo].[sp_retrieve_all_users]
 AS
	BEGIN
		SELECT	[SLP].[SLPID], [SLP].[FirstName], [SLP].[LastName], [SLP].[Email], [Teacher].[TeacherID], [Teacher].[FirstName], [Teacher].[LastName], [Teacher].[Email]
		FROM	[SLP], [Teacher]
	END
GO


 print '' print '*** Creating sp_retrieve_teacher_info'
 GO
 CREATE PROCEDURE [dbo].[sp_retrieve_teacher_info]
 AS
	BEGIN
		SELECT	[Teacher].[TeacherID], [Teacher].[FirstName], [Teacher].[LastName], [Teacher].[Email]
		FROM	[Teacher]
	END
GO


 print '' print '*** Creating sp_retrieve_all_slp_emails'
 GO
 CREATE PROCEDURE [dbo].[sp_retrieve_all_slp_emails]
	(
		@Email			[nvarchar](250)
	)
 AS
	BEGIN
		SELECT	[SLPID], [FirstName], [LastName]
		FROM 	[SLP]
		WHERE	[Email] = @Email
	END
 GO
 
 print '' print '*** Creating sp_retrieve_all_manager_emails'
 GO
 CREATE PROCEDURE [dbo].[sp_retrieve_all_manager_emails]
 	(
		@Email			[nvarchar](250)
	)
 AS
	BEGIN
		SELECT	[ManagerID], [FirstName], [LastName]
		FROM 	[Manager]
		WHERE	[Email] = @Email
	END
GO
 
 print '' print '*** Creating sp_retrieve_all_teacher_emails'
 GO
 CREATE PROCEDURE [dbo].[sp_retrieve_all_teacher_emails]
 	(
		@Email			[nvarchar](250)
	)
 AS
	BEGIN
		SELECT	[TeacherID], [FirstName], [LastName]
		FROM 	[Teacher]
		WHERE	[Email] = @Email
	END
GO
 
print '' print '*** Creating sp_retrieve_student_info'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_student_info]
AS
	BEGIN
		SELECT	[Student].[StudentID], [School].[Name], [Student].[NCESID], [Student].[Birthday], [Student].[Grade], [Student].[FirstName], 
				[Student].[LastName], [IEP].[IEPType], [IEP].[IEPDate], [IEP].[IEPLeaderFirstName], [IEP].[IEPLeaderLastName], 
				[IEP].[IEPNotes], [Student].[Address], [Student].[City], [Student].[StateID], [Student].[ZipCode], [IEP].[GoalType], 
				[IEP].[Active]
		FROM	[School] 
				LEFT JOIN [Student] ON [School].[NCESID] = [Student].[NCESID]
				LEFT JOIN [IEP] ON [Student].[StudentID] = [IEP].[StudentID]
	END
GO



print '' print '*** Creating sp_retrieve_student_info_by_id'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_student_info_by_id]
	(
		@StudentID		[nvarchar](50)
	)
AS
	BEGIN
		SELECT	[Student].[StudentID], [School].[Name], [Student].[NCESID], [Student].[Birthday], [Student].[Grade], [Student].[FirstName], 
				[Student].[LastName], [IEP].[IEPID], [IEP].[IEPType], [IEP].[IEPDate], [IEP].[IEPLeaderFirstName], [IEP].[IEPLeaderLastName], 
				[IEP].[IEPNotes], [Student].[Address], [Student].[City], [Student].[StateID], [Student].[ZipCode], [IEP].[GoalType], 
				[IEP].[Active]
		FROM	[School] 
				LEFT JOIN [Student] ON [School].[NCESID] = [Student].[NCESID]
				LEFT JOIN [IEP] ON [Student].[StudentID] = [IEP].[StudentID]
		WHERE	[Student].[StudentID] = @StudentID	
	END
GO



print '' print '*** Creating sp_retrieve_student_info_by_teacherID'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_student_info_by_teacherID]
	(
		@TeacherID			[nvarchar](50)
	)
AS
	BEGIN
		SELECT	[Student].[StudentID], [School].[Name], [Student].[NCESID], [Student].[Birthday], [Student].[TeacherID], [Student].[Grade], [Student].[FirstName], [Student].[LastName], [IEP].[IEPType], [IEP].[IEPDate], [IEP].[IEPLeaderFirstName], [IEP].[IEPLeaderLastName], [IEP].[IEPNotes], [Student].[Address], 
		[Student].[City], [Student].[StateID], [Student].[ZipCode], [IEP].[GoalType], [IEP].[Active]
		FROM	[School] 
				Inner Join [Student] ON [School].[NCESID] = [Student].[NCESID]
				Inner JOIN [IEP] ON [Student].[StudentID] = [IEP].[StudentID]
		WHERE	[Student].[TeacherID] = @TeacherID
	END
GO


print '' print '*** Creating sp_retrieve_student_info_by_slpID'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_student_info_by_slpID]
	(
		@SLPID			[nvarchar](50)
	)
AS
	BEGIN
		SELECT	[Student].[StudentID], [School].[Name], [Student].[NCESID], [Student].[Birthday], [Student].[Grade], [Student].[FirstName], [Student].[LastName], [IEP].[IEPType], [IEP].[IEPDate], [IEP].[IEPLeaderFirstName], [IEP].[IEPLeaderLastName], [IEP].[IEPNotes], [Student].[Address], [Student].[City], [Student].[StateID], [Student].[ZipCode], [IEP].[GoalType], [IEP].[Active],  [IEP].[SLPID]
		FROM	[School] 
				Inner Join [Student] ON [School].[NCESID] = [Student].[NCESID]
				Inner JOIN [IEP] ON [Student].[StudentID] = [IEP].[StudentID]
		WHERE	[IEP].[SLPID] = @SLPID
	END
GO


/*
print '' print '*** Creating sp_retrieve_all_users'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_users]
AS
	BEGIN
		SELECT [SLP].[FirstName], [SLP].[LastName], [SLP].[Email], [Teacher].[FirstName], [Teacher].[LastName], [Teacher].[Email]
		FROM [SLP] Full Outer Join [Teacher] ON [SLP].[Email] = [Teacher].[Email]
	END
GO
*/

/*
print '' print '*** Creating sp_retrieve_all_users'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_users]
AS
	BEGIN
		SELECT	[SLP].[FirstName], [SLP].[LastName], [SLP].[Email], [Teacher].[FirstName], 
				[Teacher].[LastName], [Teacher].[Email]
		FROM	[SLP], [Teacher]
		WHERE 	
	END
GO	
*/

print '' print '*** Creating sp_retrieve_all_iep_types'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_iep_types]
AS
	BEGIN
		SELECT		[IEPType]
		FROM		[IEPType]
		ORDER BY	[IEPType]
END

print '' print '*** Creating sp_retrieve_all_grade'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_grade]
AS
	BEGIN
		SELECT		[Grade]
		FROM		[Grade]
		ORDER BY	[Grade]
END


print '' print '*** Creating sp_retrieve_all_schools'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_schools]
AS
	BEGIN
		SELECT		[Name]
		FROM		[School]
		ORDER BY	[Name]
END

print '' print '*** Creating sp_retrieve_all_goaltypes'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_goaltypes]
AS
	BEGIN
		SELECT		[GoalType]
		FROM		[GoalType]
		ORDER BY	[GoalType]
END

print '' print '*** Creating sp_retrieve_slpid'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_slpid]
AS
	BEGIN
		SELECT		[SLPID]
		FROM		[SLP]
		ORDER BY	[SLPID]
END


print '' print '*** Creating sp_retrieve_all_stateID'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_stateID]
AS
	BEGIN
		SELECT		[StateID]
		FROM		[USState]
		ORDER BY	[StateID]
END


print '' print '*** Creating sp_retrieve_teacher_names'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_teacher_names]
AS
	BEGIN
		SELECT		[FirstName]
		FROM		[Teacher]
		ORDER BY	[FirstName]
END


print '' print '*** Creating sp_get_manager_username_by_email'
GO
CREATE PROCEDURE sp_get_manager_username_by_email
	(
		@Email				[nvarchar](250)
	)
AS
BEGIN
	SELECT [ManagerID], [FirstName], [LastName]
	FROM   [Manager]
	WHERE  [Email] = @Email
END
GO

print '' print '*** Creating sp_get_slp_username_by_email'
GO
CREATE PROCEDURE sp_get_slp_username_by_email
	(
		@Email				[nvarchar](250)
	)
AS
BEGIN
	SELECT [SLPID], [FirstName], [LastName], [ManagerID]
	FROM   [SLP]
	WHERE  [Email] = @Email
END
GO

print '' print '*** Creating sp_get_teacher_username_by_email'
GO
CREATE PROCEDURE sp_get_teacher_username_by_email
	(
		@Email				[nvarchar](250)
	)
AS
BEGIN
	SELECT [TeacherID], [NCESID], [FirstName], [LastName]
	FROM   [Teacher]
	WHERE  [Email] = @Email
END
GO



print '' print '*** Creating sp_authenticate_manager'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_manager]
	(
		@Email						[nvarchar](250),
		@PasswordHash				[nvarchar](100)
	)
AS
	BEGIN
		SELECT COUNT ([ManagerID])
		FROM [Manager] 
		WHERE [Email] = @Email
			AND [PasswordHash] = @PasswordHash
	END
GO

print '' print '*** Creating sp_authenticate_slp'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_slp]
	(
		@Email						[nvarchar](250),
		@PasswordHash				[nvarchar](100)
	)
AS
	BEGIN
		SELECT COUNT ([SLPID])
		FROM [SLP] 
		WHERE [Email] = @Email
			AND [PasswordHash] = @PasswordHash
	END
GO

print '' print '*** Creating sp_authenticate_teacher'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_teacher]
	(
		@Email						[nvarchar](250),
		@PasswordHash				[nvarchar](100)
	)
AS
	BEGIN
		SELECT COUNT ([TeacherID])
		FROM [Teacher] 
		WHERE [Email] = @Email
			AND [PasswordHash] = @PasswordHash
	END
GO



	
	
	
	