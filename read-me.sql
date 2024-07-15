INSERT INTO categorias (idCategorias, Nome)
VALUES
("1", "Alimentos"),
("2", "Conta Luz"),
("3", "Conta Água"),
("4", "Lazer");

INSERT INTO familia (idFamilia, nomeFamilia)
VALUES
("1", "Santos"),
("2", "Souza"),
("3", "Santonni"),
("4", "Maronni");

INSERT INTO familiaCategorias (idFamiliaCategorias, idFamilia, idCategorias)
VALUES
("1", "1", "1"),
("2", "2", "1"),
("3", "3", "1"),
("4", "4", "1"),
("5", "1", "2"),
("6", "1", "3");

INSERT INTO usuarios (idUsuario, idFamilia, Nome, Login, Senha, adm)
VALUES
("1", "1", "João", "João6969", "admin123", "1"),
("2", "1", "Maria", "MariDragonSlayer", "JoãoTemPauPequeno", "0"),
("3", "1", "Joaquim", "quimMinecraft", "redstone4life", "0"),
("4", "2", "Roberto", "Roberto1998", "senha", "0"),
("5", "2", "Anita", "AnitaSouza", "Cacto4ever", "1"),
("6", "3", "Jenna", "JennaSantonniIII", "realeza", "1");

INSERT INTO gastos (idUsuario, idCategoria, Nome, Valor, Data)
VALUES
("3", "4", "Licença do Minecraft", "34.40", "2024-02-02"),
("4", "3", "Conta água 01/2024", "450.20", "2024-01-29"),
("6", "1", "Filé minginhon 5 estrelas", "99.99", "2024-04-12"),
("5", "4", "Show da Annita", "300.00", "2024-06-22");
