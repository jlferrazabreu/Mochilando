Create database DB_Mochilando

create table Cliente
(
	  Id int identity (1,1) primary key
	, Nome varchar(200) not null
	, Cpf varchar(11) not null
	, Email varchar(100) not null
	, Senha varchar(24) not null
	, DataCadastro datetime default getdate()
	, Telefone varchar(20)
	, Ativo bit default 1
)