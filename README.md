# SchoolFlow-API

API REST desenvolvida em ASP.NET Core para gerenciamento escolar, permitindo o cadastro de professores, turmas e alunos, além do controle de relacionamento entre eles.

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger
- Git

## Funcionalidades

- Cadastro de professores
- Cadastro de turmas
- Associação de turmas a professores
- Cadastro de alunos
- Associação de alunos a turmas
- Validação de e-mail único
- Tratamento global de exceções
- Respostas padronizadas

## Como Executar o Projeto

1. Clone o repositório
2. Configure a string de conexão no arquivo `appsettings.json`
3. Execute as migrations do Entity Framework
4. Rode o projeto
5. Acesse o Swagger em `https://localhost:xxxx/swagger`

## Estrutura do Projeto

- Controllers
- Models
- Data
- Middlewares
- Responses

---

Desenvolvido por Matheus Mendonça
