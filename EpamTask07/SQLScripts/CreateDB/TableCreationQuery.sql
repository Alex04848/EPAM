USE [University];


CREATE TABLE Speciality(
	ID INT PRIMARY KEY IDENTITY(1,1),
	AbreviationOfSpeciality NVARCHAR(20),
	FullNameOfSpeciality NVARCHAR(50)
);

CREATE TABLE Teacher(
	ID INT PRIMARY KEY IDENTITY(1,1),
	FullName NVARCHAR(50),
	DateOfBirth Date,
	Gender INT DEFAULT 0
);

CREATE TABLE [Group](
	ID INT PRIMARY KEY IDENTITY(1,1),
	NumOfCourse INT DEFAULT 0,
	NumOfGroup INT DEFAULT 0,
	SpecialityID INT DEFAULT 0,
	CHECK (NumOfCourse >= 0 AND NumOfGroup >= 0),
	FOREIGN KEY (SpecialityID) REFERENCES Speciality(ID)
);


CREATE TABLE [Subject](
	ID INT PRIMARY KEY IDENTITY(1,1),
	NameOfSubject NVARCHAR(20),
	CountOfLections INT DEFAULT 0,
	CountOfPractice INT DEFAULT 0,
	CHECK (CountOfLections >= 0 AND CountOfPractice >= 0) 
);

CREATE TABLE [Session](
	ID INT PRIMARY KEY IDENTITY(1,1),
	NameOfSession NVARCHAR(20),
	StartDate Date,
	EndDate Date,
	CHECK (EndDate > StartDate)
);

CREATE TABLE Student(
	ID INT PRIMARY KEY IDENTITY(1,1),
	FullName NVARCHAR(50),
	DateOfBirth Date,
	GroupID INT DEFAULT 0,
	Gender INT DEFAULT 0,
	CHECK (Gender = 0 OR Gender = 1),
	FOREIGN KEY (GroupID) REFERENCES [Group](ID)
);

CREATE TABLE StudentsGrade(
	ID INT PRIMARY KEY IDENTITY(1,1),
	StudentID INT DEFAULT 0,
	SubjectID INT DEFAULT 0,
	Grade INT DEFAULT 0,
	SessionID INT DEFAULT 0,
	TeacherID INT DEFAULT 0,
	CHECK (Grade >= 0 AND Grade <= 10),
	FOREIGN KEY (StudentID) REFERENCES Student(ID),
	FOREIGN KEY (SubjectID) REFERENCES [Subject](ID),
	FOREIGN KEY (SessionID) REFERENCES [Session](ID),
	FOREIGN KEY (TeacherID) REFERENCES [Teacher](ID)
);

CREATE TABLE ExaminationEvent(
	ID INT PRIMARY KEY IDENTITY(1,1),
	SubjectID INT DEFAULT 0,
	GroupID INT DEFAULT 0,
	DateOfExam Date,
	TypeOfEvent INT DEFAULT 0,
	SessionID INT DEFAULT 0,
	TeacherID INT DEFAULT 0,
	CHECK (TypeOfEvent = 0 OR TypeOfEvent = 1),
	FOREIGN KEY (SubjectID) REFERENCES [Subject](ID),
	FOREIGN KEY (GroupID) REFERENCES [Group](ID),
	FOREIGN KEY (SessionID) REFERENCES [Session](ID),
	FOREIGN KEY (TeacherID) REFERENCES [Teacher](ID)
);
