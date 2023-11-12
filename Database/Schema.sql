CREATE DATABASE SchoolKZL
--USE SchoolKZL;

-- Tabela Nauczyciel
CREATE TABLE Teacher
(
    Id uniqueidentifier DEFAULT NEWID() PRIMARY KEY, 
    Name VARCHAR(50),
    Surname VARCHAR(50),
    Post DECIMAL(3, 1),
    StartOfWork DATE
);

-- Tabela Klasa
CREATE TABLE SchoolClass
(
    Id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
    ClassName VARCHAR(10)
);

-- Tabela Uczen
CREATE TABLE Student
(
    Id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
    Name VARCHAR(50),
    Surname VARCHAR(50),
    DateOfBirth DATE,
    GradeAvarage decimal(3, 1),
    ClassId uniqueidentifier,
    FOREIGN KEY (ClassId) REFERENCES SchoolClass(Id)
);

-- Tabela laczaca nauczycieli i klasy (relacja wiele do wielu)
CREATE TABLE TeachersClasses
(
    TeacherId uniqueidentifier DEFAULT NEWID(),
    SchoolClassID uniqueidentifier DEFAULT NEWID(),
    FOREIGN KEY (TeacherId) REFERENCES Teacher(Id),
    FOREIGN KEY (SchoolClassID) REFERENCES SchoolClass(Id)
);

-- Tabela laczaca uczniow i klasy (relacja jeden do wielu)
CREATE TABLE StudentsClasses
(
    StudentId uniqueidentifier,
    SchoolClassId uniqueidentifier,
    PRIMARY KEY (StudentId, SchoolClassId),
    FOREIGN KEY (StudentId) REFERENCES Student(Id),
    FOREIGN KEY (SchoolClassId) REFERENCES SchoolClass(Id)
);
