--drop database courseManage;
--create database courseManage; 

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
addressStreet1 varchar(100),
addressStreet2 varchar(50),
addressSuburb varchar (50),
addressState varchar(50),
addressPostCode smallint,
campus varchar(50));

create table Skills(
skillId smallint primary key not null identity(1,1),
departmentId smallint not null,
skillName varchar(80) not null,
skillDescription varchar(500) not null
constraint Skill_department_fk foreign key (departmentId) references Departments(departmentId));

create table Students(
studentId smallint primary key not null identity (1,1),
locationId smallint not null,
studentFirstName varchar(30) not null,
studentLastName varchar(30)  not null,
studentDateOfBirth date not null,
studentEmail varchar(80) not null,
studentCountryOfOrigin varchar(20) not null,
studentGender tinyint not null,
studentDisability bit not null,
studentDisabilityDescription varchar(50)
constraint student_location_fk foreign key (locationId) references Locations(locationId));


create table Courses(
courseId smallint primary key not null identity (1,1),
departmentId smallint not null,
locationId smallint not null,
courseName varchar(50) not null,
courseCost double precision not null,
courseDeliveryType tinyint not null,
courseStartDate date not null,
courseEndDate date not null,
courseDescription varchar(500) not null
constraint Course_department_fk foreign key (departmentId) references Departments(departmentId),
constraint Course_location_fk foreign key (locationId) references Locations(locationId));

create table Teachers(
teacherId smallint primary key not null identity (1,1),
locationId smallint not null,
departmentId smallint not null,
teacherFirstName varchar(50) not null,
teacherLastName varchar(50) not null,
teacherEmail varchar(100) not null,
teacherDepartment varchar(50) not null
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
insert into Locations values('ekm st',null,'granville','NSW',2161,'granville');
insert into Locations values('pitt st',null,'merrylands','NSW',2160,null);
insert into Locations values('parramatta rd',null,'Parramatta','NSW',2260,'Mt Druitt');
insert into Locations values('chetwynd rd',null,'guildford','NSW',2141,null);
insert into Locations values('northumberland st',null,'liverpool','nsw',2001,'liverpool');
insert into Skills values(1,'Java', 'being good at java');
insert into Skills values(1,'C Sharp', 'being good at C#');
insert into Skills values (1,'Database','Being awesome at Sql');
insert into Skills values(1,'Web design','being good at html and php');
insert into Skills values(2,'Scissors','being trustworthy with the sharp object scissors');
insert into Skills values(2,'Style','you got some!');
insert into Skills values(3,'fruit','know how to plant fruit based plants');
insert into Skills values(3,'veggies','you know how to grow some veggies');
insert into Skills values(4,'Leadership','hurting peoples feelings');
insert into SKills values(4,'Con-Artistry','being a business man');
insert into Skills values(5,'phone manner','know how to fake pleasentness on the phone');
insert into Skills values(5,'Helpfulness','can actually help people with a problem');
insert into Students values(1,'Bob','Saget','1995-05-15','bob-saget@live.com','Australia', 1, 1, 'Crippling Depression');
insert into Students values(2,'Jim','Barnes','1994-08-13','Barnesy88@hotmail.com','Australia',2,0,null);
insert into Students Values(3,'Dave','Hughes','1987-04-22','theGoonie@yahoo.com','Australia',1,0,null);
insert into Students values(4,'Floyd','Mayweather','1976-07-11','glassjaw22@hotmail.com','Australia',1,0,null);
insert into Students values(5,'Ozzy','Osbourne','1956-05-06','lordofdarnkness@gmail.com','Austalia',1,1,'Bi-polar');
insert into Courses values(1,1,'Diploma of Software development',10000.00,2,'2017-06-10','2017-11-26','Final level of education provided at tafe regarding IT');
insert into Courses values(1,1,'Certificate IV IT',8000.00,2,'2017-06-10','2017-11-26','Further Study in IT');
insert into Courses values(1,1,'Certificate III IT',5000.00,2,'2017-06-10','2017-11-26','Basic level in IT');
insert into Courses values(1,3,'Certificate II IT',3000.00,2,'2017-06-10','2017-11-26','Learning what the on button the the computer is for');
insert into Courses values(1,3,'Certificate IV Web Design',8000.00,2,'2017-06-10','2017-11-26','Further study of web design');
insert into Courses values(1,1,'Certificate III Hair Dressing',5000.00,2,'2017-06-10','2017-11-26','Basic level in Hair Dressing');
insert into Courses values(1,1,'Certificate II Hair Dressing',3000.00,2,'2017-06-10','2017-11-26','Hair Dressing stuff');
insert into Courses values(1,1,'Certificate IV Hair Dressing',8000.00,2,'2017-06-10','2017-11-26','Further study of Hair Dressing');
insert into Courses values(1,1,'Certificate III Gardening',5000.00,2,'2017-06-10','2017-11-26','Basic level in Gardening');
insert into Courses values(1,1,'Certificate II Gardening',3000.00,2,'2017-06-10','2017-11-26','Gardening stuff');
insert into Courses values(1,5,'Certificate IV Gardening',8000.00,2,'2017-06-10','2017-11-26','Further study of Gardening');
insert into Courses values(1,5,'Certificate III Commerce',5000.00,2,'2017-06-10','2017-11-26','Basic level in Commerce');
insert into Courses values(1,1,'Certificate II Commerce',3000.00,2,'2017-06-10','2017-11-26','Commerce stuff');
insert into Courses values(1,5,'Certificate IV Commerce',8000.00,2,'2017-06-10','2017-11-26','Further study of Commerce');
insert into Courses values(1,1,'Certificate III Admin',5000.00,2,'2017-06-10','2017-11-26','Basic level in Admin');
insert into Courses values(1,1,'Certificate II Admin',3000.00,2,'2017-06-10','2017-11-26','Admin stuff');
insert into Courses values(1,1,'Certificate IV Admin',8000.00,2,'2017-06-10','2017-11-26','Further study of Admin');
insert into Teachers values(1,1,'Ned','Bond','JamesBondLover@gmail.com','IT');
insert into Teachers Values(2,1,'Rui','Guy','ThatOneGuy@gmail.com','IT');
insert into Teachers Values(3,1,'Javier','Rameriz','theotherguy@yahoo.com','IT');
insert into Teachers values(4,1,'Shubha','Too','thescapegoat@live.com','IT');
insert into Teachers values (5,1,'Raj','Dude', 'projectmanagedude@gmail.com','IT');
insert into Teachers Values(4,2,'Jacline','Kenny','JackyKenn@live.com','hair dressing');
insert into Teachers values(2,2,'robert','bartine','robbytheman@gmail.com','hair dressing');
insert into Teachers values(1,3,'bob','builder','wecanfixit@live.com','gardening');
insert into Teachers values(4,3,'sally','jenkins','sisterofleeroy@yahoo.com','gardening');
insert into Teachers values(5,4,'ben','clock','bigbenji@hotmail.com','commerce');
insert into Teachers values(1,4,'mike','tyson','thebutterfly@gmail.com','commerce');
insert into Teachers values(4,5,'Don','King','Kingpin33@gmail.com','admin');
insert into Teachers values(2,5,'Chris','Benoit','Wannabesuperstar@live.com','admin');
insert into Units values(1,'Optimising Search Functions',2,10,'Getting taught how to make and use search'); --Elective = 2
insert into Units values(1,'Cloud Computing',2,15,'Getting taught how to make and use Clouds, cloud dev techniques and events');
insert into Units values(1,'Intro programming',1,25,'Getting taught the basics of a programming language');
insert into Units values(1,'Word proccessing',1,30,'teaching how to use microsoft office');
insert into units values(1,'Web design',1,25,'learning HTML');
insert into units values(2,'Blow Drying',1,10,'Learing what a hair dryer is');
insert into units values(2,'Scissors',1,10,'Scissor stuff');
insert into units values(3,'shovelling',1,20,'Dig a hole, dig a hole');
insert into units values(3,'planting stuff', 2,25,'jam em in');
insert into units values(4,'calculate',1,50,'math stuff');
insert into units values(4,'scam artistry',1,50,'Learn the ways of the merchant');
insert into units values(5,'help desk',2,25,'learning phone manner and stuff');
insert into units values(5,'phone',1,40,'learn to phone');
insert into Assessments values(1,1,1,'Create the search','2017-08-13','2017-09-01','students will be left alone to produce a fully function search feature');
insert into Assessments values(1,1,1,'Create Cloud','2017-08-13','2017-09-01','students will be left alone to produce a fully functional cloud');
insert into Assessments values(1,1,1,'Make a program','2017-08-13','2017-09-01','Make a functioning console application');
insert into Assessments values(1,1,1,'Display skills with office','2017-08-13','2017-09-01','Show skills developed using word,excel and powerpoint');
insert into Assessments values (1,1,1,'Make a website','2017-08-13','2017-09-01','Develop a website');
insert into Assessments values(6,6,2,'Cutting hair','2017-08-13','2017-09-01','cut hair properly');
insert into Assessments values(6,6,2,'blow dry','2017-08-13','2017-09-01','dry hair without setting fire to it');
insert into Assessments values(8,8,3,'dig a trench','2017-08-13','2017-09-01','demonstrate proper use of your tool');
insert into Assessments values(8,8,3,'plant plants','2017-08-13','2017-09-01','get em in there!');
insert into Assessments values(10,10,4,'Spend money','2017-08-13','2017-09-01','spend it all!!!');
insert into Assessments values(10,10,4,'Make money','2017-08-13','2017-09-01','Con money you lil devil you');
insert into Assessments values(12,12,5,'Answer the phone','2017-08-13','2017-09-01','Pick up the dang phone');
insert into Assessments values(12,12,5,'help desk','2017-08-13','2017-09-01','being helpful at a desk');
insert into Enrolments values(1,1,'2017-06-19','2017-11-15',10000.00,5000.00,2);
insert into Enrolments values(2,2,'2017-06-19','2017-11-15',8000.00,5000.00,2);
insert into Enrolments values(3,3,'2017-06-19','2017-11-15',5000.00,4500.00,2);
insert into Enrolments values(4,4,'2017-06-19','2017-11-15',3000.00,3000.00,2);
insert into Enrolments values(5,5,'2017-06-19','2017-11-15',8000.00,5000.00,2);
insert into Teacher_Skills values(1,1);
insert into Teacher_Skills values(2,2);    
insert into Teacher_Skills values(3,3);
insert into Teacher_Skills values(4,4);
insert into Teacher_Skills values(5,5);
insert into Unit_Skills values(1,1);
insert into Unit_Skills values(2,2); 
insert into Unit_Skills values(3,3); 
insert into Unit_Skills values(4,4); 
insert into Unit_Skills values(5,5);
insert into Course_Teachers values(1,1);
insert into Course_Teachers values(2,2); 
insert into Course_Teachers values(3,3);
insert into Course_Teachers values (4,4);
insert into Course_Teachers values (5,5);
insert into Course_Units values(1,1);
insert into Course_Units values(2,2); 
insert into Course_Units values(3,3); 
insert into Course_Units values(4,4); 
insert into Course_Units values(5,5);
insert into Unit_Teachers values(1,1);
insert into Unit_Teachers values(2,2);
insert into Unit_Teachers values (3,3); 
insert into Unit_Teachers values(4,4);
insert into Unit_Teachers values (5,5);
