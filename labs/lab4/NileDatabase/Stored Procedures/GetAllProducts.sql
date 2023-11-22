-- Get all the products.
-- PARAMETERS
--    None
-- RETURNS
--    Id | INT | ID of the product
--    Name | STRING | Name of the product
--    Price | MONEY | Product price
--    Description | STRING | Product description
--    IsDiscontinued | BIT | Is the product discontinued?
CREATE PROCEDURE [dbo].[GetAllProducts]	
AS BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Price, Description, IsDiscontinued
    FROM Products
END
