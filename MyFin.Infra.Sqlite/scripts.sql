DROP TABLE Tarefas

CREATE TABLE Tarefas2 (
    Id INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE ,
    Descricao TEXT NOT NULL,
    Data text NOT NULL,
    Valor decimal(10, 5) NOT NULL
);

CREATE TABLE "Tarefas" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Descricao"	TEXT NOT NULL,
	"Pontos"	INTEGER NOT NULL DEFAULT (0),
	"Data"	text DEFAULT '1970-01-01 00:00:00.000',
	"Valor"	decimal(10, 5) ,
	"Conta"	TEXT,
	"DataVcto"	text,
	"DataPgto"	text,
	PRIMARY KEY("Id" AUTOINCREMENT)
);


INSERT INTO Tarefas (Descricao, Ano, Mes, Dia, Hora, Minuto)
VALUES
    ('Estudar algo',          2020, 12, 6,  10, 00), --dom 
    ('Aula de piano',         2020, 12, 7,  19, 00), --seg 
    ('Aula de Kung fu',       2020, 12, 7,  20, 00), --seg 
    ('Preceptoria',           2020, 12, 8,  21, 00), --ter 
    ('Estudar Kotlin',        2020, 12, 8,  10, 00), --ter 
    ('Assistir Cobra Kai',    2020, 12, 9,  10, 00), --qua 
    ('Aula de Kung fu',       2020, 12, 9,  20, 00), --qua 
    ('Fazer lição de inglês', 2020, 12, 10, 10, 00), --qui 
    ('Telão',                 2020, 12, 11, 10, 00), --sex
    ('Descansar',             2020, 12, 13, 10, 00)  --outro domingo


ALTER TABLE Tarefas
ADD COLUMN Data text default '2020-12-25 00:00:00.000' 
ALTER TABLE Tarefas
ADD COLUMN DataVcto text default '1970-01-01 00:00:00.000' 