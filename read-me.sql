CREATE TABLE `categorias`(
    `idCategorias` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nomeCategoria` VARCHAR(255) NOT NULL
);
CREATE TABLE `usuarios`(
    `idUsuario` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idFamilia` INT UNSIGNED NOT NULL,
    `nome` VARCHAR(255) NOT NULL,
    `login` VARCHAR(255) NOT NULL,
    `senha` VARCHAR(255) NOT NULL,
    `adm` BOOLEAN NOT NULL
);
CREATE TABLE `familia`(
    `idFamilia` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nomeFamilia` VARCHAR(255) NOT NULL
);
CREATE TABLE `familiaCategorias`(
    `idFamiliaCategorias` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idFamilia` INT UNSIGNED NOT NULL,
    `idCategorias` INT UNSIGNED NOT NULL
);
CREATE TABLE `gastos`(
    `idGastos` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idUsuario` INT UNSIGNED NOT NULL,
    `idCategoria` INT UNSIGNED NOT NULL,
    `nome` VARCHAR(255) NOT NULL,
    `valor` DECIMAL(8, 2) NOT NULL,
    `data` DATE NOT NULL,
    `idFamilia` INT
);

ALTER TABLE
    `gastos` ADD CONSTRAINT `gastos_idusuario_foreign` FOREIGN KEY(`idUsuario`) REFERENCES `usuarios`(`idUsuario`);
ALTER TABLE
    `usuarios` ADD CONSTRAINT `usuarios_idfamilia_foreign` FOREIGN KEY(`idFamilia`) REFERENCES `familia`(`idFamilia`);
ALTER TABLE
    `familiaCategorias` ADD CONSTRAINT `familiacategorias_idfamilia_foreign` FOREIGN KEY(`idFamilia`) REFERENCES `familia`(`idFamilia`);
ALTER TABLE
    `familiaCategorias` ADD CONSTRAINT `familiacategorias_idcategorias_foreign` FOREIGN KEY(`idCategorias`) REFERENCES `categorias`(`idCategorias`);
ALTER TABLE
    `gastos` ADD CONSTRAINT `gastos_idcategoria_foreign` FOREIGN KEY(`idCategoria`) REFERENCES `categorias`(`idCategorias`);

---------------------------- INSERT ---------------------------- INSERT ---------------------------- INSERT ---------------------------- INSERT ---------------------------- INSERT 

INSERT INTO categorias (nomeCategoria)
VALUES
("Alimentos"),
("Conta Luz"),
("Conta Água"),
("Lazer");

INSERT INTO familia (nomeFamilia)
VALUES
("Santos"),
("Souza"),
("Santonni"),
("Maronni");

INSERT INTO familiaCategorias (idFamilia, idCategorias)
VALUES
("1", "1"),
("2", "1"),
("3", "1"),
("4", "1"),
("1", "2"),
("1", "3");


INSERT INTO usuarios (idFamilia, nome, login, senha, adm)
VALUES
("1", "João", "João6969", "admin123", "0"),
("1", "Maria", "MariDragonSlayer", "JoãoTemPauPequeno", "1"),
("1", "Joaquim", "quimMinecraft", "redstone4life", "1"),
("2", "Roberto", "Roberto1998", "senha", "1"),
("2", "Anita", "AnitaSouza", "Cacto4ever", "0"),
("3", "Jenna", "JennaSantonniIII", "realeza", "0");

INSERT INTO gastos (idUsuario, idCategoria, nome, valor, data)
VALUES
("3", "4", "Licença do Minecraft", "34.40", "2024-02-02"),
("4", "3", "Conta água 01/2024", "450.20", "2024-01-29"),
("6", "1", "Filé minginhon 5 estrelas", "99.99", "2024-04-12"),
("5", "4", "Show da Annita", "300.00", "2024-06-22");