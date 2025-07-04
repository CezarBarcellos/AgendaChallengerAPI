-- master.dbo.Usuario definição

-- Drop table

-- DROP TABLE master.dbo.Usuario;

CREATE TABLE master.dbo.Usuario (
	Id int IDENTITY(1,1) NOT NULL,
	Nome nvarchar(MAX) COLLATE Latin1_General_CI_AS NOT NULL,
	Email nvarchar(MAX) COLLATE Latin1_General_CI_AS NOT NULL,
	Ativo bit NOT NULL,
	DataCriacao datetime2 NOT NULL,
	DataAlteracao datetime2 NOT NULL,
	Senha nvarchar(MAX) COLLATE Latin1_General_CI_AS DEFAULT N'' NOT NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY (Id)
);