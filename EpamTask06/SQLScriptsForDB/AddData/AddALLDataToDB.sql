USE [University];

/* Add Specialities */

INSERT INTO [Speciality] VALUES (N'ИТ',N'Информационные Технологии');
INSERT INTO [Speciality] VALUES (N'ЭУ',N'Экономика и управление на предприятии');

/* --------------------------------------------------------------------------- */

/* Add Subjects */

INSERT INTO [Subject] VALUES (N'Математика',20,30);
INSERT INTO [Subject] VALUES (N'Программирование',20,30);
INSERT INTO [Subject] VALUES (N'Экономика',20,30);
INSERT INTO [Subject] VALUES (N'Философия',15,18);
INSERT INTO [Subject] VALUES (N'Физкультура',0,20);
INSERT INTO [Subject] VALUES (N'Физика',20,20);
INSERT INTO [Subject] VALUES (N'История',20,20);
INSERT INTO [Subject] VALUES (N'ООП',20,30);

/* --------------------------------------------------------------------------- */

/* Add Sessions */

INSERT INTO [Session] VALUES (N'Зимняя Сессия 2018','2018-01-05','2018-01-30');
INSERT INTO [Session] VALUES (N'Летняя Сессия 2018','2018-06-05','2018-06-28');

/* --------------------------------------------------------------------------- */

/* Add Groups */

INSERT INTO [Group] VALUES (1,1,1);
INSERT INTO [Group] VALUES (1,1,2);

/* --------------------------------------------------------------------------- */

/* Add Students */

INSERT INTO [Student] VALUES (N'Павел Свинтицкий','1999-02-01',1,0);
INSERT INTO [Student] VALUES (N'Петр Петров','1997-04-10',1,0);
INSERT INTO [Student] VALUES (N'Свин Павлицкий','1997-10-15',1,0);
INSERT INTO [Student] VALUES (N'Петр Иванов','1997-04-10',1,0);
INSERT INTO [Student] VALUES (N'Павел Иванов','1998-03-05',1,0);
INSERT INTO [Student] VALUES (N'Петр Тручек','1997-01-07',1,0);
INSERT INTO [Student] VALUES (N'Иван Иванов','1998-03-27',1,0);
INSERT INTO [Student] VALUES (N'Иван Петров','1999-07-14',1,0);


INSERT INTO [Student] VALUES (N'Денис Иванов','1996-09-01',2,0);
INSERT INTO [Student] VALUES (N'Петр Смирнов','2000-05-10',2,0);
INSERT INTO [Student] VALUES (N'Олег Смирнов','1998-05-15',2,0);
INSERT INTO [Student] VALUES (N'Кирилл Петров','1999-07-10',2,0);
INSERT INTO [Student] VALUES (N'Андрей Иванов','1998-09-05',2,0);
INSERT INTO [Student] VALUES (N'Олег Тручек','1997-01-09',2,0);

/* --------------------------------------------------------------------------- */

/* Add Examination Events */

INSERT INTO [ExaminationEvent] VALUES(5,1,'2018-01-07',1,1);
INSERT INTO [ExaminationEvent] VALUES(5,2,'2018-01-09',1,1);


INSERT INTO [ExaminationEvent] VALUES(1,1,'2018-01-12',0,1);
INSERT INTO [ExaminationEvent] VALUES(2,1,'2018-01-17',0,1);
INSERT INTO [ExaminationEvent] VALUES(4,1,'2018-01-22',0,1);
INSERT INTO [ExaminationEvent] VALUES(6,1,'2018-01-27',0,1);

INSERT INTO [ExaminationEvent] VALUES(4,2,'2018-01-14',0,1);
INSERT INTO [ExaminationEvent] VALUES(3,2,'2018-01-19',0,1);
INSERT INTO [ExaminationEvent] VALUES(7,2,'2018-01-24',0,1);
INSERT INTO [ExaminationEvent] VALUES(1,2,'2018-01-29',0,1);


INSERT INTO [ExaminationEvent] VALUES(5,1,'2018-01-07',1,2);
INSERT INTO [ExaminationEvent] VALUES(5,2,'2018-01-09',1,2);


INSERT INTO [ExaminationEvent] VALUES(1,1,'2018-06-12',0,2);
INSERT INTO [ExaminationEvent] VALUES(8,1,'2018-06-17',0,2);
INSERT INTO [ExaminationEvent] VALUES(7,1,'2018-06-22',0,2);
INSERT INTO [ExaminationEvent] VALUES(6,1,'2018-06-27',0,2);

INSERT INTO [ExaminationEvent] VALUES(3,2,'2018-06-14',0,2);
INSERT INTO [ExaminationEvent] VALUES(7,2,'2018-06-19',0,2);
INSERT INTO [ExaminationEvent] VALUES(4,2,'2018-06-24',0,2);
INSERT INTO [ExaminationEvent] VALUES(1,2,'2018-06-29',0,2);

/* --------------------------------------------------------------------------- */

/* Add Students Grades */

/*	First Session FirstGroup */
INSERT INTO [StudentsGrade] VALUES (1,1,9,1);
INSERT INTO [StudentsGrade] VALUES (2,1,7,1);
INSERT INTO [StudentsGrade] VALUES (3,1,8,1);
INSERT INTO [StudentsGrade] VALUES (4,1,9,1);
INSERT INTO [StudentsGrade] VALUES (5,1,4,1);
INSERT INTO [StudentsGrade] VALUES (6,1,7,1);
INSERT INTO [StudentsGrade] VALUES (7,1,7,1);
INSERT INTO [StudentsGrade] VALUES (8,1,5,1);

INSERT INTO [StudentsGrade] VALUES (1,2,3,1);
INSERT INTO [StudentsGrade] VALUES (2,2,2,1);
INSERT INTO [StudentsGrade] VALUES (3,2,6,1);
INSERT INTO [StudentsGrade] VALUES (4,2,6,1);
INSERT INTO [StudentsGrade] VALUES (5,2,5,1);
INSERT INTO [StudentsGrade] VALUES (6,2,7,1);
INSERT INTO [StudentsGrade] VALUES (7,2,4,1);
INSERT INTO [StudentsGrade] VALUES (8,2,4,1);

INSERT INTO [StudentsGrade] VALUES (1,4,3,1);
INSERT INTO [StudentsGrade] VALUES (2,4,2,1);
INSERT INTO [StudentsGrade] VALUES (3,4,5,1);
INSERT INTO [StudentsGrade] VALUES (4,4,4,1);
INSERT INTO [StudentsGrade] VALUES (5,4,7,1);
INSERT INTO [StudentsGrade] VALUES (6,4,7,1);
INSERT INTO [StudentsGrade] VALUES (7,4,7,1);
INSERT INTO [StudentsGrade] VALUES (8,4,7,1);


INSERT INTO [StudentsGrade] VALUES (1,6,8,1);
INSERT INTO [StudentsGrade] VALUES (2,6,4,1);
INSERT INTO [StudentsGrade] VALUES (3,6,3,1);
INSERT INTO [StudentsGrade] VALUES (4,6,2,1);
INSERT INTO [StudentsGrade] VALUES (5,6,7,1);
INSERT INTO [StudentsGrade] VALUES (6,6,7,1);
INSERT INTO [StudentsGrade] VALUES (7,6,5,1);
INSERT INTO [StudentsGrade] VALUES (8,6,8,1);
/*---------------------------------------------*/

/* Second Group */

INSERT INTO [StudentsGrade] VALUES (9,4,5,1);
INSERT INTO [StudentsGrade] VALUES (10,4,4,1);
INSERT INTO [StudentsGrade] VALUES (11,4,4,1);
INSERT INTO [StudentsGrade] VALUES (12,4,8,1);
INSERT INTO [StudentsGrade] VALUES (13,4,9,1);
INSERT INTO [StudentsGrade] VALUES (14,4,7,1);

INSERT INTO [StudentsGrade] VALUES (9,3,3,1);
INSERT INTO [StudentsGrade] VALUES (10,3,2,1);
INSERT INTO [StudentsGrade] VALUES (11,3,4,1);
INSERT INTO [StudentsGrade] VALUES (12,3,9,1);
INSERT INTO [StudentsGrade] VALUES (13,3,5,1);
INSERT INTO [StudentsGrade] VALUES (14,3,8,1);

INSERT INTO [StudentsGrade] VALUES (9,7,3,1);
INSERT INTO [StudentsGrade] VALUES (10,7,4,1);
INSERT INTO [StudentsGrade] VALUES (11,7,5,1);
INSERT INTO [StudentsGrade] VALUES (12,7,6,1);
INSERT INTO [StudentsGrade] VALUES (13,7,6,1);
INSERT INTO [StudentsGrade] VALUES (14,7,9,1);

INSERT INTO [StudentsGrade] VALUES (9,1,6,1);
INSERT INTO [StudentsGrade] VALUES (10,1,4,1);
INSERT INTO [StudentsGrade] VALUES (11,1,5,1);
INSERT INTO [StudentsGrade] VALUES (12,1,8,1);
INSERT INTO [StudentsGrade] VALUES (13,1,9,1);
INSERT INTO [StudentsGrade] VALUES (14,1,9,1);
/*---------------------------------------------*/



/* Second Session FirstGroup */

INSERT INTO [StudentsGrade] VALUES (1,1,9,2);
INSERT INTO [StudentsGrade] VALUES (2,1,4,2);
INSERT INTO [StudentsGrade] VALUES (3,1,8,2);
INSERT INTO [StudentsGrade] VALUES (4,1,7,2);
INSERT INTO [StudentsGrade] VALUES (5,1,7,2);
INSERT INTO [StudentsGrade] VALUES (6,1,8,2);
INSERT INTO [StudentsGrade] VALUES (7,1,8,2);
INSERT INTO [StudentsGrade] VALUES (8,1,6,2);

INSERT INTO [StudentsGrade] VALUES (1,8,7,2);
INSERT INTO [StudentsGrade] VALUES (2,8,3,2);
INSERT INTO [StudentsGrade] VALUES (3,8,5,2);
INSERT INTO [StudentsGrade] VALUES (4,8,5,2);
INSERT INTO [StudentsGrade] VALUES (5,8,8,2);
INSERT INTO [StudentsGrade] VALUES (6,8,8,2);
INSERT INTO [StudentsGrade] VALUES (7,8,7,2);
INSERT INTO [StudentsGrade] VALUES (8,8,9,2);

INSERT INTO [StudentsGrade] VALUES (1,7,7,2);
INSERT INTO [StudentsGrade] VALUES (2,7,2,2);
INSERT INTO [StudentsGrade] VALUES (3,7,3,2);
INSERT INTO [StudentsGrade] VALUES (4,7,5,2);
INSERT INTO [StudentsGrade] VALUES (5,7,7,2);
INSERT INTO [StudentsGrade] VALUES (6,7,7,2);
INSERT INTO [StudentsGrade] VALUES (7,7,7,2);
INSERT INTO [StudentsGrade] VALUES (8,7,7,2);


INSERT INTO [StudentsGrade] VALUES (1,6,7,2);
INSERT INTO [StudentsGrade] VALUES (2,6,7,2);
INSERT INTO [StudentsGrade] VALUES (3,6,5,2);
INSERT INTO [StudentsGrade] VALUES (4,6,5,2);
INSERT INTO [StudentsGrade] VALUES (5,6,8,2);
INSERT INTO [StudentsGrade] VALUES (6,6,9,2);
INSERT INTO [StudentsGrade] VALUES (7,6,7,2);
INSERT INTO [StudentsGrade] VALUES (8,6,7,2);
/*---------------------------------------------*/



/* Second Group */

INSERT INTO [StudentsGrade] VALUES (9,3,4,2);
INSERT INTO [StudentsGrade] VALUES (10,3,6,2);
INSERT INTO [StudentsGrade] VALUES (11,3,3,2);
INSERT INTO [StudentsGrade] VALUES (12,3,7,2);
INSERT INTO [StudentsGrade] VALUES (13,3,8,2);
INSERT INTO [StudentsGrade] VALUES (14,3,8,2);

INSERT INTO [StudentsGrade] VALUES (9,7,4,2);
INSERT INTO [StudentsGrade] VALUES (10,7,3,2);
INSERT INTO [StudentsGrade] VALUES (11,7,3,2);
INSERT INTO [StudentsGrade] VALUES (12,7,8,2);
INSERT INTO [StudentsGrade] VALUES (13,7,6,2);
INSERT INTO [StudentsGrade] VALUES (14,7,9,2);

INSERT INTO [StudentsGrade] VALUES (9,4,2,2);
INSERT INTO [StudentsGrade] VALUES (10,4,3,2);
INSERT INTO [StudentsGrade] VALUES (11,4,6,2);
INSERT INTO [StudentsGrade] VALUES (12,4,7,2);
INSERT INTO [StudentsGrade] VALUES (13,4,7,2);
INSERT INTO [StudentsGrade] VALUES (14,4,7,2);

INSERT INTO [StudentsGrade] VALUES (9,1,6,2);
INSERT INTO [StudentsGrade] VALUES (10,1,4,2);
INSERT INTO [StudentsGrade] VALUES (11,1,5,2);
INSERT INTO [StudentsGrade] VALUES (12,1,8,2);
INSERT INTO [StudentsGrade] VALUES (13,1,9,2);
INSERT INTO [StudentsGrade] VALUES (14,1,9,2);
/*---------------------------------------------*/

/* --------------------------------------------------------------------------- */