--create database SpartaGlobalDB


--use SpartaGlobalDB

--create table Courses(
--	CourseId int not null identity primary key,
--	CourseName nvarchar(50),
--	CourseType varchar(50)
--)

--create table Students(
--	StudentId int not null identity primary key,
--	StudentName nvarchar(50),
--	Score int,
--	CourseId int FOREIGN KEY REFERENCES Courses(CourseId)
--)

--insert into Courses values ('Engineering 66', 'C# Dev'), ('Engineering 58', 'Java Dev'), ('Engineering 67', 'DevOps')
insert into Students values ('Leo', 8, 1), ('Harry', 8, 1), ('Chen', 9, 1), ('John', 6, 2), ('Jane', 8, 2), ('Paul', 7, 2), ('Josephine', 6, 3), ('Mary', 9, 3),
							('James', 10, 3)


select * from Courses
select * from Students