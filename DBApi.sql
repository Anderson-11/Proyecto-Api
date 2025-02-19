Create database DBApi;

USE DBApi;

CREATE TABLE Productos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Precio DECIMAL(6, 2) NOT NULL,
	Stock INT NOT NULL
);

select * from Productos;

INSERT INTO Productos (Nombre, Precio, Stock) VALUES
('Laptop', 999.99, 10),
('Smartphone', 499.50, 25),
('Tablet', 299.99, 15),
('Auriculares', 89.99, 50),
('Reloj inteligente', 199.99, 30);