# Propósito do Sistema

Este projeto demonstra uma arquitetura de microsserviços para gerenciar pedidos, inventários e pagamentos. Ele permite que os usuários façam pedidos, consultem a disponibilidade de itens no estoque e realizem pagamentos através da API do Stripe. O sistema também atualiza automaticamente o status dos pedidos com base na confirmação ou cancelamento do pagamento.

# Usuários

- Usuários do sistema: Pessoas que utilizam a plataforma para realizar login, consultar itens disponíveis e fazer pedidos.

- Administradores (opcional): Responsáveis por gerenciar o inventário e monitorar pedidos.

# Requisitos Funcionais

**1. Gestão de Inventário:**
   - Consultar itens disponíveis.
   - Adicionar, editar ou remover itens do inventário.

**2. Gestão de Usuários:**
  - Cadastro de novos usuários.
  - Login e autenticação para realizar pedidos.

**3. Gestão de Pedidos:**
  - Criar pedidos vinculados a usuários e itens do inventário.
  - Calcular automaticamente o preço total com base na quantidade solicitada.
  - Atualizar o status do pedido com base no pagamento via Stripe.
  - Listar, editar e cancelar pedidos existentes.

**4. Integração com Stripe:**
  - Gerar links de pagamento únicos para cada pedido.
  - Atualizar o status do pedido após confirmação ou cancelamento do pagamento.

**5. Autenticação e Segurança:**
  - Operações protegidas com autenticação baseada em usuários.

# Tabelas do Banco de Dados

**1. Inventory**
  - Campo	Tipo	Descrição.
  - id	Integer (PK)	Identificador único do item.
  - name	String	Nome do item.
  - description	String	Descrição detalhada do item.
  - price	Float	Preço do item.
  - quantity	Integer	Quantidade em estoque.

**2. Users**
  - Campo	Tipo	Descrição.
  - id	Integer (PK)	Identificador único do usuário.
  - login	String	Nome de usuário.
  - password	String	Senha do usuário.

**3. Order**
  - Campo	Tipo	Descrição.
  - id	Integer (PK)	Identificador único do pedido.
  - user_id	Integer (FK)	ID do usuário que realizou o pedido.
  - inventory_id	Integer (FK)	ID do item do inventário relacionado.
  - quantity	Integer	Quantidade do item solicitado no pedido.
  - total_price	Float	Preço total calculado do pedido.
  - status	Enum	Status do pedido: Pending, Paid, Cancelled.

# APIs Externas

O sistema integra pagamentos utilizando a API do Stripe.

# Arquitetura do Sistema

Este projeto utiliza a arquitetura de microsserviços com as seguintes tecnologias:

- Backend: Implementado em .NET.
- Banco de dados: SQLite para armazenamento persistente.
- REST API: Comunicação entre microsserviços e usuários.
- Microsserviços principais:
- Inventário: CRUD para itens no estoque.
- Usuários: CRUD para cadastro e autenticação de usuários.
- Pedidos: CRUD para gerenciamento de pedidos e integração com Stripe.
