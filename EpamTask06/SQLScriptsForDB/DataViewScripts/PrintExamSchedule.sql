USE [University];

DECLARE @IDForGroup INT;
DECLARE @IDForSession INT;

/*
	WinterSession_2018 = 1
	SummerSession_2018 = 1
	----------------------
	FirstGroup = 1
	SecondGroup = 2
*/


SET @IDForGroup = 1;
SET @IDForSession = 1;


SELECT [ID],
(SELECT [ID] FROM [Subject] WHERE [ID] = [SubjectID]) AS [SubjID],
(SELECT [NameOfSubject] FROM [Subject] WHERE [ID] = [SubjectID]) AS ExamName,
(SELECT (SELECT [AbreviationOfSpeciality] FROM [Speciality] WHERE [ID] = [SpecialityID]) 
+ CAST([NumOfGroup] AS NVARCHAR)  + CAST([NumOfGroup] AS NVARCHAR) FROM [Group] WHERE [ID] = [GroupID]) AS GroupName,
[DateOfExam]

 FROM [ExaminationEvent] 

WHERE [GroupID] = @IDForGroup AND [TypeOfEvent] = 0 AND [SessionID] = @IDForSession;