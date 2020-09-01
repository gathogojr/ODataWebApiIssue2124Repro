CREATE DATABASE Repro2124Db;
USE Repro2124Db;

CREATE TABLE Projects (Id INT PRIMARY KEY, Name VARCHAR(255) NOT NULL);
CREATE TABLE Employees (Id INT PRIMARY KEY, Name VARCHAR(255) NOT NULL);
CREATE TABLE Tasks (Id INT PRIMARY KEY, Description VARCHAR(255) NOT NULL, ProjectId INT, SupervisorId INT);

ALTER TABLE Tasks ADD CONSTRAINT FK_Tasks_Projects FOREIGN KEY (ProjectId) REFERENCES Projects(Id);
ALTER TABLE Tasks ADD CONSTRAINT FK_Tasks_Employees FOREIGN KEY (SupervisorId) REFERENCES Employees(Id);

INSERT INTO Projects (Id, Name) VALUES (1, 'Pipeline Installation');
INSERT INTO Employees (Id, Name) VALUES (1, 'Nancy Davolio');
INSERT INTO Employees (Id, Name) VALUES (2, 'Andrew Fuller');
INSERT INTO Tasks (Id, Description, ProjectId, SupervisorId) VALUES (1, 'Install Piping', 1, 1);
INSERT INTO Tasks (Id, Description, ProjectId, SupervisorId) VALUES (2, 'Install Couplings', 1, 1);
INSERT INTO Tasks (Id, Description, ProjectId, SupervisorId) VALUES (3, 'QA Inspection', 1, 2);