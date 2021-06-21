use Projeto;
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