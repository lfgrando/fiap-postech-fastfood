# fiap-postech-fastfood
Backend system for a self-service fast food restaurant, developed as part of the FIAP Software Architecture Tech Challenge. Implements Domain-Driven Design (DDD) and Hexagonal Architecture. Includes customer registration, product management, order tracking, and integration with Mercado Pago via QR Code for checkout.

# 🍔 FIAP Postech Fast Food

Projeto desenvolvido para o Tech Challenge da FIAP Pós-Tech, com foco na construção de um sistema de autoatendimento de fast food.

---

## 📌 Sobre o projeto

Este sistema tem como objetivo gerenciar o processo de pedidos em uma lanchonete que opera por meio de totens de autoatendimento (*kiosks*), oferecendo:

- Cadastro e identificação de clientes
- Visualização e montagem de pedidos via menu digital
- Integração com gateway de pagamento (Mercado Pago - QR Code)
- Acompanhamento do pedido até a retirada

---

## ⚙️ Tecnologias utilizadas

- [.NET 8.0](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- **MongoDB** (utilizado como banco principal para todos os módulos)
- **Docker** e **Docker Compose**
- **Swagger** para documentação da API
- **mongo-express** para visualização e consulta da base de dados

---

## 🚀 Como executar o projeto

### Pré-requisitos

- Docker instalado
- .NET 8.0

### Passos

1. Subir o ambiente completo (API + MongoDB + mongo-express):

   Comando:

   ```bash
	docker-compose up --build -d
   ```

   Isso irá:  
   - Subir todos os containers  
   - Executar automaticamente o seed de dados via `db/init/init.js`
   - Inicializar o Swagger na API  
   - Disponibilizar o banco de dados com nome `fiap_fastfood`

2. Encerrar os serviços:

   Comando:
   ```bash
   docker-compose down -v
   ```
---

## 🧪 Acessos úteis

- Swagger UI: [https://localhost:7206/swagger/index.html](https://localhost:7206/swagger/index.html)
- Mongo Express: [http://localhost:8081](http://localhost:8081)
  - Banco: `fiap_fastfood`

---

## 📂 Estrutura de Pastas (Arquitetura Hexagonal)

src/  
├── Adapters/  
│   ├── Driven/  
│   │   ├── DataAccess/  
│   │   │   └── MongoAdapter/  
│   │   ├── Kitchen.Infra/  
│   │   ├── Menu.Infra/  
│   │   ├── Order.Infra/  
│   │   ├── Payment.Infra/  
│   │   ├── SelfService.Infra/  
│   │   └── Stock.Infra/  
│   └── Driving/  
│       └── Api/  
├── Core/  
│   ├── Kitchen/  
│   │   ├── Kitchen.Application/  
│   │   └── Kitchen.Domain/  
│   ├── Menu/  
│   │   ├── Menu.Application/  
│   │   └── Menu.Domain/  
│   ├── Order/  
│   │   ├── Order.Application/  
│   │   └── Order.Domain/  
│   ├── Payment/  
│   │   ├── Payment.Application/  
│   │   └── Payment.Domain/  
│   ├── SelfService/  
│   │   ├── SelfService.Application/  
│   │   └── SelfService.Domain/  
│   └── Stock/  
│       ├── Stock.Application/  
│       └── Stock.Domain/  
├── CrossCutting/  
│   └── CrossCutting.Exceptions/  
db/



---

## 🔗 Principais Endpoints

| Método | Rota                          | Descrição                                    |
|--------|-------------------------------|----------------------------------------------|
| GET    | /Menu                         | Obtém os itens disponíveis no cardápio       |
| POST   | /SelfService/customer         | Cadastra um novo cliente                     |
| GET    | /SelfService/customer/[cpf]   | Busca cliente por CPF                        |
| POST   | /Order/[id]/checkout          | Confirma pedido e obtém dados para pagamento |
| GET    | /Order/[id]/confirm-payment   | Lista todos os pedidos                       |

ℹ️ Para mais detalhes, acesse o [Swagger](https://localhost:7206/swagger/index.html).

---

## 🧠 Arquitetura

A aplicação segue princípios de Domain-Driven Design (DDD) e Arquitetura Hexagonal, separando claramente:

- Lógica de domínio  
- Casos de uso  
- Interfaces de entrada (API)  
- Interfaces de saída (MongoDB)  

---

## 📥 Seed de dados

O script `db/init/init.js` popula o banco com os itens de menu iniciais automaticamente ao subir os containers.

---

## 🛑 Encerrando o ambiente

Comando:
```bash
docker-compose down -v
```

---

## 🧑‍💻 Autores

Projeto desenvolvido como parte da Pós-Tech em Arquitetura de Software - FIAP por:
- Leandro Grando - [lfgrando](https://github.com/lfgrando)
- Victor Montenegro - [Victor-Montenegro](https://github.com/Victor-Montenegro)
- José Elias - [eliasjay](https://github.com/eliasjay)