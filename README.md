# GitHub API Intermediária

Este projeto é uma API intermediária desenvolvida em **C#** com o objetivo de consumir os repositórios do GitHub da Take.net e disponibilizar as informações de forma organizada. A API segue as boas práticas de desenvolvimento RESTful e é integrada com um chatbot criado na plataforma **Blip**.

## Funcionalidades

- Consultar repositórios públicos da organização **Take.net**.
- Filtrar repositórios baseados na linguagem de programação, como **C#**.
- Retornar detalhes específicos dos repositórios, como:
  - Nome
  - Descrição
  - Data de criação
  - Última atualização
  - Quantidade de estrelas
  - Quantidade de forks
- Tratamento de erros para respostas consistentes.

## Tecnologias Utilizadas

- **C#** com **.NET 6/7/9**
- **ASP.NET Core Web API**
- **HttpClient** para consumir a API do GitHub
- **Swagger** para documentação da API
- **Docker** para containerização
- **Blip** para integração com o chatbot

## Configuração do Ambiente

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado
- [Docker](https://www.docker.com/) (opcional para execução via container)
- [Visual Studio Code](https://code.visualstudio.com/) (ou outro editor de sua preferência)
- Conta no [Render](https://render.com/) para hospedagem (opcional)

### Configuração do Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/RiltonMaciel/GitHubApi.git
   cd GitHubApi


