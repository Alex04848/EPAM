USE [University];

DECLARE @IDOfGroup INT;

/*
	FirstGroup = 1
	SecondGroup = 2

*/

SET @IDOfGroup = 1;


SELECT [FullName],  
(SELECT ((SELECT [AbreviationOfSpeciality] FROM [Speciality] WHERE [ID] = [SpecialityID])
+ '-' + CAST([NumOfCourse] AS NVARCHAR) + 
CAST([NumOfGroup] AS NVARCHAR)) 

 FROM [Group] WHERE [ID] = GroupID) AS GroupName

 FROM [Student] WHERE [GroupID] = @IDOfGroup;
