IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Tbl_Paciente] (
    [Cod_Paciente] int NOT NULL IDENTITY,
    [CPF_Paciente] BIGINT NOT NULL,
    [Nome_Paciente] VARCHAR(90) NOT NULL,
    [Data_Nascimento] DATE NOT NULL,
    CONSTRAINT [PK_Tbl_Paciente] PRIMARY KEY ([Cod_Paciente])
);

GO

CREATE TABLE [Tbl_Agenda] (
    [Cod_Agenda] int NOT NULL IDENTITY,
    [CPF_Paciente_Agenda] BIGINT NOT NULL,
    [Data_Consulta] DATE NOT NULL,
    [Hora_Inicial] DATETIME NOT NULL,
    [Hora_Final] DATETIME NOT NULL,
    [DATA_Hora_Consulta] DATETIME NOT NULL,
    [PacienteID] int NOT NULL,
    [FK_Paciente] int NOT NULL,
    CONSTRAINT [PK_Tbl_Agenda] PRIMARY KEY ([Cod_Agenda]),
    CONSTRAINT [FK_Tbl_Agenda_Tbl_Paciente_FK_Paciente] FOREIGN KEY ([FK_Paciente]) REFERENCES [Tbl_Paciente] ([Cod_Paciente]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Tbl_Agenda_FK_Paciente] ON [Tbl_Agenda] ([FK_Paciente]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220702012950_inicial', N'3.1.26');

GO

