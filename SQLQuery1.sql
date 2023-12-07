create database app_recruitment;
use app_recruitment;

create table PositionType(
	candidateTypeID int primary key ,
	candidateTypeName varchar(50),
);

create table candidate(
	candidateID int primary key,
	fullName nvarchar(50),
	birthday date,
	phone varchar(10),
	email varchar(50),
	candidateType int,
	foreign key (candidateType) references PositionType(candidateTypeID)
);




create table certificate(
	certificateID int primary key,
	cerName nvarchar(50),
	cerRank nvarchar(10),
	cerDate date,
	candidateID int ,
	foreign key (candidateID) references candidate(candidateID)
	
);

create table fresher(
 fresherID int primary key ,
 graduationRank nvarchar(20),
 graduationDate Date,
 education nvarchar(50),
 candidateID int ,
 foreign key (candidateID) references candidate(candidateID)
);



create table intern(
 internID int primary key ,
 semester int ,
 universityName nvarchar(50),
 candidateID int,
 foreign key (candidateID) references candidate(candidateID)
);

create table experience(
	expID int primary key ,
	expYear int ,
	proSkill varchar(50),
	candidateID int,
	foreign key (candidateID) references candidate(candidateID)
);




update candidate set candidateType = 3 where candidateID = 3 ;
select * from candidate where candidateID = 1;
select * from fresher;
select * from PositionType;
select * from certificate where candidateID = 1 ;

update candidate set candidateType = 3 where candidateType = 1;
