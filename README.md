# AgendaChallenger

Este é um projeto de gerenciamento de compromissos com integração ao Google Calendar e autenticação JWT. Desenvolvido com foco em boas práticas, arquitetura limpa e escalabilidade.

---

## 👨‍💻 Desenvolvedor

**Cézar da Cunha Barcellos**  
📍 Belo Horizonte - MG

---

## 🧰 Tecnologias e Padrões Utilizados

### ✔️ Visual Studio 2022
Ferramenta de desenvolvimento poderosa, com suporte a C#, .NET, debugging avançado e integração com Git.

### ✔️ MediatR
Implementa o padrão **Mediator**, promovendo um baixo acoplamento entre componentes. Usei para separar responsabilidades em comandos e eventos.

### ✔️ CQRS (Command Query Responsibility Segregation)
Separação entre comandos (ações que alteram estado) e consultas (ações que apenas leem dados), aumentando performance e organização do código.

### ✔️ Entity Framework Core
ORM para mapeamento objeto-relacional, usei porque facilita o acesso e manipulação de dados com suporte a LINQ, migrations e integrações com bancos de dados modernos, embora custe um pouco de desempenho.

### ✔️ JWT (JSON Web Token)
Utilizado para autenticação via token Bearer. Usei para promover proteção por autenticação segura e escalável, ideal para APIs modernas.

## 📦 Pacotes Instalados

- **MediatR** – Facilita a implementação de padrões como CQRS e Mediator.
- **Google.Apis.Calendar.v3** – Integração com o Google Calendar para sincronização de compromissos.
- **Microsoft.AspNetCore.Authentication.JwtBearer** – Suporte à autenticação com JWT.
- **Microsoft.EntityFrameworkCore** – ORM para .NET, facilita a manipulação do banco de dados.

## ⚙️ Configurações de Ambiente

As configurações de ambiente (como strings de conexão, parâmetros do Google Calendar, JWT e portas de escuta) estão no arquivo `appsettings.json` de cada projeto.

▶️ Como Executar a API
Para que a aplicação funcione corretamente, certifique-se de iniciar os 3 projetos principais da solução:

AgendaChallenger – Projeto principal da API.
Data – Responsável pelo acesso a dados via Entity Framework.
GoogleCalendar – Serviço responsável pela integração com o Google Calendar.
Você pode iniciar todos os projetos diretamente pelo Visual Studio 2022, definindo múltiplos projetos de inicialização.

📌 Funcionalidades
✅ Cadastro, edição e exclusão de compromissos
✅ Visualização de compromissos em tabela e calendário
✅ Autenticação segura com JWT (Operações do Compromisso)
✅ Sincronização com Google Calendar
✅ Separação clara entre leitura e escrita com CQRS
✅ Código limpo e desacoplado com MediatR

📄 Licença
Este projeto está sob licença MIT. Sinta-se livre para estudar, modificar e contribuir!
