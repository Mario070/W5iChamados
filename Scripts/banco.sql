CREATE TABLE Setores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL
);

CREATE TABLE Prioridades (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    TempoEstimadoHoras INT NOT NULL
);

CREATE TABLE Chamados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(200) NOT NULL,
    Descricao VARCHAR(500),

    SetorId INT NOT NULL,
    PrioridadeId INT NOT NULL,

    Status VARCHAR(30) NOT NULL,

    DataAbertura DATETIME NOT NULL,
    DataInicio DATETIME NULL,
    DataFim DATETIME NULL,

    Solucao VARCHAR(500),

    FOREIGN KEY (SetorId) REFERENCES Setores(Id),
    FOREIGN KEY (PrioridadeId) REFERENCES Prioridades(Id)
);

INSERT INTO Prioridades (Nome, TempoEstimadoHoras)
VALUES
('Baixa', 48),
('Média', 24),
('Alta', 4);