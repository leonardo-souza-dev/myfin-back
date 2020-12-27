DROP TABLE Tarefas

CREATE TABLE Tarefas (
    Id INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE ,
    Descricao TEXT NOT NULL,
    Ano INTEGER NOT NULL,
    Mes INTEGER NOT NULL,
    Dia INTEGER NOT NULL,
    Hora INTEGER NOT NULL,
    Minuto INTEGER NOT NULL
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