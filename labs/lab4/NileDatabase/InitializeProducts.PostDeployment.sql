/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DECLARE @sourceProducts TABLE (Name VARCHAR(100), Description VARCHAR(MAX), Price MONEY, IsDiscontinued BIT)
INSERT INTO @sourceProducts VALUeS 
      ('Windows Phone', 'Windows 10 Phone', 100, 0),
      ('Galaxy S7', 'Good phone', 650, 0),
      ('Galaxy Note 7', 'FAA ban edition', 150, 1),
      ('iPhone X', 'Outdated', 1900, 1),
      ('Dog Frisbee - Blue', 'Blue', 4.25, 0),
      ('Dog Frisbee - Green', 'Green', 4.25, 0),
      ('Dog Frisbee - Red', 'Red', 4.25, 0),
      ('Dog Frisbee - Yellow', 'Yellow', 4.25, 0),
      ('Surge Protector - 2100J', '15 plugs', 21.99, 0),
      ('Surge Protector - 1100J', '5 plugs', 10.99, 1),
      ('SanDisk USB Flash Drive 128 GB', '128 GB', 11.99, 0),
      ('SanDisk USB Flash Drive 1 GB', '1 GB', 1.99, 1),
      ('Samsung USB Flash Drive 64 GB', '64 GB', 5.99, 0),
      ('Sansung USB Flash Drive 1 TB', '1 TB', 30.99, 0),
      ('Louisville Slugger - Natural Clear', 'Wood bat', 39.99, 0),
      ('Louisville Slugger - Black', 'Wood bat', 30.99, 0),
      ('Louisville Slugger - Green', 'Wood bat', 30.99, 0),
      ('Louisville Slugger - Blue', 'Wood bat', 30.99, 0),
      ('Baseball Standard Official - Standard', 'Size 9', 6.99, 0),
      ('Baseball Standard Official - Youth', 'Size 8Y', 5.99, 1)      

MERGE Products AS Target
USING @SourceProducts AS Source ON Source.Name = Target.Name
WHEN NOT MATCHED BY Target THEN INSERT (Name, Description, Price, IsDiscontinued) VALUES (Source.Name, Source.Description, Source.Price, Source.IsDiscontinued)
WHEN MATCHED THEN UPDATE SET Name = Source.Name, Price = source.Price, Description = source.Description, IsDiscontinued = source.IsDiscontinued;