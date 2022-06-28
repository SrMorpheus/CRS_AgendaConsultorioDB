CREATE DATABASE ConsultorioDB;

Go

USE ConsultorioDB

Go

CREATE TABLE Tbl_Paciente(

Cod_Paciente INT NOT NULL IDENTITY PRIMARY KEY,

CPF_Paciente BIGINT NOT NULL ,

Nome_Paciente VARCHAR(90) NOT NULL,

Data_Nascimento DATE NOT NULL,


)

GO


CREATE TABLE Tbl_Agenda (

Cod_Agenda INT NOT NULL IDENTITY PRIMARY KEY ,

CPF_Paciente_Agenda BIGINT NOT NULL,

Data_Consulta DATE NOT NULL,

Hora_Inicial DATETIME NOT NULL,

Hora_Final DATETIME NOT NULL,

DATA_Hora_Consulta DATETIME NOT NULL,

FK_Paciente INT NOT NULL


)

GO

ALTER TABLE Tbl_Agenda 
ADD CONSTRAINT FK_PACIENTE_ID FOREIGN KEY(FK_Paciente)
	REFERENCES Tbl_Paciente (Cod_Paciente)
GO


insert into Tbl_Paciente (Nome_Paciente, CPF_Paciente ,Data_Nascimento) values ('bruno', 03950033262, '2019-12-12');


insert into Tbl_Agenda (CPF_Paciente_Agenda, FK_Paciente, Data_Consulta, Hora_Inicial, Hora_Final , DATA_Hora_Consulta) values (03950033262,1,GETDATE(), GETDATE(), GETDATE(), GETDATE());