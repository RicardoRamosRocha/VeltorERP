# Modelagem Inicial do Banco de Dados

## Company

Representa a oficina cadastrada no sistema.

| Campo     | Tipo     |
| --------- | -------- |
| Id        | Guid     |
| Name      | string   |
| Document  | string   |
| Phone     | string   |
| Email     | string   |
| Address   | string   |
| CreatedAt | DateTime |

---

## Customer

Representa o cliente da oficina.

| Campo     | Tipo     |
| --------- | -------- |
| Id        | Guid     |
| CompanyId | Guid     |
| Name      | string   |
| Phone     | string   |
| Email     | string   |
| Document  | string   |
| CreatedAt | DateTime |

---

## Vehicle

Representa o veículo do cliente.

| Campo      | Tipo   |
| ---------- | ------ |
| Id         | Guid   |
| CustomerId | Guid   |
| Plate      | string |
| Brand      | string |
| Model      | string |
| Year       | int    |
| Color      | string |
| Mileage    | int    |

---

## ServiceOrder

Representa uma Ordem de Serviço.

| Campo       | Tipo      |
| ----------- | --------- |
| Id          | Guid      |
| CustomerId  | Guid      |
| VehicleId   | Guid      |
| OpenDate    | DateTime  |
| CloseDate   | DateTime? |
| Status      | string    |
| TotalAmount | decimal   |

Status possíveis:

* Open
* InProgress
* WaitingParts
* Finished
* Delivered
* Cancelled

---

## ServiceOrderItem

Itens executados na Ordem de Serviço.

| Campo          | Tipo    |
| -------------- | ------- |
| Id             | Guid    |
| ServiceOrderId | Guid    |
| Description    | string  |
| Quantity       | decimal |
| UnitPrice      | decimal |
| TotalPrice     | decimal |

---

## Product

Peças e produtos utilizados.

| Campo         | Tipo    |
| ------------- | ------- |
| Id            | Guid    |
| CompanyId     | Guid    |
| Name          | string  |
| Description   | string  |
| StockQuantity | decimal |
| CostPrice     | decimal |
| SalePrice     | decimal |

---

## StockMovement

Controle de entradas e saídas.

| Campo     | Tipo     |
| --------- | -------- |
| Id        | Guid     |
| ProductId | Guid     |
| Type      | string   |
| Quantity  | decimal  |
| Date      | DateTime |

Tipos:

* Entry
* Exit

---

## User

Usuários do sistema.

Implementado através do ASP.NET Core Identity.
