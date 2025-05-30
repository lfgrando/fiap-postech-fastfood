# 🔤 Ubiquitous Language — FIAP Postech Fast Food

Este documento define os principais termos e conceitos utilizados de forma consistente por todas as partes envolvidas no projeto.

---

### 👤 Customer (Cliente)
Pessoa que interage com o sistema para realizar um pedido. Pode se identificar via CPF, realizar um cadastro básico, ou permanecer anônima.

---

### 🖥️ Self-Service (Totem / Auto-atendimento)
Terminal físico de autoatendimento onde o cliente interage com o sistema, monta seu pedido, escolhe os itens desejados e realiza o pagamento.

---

### 🧠 System Core (Sistema)
Conjunto de componentes responsáveis por orquestrar as operações internas da aplicação, incluindo o gerenciamento de pedidos, controle de fluxo entre módulos e persistência de dados.

---

### 🧾 Order (Módulo de Pedidos)
Responsável por capturar, validar e processar os pedidos realizados pelos clientes. Controla o ciclo de vida do pedido:
- Recebido
- Em preparo
- Pronto
- Finalizado

---

### 🍔 Menu (Gestão de Cardápio)
Gerencia os itens disponíveis para pedido, agrupando-os em categorias fixas:
- MainCourse (Lanche)
- SideDish (Acompanhamento)
- Beverage (Bebida)
- Dessert (Sobremesa)

---

### 🔥 Kitchen (Cozinha)
Gerencia a fila de pedidos da cozinha e o progresso da preparação.

---

### 📦 Stock (Estoque)
Controle da disponibilidade de produtos, permitindo ao estabelecimento ajustar o menu conforme a quantidade disponível.

---

### 💳 Payment Gateway
Responsável por integrar e registrar o pagamento dos pedidos. No MVP, utiliza QR Code do Mercado Pago como forma de checkout.