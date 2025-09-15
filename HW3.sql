--1.List all cities that have both Employees and Customers.
		-- I'm assuming you ask for the cities that appear in both (intersection):
		SELECT City FROM Employees
		INTERSECT
		SELECT City FROM Customers
		-- If you meant all of them, I also have this:
		SELECT City FROM Employees
		UNION
		SELECT City FROM Customers


--2.  List all cities that have Customers but no Employee.
		--a. Use sub-query
		SELECT DISTINCT c.City
		FROM Customers c
		WHERE NOT EXISTS (
			SELECT e.City
			FROM Employees e
			WHERE e.City = c.City);
		--b. Do not use sub-query
		SELECT City FROM Customers
		EXCEPT
		SELECT City FROM Employees


--3.  List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(od.Quantity) AS TotalOrders
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName


--4.  List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS TotalOrder
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE c.City IS NOT NULL
GROUP BY c.City


--5. List all Customer Cities that have at least two customers.
-- I'm assuming you want those with DIFFERENT customers.
		--a. Use union
		SELECT City FROM Customers
		WHERE City in (
		SELECT c.City FROM Customers c
		JOIN Customers i ON c.City = i.City AND c.CustomerID <> i.CustomerID) -- AND is while matching, WHERE is after the matching
		UNION
		SELECT City FROM Customers
		WHERE City in (
		SELECT c.City FROM Customers c
		JOIN Customers i ON c.City = i.City AND c.CustomerID <> i.CustomerID) -- AND is while matching, WHERE is after the matching
		---------------------------------------------------------------------------------------
		SELECT City FROM Customers
		GROUP BY City
		HAVING COUNT(CustomerID) > 1
		--b. Use sub-query and no union
		SELECT City FROM Customers
		GROUP BY City
		HAVING COUNT(CustomerID) > 1


--6.List all Customer Cities that have ordered at least two different kinds of products.
WITH CList AS (
SELECT o.CustomerID FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID
HAVING COUNT(DISTINCT od.ProductID) > 1)

SELECT DISTINCT City FROM Customers
WHERE CustomerID IN (SELECT CustomerID FROM CList)


--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT DISTINCT c.CompanyName FROM Customers c
JOIN Orders o ON o.CustomerID = c.CustomerID
WHERE c.City != o.ShipCity 
-- Optional:
AND c.City is not NULL AND o.ShipCity is not NULL


--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH Prod AS (
	SELECT p.ProductID, p.ProductName, SUM(od.Quantity) AS TotalOrders, CAST(AVG(od.UnitPrice) AS DECIMAL(7, 2)) AS AVGPRICE
	FROM Products p
	JOIN [Order Details] od ON p.ProductID = od.ProductID
	GROUP BY p.ProductID, p.ProductName
), 
CityRank AS (
	SELECT p.ProductID, c.City, 
	ROW_NUMBER() OVER (PARTITION BY p.ProductID ORDER BY SUM(od.Quantity) DESC) AS Ranking
	FROM Products p
	JOIN [Order Details] od ON p.ProductID = od.ProductID
	JOIN Orders o ON od.OrderID = o.OrderID
	JOIN Customers c ON o.CustomerID = c.CustomerID
	GROUP BY p.ProductID, c.City)

SELECT TOP 5 p.ProductName, p.AVGPRICE, cr.City FROM Prod p
JOIN CityRank cr ON p.ProductID = cr.ProductID AND cr.Ranking = 1
ORDER BY p.TotalOrders DESC


--9.List all cities that have never ordered something but we have employees there.
	--a. Use sub-query
	SELECT DISTINCT City FROM Employees
	WHERE City NOT IN ( SELECT DISTINCT ShipCity FROM Orders )

	--b. Do not use sub-query
	SELECT DISTINCT City FROM Employees
	EXCEPT
	SELECT DISTINCT ShipCity FROM Orders


/* 10.List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is,
and also the city of most total quantity of products ordered from. 
(tip: join  sub-query) */
WITH TopEmployeeCity AS (
SELECT TOP 1 e.City FROM Employees e
JOIN Orders o ON e.EmployeeID = o.EmployeeID
GROUP BY e.City
ORDER BY COUNT(o.OrderID) DESC ), TopCity AS (
SELECT TOP 1 c.City FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY SUM(od.Quantity) DESC )

SELECT e.City FROM TopEmployeeCity e
JOIN TopCity c ON e.City = c.City


--11.How do you remove the duplicates record of a table?
/*
I think I could use DISTINCT to get a new table, drop the old table, and rename the new table.
*/