

insert into Tbl_Paciente (Nome_Paciente, CPF_Paciente ,Data_Nascimento) values ('bruno', 03950033262, '2019-12-12');


insert into Tbl_Agenda (CPF_Paciente_Agenda, FK_Paciente, Data_Consulta, Hora_Inicial, Hora_Final , DATA_Hora_Consulta) values (03950033262,1,GETDATE(), GETDATE(), GETDATE(), GETDATE());