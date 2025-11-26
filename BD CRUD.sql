CREATE DATABASE FinancasPessoaisDB;
GO

USE FinancasPessoaisDB;
GO

CREATE TABLE Lancamentos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descricao VARCHAR(255) NOT NULL,
    Valor DECIMAL(10, 2) NOT NULL,
    DataLancamento DATE NOT NULL,
    Tipo VARCHAR(10) NOT NULL CHECK (Tipo IN ('Credito', 'Debito'))
);