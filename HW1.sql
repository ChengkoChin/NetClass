--1.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter
SELECT ProductID, Name, Color, ListPrice FROM Production.Product

--2.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, excludes the rows that ListPrice is 0
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice != 0

--3.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are NULL for the Color column
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color is NULL

--4.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color is not NULL

--5.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, 
--and the column ListPrice has a value greater than zero
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color is not NULL AND ListPrice > 0

--6.Write a query that concatenates the columns Name and Color like 'LL Crankarm: Black' from the Production.Product table by excluding the rows that are null for color.
SELECT Name + ': ' + Color AS 'Name and Color'
FROM Production.Product
WHERE Color is not NULL

--7.Write a query that generates the following result set from Production.Product:
<single column>
NAME: LL Crankarm -- COLOR: Black
NAME: ML Crankarm -- COLOR: Black
NAME: HL Crankarm -- COLOR: Black
NAME: Chainring Bolts -- COLOR: Silver
NAME: Chainring Nut -- COLOR: Silver
NAME: Chainring -- COLOR: Black
NAME: Freewheel -- COLOR: Silver
NAME: Front Derailleur Cage -- COLOR: Silver
...
SELECT 'NAME: ' + Name + ' -- COLOR: ' + Color
FROM Production.Product
WHERE Color is not NULL AND Name is not NULL -- Not sure if I need to handle the NULL cases. If I need I would add this conditional

--8.Write a query to retrieve the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID between 400 AND 500

--9.Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color = 'black' or Color = 'blue'

--10.Write a query to get a result set on products that begins with the letter S. 
SELECT Name FROM Production.Product
WHERE Name like 'S%'

--11.Write a query that retrieves the columns Name and ListPrice from the Production.Product table. 
--Order the result set by the Name column.
SELECT Name, ListPrice
FROM Production.Product
ORDER BY Name

--12. Write a query that retrieves the columns Name and ListPrice from the Production.Product table. 
--Order the result set by the Name column. The products name should start with either 'A' or 'S'
SELECT Name, ListPrice
FROM Production.Product
WHERE Name like 'A%' or Name like 'S%'
ORDER BY Name

--13.Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. 
--After this zero or more letters can exists. Order the result set by the Name column.
SELECT Name FROM Production.Product
WHERE Name like 'SPO%' AND Name not like 'SPOK%'
ORDER BY Name

--14.Write a query that retrieves unique colors from the table Production.Product. Order the results in descending manner
SELECT DISTINCT Color FROM Production.Product WHERE Color is not NULL ORDER BY Color desc -- I handled NULL since it's not a color

--15.Write a query that retrieves the unique combination of columns ProductSubcategoryID and Color from the Production.Product table. 
--We do not want any rows that are NULL.in any of the two columns in the result.

-- This last one wasn't clear. But I think it's asking for the a combination that doesn't repeat.
SELECT DISTINCT ProductSubcategoryID, Color FROM Production.Product WHERE ProductSubcategoryID is not NULL and Color is not NULL