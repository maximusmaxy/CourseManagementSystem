--Drop tables
if object_id('Unit_Teachers','U') is not null
drop table unit_teachers;
if object_id('Unit_Skills', 'U') is not null
drop table Unit_Skills;
if object_id('Course_Teachers', 'U') is not null
drop table Course_Teachers;
if object_id('Course_Units', 'U') is not null
drop table Course_Units;
if object_id('Teacher_Skills', 'U') is not null
drop table Teacher_Skills;
if object_id('Enrolments', 'U') is not null
drop table Enrolments;

if object_id('Skills', 'U') is not null
drop table Skills;
if object_id('Assessments', 'U') is not null
drop table Assessments;

if object_id('Courses', 'U') is not null
drop table Courses;
if object_id('Students', 'U') is not null
drop table Students;
if object_id('Units', 'U') is not null
drop table Units;
if object_id('Teachers', 'U') is not null
drop table Teachers;
if object_id('Locations', 'U') is not null
drop table Locations;
if object_id('Departments','U') is not null
drop table Departments;

go

--Create Tables
create table Departments(
departmentId smallint primary key identity(1,1) not null,
departmentName varchar(50) not null);

create table Locations (locationId smallint primary key not null identity(1,1),
addressStreet1 varchar(100) not null,
addressStreet2 varchar(50),
addressSuburb varchar (50),
addressState varchar(50),
addressPostCode smallint);

create table Skills(
skillId smallint primary key not null identity(1,1),
departmentId smallint not null,
skillName varchar(80) not null,
skillDescription varchar(500) not null
constraint Skill_department_fk foreign key (departmentId) references Departments(departmentId));

create table Students(
studentId smallint primary key not null identity (1,1),
studentFirstName varchar(30) not null,
studentLastName varchar(30)  not null,
locationId smallint not null,
studentDateOfBirth date not null,
studentEmail varchar(80) not null,
studentCountryOfOrigin varchar(20) not null,
studentGender tinyint not null,
studentDisability bit not null,
studentDisabilityDescription varchar(50));

create table Courses(
courseId smallint primary key not null identity (1,1),
courseName varchar(50) not null,
courseCost double precision not null,
courseDeliveryType tinyint not null,
courseStartDate date not null,
courseEndDate date not null,
locationId smallint not null,
departmentId smallint not null,
courseDescription varchar(500) not null);

create table Teachers(
teacherId smallint primary key not null identity (1,1),
locationId smallint not null,
departmentId smallint not null,
teacherFirstName varchar(50) not null,
teacherLastName varchar(50) not null
constraint teacher_department_fk foreign key (departmentId) references Departments(departmentId),
constraint teacher_location_fk foreign key (locationId) references Locations(locationId));

create table Units(
unitId smallint primary key not null identity (1,1),
departmentId smallint not null,
unitName varchar(50)not null,
unitType tinyint not null,
numOfHours smallint not null,
unitDescription varchar(500) not null
constraint Unit_department_fk foreign key (departmentId) references Departments(departmentId));
 
create table Assessments(
assessmentId smallint primary key not null identity(1,1),
unitId smallint not null,
teacherId smallint not null,
departmentId smallint not null,
assessmentName varchar(40) not null,
assessmentStartDate date not null,
assessmentDueDate date not null,
assessmentDescription varchar(500) not null,
constraint assessment_unit_fk foreign key (unitId) references Units(unitId),
constraint assessment_teacher_fk foreign key (teacherId) references Teachers(teacherId),
constraint assessment_department_fk foreign key (departmentId) references Departments(departmentId));

create table Enrolments(
enrolmentId smallint primary key not null identity (1,1),
studentId smallint not null,
courseId smallint not null,
enrolmentDate date not null,
completionDate date not null,
enrolmentCost double precision not null,
discountCost double precision not null,
semester tinyint not null,
constraint student_course_unique unique(studentId, courseId),
constraint enrolment_student_fk foreign key (studentId) references Students(studentId),
constraint enrolment_course_fk foreign key (courseId) references Courses(courseId)) ;

create table Teacher_Skills(
teacherId smallint not null,
skillId smallint not null,
primary key(teacherId,skillId),
constraint teacher_skill_teacher_fk foreign key (teacherId) references Teachers(teacherId),
constraint teacher_skill_skill_fk foreign key (skillId) references Skills(skillId));

create table Unit_Skills(unitId smallint not null,
skillId smallint not null
primary key(unitId, skillId)
constraint unit_skill_unit_fk foreign key (unitId) references Units(unitId),
constraint unit_skill_skill_fk foreign key (skillId) references Skills(skillId));

create table Course_Teachers(
courseId smallint not null,
teacherId smallint not null
primary key(courseId,teacherId)
constraint course_teacher_course_fk foreign key (courseId) references Courses(courseId),
constraint course_teacher_teacher_fk foreign key (teacherId) references Teachers(teacherId));

create table Course_Units(
courseId smallint not null,
unitId smallint not null
primary key(courseId,unitId)
constraint course_unit_course_fk foreign key (courseId) references Courses(courseId),
constraint course_unit_unit_fk foreign key (unitId) references Units(unitId));

create table Unit_Teachers(
unitId smallint not null,
teacherId smallint not null
primary key(unitId,teacherId)
constraint unit_teacher_unit_fk foreign key (unitId) references Units(unitId),
constraint unit_teacher_teacher_fk foreign key (teacherId) references Teachers(teacherId));

--Populate Tables
insert into Departments values('IT');
insert into Departments values('Hair Dressing');
insert into Departments values('Gardening');
insert into Departments values('Commerce');
insert into Departments values('Admin');
insert into Locations values('ekm st',null,'granville','NSW',2161);
insert into Locations values('pitt st',null,'merrylands','NSW',2160);
insert into Locations values('parramatta rd',null,'Parramatta','NSW',2260);
insert into Locations values('chetwynd rd',null,'guildford','NSW',2141);
insert into Locations values('northumberland st',null,'liverpool','nsw',2001);
insert into Skills values(1,'Java', 'being good at java');
insert into Skills values(1,'C Sharp', 'being good at C#');
insert into Skills values (1,'Database','Being awesome at Sql');
insert into Skills values(1,'Web design','being good at html and php');
insert into Skills values(4,'Leadership','hurting peoples feelings');
insert into Students values('Bob','Saget',1,'1995-05-15','bob-saget@live.com','Australia', 1, 1, 'Crippling Depression');
insert into Students values('Jim','Barnes',2,'1994-08-13','Barnesy88@hotmail.com','Australia',2,0,null);
insert into Students Values('Dave','Hughes',3,'1987-04-22','theGoonie@yahoo.com','Australia',1,0,null);
insert into Students values('Floyd','Mayweather',4,'1976-07-11','glassjaw22@hotmail.com','Australia',1,0,null);
insert into Students values('Ozzy','Osbourne',5,'1956-05-06','lordofdarnkness@gmail.com','Austalia',1,1,'Bi-polar');
insert into Courses values('Diploma of Software development',10000.00,2,'2017-06-10','2017-11-26', 1, 1,'Final level of education provided at tafe regarding IT');
insert into Courses values('Certificate IV IT',8000.00,2,'2017-06-10','2017-11-26',1,1,'Further Study in IT');
insert into Courses values('Certificate III IT',5000.00,2,'2017-06-10','2017-11-26',1,1,'Basic level in IT');
insert into Courses values('Certificate II IT',3000.00,2,'2017-06-10','2017-11-26',1,1,'Learning what the on button the the computer is for');
insert into Courses values('Certificate IV Web Design',8000.00,2,'2017-06-10','2017-11-26',1,1,'Further study of web design');
insert into Teachers values(1,1,'Ned','Bond');
insert into Teachers Values(2,1,'Rui','Guy');
insert into Teachers Values(3,1,'Javier','Rameriz');
insert into Teachers values(4,1,'Shubha','Too');
insert into Teachers values (5,1,'Raj','Dude');
insert into Units values(1,'Optimising Search Functions',2,10,'Getting taught how to make and use search'); --Elective = 2
insert into Units values(1,'Cloud Computing',2,15,'Getting taught how to make and use Clouds, cloud dev techniques and events');
insert into Units values(1,'Intro programming',1,25,'Getting taught the basics of a programming language');
insert into Units values(1,'Word proccessing',1,30,'teaching how to use microsoft office');
insert into units values(1,'Web design',1,25,'learning HTML');
insert into Assessments values(1,1,1,'Create the search','2017-08-13','2017-09-01','students will be left alone to produce a fully function search feature');
insert into Assessments values(1,1,1,'Create Cloud','2017-08-13','2017-09-01','students will be left alone to produce a fully functional cloud');
insert into Assessments values(1,1,1,'Make a program','2017-08-13','2017-09-01','Make a functioning console application');
insert into Assessments values(1,1,1,'Display skills with office','2017-08-13','2017-09-01','Show skills developed using word,excel and powerpoint');
insert into Assessments values (1,1,1,'Make a website','2017-08-13','2017-09-01','Develop a website');
insert into Enrolments values(1,1,'2017-06-19','2017-11-15',10000.00,5000.00,2);
insert into Enrolments values(2,2,'2017-06-19','2017-11-15',8000.00,5000.00,2);
insert into Enrolments values(3,3,'2017-06-19','2017-11-15',5000.00,4500.00,2);
insert into Enrolments values(4,4,'2017-06-19','2017-11-15',3000.00,3000.00,2);
insert into Enrolments values(5,5,'2017-06-19','2017-11-15',8000.00,5000.00,2);
insert into Teacher_Skills values(1,1);
insert into Unit_Skills values(1,1);
insert into Course_Teachers values(1,1);
insert into Course_Units values(1,1);
insert into Unit_Teachers values(1,1);