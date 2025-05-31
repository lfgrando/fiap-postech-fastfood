db = db.getSiblingDB('fiap_fastfood');

db.createUser({
  user: "fastfood_user",
  pwd: "Fastfood2025!",
  roles: [ { role: "readWrite", db: "fiap_fastfood" } ]
});

const now = new Date();

db.menuItem.createIndex({ Name: 1 }, { unique: true });

db.menuItem.insertMany([
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Burrito de Carne",
    Price: 22.90,
    Description: "Tortilla recheada com carne bovina, arroz, feijão, queijo e molho especial.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Quesadilla de Frango",
    Price: 19.50,
    Description: "Tortilla crocante recheada com frango desfiado, queijo e pimentões grelhados.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Tacos Trio",
    Price: 18.00,
    Description: "Trio de tacos com recheios variados: carne, frango e vegetariano.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Nacho Supreme",
    Price: 21.00,
    Description: "Nachos com carne, queijo derretido, sour cream e guacamole.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Enchiladas de Queijo",
    Price: 20.00,
    Description: "Tortillas assadas recheadas com queijo, molho vermelho e coentro.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Taco Bowl",
    Price: 23.50,
    Description: "Tigela com arroz, feijão, carne, alface, queijo e molho picante.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Burrito Vegetariano",
    Price: 20.90,
    Description: "Burrito com legumes grelhados, guacamole, arroz e feijão preto.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Tacos de Peixe",
    Price: 22.00,
    Description: "Tortillas recheadas com filé de peixe empanado, molho e repolho.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Chili com Carne",
    Price: 19.00,
    Description: "Ensopado de carne moída com feijão, pimenta e temperos mexicanos.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Taco Triplo Especial",
    Price: 24.00,
    Description: "Combo com 3 tacos grandes: carne, frango e porco desfiado.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },

  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Combo Burrito + Nachos + Refrigerante",
    Price: 32.00,
    Description: "Burrito de carne + nachos com queijo + refrigerante lata.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Combo Quesadilla + Elotes + Agua Fresca",
    Price: 31.00,
    Description: "Quesadilla de frango + espiga de milho + água fresca de hibisco.",
    Category: "MainCourse",
    IsActive: true,
    IsDeleted: false
  },

  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Nachos com Queijo",
    Price: 12.00,
    Description: "Porção de nachos crocantes com cobertura de queijo derretido.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Chips com Guacamole",
    Price: 13.50,
    Description: "Chips de milho acompanhados de guacamole fresco.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Elotes",
    Price: 10.00,
    Description: "Espiga de milho grelhada com maionese, queijo e pimenta.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Feijão Refrito",
    Price: 8.00,
    Description: "Feijão temperado típico mexicano, amassado e refogado.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Arroz Mexicano",
    Price: 7.50,
    Description: "Arroz com molho de tomate, alho, cebola e ervas.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Mini Tacos",
    Price: 11.00,
    Description: "Mini tacos crocantes recheados com carne e queijo.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Jalapeños Empanados",
    Price: 9.00,
    Description: "Pimentas jalapeño recheadas com queijo e empanadas.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Sour Cream",
    Price: 4.00,
    Description: "Porção de sour cream para acompanhar os pratos.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Guacamole Extra",
    Price: 5.00,
    Description: "Porção extra de guacamole caseiro.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Molho Picante",
    Price: 3.50,
    Description: "Molho de pimenta caseiro estilo mexicano.",
    Category: "SideDish",
    IsActive: true,
    IsDeleted: false
  },
{
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Refrigerante Lata",
    Price: 6.00,
    Description: "Lata 350ml de refrigerante (Coca-Cola, Guaraná, etc).",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Água Mineral",
    Price: 4.50,
    Description: "Garrafa de água sem gás 500ml.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Água com Gás",
    Price: 5.00,
    Description: "Garrafa de água com gás 500ml.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Agua Fresca de Hibisco",
    Price: 7.50,
    Description: "Bebida natural levemente adoçada feita com hibisco.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Agua Fresca de Tamarindo",
    Price: 7.50,
    Description: "Bebida mexicana refrescante feita com tamarindo natural.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Horchata",
    Price: 8.00,
    Description: "Bebida doce à base de arroz, leite, baunilha e canela.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Suco de Laranja Natural",
    Price: 7.00,
    Description: "Suco 100% natural de laranja, sem adição de açúcar.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Suco de Abacaxi com Hortelã",
    Price: 7.00,
    Description: "Bebida refrescante feita com abacaxi e toque de hortelã.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Chá Gelado de Limão",
    Price: 6.50,
    Description: "Chá preto gelado com sabor de limão e pouco açúcar.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  },
  {
    _id: ObjectId(),
    CreatedAt: now,
    Name: "Limonada Mexicana",
    Price: 7.50,
    Description: "Limonada com toque de hortelã e açúcar mascavo.",
    Category: "Beverage",
    IsActive: true,
    IsDeleted: false
  }  
]);
