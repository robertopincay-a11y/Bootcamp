
  --Offset fetch
  DECLARE @PAGE_NUMBER INT =3;
  DECLARE @ROWS_PER_PAGE INT = 10;

  select  *  from SalesLT.Customer
  where CustomerID is not null
  ORDER BY CustomerID
  offset (@PAGE_NUMBER-1) * @ROWS_PER_PAGE  rows
  fetch next @ROWS_PER_PAGE rows only;

  select * from SalesLT.ProductCategory
  order by Name asc;

  --  Like
  SELECT * FROM  SalesLT.Customer
  WHERE FirstName LIKE '%R%';

  SELECT * FROM  SalesLT.Customer
  WHERE FirstName = 'Robert';
  
  --Between
  select FirstName, LastName,ModifiedDate from SalesLT.Customer
  where ModifiedDate between '2006-01-01' and '2007-01-01';

  --Count
  select count(*) as Total_customers from SalesLT.Customer
  select * from SalesLT.Customer

  select SUM(TotalDue) as Total_ventas from SalesLT.SalesOrderHeader  

  --Group by
  select ProductCategoryID, COUNT(ProductCategoryID) as Cantidad 
  from SalesLT.Product
  GROUP BY ProductCategoryID
  ORDER BY ProductCategoryID
 
 --Join
 select * from SalesLT.Product p
 inner join SalesLT.ProductCategory g
    on p.ProductCategoryID = g.ProductCategoryID 
    



--Ejercicio en Clase

 --1 Total De Clientes
 Select Count(CustomerID) as Total_Clientes from SalesLT.Customer

 --2 Total de Ventas en el mes "x"
 DECLARE @Fecha DATETIME2 = CONVERT(DATETIME2,'2008-06-01')

 SELECT Count(OrderDate) as Total_Ventas
 FROM SalesLT.SalesOrderHeader
 WHERE OrderDate = @Fecha


 --3 Ordenar las categorias por nombre
 SELECT TOP 5 WITH TIES Name 
 FROM SalesLT.ProductCategory 
 ORDER BY Name ASC
 

 --4 Relacionar Cabecera y detalle factura
 DECLARE @Id INT = 71780;
 DECLARE @PAGE_NUMBER INT =1;
 DECLARE @ROWS_PER_PAGE INT = 3;
 
 SELECT *
 FROM SalesLT.SalesOrderHeader p
 INNER JOIN SalesLT.SalesOrderDetail c 
    on p.SalesOrderID = c.SalesOrderID
where p.SalesOrderID = @Id
ORDER BY p.SalesOrderID
  offset (@PAGE_NUMBER-1) * @ROWS_PER_PAGE  rows
  fetch next @ROWS_PER_PAGE rows only;

 -- Implementacion Paginacion
 ----Uso de distinct y top


