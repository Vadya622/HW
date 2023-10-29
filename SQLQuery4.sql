SELECT * FROM Sales.Customer;
SELECT * FROM Sales.Store ORDER BY Name;
SELECT TOP 10 * FROM HumanResources.Employee WHERE BirthDate > '1989-09-28';
SELECT NationalIDNumber, LoginID, JobTitle FROM HumanResources.Employee WHERE LoginID LIKE '%0' ORDER BY JobTitle;

SELECT * FROM Person.Person WHERE YEAR(ModifiedDate) = 2008 AND MiddleName IS NOT NULL AND Title IS NULL;

SELECT DISTINCT d.Name FROM HumanResources.EmployeeDepartmentHistory edh 
JOIN HumanResources.Department d ON edh.DepartmentID = d.DepartmentID;
SELECT TerritoryID, SUM(CommissionPct) FROM Sales.SalesPerson GROUP BY TerritoryID HAVING SUM(CommissionPct) > 0;
SELECT * FROM HumanResources.Employee WHERE VacationHours = (SELECT MAX(VacationHours) FROM HumanResources.Employee);
SELECT * FROM HumanResources.Employee WHERE JobTitle IN ('Торговый представитель', 'Администратор сети', 'Менеджер сети');


