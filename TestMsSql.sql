-- В базе данных MS SQL Server есть продукты и категории.
-- Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов.
-- Написать SQL запрос для выбора всех пар «Имя продукта – Имя категории».
-- Если у продукта нет категорий, то его имя все равно должно выводиться.


IF OBJECT_ID('ProductCategory', 'U') IS NOT NULL
DROP TABLE ProductCategory;
IF OBJECT_ID('Product', 'U') IS NOT NULL
DROP TABLE Product;
IF OBJECT_ID('Category', 'U') IS NOT NULL
DROP TABLE Category;

IF OBJECT_ID('Product', 'U') IS NULL
CREATE TABLE Product (
    id INT IDENTITY(1,1) NOT NULL,
    name NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_Product_id PRIMARY KEY CLUSTERED (id ASC)
);

IF OBJECT_ID('Category', 'U') IS NULL
CREATE TABLE Category (
    id INT IDENTITY(1,1) NOT NULL,
    name NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_Category_id PRIMARY KEY CLUSTERED (id ASC)
);

IF OBJECT_ID('ProductCategory', 'U') IS NULL
CREATE TABLE ProductCategory (
    ProductId INT,
    CategoryId INT

    FOREIGN KEY(ProductId) REFERENCES Product(Id),
    FOREIGN KEY(CategoryId) REFERENCES Category(Id),
    PRIMARY KEY CLUSTERED (ProductId, CategoryId)
);

INSERT INTO Product (name) VALUES ('Product1');
INSERT INTO Product (name) VALUES ('Product2');
INSERT INTO Product (name) VALUES ('Product3');
INSERT INTO Product (name) VALUES ('Product4');

INSERT INTO Category (name) VALUES ('Category1');
INSERT INTO Category (name) VALUES ('Category2');
INSERT INTO Category (name) VALUES ('Category3');
INSERT INTO Category (name) VALUES ('Category4');

INSERT INTO ProductCategory VALUES (1, 1);
INSERT INTO ProductCategory VALUES (1, 2);
INSERT INTO ProductCategory VALUES (2, 2);

SELECT p.name AS ProductName, c.name AS CategoryName
FROM Product AS p
LEFT JOIN ProductCategory AS pc ON p.id = pc.ProductId
LEFT JOIN Category AS c ON c.id = pc.CategoryId;