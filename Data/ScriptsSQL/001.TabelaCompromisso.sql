-- master.dbo.Compromisso definição

-- Drop table

-- DROP TABLE master.dbo.Compromisso;

CREATE TABLE master.dbo.Compromisso (
	Id varchar(256) COLLATE Latin1_General_CI_AS NOT NULL,
	Titulo varchar(4000) COLLATE Latin1_General_CI_AS NOT NULL,
	Descricao varchar(4000) COLLATE Latin1_General_CI_AS NOT NULL,
	DataInicio datetime2(0) NOT NULL,
	DataFim datetime2(0) NOT NULL,
	Localizacao varchar(256) COLLATE Latin1_General_CI_AS NULL,
	Status int NULL,
	Ativo bit NOT NULL,
	DataCriacao datetime2(0) NOT NULL,
	DataAlteracao datetime2(0) NULL,
	CONSTRAINT Compromisso_PK PRIMARY KEY (Id)
);