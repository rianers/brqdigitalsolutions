# BRQ Digital Solution

API Restful criada para cadastro de candidatos para processos seletivos dentro da BRQ, onde são enviadas requisições HTTP para cadastro, atualização e pesquisas.

No sistema há 4 endpoints divididos em:

### Candidato

- `GET /Candidates` <br>
  Retorna o cadastro de determinado candidato, permitindo também a busca por candidatos por campo-chave (Nome, Email, CPF, Skills e Certificações).
- `GET /Candidates/{id}` <br>
  Retorna o cadastro de determinado candidato pelo seu ID.
- `POST /Candidates` <br>
  Cadastra um candidato.
- `PUT /Candidates/{id}` <br>
  Atualiza o cadastro de um candidato.

</br>
Para verificar a documentação da utilização dessas API'S, complete o tópico de <a href="#instalacao"> 🔧 Instalação </a>. O Swagger informará os parâmetros e rotas necessárias.
<img src="https://media.discordapp.net/attachments/908865516016390156/969784991812841482/unknown.png?width=1020&height=347"></img>

# 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto na sua máquina local para fins de desenvolvimento e teste.

```sh
$ git clone https://github.com/rianers/brqdigitalsolutions.git brqdigitalsolutions
```

# 📋 Pré-requisitos

O que é necessário para a instalação?

- [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)
- [PostgreSQL](https://hub.docker.com/_/postgres)

# 🔧 Instalação

Uma série de exemplos passo-a-passo que informam o que você deve executar para ter um ambiente de desenvolvimento em execução.

```sh
# Crie um arquivo .env usando como base o .env.example, edite esse arquivi (.env) com as credenciais de configuração do seu banco postgres

DB_HOSTNAME= // host do banco
DB_PORT=5432 // porta do banco
DB_DATABASE= // nome do banco
DB_USERNAME= // usuario do banco
DB_PASSWORD= // senha do banco
```

# 🛠️ Tecnologias

- [.NET 6](https://dotnet.microsoft.com/en-us/) - Tecnologia de desenvolvimento da API
- [Swagger](https://swagger.io/) - Ferramenta para criação da documentação da API.
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/) - ORM utilizado para criação de relação entre o modelo físico e o modelo lógico da aplicação.

Developed by [LiftOff 🚀]() with :heart: but without :coffee:
