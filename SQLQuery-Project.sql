create table Admin(
Id int primary key identity (1,1),
Name varchar(100) not null check (len(trim(Name)) >0 ),
Email varchar(100) unique not null check (len(trim(Email)) >0 ),
Password varchar(20) not null check (len(trim(Password)) >=6 ),
);

create table Student(
Id int primary key identity (1,1),
Name varchar(100) not null check (len(trim(Name)) >0 ),
Email varchar(100) unique not null check (len(trim(Email)) >0 ),
Password varchar(20) not null check (len(trim(Password)) >=6 ),
Grade int check (Grade > 0)
);

create table Teacher(
Id int primary key identity (1,1),
Name varchar(30) not null check (len(trim(Name)) >0 ),
Email varchar(30) unique not null check (len(trim(Email)) >0 ),
Password varchar(20) not null check (len(trim(Password)) >=6 ),
Title varchar(100)
);

create table Course(
Id int primary key identity (1,1),
Name varchar(100) unique not null check (len(trim(Name)) >0 ),
NumberOfLessons int not null check(NumberOfLessons>0),
Category varchar(100) not null check (len(trim(Category)) >0 ),
Duration int not null check (Duration >0),
Adminid int not null ,
foreign key(Adminid) references Admin(Id),
Teacherid int,
foreign key(Teacherid) references Teacher(Id),
);
create table Enrollment(
    Id int primary key identity(1,1),
    Studentid int not null,
    Courseid int not null,
    foreign key(Studentid) references Student(Id),
    foreign key(Courseid) references Course(Id),
);

create table Quiz(
Id int primary key identity (1,1),
Name varchar(100) not null check (len(trim(Name)) >0 ),
Duration int not null check (Duration >0),
CourseId int not null ,
foreign key(Courseid) references Course(Id),

);


create table Questions(
Id int primary key identity (1,1),
TypeOfQuestion varchar(50) not null check (len(trim(TypeOfQuestion)) >0 and TypeOfQuestion in('ShortAnswerQuestion','MultipleChoiceQuestion','TrueFalseQuestion') ),
Text varchar(max) not null check (len(trim(Text)) >0 ),
Mark decimal(5,2) not null check(Mark > 0 and Mark <100),
CorrectAnswer varchar(100) not null check (len(trim(CorrectAnswer)) >0 ),
Quizid int not null ,
foreign key (Quizid) references Quiz(Id)
);

create table QuizAttempt(
Id int primary key identity (1,1),
StudentAnswers varchar(200) not null check (len(trim(StudentAnswers)) >0 ),
Score int not null check(Score>=0),
TimeTaken int not null check(TimeTaken>0),
Studentid int not null,
Quizid int not null ,
foreign key (Studentid) references Student(Id),
foreign key (Quizid) references Quiz(Id),
);

create table questionoption (
id int primary key identity(1,1),
questionid int not null,
optiontext varchar(200) not null
check (len(trim(optiontext)) > 0),
foreign key (questionid) references questions(id)
);

create table questionanswer (
id int primary key identity(1,1),
questionid int not null,
answertext varchar(200) not null
check (len(trim(answertext)) > 0),
foreign key (questionid) references questions(id)
);

insert into Admin(Name,Email,Password)
values 
    ('Mazen',    'ahmed.admin@school.com',    'Admin@123456'),
    ('Mohamed',  'mohamed.admin@school.com',  'Admin@234567'),
    ('Ali',      'ali.admin@school.com',      'Admin@345678'),
    ('Sara',     'sara.admin@school.com',     'Admin@456789'),
    ('Mona',     'mona.admin@school.com',     'Admin@567890'),
    ('Khaled',   'khaled.admin@school.com',   'Admin@678901'),
    ('Youssef',  'youssef.admin@school.com',  'Admin@789012'),
    ('Fatma',    'fatma.admin@school.com',    'Admin@890123'),
    ('Omar',     'omar.admin@school.com',     'Admin@901234'),
    ('Nour',     'nour.admin@school.com',     'Admin@012345'),
    ('Hassan',   'hassan.admin@school.com',   'Admin@112233'),
    ('Aya',      'aya.admin@school.com',      'Admin@223344'),
    ('Mostafa',  'mostafa.admin@school.com',  'Admin@334455'),
    ('Salma',    'salma.admin@school.com',    'Admin@445566'),
    ('Ibrahim',  'ibrahim.admin@school.com',  'Admin@556677'),
    ('Hana',     'hana.admin@school.com',     'Admin@667788'),
    ('Tarek',    'tarek.admin@school.com',    'Admin@778899'),
    ('Dina',     'dina.admin@school.com',     'Admin@889900'),
    ('Mahmoud',  'mahmoud.admin@school.com',  'Admin@990011'),
    ('Rana',     'rana.admin@school.com',     'Admin@101010');
insert into Student(Name,Email,Password,Grade)
values
    ('Mazen',     'sara.student@school.com',     'Student@123456', 'Grade 1'),
    ('Youssef',  'youssef.student@school.com',  'Student@234567', 'Grade 1'),
    ('Mariam',   'mariam.student@school.com',   'Student@345678', 'Grade 2'),
    ('Omar',     'omar.student@school.com',     'Student@456789', 'Grade 2'),
    ('Hana',     'hana.student@school.com',     'Student@567890', 'Grade 3'),
    ('Ali',      'ali.student@school.com',      'Student@678901', 'Grade 3'),
    ('Nour',     'nour.student@school.com',     'Student@789012', 'Grade 4'),
    ('Khaled',   'khaled.student@school.com',   'Student@890123', 'Grade 4'),
    ('Fatma',    'fatma.student@school.com',    'Student@901234', 'Grade 5'),
    ('Mostafa',  'mostafa.student@school.com',  'Student@012345', 'Grade 5'),
    ('Aya',      'aya.student@school.com',      'Student@112233', 'Grade 6'),
    ('Tarek',    'tarek.student@school.com',    'Student@223344', 'Grade 6'),
    ('Salma',    'salma.student@school.com',    'Student@334455', 'Grade 7'),
    ('Ibrahim',  'ibrahim.student@school.com',  'Student@445566', 'Grade 7'),
    ('Dina',     'dina.student@school.com',     'Student@556677', 'Grade 8'),
    ('Mahmoud',  'mahmoud.student@school.com',  'Student@667788', 'Grade 8'),
    ('Rana',     'rana.student@school.com',     'Student@778899', 'Grade 9'),
    ('Hassan',   'hassan.student@school.com',   'Student@889900', 'Grade 9'),
    ('Mona',     'mona.student@school.com',     'Student@990011', 'Grade 10'),
    ('Ahmed',    'ahmed.student@school.com',    'Student@101010', 'Grade 10');

INSERT INTO Teacher (Name, Email, Password, Title)
VALUES 
    ('Ahmed Hassan',    'ahmed.hassan@school.com',    'Teacher@123456', 'Mathematics Teacher'),
    ('Mohamed Ali',     'mohamed.ali@school.com',     'Teacher@234567', 'Physics Teacher'),
    ('Sara Ibrahim',    'sara.ibrahim@school.com',    'Teacher@345678', 'Chemistry Teacher'),
    ('Mona Khaled',     'mona.khaled@school.com',     'Teacher@456789', 'Biology Teacher'),
    ('Youssef Tarek',   'youssef.tarek@school.com',   'Teacher@567890', 'English Teacher'),
    ('Fatma Mahmoud',   'fatma.mahmoud@school.com',   'Teacher@678901', 'Arabic Teacher'),
    ('Omar Mostafa',    'omar.mostafa@school.com',    'Teacher@789012', 'History Teacher'),
    ('Nour Adel',       'nour.adel@school.com',       'Teacher@890123', 'Geography Teacher'),
    ('Hassan Samir',    'hassan.samir@school.com',    'Teacher@901234', 'Computer Science Teacher'),
    ('Aya Waleed',      'aya.waleed@school.com',      'Teacher@012345', 'Art Teacher'),
    ('Mostafa Nabil',   'mostafa.nabil@school.com',   'Teacher@112233', 'Music Teacher'),
    ('Salma Hany',      'salma.hany@school.com',      'Teacher@223344', 'PE Teacher'),
    ('Ibrahim Fathy',   'ibrahim.fathy@school.com',   'Teacher@334455', 'Math Teacher'),
    ('Hana Gamal',      'hana.gamal@school.com',      'Teacher@445566', 'Science Teacher'),
    ('Tarek Ashraf',    'tarek.ashraf@school.com',    'Teacher@556677', 'French Teacher'),
    ('Dina Sherif',     'dina.sherif@school.com',     'Teacher@667788', 'German Teacher'),
    ('Mahmoud Rami',    'mahmoud.rami@school.com',    'Teacher@778899', 'IT Teacher'),
    ('Rana Amr',        'rana.amr@school.com',        'Teacher@889900', 'Economics Teacher'),
    ('Khaled Sameh',    'khaled.sameh@school.com',    'Teacher@990011', 'Statistics Teacher'),
    ('Ali Yasser',      'ali.yasser@school.com',      'Teacher@101010', 'Philosophy Teacher');

INSERT INTO Course (Name, NumberOfLessons, Category, Duration, AdminId, TeacherId)
VALUES 
    ('Introduction to Programming',  20, 'Programming',        12, 1, 1),
    ('Advanced C#',                  30, 'Programming',        16, 1, 1),
    ('Web Development Basics',       25, 'Web Development',    14, 1, 5),
    ('HTML & CSS Mastery',           18, 'Web Development',    10, 1, 5),
    ('JavaScript Essentials',        22, 'Web Development',    12, 2, 5),
    ('React Fundamentals',           28, 'Web Development',    16, 2, 9),
    ('SQL & Databases',              24, 'Database',           12, 2, 9),
    ('Data Structures',              32, 'Computer Science',   18, 3, 13),
    ('Algorithms',                   30, 'Computer Science',   16, 3, 13),
    ('Operating Systems',            26, 'Computer Science',   14, 3, 9),
    ('Computer Networks',            24, 'Networking',         12, 4, 17),
    ('Cyber Security Basics',        20, 'Security',           10, 4, 17),
    ('Python for Beginners',         18, 'Programming',        10, 4, 1),
    ('Machine Learning Intro',       35, 'AI',                 20, 5, 13),
    ('Deep Learning',                40, 'AI',                 22, 5, 13),
    ('Mobile App Development',       28, 'Mobile',             16, 5, 9),
    ('Flutter Basics',               24, 'Mobile',             12, 6, 9),
    ('UI/UX Design',                 16, 'Design',             8,  6, 10),
    ('Graphic Design',               14, 'Design',             8,  6, 10),
    ('Project Management',           12, 'Management',         6,  7, 19);

INSERT INTO Quiz (Name, Duration, CourseId)
VALUES 
    ('C# Basics Quiz 1',              30, 1),
    ('C# Basics Quiz 2',              30, 1),
    ('C# Midterm Exam',               60, 1),
    ('Advanced C# Quiz',              45, 2),
    ('Advanced C# Final Exam',        90, 2),
    ('HTML Basics Quiz',              20, 3),
    ('CSS Layout Quiz',               25, 3),
    ('Web Development Midterm',       50, 3),
    ('HTML & CSS Final Exam',         75, 4),
    ('JavaScript Quiz 1',             30, 5),
    ('JavaScript Quiz 2',             30, 5),
    ('JavaScript Final Exam',         90, 5),
    ('React Components Quiz',         35, 6),
    ('React Hooks Quiz',              35, 6),
    ('React Final Exam',              80, 6),
    ('SQL SELECT Quiz',               25, 7),
    ('SQL Joins Quiz',                30, 7),
    ('Database Midterm Exam',         60, 7),
    ('Data Structures Quiz',          40, 8),
    ('Algorithms Final Exam',         90, 9);

INSERT INTO Questions (TypeOfQuestion, Text, Mark, CorrectAnswer, QuizId)
VALUES 
    -- Quiz 1: C# Basics Quiz 1
    ('MultipleChoiceQuestion', 'What is the correct keyword to declare a variable in C#?', 5.00, 'var', 1),
    ('TrueFalseQuestion',      'C# is a case-sensitive language.', 2.00, 'True', 1),
    ('ShortAnswerQuestion',    'What is the base class of all classes in C#?', 3.00, 'Object', 1),
    
    -- Quiz 2: C# Basics Quiz 2
    ('MultipleChoiceQuestion', 'Which of these is NOT a C# data type?', 5.00, 'stringarray', 2),
    ('TrueFalseQuestion',      'int can store decimal numbers.', 2.00, 'False', 2),
    
    -- Quiz 3: C# Midterm Exam
    ('MultipleChoiceQuestion', 'What does OOP stand for?', 10.00, 'Object Oriented Programming', 3),
    ('ShortAnswerQuestion',    'Explain the difference between class and struct.', 15.00, 'Class is reference type, struct is value type', 3),
    ('TrueFalseQuestion',      'Interfaces can have implementation in C# 8+.', 5.00, 'True', 3),
    
    -- Quiz 4: Advanced C# Quiz
    ('MultipleChoiceQuestion', 'What is a delegate in C#?', 8.00, 'Type-safe function pointer', 4),
    ('ShortAnswerQuestion',    'What is LINQ?', 7.00, 'Language Integrated Query', 4),
    
    -- Quiz 6: HTML Basics Quiz
    ('MultipleChoiceQuestion', 'What does HTML stand for?', 3.00, 'HyperText Markup Language', 6),
    ('TrueFalseQuestion',      'HTML is a programming language.', 2.00, 'False', 6),
    ('ShortAnswerQuestion',    'What tag is used for the largest heading?', 3.00, '<h1>', 6),
    
    -- Quiz 10: JavaScript Quiz 1
    ('MultipleChoiceQuestion', 'Which keyword declares a block-scoped variable?', 5.00, 'let', 10),
    ('TrueFalseQuestion',      'JavaScript is the same as Java.', 2.00, 'False', 10),
    ('ShortAnswerQuestion',    'What is the output of typeof null?', 3.00, 'object', 10),
    
    -- Quiz 13: React Components Quiz
    ('MultipleChoiceQuestion', 'What is JSX?', 8.00, 'JavaScript XML', 13),
    ('TrueFalseQuestion',      'React components must start with uppercase letter.', 2.00, 'True', 13),
    
    -- Quiz 16: SQL SELECT Quiz
    ('MultipleChoiceQuestion', 'Which clause filters rows in SQL?', 5.00, 'WHERE', 16),
    ('ShortAnswerQuestion',    'What does SELECT * do?', 5.00, 'Selects all columns', 16);

INSERT INTO QuizAttempt (StudentAnswers, Score, TimeTaken, Studentid, Quizid)
VALUES 
    ('1:A,2:B,3:C',                     18, 25, 1,  1),
    ('1:B,2:A,3:C',                     15, 28, 2,  1),
    ('1:A,2:B,3:C,4:D',                 20, 20, 3,  1),
    ('1:C,2:A,3:B',                     12, 22, 4,  2),
    ('1:A,2:B,3:C',                     17, 26, 5,  2),
    ('1:A,2:B,3:C,4:D,5:A',             45, 55, 1,  3),
    ('1:B,2:A,3:C,4:B,5:A',             38, 58, 2,  3),
    ('1:A,2:B,3:C,4:D,5:A',             50, 48, 3,  3),
    ('1:A,2:B',                         8,  15, 6,  6),
    ('1:A,2:B',                         9,  12, 7,  6),
    ('1:A,2:B',                         10, 10, 8,  6),
    ('1:A,2:B,3:C',                     22, 28, 9,  10),
    ('1:B,2:A,3:C',                     18, 30, 10, 10),
    ('1:A,2:B,3:C',                     25, 25, 11, 10),
    ('1:A,2:B,3:C,4:D',                 28, 32, 12, 13),
    ('1:B,2:A,3:C,4:D',                 25, 34, 13, 13),
    ('1:A,2:B,3:C,4:D',                 30, 28, 14, 13),
    ('1:A,2:B',                         12, 20, 15, 16),
    ('1:B,2:A',                         10, 22, 16, 16),
    ('1:A,2:B',                         15, 18, 17, 16);   
         
insert into Enrollment(Studentid, Courseid)
values
    (1, 1), (2, 1), (3, 1), (4, 1),
    (5, 2), (6, 2), (7, 2),(8, 3),
    (9, 3), (10, 3),(11, 4), (12, 4),
    (13, 5), (14, 5),(15, 6), (16, 6),
    (17, 7), (18, 7),(19, 8), (20, 8);


insert into questionoption (questionid, optiontext)
values
(1, '2'), (1, '3'), (1, '4'), (1, '5'),
(2, '6'), (2, '7'), (2, '8'), (2, '9'),
(3, '10'), (3, '15'), (3, '20'), (3, '25'),
(4, 'true'), (4, 'false'), (4, 'none'), (4, 'both'),
(5, 'int'), (5, 'string'), (5, 'bool'), (5, 'char'),
(6, 'select'), (6, 'insert'), (6, 'update'), (6, 'delete'),
(7, 'primary key'), (7, 'foreign key'), (7, 'null'), (7, 'default'),
(8, 'html'), (8, 'css'), (8, 'sql'), (8, 'all'),
(9, '1'), (9, '2'), (9, '3'), (9, '4'),
(10, 'true'), (10, 'false'), (10, 'none'), (10, 'all'),
(11, 'class'), (11, 'object'), (11, 'method'), (11, 'all'),
(12, '0'), (12, '1'), (12, '-1'), (12, 'null'),
(13, 'insert'), (13, 'create'), (13, 'drop'), (13, 'all'),
(14, 'int'), (14, 'decimal'), (14, 'varchar'), (14, 'all'),
(15, 'true'), (15, 'false'), (15, 'none'), (15, 'all'),
(16, 'get'), (16, 'set'), (16, 'get and set'), (16, 'none'),
(17, 'loop'), (17, 'array'), (17, 'class'), (17, 'namespace'),
(18, 'and'), (18, 'or'), (18, 'not'), (18, 'all'),
(19, 'true'), (19, 'false'), (19, 'null'), (19, 'empty'),
(20, 'select'), (20, 'where'), (20, 'order by'), (20, 'all');



insert into questionanswer (questionid, answertext)
values
(1, '4'),
(2, '8'),
(3, '20'),
(4, 'true'),
(5, 'int'),
(6, 'insert'),
(7, 'primary key'),
(8, 'all'),
(9, '3'),
(10, 'true'),
(11, 'all'),
(12, '0'),
(13, 'create'),
(14, 'all'),
(15, 'true'),
(16, 'get and set'),
(17, 'array'),
(18, 'all'),
(19, 'null'),
(20, 'all');

--1-
select
    c.Name   as CourseName,
    t.Name   as TeacherName,
    c.category as Category
from Course c
inner join Teacher t on t.id = c.teacherid;
--2-
select 
    q.Name        as QuizName,
    count(qs.Id)  as NumberOfQuestions
from Quiz q
left join Questions qs on qs.Quizid = q.Id
group by q.Id, q.Name;
--3-
select * from Questions
where Quizid = 2;
--4-
select 
    s.Name as StudentName,
    c.Name as CourseName
from Student s
inner join Enrollment e on e.Studentid = s.Id
inner join Course c on c.Id = e.Courseid
where c.Name = 'Introduction to Programming';
--5-
select 
    c.Name       as CourseName,
    count(q.Id)  as NumberOfQuizzes
from Quiz q
inner join Course c on q.Courseid = c.Id
where c.Name = 'Introduction to Programming'
group by c.Id, c.Name;
--6-
select 
    c.Name       as CourseName,
    t.Name  as TeacherName
from Course c
left join Teacher t on c.teacherid = t.Id
--7-
update Course
set Duration = 5;
--8-
delete from Questions
where Quizid = 5
and (select count(*) from QuizAttempt where Quizid = 5) = 0;


delete from Quiz
where Id = 5
and (select count(*) from QuizAttempt where Quizid = 5) = 0;
--9-
select avg(Duration) from Quiz;
--10-
select q.Name as QuizName ,avg(qa.Score) as AverageScore from QuizAttempt qa  
inner join Quiz q  on q.id=qa.Quizid
group by q.Name,q.id;
--11-
select 
    s.Name          as StudentName,
    q.Name          as QuizName,
    qa.StudentAnswers as StudentAnswer,
    qa.Score        as Score
from QuizAttempt qa
inner join Student s on s.Id = qa.Studentid
inner join Quiz    q on q.Id = qa.Quizid
order by q.Name, s.Name;
--12-
select 
    c.Name              as CourseName,
    count(e.Studentid)  as NumberOfStudents
from Course c
inner join Enrollment e on e.Courseid = c.Id
group by c.Id, c.Name
having count(e.Studentid) > 5;
--13-
select distinct 
    c.Name as CourseName
from Course c
inner join Quiz q on q.Courseid = c.Id;
--14-
insert into Admin(Name, Email, Password)
values ('Ahmed', 'ahmed.admin@school.com', 'Admin@123456');
--15-
select 
    s.Name                  as StudentName,
    c.Name                  as CourseName,
    q.Name                  as QuizName,
    qa.Score                as TotalScore,
    case 
        when qa.Score >= 50 then 'Pass'
        else 'Fail'
    end                     as Result
from QuizAttempt qa
inner join Student s on s.Id = qa.Studentid
inner join Quiz    q on q.Id = qa.Quizid
inner join Course  c on c.Id = q.Courseid
where s.Id = 1
order by c.Name, q.Name;