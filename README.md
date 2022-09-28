# Pottencial API 

Foi desenvolvida uma API REST para cadastro de Contatos

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- SQL Server
- Swagger
- Injeção de Dependência
- Programação Orientada a Objetos

## Funcionalidades
- Cadastro de Contatos
- Listagem de Contatos
- Atualização de Contatos
- Exclusão de Contatos

## Passo a passo para rodar o Projeto (Visual Studio Code)
- Necessário SDK .NET 6.0 
##
- dotnet tool install --global dotnet-ef
- Alterar o arquivo "appsettings.Development", adicionando os dados do seu banco Local (Necessário ser SQL Server, recomendo usar autenticação por usuário do SQL, caso use autenticação pelo windows, necessário alterar os dados da conexão)
- dotnet ef migrations add AdicionarContatoAgenda 
- dotnet ef database update
- dotnet run
