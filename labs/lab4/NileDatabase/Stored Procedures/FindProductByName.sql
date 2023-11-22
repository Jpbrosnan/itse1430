-- Finds all products with the given name.
-- PARAMETERS
--    @name | STRING | Name of the product
-- RETURNS
--    Id | INT | ID of the product
--    Name | STRING | Name of the product
--    Price | MONEY | Product price
--    Description | STRING | Product description
--    IsDiscontinued | BIT | Is the product discontinued?
CREATE PROCEDURE [dbo].[FindProductByName]
	@name VARCHAR(100)
AS BEGIN
    SET NOCOUNT ON;

	SELECT Id, Name, Price, Description, IsDiscontinued
    FROM Products
    WHERE Name = @name
END