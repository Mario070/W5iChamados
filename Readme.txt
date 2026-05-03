W5iChamados - Sistema de Controle de Chamados

Aplicação desenvolvida com o objetivo de gerenciar o fluxo de chamados de suporte ou solicitações internas. O sistema permite o cadastro, acompanhamento e finalização de chamados, respeitando regras de negócio e controle de tempo baseado em prioridades.

Tecnologias Utilizadas

* .NET (ASP.NET Core Web API)
* C#
* Entity Framework Core
* SQL Server
* Swagger 


Arquitetura

Controllers → Camada de entrada 
Services    → Regras de negócio
Models      → Entidades do sistema
Data        → Contexto do banco 
DTOs        → Objetos de transferência de dados
Scripts     → Script SQL de criação do banco

Funcionalidades

Cadastro

* Setores
* Prioridades (com tempo estimado em horas)

Chamados

* Abertura de chamado
* Início de atendimento (check-in)
* Finalização (check-out com solução)
* Cancelamento de chamado

Regras de Negócio

* Não é possível iniciar chamados finalizados ou cancelados
* Não é possível finalizar chamados que não foram iniciados
* Controle de tempo baseado na prioridade
* Identificação de chamados atrasados

Listagem

Exibe:

  * Setor
  * Prioridade
  * Status
  * Tempo de atendimento
  * Indicação de atraso

Exemplo de Resposta

json
{
  "id": 1,
  "titulo": "Erro na impressora",
  "setor": "TI",
  "prioridade": "Média",
  "status": "Finalizado",
  "tempo": "0h 2m 10s",
  "tempoHoras": 0.03,
  "atrasado": false
}

Como executar o projeto

1: Clonar o repositório

git clone <url-do-repositorio>
cd W5iChamados

2: Configurar o banco de dados

* Criar banco no SQL Server
* Executar o script localizado em: Scripts/banco.sql

3: Configurar a conexão

Editar o arquivo: appsettings.json

json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=W5iChamadosDB;Trusted_Connection=True;TrustServerCertificate=True;"
}


4: Executar a aplicação

dotnet run

5: Acessar Swagger

http://localhost:xxxx/swagger

Autor: Mario Cezar Da Silva Carvalho Filho
