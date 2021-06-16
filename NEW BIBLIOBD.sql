USE Projeto;
CREATE SCHEMA BiblioBD;

/*DROP TABLE BiblioBD.emprestimoItem
	DROP TABLE BiblioBD.jornais
	DROP TABLE BiblioBD.cd
	DROP TABLE BiblioBD.perifericos
	DROP TABLE BiblioBD.revistas
	DROP TABLE BiblioBD.livro
	DROP TABLE BiblioBD.filme*/
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
	FOREIGN KEY (biblioteca) REFERENCES BiblioBD.biblioteca(nome)
	);

CREATE TABLE BiblioBD.gerente (
	biblioteca varchar(60), --fk e pk
	id int, --fk e pk
	inicio date,
	fim date,
	PRIMARY KEY(biblioteca,id),
	FOREIGN KEY (biblioteca,id) REFERENCES BiblioBD.funcionario(biblioteca,id)
	);

CREATE TABLE BiblioBD.membro (
	biblioteca varchar(60), --fk e pk
	id int, --fk e pk
	email varchar(60) UNIQUE,
	morada varchar(60),
	nome varchar(60),
	nascimento date,
	NIF int UNIQUE,
	PRIMARY KEY (biblioteca,id),
	FOREIGN KEY (biblioteca) REFERENCES BiblioBD.biblioteca(nome));

CREATE TABLE BiblioBD.emprestimo (
	numero int, --pk
	funcionario int,
	biblioteca varchar(60),
	membro int,
	limite date,
	emprestimo date,
	PRIMARY KEY (biblioteca,numero),
	FOREIGN KEY (biblioteca,funcionario) REFERENCES BiblioBD.funcionario(biblioteca,id),
	FOREIGN KEY (biblioteca,membro) REFERENCES BiblioBD.membro(biblioteca,id));

CREATE TABLE BiblioBD.tipoAtividade (
	biblioteca varchar(60),
	tipo varchar(60),
	funcionario int,
	PRIMARY KEY (tipo),
	FOREIGN KEY (biblioteca,funcionario) REFERENCES BiblioBD.funcionario(biblioteca,id));

CREATE TABLE BiblioBD.atividade (
	biblioteca varchar(60),
	nome varchar(60),
	tipo varchar(60),
	dataAti date,
	horario time,
	PRIMARY KEY (biblioteca, nome),
	FOREIGN KEY (biblioteca) REFERENCES BiblioBD.biblioteca(nome));

CREATE TABLE BiblioBD.atividadeMembro (
	biblioteca varchar(60),
	membro int,
	nome varchar(60),
	PRIMARY KEY (biblioteca,membro,nome),
	FOREIGN KEY (biblioteca,nome) REFERENCES BiblioBD.atividade(biblioteca,nome),
	FOREIGN KEY (biblioteca,membro) REFERENCES BiblioBD.membro(biblioteca,id));

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

DROP TABLE BiblioBD.cd
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

--inserir dados
-- 1 biblioteca:
--SELECT * FROM BiblioBD.funcionario
INSERT INTO BiblioBD.biblioteca VALUES ('Biblioteca Municipal',925148635,'3288 At, Rd.');
-- 8 empregados:
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',1,100000000,'Nunc@rhoncus.org','2861 Non, Rd.','Charde Colon','1974-04-21',251456842,'2014-03-01',NULL);
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',2,100000003,'diam.dictum@magnaPhasellusdolor.co.uk','2212 Sed, Rd.','Candace Bartlett','1982-02-01',251456844,'2015-07-14','2021-06-08');
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',3,100000006,'libero@ipsumporta.edu','540-8326 Facilisis Av.','Basil Mcfadden','1993-11-02',251456846,'2016-03-16',NULL);
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',4,100000009,'Pellentesque.tincidunt@lectusjustoeu.edu','P.O. Box 324, 9201 Ornare, Rd.','Hop Randolph','1990-04-22',251456848,'2017-08-19',NULL);
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',5,100000012,'semper@blanditcongueIn.net','Ap #558-9535 Sed Av.','Leonard Duncan','1972-12-05',251456850,'2017-06-26',NULL);
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',6,100000015,'Quisque@etultrices.org','433-5753 Fringilla Road','Kathleen Craig','1995-10-28',251456852,'2016-01-28',NULL);
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',7,100000018,'nunc@pellentesquemassalobortis.com','3242 Gravida Avenue','Malachi Dodson','2001-05-10',251456854,'2015-05-14',NULL);
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',8,100000021,'metus.In@aliquetlobortis.net','P.O. Box 582, 3125 Vivamus St.','Ezra Dejesus','1997-01-15',251456856,'2015-06-17',NULL);

-- 1 gerente:
INSERT INTO BiblioBD.gerente VALUES('Biblioteca Municipal',7,'2016-06-21',NULL);

-- 20 membros:
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',1,'orci.Ut@Suspendisse.com','P.O. Box 296, 8643 Placerat, St.','Debra Burnett','1966-10-06',241456842);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',2,'Fusce@diamatpretium.com','875-1951 Non, Road','Sierra Norris','1984-11-28',241456844);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',3,'id@Duis.org','Ap #444-5343 Est, Avenue','Tyler Deleon','1972-12-11',241456846);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',4,'id.libero.Donec@eget.edu','9797 Aptent Rd.','Tad Stephens','1978-08-11',241456848);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',5,'feugiat.non@malesuadaIntegerid.net','338 Nullam Rd.','Reese Cantu','2002-04-07',241456850);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',6,'sociis.natoque.penatibus@habitantmorbi.com','P.O. Box 310, 7664 Convallis Rd.','Dorothy Morse','1988-03-31',241456852);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',7,'Nullam.scelerisque@Maurisnon.ca','5983 Sagittis. Rd.','Todd Mcneil','1995-03-29',241456854);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',8,'Vivamus.euismod@ultricesmauris.org','586-1504 Turpis Rd.','Macaulay Sharp','1968-12-10',241456856);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',9,'Nam.nulla.magna@nunc.ca','P.O. Box 166, 3102 Mauris Avenue','Rooney Morgan','1967-09-06',241456858);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',10,'ac.mi@orciin.org','P.O. Box 249, 9466 Iaculis Av.','Daryl Franklin','1983-03-07',241456860);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',11,'risus.at@laoreetipsum.edu','862-5466 Magna Ave','Troy Wilcox','1978-02-05',241456862);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',12,'a.odio.semper@vitaepurusgravida.org','P.O. Box 607, 4625 Pellentesque, Road','Ignacia Velasquez','2002-11-05',241456864);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',13,'egestas@velvenenatisvel.co.uk','Ap #421-5781 Non Street','Salvador Burnett','1969-04-20',241456866);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',14,'turpis.nec.mauris@ettristique.com','223-5847 Morbi Rd.','Norman Thomas','1970-03-15',241456868);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',15,'lorem@euismodestarcu.com','Ap #203-6041 Egestas. St.','Phyllis Weaver','1962-04-18',241456870);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',16,'laoreet@augue.org','P.O. Box 301, 3001 Mi Street','Talon Odonnell','1982-05-08',241456872);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',17,'gravida.Aliquam@nec.com','294-109 Nec, Avenue','Quinn Alexander','2004-10-11',241456874);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',18,'placerat.Cras@scelerisqueneque.edu','Ap #591-6965 Odio. Street','Kennan Rogers','1980-03-16',241456876);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',19,'eu@nequeSedeget.edu','Ap #939-3671 Elit Avenue','Doris Conway','1990-03-19',241456878);
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',20,'massa@etultrices.co.uk','516-2882 Ipsum Road','Lucy Bell','1988-08-30',241456880);
--DELETE FROM BiblioBD.funcionario

-- 3 tipos de atividades
INSERT INTO BiblioBD.tipoAtividade VALUES ('Biblioteca Municipal','Teatro',6);
INSERT INTO BiblioBD.tipoAtividade VALUES ('Biblioteca Municipal','Leitura',8);
INSERT INTO BiblioBD.tipoAtividade VALUES ('Biblioteca Municipal','Pintura',1);

-- 3 atividades:
INSERT INTO BiblioBD.atividade VALUES('Biblioteca Municipal','O sol dourado','Teatro','2021-07-1','15:30');
INSERT INTO BiblioBD.atividade VALUES('Biblioteca Municipal','Harry Potter e a Pedra Filosofal','Leitura','2021-06-15','14:00');
INSERT INTO BiblioBD.atividade VALUES('Biblioteca Municipal','Pinta o teu Van Gogh','Pintura','2021-06-27','16:00');

-- Membros das atividades (3/atividade):
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',19,'O sol dourado');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',8,'O sol dourado');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',7,'O sol dourado');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',13,'Harry Potter e a Pedra Filosofal');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',10,'Harry Potter e a Pedra Filosofal');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',5,'Harry Potter e a Pedra Filosofal');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',12,'Pinta o teu Van Gogh');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',5,'Pinta o teu Van Gogh');
INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',3,'Pinta o teu Van Gogh');

-- 5 emprestimos:
INSERT INTO BiblioBD.emprestimo VALUES (1,3,'Biblioteca Municipal',5,'2021-06-13','2021-05-13');
INSERT INTO BiblioBD.emprestimo VALUES (2,6,'Biblioteca Municipal',12,'2021-06-15','2021-05-15');
INSERT INTO BiblioBD.emprestimo VALUES (3,3,'Biblioteca Municipal',18,'2021-07-1','2021-06-1');
INSERT INTO BiblioBD.emprestimo VALUES (4,5,'Biblioteca Municipal',1,'2021-08-10','2021-07-10');
INSERT INTO BiblioBD.emprestimo VALUES (5,4,'Biblioteca Municipal',11,'2021-08-25','2021-07-25');

-- 30 items
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',1);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',2);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',3);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',4);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',5);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',6);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',7);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',8);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',9);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',10);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',11);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',12);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',13);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',14);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',15);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',16);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',17);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',18);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',19);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',20);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',21);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',22);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',23);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',24);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',25);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',26);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',27);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',28);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',29);
INSERT INTO BiblioBD.item VALUES ('Biblioteca Municipal',30);

-- 8 items emprestados:
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',1,15);
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',1,26);
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',2,3);
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',3,9);
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',4,16);
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',4,7);
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',5,28);
INSERT INTO BiblioBD.emprestimoItem VALUES ('Biblioteca Municipal',5,15);

-- 5 jornais:
INSERT INTO BiblioBD.jornais VALUES ('Biblioteca Municipal',1,'Geral','Publico','diario','2021-06-1',178);
INSERT INTO BiblioBD.jornais VALUES ('Biblioteca Municipal',2,'Geral','Jornal de Noticias','diario','2021-06-1',178);
INSERT INTO BiblioBD.jornais VALUES ('Biblioteca Municipal',3,'Geral','Correio da Manha','diario','2021-06-1',178);
INSERT INTO BiblioBD.jornais VALUES ('Biblioteca Municipal',4,'Geral','Diario de noticias','semanal','2021-05-29',18);
INSERT INTO BiblioBD.jornais VALUES ('Biblioteca Municipal',5,'Geral','Avante!','semanal','2021-05-29',18);

-- 5 revistas:
INSERT INTO BiblioBD.revistas VALUES ('Biblioteca Municipal',6,'Geral','Maria','semanal','2021-06-1',18);
INSERT INTO BiblioBD.revistas VALUES ('Biblioteca Municipal',7,'Geral','Visao Junior','semanal','2021-06-1',18);
INSERT INTO BiblioBD.revistas VALUES ('Biblioteca Municipal',8,'Geral','Visao','semanal','2021-06-1',18);
INSERT INTO BiblioBD.revistas VALUES ('Biblioteca Municipal',9,'Geral','Sabado','semanal','2021-05-29',18);
INSERT INTO BiblioBD.revistas VALUES ('Biblioteca Municipal',10,'Geral','Caras','semanal','2021-05-29',18);

-- 5 filmes:
INSERT INTO BiblioBD.filme VALUES ('Biblioteca Municipal',11,'Crianca','William Steig','Animação',2001,'Shrek');
INSERT INTO BiblioBD.filme VALUES ('Biblioteca Municipal',12,'Crianca','William Steig','Animação',2004,'Shrek 2');
INSERT INTO BiblioBD.filme VALUES ('Biblioteca Municipal',13,'Crianca','William Steig','Animação',2007,'Shrek - O terceiro');
INSERT INTO BiblioBD.filme VALUES ('Biblioteca Municipal',14,'Crianca','William Steig','Animação',2010,'Shrek Para Sempre');
INSERT INTO BiblioBD.filme VALUES ('Biblioteca Municipal',15,'Adulto','Stanley Kubrick','Terror',1980,'The Shinning');

-- 5 CDS:
INSERT INTO BiblioBD.cd VALUES ('Biblioteca Municipal',16,'One Direction','Pop',2013,'Adulto','Midnight Memories');
INSERT INTO BiblioBD.cd VALUES ('Biblioteca Municipal',17,'Taylor Swift','Pop',2020,'Adulto','Evermore');
INSERT INTO BiblioBD.cd VALUES ('Biblioteca Municipal',18,'Arctic Monkeys','Indie',2013,'Adulto','AM');
INSERT INTO BiblioBD.cd VALUES ('Biblioteca Municipal',19,'Michael Jackson','Pop',1982,'Adulto','Thriller');
INSERT INTO BiblioBD.cd VALUES ('Biblioteca Municipal',20,'Pink Floyd','Pop',1973,'Adulto','The Dark Side of the Moon');

-- 5 perifericos: 
INSERT INTO BiblioBD.perifericos VALUES ('Biblioteca Municipal',21,'Sony','MDRZX110','Fones'); 
INSERT INTO BiblioBD.perifericos VALUES ('Biblioteca Municipal',22,'Sony','WH-CH510','Fones'); 
INSERT INTO BiblioBD.perifericos VALUES ('Biblioteca Municipal',23,'Philips','3000','Fones');
INSERT INTO BiblioBD.perifericos VALUES ('Biblioteca Municipal',24,'SPC','8488D','MP3');
INSERT INTO BiblioBD.perifericos VALUES ('Biblioteca Municipal',25,'Denver','DM-24MK2','Leitor de CDs');

-- 5 livros:
INSERT INTO BiblioBD.livro VALUES ('Biblioteca Municipal',26,'Cassandra Clare','WALKER BOOKS LTD',2010,9781406330342,'Ingles','Fantasia','Juvenil','Clockwork Angel');
INSERT INTO BiblioBD.livro VALUES ('Biblioteca Municipal',27,'Jose Saramago','Porto Editora',1982,9789720046710,'Portugues','Romance','Adulto','Memorial do Convento');
INSERT INTO BiblioBD.livro VALUES ('Biblioteca Municipal',28,'Luis de Camoes','Porto Editora',1572,9789720049568,'Portugues','Poesia','Adulto','Os Lusiadas');
INSERT INTO BiblioBD.livro VALUES ('Biblioteca Municipal',29,'Filipe Faria ','Editorial Presenca',2015,9789722357067,'Portugues','Fantasia','Juvenil','A Alvorada dos Deuses');
INSERT INTO BiblioBD.livro VALUES ('Biblioteca Municipal',30,'Louisa May Alcott','PENGUIN USA',1869,9780147514011,'Ingles','Ficçao','Juvenil','Little Women');

-- Exemplos de consultas
--a)Ver funcionários que ainda trabalham na biblioteca
	SELECT * FROM BiblioBD.funcionario WHERE fim IS NULL
--b)Procurar o SSN do gerente 
	SELECT SSN FROM BiblioBD.funcionario JOIN BiblioBD.gerente ON BiblioBD.funcionario.id=BiblioBD.gerente.id
--c)Ver os empréstimos feitos pelo membro com ID=3
	SELECT * FROM BiblioBD.emprestimo WHERE BiblioBD.emprestimo.membro=11
--d)Ver se o livro com título ‘Os Lusiadas’ está disponível para empréstimo
	SELECT * FROM BiblioBD.emprestimo JOIN BiblioBD.emprestimoItem ON  BiblioBD.emprestimo.numero=BiblioBD.emprestimoItem.numero JOIN BiblioBD.livro ON BiblioBD.emprestimoItem.id=BiblioBD.livro.id WHERE titulo='Os Lusiadas'
--e)Lista de CD’s lançados depois de 1990 que estão na biblioteca
	SELECT * FROM BiblioBD.cd WHERE BiblioBD.cd.ano>1990
--f)Listar o nome dos membros que participam em mais que uma atividade
	SELECT t.nome FROM (SELECT BiblioBD.membro.nome,COUNT(*) AS soma FROM BiblioBD.membro JOIN BiblioBD.atividadeMembro ON BiblioBD.membro.id=BiblioBD.atividadeMembro.membro GROUP BY BiblioBD.membro.nome) AS t WHERE t.soma>1
--g)Ver o dia e a hora de atividades do tipo ‘teatro’
	SELECT dataAti,horario FROM BiblioBD.atividade WHERE BiblioBD.atividade.tipo LIKE 'Teatro' 

--Functions
-- adicionar membro (entrada)
-- procurar reservas (entrada e saida)
GO
CREATE FUNCTION BiblioBD.ProcurarReservasMembro(@id INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE membro=@id)

GO
SELECT * FROM BiblioBD.ProcurarReservasMembro(1)
-- trigger para as datas
GO
CREATE TRIGGER checkDates ON BiblioBD.funcionario AFTER INSERT AS
DECLARE @d1 AS DATE
DECLARE @d2 AS DATE
DECLARE @dn AS DATE
SELECT @d1=inicio,@d2=fim,@dn=nascimento FROM inserted
IF (@d1>@d2 OR @dn>@d1)
	BEGIN
	RAISERROR('Datas incorretas, tente de novo.', 16, 1);
	ROLLBACK TRAN;
	END

-- estas instrução dao erro :)
--INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',11,100025356,'a@s.pt','viapublica','antonio faria da cruz','1992-05-13',15615256,'2017-02-21',NULL);
--INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',10,100023150,'ewc@rhoncus.org','2861 Non, Rd.','Chwdde Colon','1974-04-21',251454142,'2014-03-01','2013-03-02');

GO
--DROP TRIGGER BiblioBD.checkDatesMngr 
GO
CREATE TRIGGER checkDatesMngr ON BiblioBD.gerente INSTEAD OF INSERT AS
DECLARE @inicio AS DATE
DECLARE @fim AS DATE
DECLARE @d1 AS DATE
DECLARE @d2 AS DATE
DECLARE @compare1 AS DATE
DECLARE @compare2 AS DATE
DECLARE @flag AS INT
SELECT @d1=inicio,@d2=fim FROM inserted
SELECT @flag=0
SELECT @inicio=BiblioBD.funcionario.inicio,@fim=BiblioBD.funcionario.fim FROM BiblioBD.funcionario JOIN inserted ON BiblioBD.funcionario.id=inserted.id
IF(@d1<@inicio or @d2>@fim)
	BEGIN
	RAISERROR('Um funcionário só pode ser gerente se já trabalhar para a biblioteca.', 16, 1);
	SELECT @flag=1
	END
DECLARE c CURSOR
FOR SELECT inicio,fim FROM BiblioBD.gerente;
OPEN c
FETCH c INTO @compare1,@compare2
WHILE @@FETCH_STATUS = 0
BEGIN
	if (@d2<@compare1 or @d1>@compare2)
		FETCH c INTO @compare1,@compare2
	else
		BEGIN
		RAISERROR('Apenas podemos ter um gerente de cada vez', 16, 1);
		SELECT @flag=1
		BREAK;
		END
END
CLOSE c;
DEALLOCATE c;
IF (@flag=0)
	INSERT INTO BiblioBD.gerente SELECT * FROM inserted;


--INSERT INTO BiblioBD.gerente VALUES('Biblioteca Municipal',1,'2016-01-21','2016-06-20'); nao da erro
--INSERT INTO BiblioBD.gerente VALUES('Biblioteca Municipal',2,'2016-06-21','2016-06-25'); da erro
select * from BiblioBD.gerente
--select * from sysobjects where name = 'checkDatesMngr'
--Buscar info da biblioteca
GO
CREATE PROC sp_Biblioteca(@nome varchar(60),@telefone int	OUTPUT,@morada varchar(60) OUTPUT)
AS 
SELECT @telefone=telefone,@morada=morada  FROM BiblioBD.biblioteca 
WHERE BiblioBD.biblioteca.nome LIKE @nome
--para usar:
DECLARE @tel int;
DECLARE @mor varchar(60);
EXEC dbo.sp_Biblioteca 'Biblioteca Municipal', @tel OUTPUT,@mor OUTPUT;
SELECT @tel AS tel ,@mor AS mor


--SELECT * FROM BiblioBD.emprestimo JOIN BiblioBD.emprestimoItem on BiblioBD.emprestimo.numero=BiblioBD.emprestimoItem.numero where id=15
GO
CREATE FUNCTION BiblioBD.ProcurarMembro(@id INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.membro WHERE id=@id)

GO
--DROP FUNCTION BiblioBD.ProcurarMembroNome
GO
CREATE FUNCTION BiblioBD.ProcurarMembroNome(@nome varchar(60)) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.membro WHERE nome LIKE  '%' + @nome + '%')

GO
GO
CREATE FUNCTION BiblioBD.ProcurarMembroIDNome(@id INT,@nome varchar(60)) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.membro WHERE nome LIKE  '%' + @nome + '%' and id=@id)

-- temos que criar a tabela oldEmprestimo
--DROP PROCEDURE BiblioBD.EliminarItem
GO
CREATE PROCEDURE BiblioBD.EliminarItem(@id INT)
AS
DECLARE @count AS INT
SELECT @count=COUNT(id) FROM BiblioBD.emprestimoItem JOIN BiblioBD.emprestimo ON BiblioBD.emprestimo.numero=BiblioBD.emprestimoItem.numero WHERE id=@id AND limite>GETDATE()
IF (@count>0)
	RAISERROR('Não pode eliminar este item, ele está num emprestimo',16,1);
ELSE
BEGIN
	DELETE FROM BiblioBD.item WHERE id=@id
END

GO
CREATE PROCEDURE BiblioBD.AdicionarMembro(@nome varchar(60),@email varchar(60),@morada varchar(60),@nascimento date,@NIF int)
AS
DECLARE @newid AS INT
SELECT @newid=MAX(id)+1 FROM BiblioBD.membro 
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',@newid,@email,@morada,@nome,@nascimento,@NIF)

GO
CREATE PROCEDURE BiblioBD.AdicionarFunc(@nome varchar(60),@email varchar(60),@morada varchar(60),@nascimento date,@NIF int,@ssn int,@inicio date,@fim date)
AS
DECLARE @newid AS INT
SELECT @newid=MAX(id)+1 FROM BiblioBD.funcionario
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',@newid,@ssn,@email,@morada,@nome,@nascimento,@NIF,@inicio,@fim)

--SELECT * FROM BiblioBD.membro
--DELETE FROM BiblioBD.Membro where nif=123
--EXEC BiblioBD.AdicionarMembro a,a,a,'2021-06-16',123

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNum(@num INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num)


GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoIDM(@idm INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE membro=@idm)

	
GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoIDF(@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE funcionario=@idf)

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNumIDF(@num INT,@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num and funcionario=@idf)
GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNumIDM(@num INT,@idm INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num and membro=@idm)
GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoIDMIDF(@idm INT,@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE membro=@idm and funcionario=@idf)
GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNumIDMIDF(@num INT,@idm INT,@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num and membro=@idm and funcionario=@idf)

GO
CREATE PROCEDURE BiblioBD.EditarMembro(@id INT,@nome varchar(60),@email varchar(60),@morada varchar(60),@nascimento date,@NIF int)
AS
UPDATE BiblioBD.membro SET nome=@nome,email=@email,morada=@morada,nascimento=@nascimento,NIF=@nif WHERE id=@id
