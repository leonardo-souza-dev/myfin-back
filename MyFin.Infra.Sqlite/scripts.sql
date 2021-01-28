CREATE TABLE Contas (
	Id              INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,
	Nome            TEXT NOT NULL,
	SaldoInicial	INTEGER NOT NULL 
)

CREATE TABLE Tarefas (
    Id                  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE ,
    Descricao           TEXT NOT NULL,
	PontosPrevistos	    INTEGER NOT NULL DEFAULT (0),
	Data                TEXT DEFAULT '1970-01-01 00:00:00.000',
	Valor	            decimal(10, 5),
	Conta               TEXT,
	DataVcto	        text,
	DataPgto            text,
	PontosRealizados	INTEGER NOT NULL DEFAULT 0,
	Concluido           INTEGER DEFAULT 0,
	Anotacoes	        TEXT,
)

ALTER TABLE Tarefas
ADD COLUMN DataVcto text default '1970-01-01 00:00:00.000' 