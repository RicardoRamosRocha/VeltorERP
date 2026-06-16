# Arquitetura

## Visão Geral

O Veltor ERP será desenvolvido utilizando Arquitetura em Camadas, separando responsabilidades para facilitar manutenção, testes e evolução do sistema.

## Estrutura da Solução

```text
VeltorERP
│
├── VeltorERP.Web
├── VeltorERP.Application
├── VeltorERP.Domain
└── VeltorERP.Infrastructure
```

## Camadas

### VeltorERP.Web

Responsável pela interface do usuário.

Responsabilidades:

* Controllers
* Views
* ViewModels
* Autenticação
* Interface MVC

---

### VeltorERP.Application

Responsável pelas regras de aplicação.

Responsabilidades:

* Services
* DTOs
* Casos de Uso
* Validações

---

### VeltorERP.Domain

Responsável pelas regras de negócio.

Responsabilidades:

* Entities
* Enums
* Interfaces
* Regras de domínio

---

### VeltorERP.Infrastructure

Responsável pelo acesso a dados.

Responsabilidades:

* Entity Framework Core
* AppDbContext
* Repositories
* Migrations
* Integrações externas

---

## Banco de Dados

* PostgreSQL

---

## ORM

* Entity Framework Core

---

## Controle de Versão

* Git
* GitHub

---

## Padrões

* SOLID
* Clean Code
* Repository Pattern
* Dependency Injection

---

## Futuro

Preparar a arquitetura para:

* Multiempresa
* API REST
* Aplicativo Mobile
* SaaS
