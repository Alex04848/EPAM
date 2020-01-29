USE [University];

SELECT (SELECT [AbreviationOfSpeciality] FROM [Speciality] WHERE [SpecialityID] = [ID]) +   
 '-' + CAST([NumOfCourse] AS NVARCHAR) + '' + CAST([NumOfGroup] AS NVARCHAR)  AS GroupOfUniversity
FROM [Group]
