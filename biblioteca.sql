use p9g4;
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