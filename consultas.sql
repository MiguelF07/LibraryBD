use Projeto;
-- Exemplos de consultas
--a)Ver funcion�rios que ainda trabalham na biblioteca
	SELECT * FROM BiblioBD.funcionario WHERE fim IS NULL
--b)Procurar o SSN do gerente 
	SELECT SSN FROM BiblioBD.funcionario JOIN BiblioBD.gerente ON BiblioBD.funcionario.id=BiblioBD.gerente.id
--c)Ver os empr�stimos feitos pelo membro com ID=3
	SELECT * FROM BiblioBD.emprestimo WHERE BiblioBD.emprestimo.membro=11
--d)Ver se o livro com t�tulo �Os Lusiadas� est� dispon�vel para empr�stimo
	SELECT * FROM BiblioBD.emprestimo JOIN BiblioBD.emprestimoItem ON  BiblioBD.emprestimo.numero=BiblioBD.emprestimoItem.numero JOIN BiblioBD.livro ON BiblioBD.emprestimoItem.id=BiblioBD.livro.id WHERE titulo='Os Lusiadas'
--e)Lista de CD�s lan�ados depois de 1990 que est�o na biblioteca
	SELECT * FROM BiblioBD.cd WHERE BiblioBD.cd.ano>1990
--f)Listar o nome dos membros que participam em mais que uma atividade
	SELECT t.nome FROM (SELECT BiblioBD.membro.nome,COUNT(*) AS soma FROM BiblioBD.membro JOIN BiblioBD.atividadeMembro ON BiblioBD.membro.id=BiblioBD.atividadeMembro.membro GROUP BY BiblioBD.membro.nome) AS t WHERE t.soma>1
--g)Ver o dia e a hora de atividades do tipo �teatro�
	SELECT dataAti,horario FROM BiblioBD.atividade WHERE BiblioBD.atividade.tipo LIKE 'Teatro' 