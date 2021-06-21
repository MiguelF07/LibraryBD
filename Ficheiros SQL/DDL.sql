use p9g4;
-- criar esquema
CREATE SCHEMA BiblioBD;

-- criar tabelas
CREATE TABLE BiblioBD.biblioteca (
	nome varchar(60) PRIMARY KEY,
	telefone int	UNIQUE,
	morada varchar(60));

CREATE TABLE BiblioBD.funcionario (
	biblioteca varchar(60), --fk e pk
	id int , --pk
	ssn int UNIQUE,
	email varchar(60) UNIQUE,
	morada varchar(60),
	nome varchar(60),
	nascimento date,
	NIF int UNIQUE,
	inicio date,
	fim date,
	PRIMARY KEY(biblioteca,id),
	FOREIGN KEY (biblioteca) REFERENCES BiblioBD.biblioteca(nome)ON DELETE CASCADE);

CREATE TABLE BiblioBD.gerente (
	biblioteca varchar(60), --fk e pk
	id int, --fk e pk
	inicio date,
	fim date,
	PRIMARY KEY(biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.funcionario(biblioteca,id)ON DELETE CASCADE);

CREATE TABLE BiblioBD.membro (
	biblioteca varchar(60), --fk e pk
	id int, --fk e pk
	email varchar(60) UNIQUE,
	morada varchar(60),
	nome varchar(60),
	nascimento date,
	NIF int UNIQUE,
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca) REFERENCES BiblioBD.biblioteca(nome)ON DELETE CASCADE);

CREATE TABLE BiblioBD.emprestimo (
	numero int, --pk
	funcionario int,
	biblioteca varchar(60),
	membro int,
	limite date,
	emprestimo date,
	PRIMARY KEY (biblioteca,numero),
	FOREIGN KEY (biblioteca,funcionario) REFERENCES BiblioBD.funcionario(biblioteca,id)ON DELETE NO ACTION,
	FOREIGN KEY (biblioteca,membro) REFERENCES BiblioBD.membro(biblioteca,id)ON DELETE NO ACTION);

CREATE TABLE BiblioBD.tipoAtividade (
	biblioteca varchar(60),
	tipo varchar(60),
	funcionario int,
	PRIMARY KEY (tipo),
	FOREIGN KEY (biblioteca,funcionario) REFERENCES BiblioBD.funcionario(biblioteca,id)ON DELETE CASCADE);

CREATE TABLE BiblioBD.atividade (
	biblioteca varchar(60),
	nome varchar(60),
	tipo varchar(60),
	dataAti date,
	horario time,
	PRIMARY KEY (biblioteca, nome),
	FOREIGN KEY (tipo) REFERENCES BiblioBD.tipoAtividade(tipo) ON DELETE NO ACTION,
	FOREIGN KEY (biblioteca) REFERENCES BiblioBD.biblioteca(nome)ON DELETE CASCADE);

CREATE TABLE BiblioBD.atividadeMembro (
	biblioteca varchar(60),
	membro int,
	nome varchar(60),
	PRIMARY KEY (biblioteca,membro,nome),
	FOREIGN KEY (biblioteca,nome) REFERENCES BiblioBD.atividade(biblioteca,nome)ON DELETE CASCADE,
	FOREIGN KEY (biblioteca,membro) REFERENCES BiblioBD.membro(biblioteca,id)ON DELETE NO ACTION);

CREATE TABLE BiblioBD.item (
	biblioteca varchar(60),
	id int, 
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca) REFERENCES BiblioBD.biblioteca(nome));
	
CREATE TABLE BiblioBD.emprestimoItem (
	biblioteca varchar(60),
	numero int,
	id int,
	PRIMARY KEY (biblioteca, numero, id),
	FOREIGN KEY (biblioteca,numero) REFERENCES BiblioBD.emprestimo(biblioteca,numero)ON DELETE CASCADE,
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.item(biblioteca,id)ON DELETE CASCADE) ;

CREATE TABLE BiblioBD.jornais (
	biblioteca varchar(60),
	id int,
	seccao varchar(60),
	marca varchar(60),
	tipo varchar(60),
	dataL date,
	edicao int,
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.item(biblioteca,id)ON DELETE CASCADE);

CREATE TABLE BiblioBD.revistas (
	biblioteca varchar(60),
	id int,
	seccao varchar(60),
	marca varchar(60),
	tipo varchar(60),
	dataL date,
	edicao int,
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.item(biblioteca,id)ON DELETE CASCADE);

CREATE TABLE BiblioBD.filme (
	biblioteca varchar(60),
	id int,
	seccao varchar(60),
	realizador varchar(60),
	genero varchar(60),
	ano int CHECK (ano>1887),
	titulo varchar(60),
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.item(biblioteca,id)ON DELETE CASCADE);

CREATE TABLE BiblioBD.perifericos (
	biblioteca varchar(60),
	id int,
	marca varchar(60),
	modelo varchar(60),
	tipo varchar(60),
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.item(biblioteca,id)ON DELETE CASCADE);

CREATE TABLE BiblioBD.cd (
	biblioteca varchar(60),
	id int,
	artista varchar(60),
	genero varchar(60),
	ano int CHECK(ano>0),
	seccao varchar (60),
	titulo varchar (60),
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.item(biblioteca,id)ON DELETE CASCADE);

CREATE TABLE BiblioBD.livro (
	biblioteca varchar(60),
	id int,
	autor varchar(60),
	editora varchar(60),
	ano int CHECK(ano>0),
	isbn varchar(60),
	lingua varchar(60),
	genero varchar(60),
	seccao varchar(60),
	titulo varchar(60),
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.item(biblioteca,id)ON DELETE CASCADE);


/*	Apagar tabelas
	
	DROP TABLE BiblioBD.jornais
	DROP TABLE BiblioBD.cd
	DROP TABLE BiblioBD.perifericos
	DROP TABLE BiblioBD.revistas
	DROP TABLE BiblioBD.livro
	DROP TABLE BiblioBD.filme
	DROP TABLE BiblioBD.emprestimoItem
	DROP TABLE BiblioBD.item	
	DROP TABLE BiblioBD.atividadeMembro
	DROP TABLE BiblioBD.atividade
	DROP TABLE BiblioBD.tipoAtividade
	DROP TABLE BiblioBD.emprestimo
	DROP TABLE BiblioBD.membro
	DROP TABLE BiblioBD.gerente
	DROP TABLE BiblioBD.funcionario
	DROP TABLE BiblioBD.biblioteca
*/