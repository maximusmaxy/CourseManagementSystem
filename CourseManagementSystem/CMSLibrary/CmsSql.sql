--Drop tables
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

--Create Tables
create table Locations (locationId smallint primary key not null identity(1,1),
addressStreet1 varchar(100) not null,
addressStreet2 varchar(50),
addressSuburb varchar (50),
addressState varchar(50),
addressPostCode smallint);

create table Skills(
skillId smallint primary key not null identity(1,1),
skillName varchar(80) not null,
skillDescription varchar(500) not null);

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
areaOfStudy varchar(40) not null,
courseDescription varchar(500) not null);

create table Teachers(
teacherId smallint primary key not null identity (1,1),
locationId smallint not null,
teacherFirstName varchar(50) not null,
teacherLastName varchar(50) not null,
teacherEmail varchar(100) not null,
teacherDepartment varchar(50) not null
constraint teacher_location_fk foreign key (locationId) references Locations(locationId));

create table Units(
unitId smallint primary key not null identity (1,1),
teacherId smallint not null,
unitName varchar(50)not null,
unitType tinyint not null,
numOfHours smallint not null,
unitDescription varchar(500) not null
constraint unit_teacher_fk foreign key (teacherId) references Teachers(teacherId));
 
create table Assessments(
assessmentId smallint primary key not null identity(1,1),
unitId smallint not null,
teacherId smallint not null,
assessmentName varchar(40) not null,
assessmentStartDate date not null,
assessmentDueDate date not null,
assessmentDescription varchar(500) not null,
constraint assessment_unit_fk foreign key (unitId) references Units(unitId),
constraint assessment_teacher_fk foreign key (teacherId) references Teachers(teacherId));

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

--Populate Tables
insert into Locations values('ekm st',null,'granville','NSW',2161);
insert into Skills values('Java', 'being good at java');
insert into Students values('bob','saget',1,'1995-05-15','bob-saget@live.com','Australia', 1, 1, 'Crippling Depression');
insert into Courses values('Diploma of Software development',10000.00,2,'2017-06-10','2017-11-26', 1, 'IT','Final level of education provided at tafe regarding IT');
insert into Teachers values(1,'Ned','Bond','JamesBondLover@gmail.com','IT');
insert into Units values(1,'Optimising Search Functions',2,10,'Getting taught how to make and use search'); --Elective = 2
insert into Assessments values(1,1,'Create the search','2017-08-13','2017-09-01','students will be left alone to produce a fully function search feature');
insert into Enrolments values(1,1,'2017-06-19','2017-11-15',10000.00,5000.00,2);
insert into Teacher_Skills values(1,1);
insert into Unit_Skills values(1,1);
insert into Course_Teachers values(1,1);
insert into Course_Units values(1,1);