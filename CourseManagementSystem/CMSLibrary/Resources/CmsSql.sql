--drop database courseManage;
--create database courseManage; 

--Drop tables
if OBJECT_id('Users','U') is not null
drop table Users;
if object_id('Unit_Teachers','U') is not null
drop table Unit_Teachers;
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
if object_id('Student_Units', 'U') is not null
drop table Student_Units
if object_id('Student_Assessments', 'U') is not null
drop table Student_Assessments

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
create table Users(
UserId smallint primary key identity(1,1) not null,
username varchar(50) not null,
passwords varchar(64) not null,
salt varchar(64) not null,
permissionType smallint not null,
studentTeacherId smallint,
constraint unique_username unique(username));

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
constraint unique_skill_name unique(skillName),
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
contactNumber varchar(12) not null,
studentAboriginal bit not null,
studentCentrelink bit not null,
studentDisability bit not null,
studentDisabilityDescription varchar(50)
constraint unique_email unique(studentEmail),
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
courseDescription varchar(5000) not null
constraint unique_course_name unique (courseName),
constraint Course_department_fk foreign key (departmentId) references Departments(departmentId),
constraint Course_location_fk foreign key (locationId) references Locations(locationId));

create table Teachers(
teacherId smallint primary key not null identity (1,1),
locationId smallint not null,
departmentId smallint not null,
teacherFirstName varchar(50) not null,
teacherLastName varchar(50) not null,
teacherEmail varchar(100) not null,
contactNumber varchar(12) not null,
constraint unique_Teacher_email unique (teacherEmail),
constraint teacher_department_fk foreign key (departmentId) references Departments(departmentId),
constraint teacher_location_fk foreign key (locationId) references Locations(locationId));

create table Units(
unitId smallint primary key not null identity (1,1),
departmentId smallint not null,
unitCode varchar(10) not null,
unitName varchar(50)not null,
unitType tinyint not null,
numOfHours smallint not null,
unitDescription varchar(500) not null,
constraint unique_unit_code unique(unitCode),
constraint unique_unit_name unique(unitName),
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
constraint unique_assessment_name unique(assessmentname),
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
totalCost double precision not null,
semester tinyint not null,
results tinyint not null,
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
teacherId smallint not null,
primary key(courseId,teacherId),
constraint course_teacher_course_fk foreign key (courseId) references Courses(courseId),
constraint course_teacher_teacher_fk foreign key (teacherId) references Teachers(teacherId));

create table Course_Units(
courseId smallint not null,
unitId smallint not null,
primary key(courseId,unitId),
constraint course_unit_course_fk foreign key (courseId) references Courses(courseId),
constraint course_unit_unit_fk foreign key (unitId) references Units(unitId));

create table Unit_Teachers(
unitId smallint not null,
teacherId smallint not null,
primary key(unitId,teacherId),
constraint unit_teacher_unit_fk foreign key (unitId) references Units(unitId),
constraint unit_teacher_teacher_fk foreign key (teacherId) references Teachers(teacherId));

create table Student_Assessments(
studentId smallint not null,
assessmentId smallint not null,
results tinyint not null,
primary key(studentId,assessmentId),
constraint student_assessment_student_fk foreign key (studentId) references Students(studentId),
constraint student_assessment_assessment_fk foreign key (assessmentId) references Assessments(assessmentId));

--Populate Tables
insert into Departments values('IT');
insert into Departments values('Hair Dressing');
insert into Departments values('Gardening');
insert into Departments values('Commerce');
insert into Departments values('Admin');
insert into Locations values('elm st',null,'granville','NSW',2161,'granville');
insert into Locations values('parramatta rd',null,'Parramatta','NSW',2260,'Mt Druitt');
insert into Locations values('northumberland st',null,'liverpool','nsw',2001,'liverpool');
insert into Locations values('place pl',null,'Redfern','NSW',2509,'Redfern');
insert into Locations values('kingswood rd', null, 'Penrith', 'NSW', 2515, 'Penrith'); 
insert into Locations values('pitt st',null,'merrylands','NSW',2160,null);
insert into Locations values('chetwynd rd',null,'guildford','NSW',2141,null);
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
insert into Students values(1,'Bob','Saget','1995-05-15','bob-saget@live.com','Australia', 1,'0432165897',0,0, 1, 'Crippling Depression');
insert into Students values(2,'Jim','Barnes','1994-08-13','Barnesy88@hotmail.com','Australia',2,'963741852',1,0,0,null);
insert into Students Values(3,'Dave','Hughes','1987-04-22','theGoonie@yahoo.com','Australia',1,'9248657132',0,1,0,null);
insert into Students values(6,'Floyd','Mayweather','1976-07-11','glassjaw22@hotmail.com','Australia',1,'0436287196',0,0,0,null);
insert into Students values(7,'Ozzy','Osbourne','1956-05-06','lordofdarkness@gmail.com','Australia',1,'9845321672',0,0,1,'Bi-polar');
insert into Students values(6,'Gunter','Rookenburg','1996-01-26','rookenburger@live.com','Zimbabwe',1,'9845391672',0,0,0,null);
insert into Courses values(1,1,'Diploma of Software development',10000.00,2,'2017-06-10','2017-11-26','Final level of education provided at tafe regarding IT');
insert into Courses values(1,1,'Certificate IV IT',8000.00,1,'2017-06-10','2017-11-26','Further Study in IT');
insert into Courses values(1,1,'Certificate III IT',5000.00,2,'2017-06-10','2017-11-26','Basic level in IT');
insert into Courses values(1,3,'Certificate II IT',3000.00,1,'2017-06-10','2017-11-26','Learning what the on button the the computer is for');
insert into Courses values(1,3,'Certificate IV Web Design',8000.00,2,'2017-06-10','2017-11-26','Further study of web design');
insert into Courses values(1,3,'Diploma of Web Design',10000.0,1,'2017-06-10','2017-11-26','Final level of studying web design');
insert into Courses values(2,1,'Certificate III Hair Dressing',5000.00,1,'2017-06-10','2017-11-26','Basic level in Hair Dressing');
insert into Courses values(2,1,'Certificate II Hair Dressing',3000.00,2,'2017-06-10','2017-11-26','Hair Dressing stuff');
insert into Courses values(2,1,'Certificate IV Hair Dressing',8000.00,2,'2017-06-10','2017-11-26','Further study of Hair Dressing');
insert into Courses values(3,1,'Certificate III Gardening',5000.00,2,'2017-06-10','2017-11-26','Basic level in Gardening');
insert into Courses values(3,1,'Certificate II Gardening',3000.00,2,'2017-06-10','2017-11-26','Gardening stuff');
insert into Courses values(3,5,'Certificate IV Gardening',8000.00,1,'2017-06-10','2017-11-26','Further study of Gardening');
insert into Courses values(4,5,'Certificate III Commerce',5000.00,2,'2017-06-10','2017-11-26','Basic level in Commerce');
insert into Courses values(4,1,'Certificate II Commerce',3000.00,2,'2017-06-10','2017-11-26','Commerce stuff');
insert into Courses values(4,5,'Certificate IV Commerce',8000.00,2,'2017-06-10','2017-11-26','Further study of Commerce');
insert into Courses values(5,1,'Certificate III Admin',5000.00,2,'2017-06-10','2017-11-26','Basic level in Admin');
insert into Courses values(5,1,'Certificate II Admin',3000.00,2,'2017-06-10','2017-11-26','Admin stuff');
insert into Courses values(5,1,'Certificate IV Admin',8000.00,2,'2017-06-10','2017-11-26','Further study of Admin');
insert into Teachers values(1,1,'Ned','Bond','JamesBondLover@gmail.com','0449152827');
insert into Teachers Values(2,1,'Rui','Guy','ThatOneGuy@gmail.com','0459152827');
insert into Teachers Values(3,1,'Javier','Rameriz','theotherguy@yahoo.com','0469152827');
insert into Teachers values(4,1,'Shubha','Too','thescapegoat@live.com','0479152827');
insert into Teachers values (5,1,'Raj','Dude', 'projectmanagedude@gmail.com','0489152827');
insert into Teachers Values(4,2,'Jacline','Kenny','JackyKenn@live.com','0499152827');
insert into Teachers values(2,2,'robert','bartine','robbytheman@gmail.com','0419152827');
insert into Teachers values(1,3,'bob','builder','wecanfixit@live.com','0429152827');
insert into Teachers values(4,3,'sally','jenkins','sisterofleeroy@yahoo.com','0439152827');
insert into Teachers values(5,4,'ben','clock','bigbenji@hotmail.com','0448152728');
insert into Teachers values(1,4,'mike','tyson','thebutterfly@gmail.com','04321568');
insert into Teachers values(4,5,'Don','King','Kingpin33@gmail.com','0448237915');
insert into Teachers values(2,5,'Chris','Benoit','Wannabesuperstar@live.com','0489311257');
insert into Units values(1,'ICTPRG418','Optimising Search Functions',2,10,'Getting taught how to make and use search'); --Elective = 2
insert into Units values(1,'ICTPRG523','Cloud Computing',2,15,'Getting taught how to make and use Clouds, cloud dev techniques and events');
insert into Units values(1,'ICTPRG206','Intro programming',1,25,'Getting taught the basics of a programming language');
insert into Units values(1,'ICTSAS203','Word proccessing',1,30,'teaching how to use microsoft office');
insert into units values(1,'ICTPRG406','Web design',1,25,'learning HTML');
insert into units values(1,'ICTICT205','Design basic organisational Documents',2,20,'Making The appropiate documents for an organisation');
insert into units values(1,'ICTWEB211','Use Social media to colaborate',1,20,'use a specific online medium to colaborate with classmates');
insert into units values(1,'BSBWHS201','Contribute to helf and safety of others',1,30,'learn the rules and regulations of the wrkplace');
insert into units values(1,'BSBSUS201','Enviromental sustainable practices',1,30,'Participate in environmentally sustainable work practices');
insert into units values(1,'ICTWEB303','Produce digital images',2,15,'make images to be suitable for the web');
insert into units values(1,'ICTWEB505','Develop complex css',1,35,'Make Complex Cascasing Style sheet');
insert into units values(1,'ICTPMG501','Manage ICT projects',1,40,'Manage Projects');
insert into units values(1,'BSBWHS304','Participate effectively in WHS',1,30,'Doing WHS stuff for safety!');
insert into units values(2,'HRBLOW123','Blow Drying',1,10,'Learing what a hair dryer is');
insert into units values(2,'HDSCUT101','Scissors',1,10,'Scissor stuff');
insert into units values(3,'POTPLT305','shovelling',1,20,'Dig a hole, dig a hole');
insert into units values(3,'POTPLT402','planting stuff', 2,25,'jam em in');
insert into units values(4,'COMCRD201','calculate',1,50,'math stuff');
insert into units values(4,'COMSCM406','scam artistry',1,50,'Learn the ways of the merchant');
insert into units values(5,'ADMPHN301','help desk',2,25,'learning phone manner and stuff');
insert into units values(5,'ADMPHN209','phone',1,40,'learn to phone');
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
insert into Enrolments values(1,1,'2017-06-19','2017-11-15',10000.00,5000.00,5000.00,2,3);
insert into Enrolments values(1,3,'2016-06-19','2016-11-15',5000.00,2500.00,2500.00,2,3);
insert into Enrolments values(1,4,'2016-01-30','2016-06-02',3000.00,1500.00,1500.00,2,3);
insert into Enrolments values(2,2,'2017-06-19','2017-11-15',8000.00,5000.00,3000.00,2,3);
insert into Enrolments values(3,3,'2017-06-19','2017-11-15',5000.00,4500.00,500.00,2,3);
insert into Enrolments values(4,4,'2017-06-19','2017-11-15',3000.00,3000.00,0,2,3);
insert into Enrolments values(5,5,'2017-06-19','2017-11-15',8000.00,5000.00,3000.0,2,3);
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
insert into Users values('Bob Saget', 'mRocQYnfs3/0/brrpSbyCHOVuFnIk16bNRJzZw4K4/E=', '4ZAXAXF1giXVGgGx6GvwzMEn6tMWmgE/ku7BQDufCqA=', 1, 1);
insert into Users values('Shubha Too', '2oM5JHkdUkw4Qvhc1XE8wqKlFGgrnasRvJIG1HqO6YM=', '3a9JMvojYWOTnUzhOHPo0Zh+dYdh48KWw65B1OcGcJQ=', 2, 2);
insert into Users values('Ned Bond', 'YLG5i+xhYw6Nn5QinZtxisycNnRguB+sq8gjVvDGpLk=', 'Kyc2q1L2/AQsawwzkALAwqA5gXya4CPFlyDH3tsGCDY=', 3, 1);
insert into Users values('admin', 'EqgnTjTef6LrMjVp6l8Fwu+Na4vvfLMYVVGMcJ931KM=', '8Z7tSOatw/EdpmY8u2ohjAhNA+WLkgLIG5+fUfMEGUM=', 4, null);
insert into Student_Assessments values (1, 1, 1), (1, 2, 1), (1, 3, 1), (1, 4, 1), (1, 5, 1);
SET IDENTITY_INSERT [dbo].[Units] ON
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (22, 1, N'ICTICT307', N'Create user documentation', 1, 20, N'This Unit describes the skills and knowledge required to create user documentation that is clear to the target audience and easy to navigate.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (23, 1, N'ICTICT409', N'Develop macros and templates for clients', 1, 20, N'This unit describes the skills and knowledge required to develop macros and templates for clients using industry recognised software applications.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (27, 1, N'ICTWHS204', N'Follow WHS and environmental policy', 1, 15, N'This unit describes the skills and knowledge required to follow safe working practices and environmental policy in the management of a telecommunications workplace.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (28, 1, N'ICTICT304', N'Implement system software changes', 1, 20, N'This unit describes the skills and knowledge required to implement system software changes and to hand over the modified system to the client''s operational area.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (30, 1, N'ICTICT308', N'Use advanced features of computer applications', 1, 20, N'This unit describes the skills and knowledge required to use computer applications employing advanced features. It involves manipulating data and accessing support resources to solve routine problems.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (31, 1, N'ICTPRG414', N'Apply introductory programming skills', 1, 30, N'This unit describes the skills and knowledge required to carry out programming activities using a procedural approach.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (32, 1, N'ICTPRG402', N'Apply query language', 1, 25, N'This unit describes the skills and knowledge required to retrieve and manipulate information stored in information systems, using a query language.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (33, 1, N'ICTICT415', N'Apply skills in object-oriented design', 1, 20, N'This unit describes the skills and knowledge required to produce an object-oriented design from specifications, applying the cyclic process of iteration from identification of class, instance, role and type to the final object-oriented model of the application.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (34, 1, N'ICTPRG410', N'Build a user interface', 1, 30, N'This unit describes the skills and knowledge required to design, build, and test a user interface (UI) to specification, including command-line interfaces (CLI), graphical user interfaces (GUI), web user interfaces (WUI) and natural user interfaces (NUI).')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (35, 1, N'ICTICT418', N'Contribute to copyright, ethics and privacy', 1, 8, N'It applies to ICT personnel who are required to gather information to determine the organisations code of ethics, and protect and maintain privacy policies and system security.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (36, 1, N'ICTWEB414', N'Design simple web page layouts', 1, 30, N'It applies to individuals working as web designers and web developers, who apply a wide range of knowledge and skills for basic web development.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (37, 1, N'ICTWEB413', N'Optimise search engines', 2, 25, N'It applies to individuals who make recommendations and monitor keyword enhancements, search engine marketing (SEM) and social network marketing (SNM).')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (38, 1, N'ICTPRG426', N'Prepare software development review', 1, 20, N'It applies to staff in the software development area who are required to ensure that the software development process incorporates quality considerations.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (39, 1, N'ICTWEB411', N'Produce basic client-side script', 1, 8, N'This unit describes the skills and knowledge required to develop interactive and engaging websites, using a range of features from various, appropriate languages.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (40, 1, N'ICTPRG404', N'Test applications', 1, 30, N'This unit describes the skills and knowledge required to prepare test plans, write test procedures or scripts according to test plans, and maintain test plans and scripts.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (41, 1, N'ICTPRG501', N'Apply advanced object-oriented language skills', 1, 40, N'This unit describes the skills and knowledge required to undertake advanced programming tasks using an object-oriented programming language.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (44, 1, N'ICTPRG604', N'Create cloud computing services', 1, 40, N'This unit describes the skills and knowledge required to design, build, test and deploy web services and cloud computing applications to specifications.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (45, 1, N'ICTPRG503', N'Debug and monitor applications', 1, 40, N'It applies to individuals who work as developers, testers and support engineers, using logging and tracing techniques to identify software problems and to monitor systems.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (46, 1, N'ICTDBS412', N'Build a database', 1, 30, N'This unit describes the skills and knowledge required to build, implement, test and evaluate a database, using an established design.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (47, 1, N'ICTWEB501', N'Build a dynamic website', 1, 8, N'It applies to individuals working as web developers who are responsible for the analysis, design, implementation, and testing of websites.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (48, 1, N'ICTICT406', N'Build a graphical user interface', 1, 30, N'This unit describes the skills and knowledge required to design, build and test a graphical user interface (GUI) to specification.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (49, 1, N'ICTPRG505', N'Build advanced user interface', 1, 40, N'This unit describes the skills and knowledge required to design, build and test an advanced user interface (UI), including interaction techniques, rich controls, improved client-side validation, customisation and personalisation, graphics and multimedia.')
INSERT INTO [dbo].[Units] ([unitId], [departmentId], [unitCode], [unitName], [unitType], [numOfHours], [unitDescription]) VALUES (50, 1, N'ICTPRG509', N'Build using rapid application development', 1, 40, N'This unit describes the skills and knowledge required to build using rapid application development (RAD) tools.')
SET IDENTITY_INSERT [dbo].[Units] OFF