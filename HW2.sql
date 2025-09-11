--1.How many products can you find in the Production.Product table?
SELECT count(ProductID) FROM Production.Product

--2.Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
--The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(*) FROM Production.Product WHERE ProductSubcategoryID is not NULL

--3.Count how many products belong to each product subcategory.
--	Write a query that displays the result with two columns:
--	ProductSubcategoryID (the subcategory ID)， CountedProducts (the number of products in that subcategory).
SELECT ProductSubcategoryID AS 'Subcategory ID', COUNT(ProductID) AS 'Number of products in Subcategory'
FROM Production.Product
WHERE ProductSubcategoryID is not NULL
GROUP BY ProductSubcategoryID

--4.How many products that do not have a product subcategory.
SELECT count(*) FROM Production.Product 
WHERE ProductSubcategoryID is NULL

--5.Write a query to list the sum of products quantity in the Production.ProductInventory table.
-- I'm assuming he wants a table since he said 'list the sum'
SELECT ProductID, SUM(Quantity) AS 'Total Per Product'
FROM Production.ProductInventory
GROUP BY ProductID

--6.Write a query to list the sum of products in the Production.ProductInventory table 
--and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID, SUM(Quantity) AS 'Quantities'
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100

--7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory 
--table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT shelf, SUM(Quantity) AS 'Quantity'
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY shelf
HAVING SUM(Quantity) < 100

--8.Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT ProductID, AVG(Quantity) AS 'Average Quantity'
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID

--9.Write query to see the average quantity of products by shelf from the table Production.ProductInventory
SELECT shelf, AVG(Quantity) AS 'Average Quantity'
FROM Production.ProductInventory
GROUP BY shelf
ORDER BY shelf -- Extra, but I wanted to see it organized

--10.Write query to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
select shelf, AVG(Quantity) AS 'Average Quantity'
FROM Production.ProductInventory
WHERE shelf <> 'N/A'
GROUP BY shelf
ORDER BY shelf

--11.List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. 
--Exclude the rows where Color or Class are null.
SELECT Color, Class, AVG(ListPrice) AS 'Average Price'
FROM Production.Product
WHERE Color is not NULL AND Class is not NULL
GROUP BY Color, Class
ORDER BY Color, Class

--12.Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables. 
--Join them and produce a result set similar to the following
SELECT country.Name AS 'Country', province.Name AS Province
FROM person.CountryRegion country
JOIN person.StateProvince province
ON country.CountryRegionCode = province.CountryRegionCode

--13.Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables
--and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT country.Name AS Country, province.Name AS Province
FROM Person.CountryRegion country
INNER JOIN person.StateProvince province
ON country.CountryRegionCode = province.CountryRegionCode
WHERE country.Name in ('Germany', 'Canada')
ORDER BY country.Name

-- Using Northwnd Database: (Use aliases for all the Joins)
--14.List all Products that has been sold at least once in the last 25 years.
SELECT p.ProductName AS ProductName
FROM Products p
INNER JOIN [Order Details] od
ON p.ProductID = od.ProductID
INNER JOIN Orders o
ON od.OrderID = o.OrderID
WHERE od.Quantity > 0 AND o.OrderDate >= DATEADD(YEAR, -25, GETDATE())

--15.List top 5 locations (Zip Code) where the products sold most.
-- I'm assuming Kimi doesn't want the repeated zip codes.
SELECT TOP 5 o.ShipPostalCode AS 'TOP 5 ZIP CODES'
FROM Orders o
INNER JOIN [Order Details] od
ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode is not NULL
GROUP BY o.ShipPostalCode
ORDER BY SUM(od.Quantity) DESC

--16.List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 o.ShipPostalCode AS 'Top 5 ZIP CODES' 
FROM Orders o
INNER JOIN [Order Details] od
ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode is not NULL AND o.OrderDate >= DATEADD(YEAR, -25, GETDATE())
GROUP BY o.ShipPostalCode
ORDER BY SUM(od.Quantity) DESC

--17.List all city names and number of customers in that city.    
SELECT City, COUNT(CustomerID) AS 'Number of Customers'
FROM Customers
GROUP BY City

--18.List city names which have more than 2 customers, and number of customers in that city
SELECT City, COUNT(CustomerID) AS 'Number of Customers'
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) > 2

--19.List the names of customers who placed orders after 1/1/98 with order date.
-- I'm assuming Kimi wants the Company names not the CustomerID. Otherwise, it might be really simple (in the same table)
-- I structure "1/1/98" as "1998-01-01"
SELECT c.CompanyName AS 'Customers (Company Names)', o.OrderDate AS 'Date'
FROM Customers c
JOIN Orders o
ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'
ORDER BY o.OrderDate

--20.List the names of all customers with the most recent order dates
SELECT c.CompanyName FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate = ( SELECT MAX(OrderDate) FROM Orders )
-- GROUP BY c.CompanyName 
ORDER BY c.CompanyName 

--21.Display the names of all customers along with the count of products they bought
SELECT c.CompanyName, SUM(od.Quantity) AS 'Total Quantity'
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CompanyName

--22.Display the customer ids who bought more than 100 Products, with count of products.
SELECT o.CustomerID, SUM(od.Quantity) AS 'Amount of Products'
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID
HAVING SUM(od.Quantity) > 100

--23.Show all the possible combinations of suppliers and shippers, representing every way a supplier can ship its products.
-- The result should display two columns:
-- Supplier CompanyName， Shipper CompanyName
SELECT su.CompanyName, sh.CompanyName -- (Implicit) CROSS JOIN
FROM Suppliers su, Shippers sh

--24.Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID

--25.Displays pairs of employees who have the same job title.
-- I'm not sure if this is what Kimi wants
SELECT e.FirstName + ' ' + e.LastName AS Employee1, 
	   m.FirstName + ' ' + m.LastName AS Employee2, 
	   e.Title
FROM Employees e
JOIN Employees m ON e.Title = m.Title AND e.EmployeeID < m.EmployeeID
ORDER BY e.Title, Employee1, Employee2;

--26.Display all the Managers who have more than 2 employees reporting to them.
SELECT e.FirstName + ' ' + e.LastName AS Manager, COUNT(m.ReportsTo) AS Passants
FROM Employees e
JOIN Employees m ON e.EmployeeID = m.ReportsTo
GROUP BY e.EmployeeID, e.FirstName, e.LastName  -- SQL Rueries to have the e.FirstName and e.LastName because every column in SELECT clause must be part of the GROUP BY clause.
HAVING COUNT(m.ReportsTo) > 2

--27.List all customers and suppliers together, grouped by city.
-- The result should display the following columns:
-- City，CompanyName，ContactName，Type (indicating whether the record is a Customer or a Supplier).
SELECT c.City, c.CompanyName, c.ContactName, 'Customer' AS TYPE
FROM Customers c
UNION ALL
SELECT s.City, s.CompanyName, s.ContactName, 'Suppliers' AS TYPE
FROM Suppliers s
ORDER BY City, CompanyName -- CompanyName is EXTRA, it's for better readability.