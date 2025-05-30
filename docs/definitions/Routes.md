# Soat Project Rotas

# Menu

### GET /menu

```json
// GetAll - Returns all menu items
Response: [MenuItem]

```

### GET /menu/item/{id}

```json
// GetItemById - Returns a specific menu item
Response: {
  "id": "ObjectId",
  "name": "string",
  "price": "string",
  "category": "enum",
  "description": "string"
  "isActive" : "bool"
}

```

### POST /menu/item

```json
// PostItem - Creates a new menu item
Request: {
  "name": "string",
  "price": "string",
  "category": "enum",
  "description": "string"
  "isActive" : "bool"
}

```

### PUT /menu/item/{id}

```json
// PutItemById - Updates an existing menu item
Request: {
  "name": "string",
  "price": "string",
  "category": "enum",
  "description": "string"
  "isActive" : "bool"
}

```

### DELETE /menu/item/{id}

Removes a menu item by ID

# Order

### POST /order

Id Auto-Generated

```json
// Creates a new order
Request: {
  "customerId": "string?",
  "customerName": "string?",
  "items": 
  [
	  {
	    "id" : "string"
		  "name": "string",
		  "price": "string",
		  "category": "enum",
		  "amount" : "int"
	  }
  ]
}

```

### PATCH /order/{id}/status

**When status is ready, records inventory Log**

```json
// Updates order status
Request: {
  "status": "enum"
}

```

### POST /order/{id}/checkout

```json
// Process order checkout
Request: {
  "paymentType": "enum"
}
Response: {
  "qrCode": "string"
  "totalPrice" : "double"
}

```

### POST /order/{id}/confirm-payment

Confirms payment for an order

### Get /order/{id}

```json
// Process order checkout
Response: {
  "id" : "string"
  "paymentType": "enum"
  "customerId": "string?",
  "customerName": "string?",
  "items": 
  [
	  {
	    "id" : "string"
		  "name": "string",
		  "price": "string",
		  "category": "enum",
		  "amount" : "int"
	  }
  ],
  "status" : "enum",
  "totalPrice" : "double"
}
```

# Customer

### GET /customer/{cpf}

Retrieves customer information by CPF

### POST /customer

```json
// Creates a new customer
Request: {
  "name": "string",
  "cpf": "string",
  "email": "string"
}
```