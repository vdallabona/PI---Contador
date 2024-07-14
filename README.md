CREATE TABLE `gastos`(
    `idGastos` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idUsuario` INT UNSIGNED NOT NULL,
    `idCategoria` INT UNSIGNED NOT NULL,
    `Nome` VARCHAR(255) NOT NULL,
    `Valor` DECIMAL(8, 2) NOT NULL,
    `Data` DATE NOT NULL
);
CREATE TABLE `usuarios`(
    `idUsuario` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idFamilia` INT UNSIGNED NOT NULL,
    `Nome` VARCHAR(255) NOT NULL,
    `Login` VARCHAR(255) NOT NULL,
    `Senha` VARCHAR(255) NOT NULL,
    `adm` BOOLEAN NOT NULL
);
CREATE TABLE `familia`(
    `idFamilia` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nomeFamilia` VARCHAR(255) NOT NULL
);
CREATE TABLE `categorias`(
    `idCategorias` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Nome` VARCHAR(255) NOT NULL
);
CREATE TABLE `familiaCategorias`(
    `idFamiliaCategorias` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `idFamilia` INT UNSIGNED NOT NULL,
    `idCategorias` INT UNSIGNED NOT NULL
);
ALTER TABLE
    `gastos` ADD CONSTRAINT `gastos_idusuario_foreign` FOREIGN KEY(`idUsuario`) REFERENCES `usuarios`(`idUsuario`);
ALTER TABLE
    `gastos` ADD CONSTRAINT `gastos_idcategoria_foreign` FOREIGN KEY(`idCategoria`) REFERENCES `categorias`(`idCategorias`);
ALTER TABLE
    `familiaCategorias` ADD CONSTRAINT `familiacategorias_idfamilia_foreign` FOREIGN KEY(`idFamilia`) REFERENCES `familia`(`idFamilia`);
ALTER TABLE
    `familiaCategorias` ADD CONSTRAINT `familiacategorias_idcategorias_foreign` FOREIGN KEY(`idCategorias`) REFERENCES `categorias`(`idCategorias`);
ALTER TABLE
    `usuarios` ADD CONSTRAINT `usuarios_idfamilia_foreign` FOREIGN KEY(`idFamilia`) REFERENCES `familia`(`idFamilia`);

---------------------------- INSERT ---------------------------- INSERT ---------------------------- INSERT ---------------------------- INSERT ---------------------------- INSERT 

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
("1", "1", "João", "João6969", "admin123", "0"),
("2", "1", "Maria", "MariDragonSlayer", "JoãoTemPauPequeno", "1"),
("3", "1", "Joaquim", "quimMinecraft", "redstone4life", "1"),
("4", "2", "Roberto", "Roberto1998", "senha", "1"),
("5", "2", "Anita", "AnitaSouza", "Cacto4ever", "0"),
("6", "3", "Jenna", "JennaSantonniIII", "realeza", "0");

INSERT INTO gastos (idUsuario, idCategoria, Nome, Valor, Data)
VALUES
("3", "4", "Licença do Minecraft", "34.40", "2024-02-02"),
("4", "3", "Conta água 01/2024", "450.20", "2024-01-29"),
("6", "1", "Filé minginhon 5 estrelas", "99.99", "2024-04-12"),
("5", "4", "Show da Annita", "300.00", "2024-06-22");

