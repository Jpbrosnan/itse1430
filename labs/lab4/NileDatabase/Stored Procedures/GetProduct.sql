-- Get a product by its ID.
-- PARAMETERS
--    @id | INT | ID of the product
-- RETURNS
--    Id | INT | ID of the product
--    Name | VARCHAR | Name of the product
--    Price | DECIMAL | Product price
--    Description | VARCHAR | Product description
--    IsDiscontinued | BIT | Is the product discontinued?
CREATE PROCEDURE [dbo].[GetProduct]
    @id INT
AS BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Price, Description, IsDiscontinued
    FROM Products
    WHERE Id = @id
END
