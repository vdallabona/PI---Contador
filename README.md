# Controle de Finanças Pessoais

Este projeto é um sistema simples para controle de finanças pessoais desenvolvido em C# com interface gráfica utilizando Windows Forms e banco de dados MySQL.

## Funcionalidades

- Cadastro de gastos associados a categorias pré-definidas.
- Visualização e edição de gastos cadastrados.
- Cadastro de Categorias.
- Interface intuitiva.

## Tecnologias Utilizadas

- C# (.NET Framework)
- Windows Forms
- MySQL

## Configuração do Ambiente

### Pré-requisitos

- Visual Studio 
- MySQL

### Configuração do Banco de Dados

1. Importe o arquivo SQL fornecido (`script.sql`) para criar as tabelas necessárias no seu banco de dados MySQL.

### Configuração do Projeto

1. Clone este repositório para o seu ambiente local.
2. Abra o projeto no Visual Studio.
3. Certifique-se de que todas as dependências foram restauradas através do NuGet Package Manager.
4. Configure a string de conexão com o seu banco de dados MySQL em `RepoGastos.cs` e `RepoCategoria.cs`.

## Como Utilizar

1. Execute o projeto no Visual Studio.
2. Faça Cadastro/login com suas credenciais.
3. Explore as funcionalidades disponíveis na interface.