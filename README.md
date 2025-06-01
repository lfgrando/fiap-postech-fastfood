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

## 📄 Documentação

- [Diagramas - Event Storming | Story Telling | Bounded Context](https://drive.google.com/drive/folders/1xNRAZfIqpomhRkz2gcdYtUZLtypkbk99)
- [Evidências de Desenvolvimento ](https://drive.google.com/drive/folders/1ptX92zr9ImXOPE8CUBSneuTZCRWBGyF4)
- [Documentos](https://drive.google.com/drive/folders/1EetNjhhsiNHsdST1Y8xH1hMnI4fPpDNv)


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

- Swagger UI: [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)
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
| POST   | /Menu                         | Criação de um novo menu                      |
| GET    | /Menu/[id]                    | Consultar item de menu pelo ID               |
| PUT    | /Menu/[id]                    | Atualizar item de menu pelo ID               |
| DELETE | /Menu/[id]                    | deletar item de menu pelo ID                 |
| POST   | /SelfService/customer         | Cadastra um novo cliente                     |
| GET    | /SelfService/customer/[cpf]   | Busca cliente por CPF                        |
| GET    | /Order                        | Consultar pedido paginado                    |
| POST   | /Order                        | Criar pedido                                 |
| GET    | /Order/[id]                   | Consultar pedido por ID                      |
| DELETE | /Order/[id]                   | Deletar pedido por ID                        |
| PATCH  | /Order/[id]                   | Atualizar itens do pedido por ID             |
| POST   | /Payment/[id]/checkout        | Confirma pedido e obtém dados para pagamento |
| GET    | /Payment/[id]/confirm-payment | Lista todos os pedidos                       |

ℹ️ Para mais detalhes, acesse o [Swagger](http://localhost:8080/swagger/index.html).

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