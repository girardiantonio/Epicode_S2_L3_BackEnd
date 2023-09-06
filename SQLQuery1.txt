SELECT COUNT(*) AS NumeroTotaleOrdini
FROM Orders;

SELECT COUNT(*) AS NumeroTotaleClienti
FROM Customers;

SELECT COUNT(*) AS NumeroTotaleClientiLondra
FROM Customers
WHERE City = 'london';

SELECT AVG(Freight) AS MediaCostoTrasporto
FROM Orders;

SELECT AVG(Freight) AS MediaCostoTrasportoBOTTM
FROM Orders
WHERE CustomerID = 'BOTTM';

SELECT CustomerID, SUM(Freight) AS SpeseTrasportoByCustomers
FROM Orders
GROUP BY CustomerID

SELECT City, COUNT(*) AS NumeroClientiByCity
FROM Customers
GROUP BY City;

SELECT OrderId, SUM(UnitPrice * Quantity) AS TotaleOrdine
FROM [Order Details]
GROUP BY OrderID;

SELECT SUM(UnitPrice * Quantity) AS TotalePerOrdine
FROM [Order Details]
WHERE OrderID = 10248;

SELECT CategoryName, COUNT(*) AS NumeroProdotti
FROM Categories
JOIN Products ON Categories.CategoryID = Products.CategoryID
GROUP BY CategoryName;

SELECT ShipCountry, COUNT(*) AS NumeroTotaleOrdini
FROM Orders
GROUP BY ShipCountry;

SELECT ShipCountry, AVG(Freight) AS MediaCostoTrasporto
FROM Orders
GROUP BY ShipCountry;
