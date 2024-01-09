CREATE TABLE User (
	UserID INTEGER PRIMARY KEY NOT NULL,
	UserName varchar(30) NOT NULL,
	Password varchar(100) NOT NULL,
	CreateDate  varchar(30),
	LastLogin varchar(30),
	LessonFinished	INTEGER,
	LessonPassed	INTEGER
)

CREATE TABLE Lesson(
	LessonID INTEGER PRIMARY KEY NOT NULL,
	LessonName varchar(20) NOT NULL

)

CREATE TABLE LessonRecord(
	LessonRecordID INTEGER PRIMARY KEY NOT NULL,
	LessonID INTEGER NOT NULL,
	UserID INTEGER NOT NULL,
	Score INTEGER NOT NULL,
	Collision_count INTEGER NOT NULL,
	Overspeed varchar(10) NOT NULL,
	AvgSpeed varchar(10) NOT NULL,
	MaxSpeed varchar(10) NOT NULL,
	WrongFaceDirection varchar(10) NOT NULL,
	AdjustDrive varchar(10) NOT NULL,
	RaiseDrive varchar(10) NOT NULL,
	TiltDrive varchar(10) NOT NULL,
	FinishTime varchar(10) NOT NULL,
	ForkTooHigh varchar(10) NOT NULL,
	RampTurning varchar(10) NOT NULL,
	RampFaceDown varchar(10) NOT NULL,
	Result varchar(10) NOT NULL,
	Create_Date varchar(30) NOT NULL
)