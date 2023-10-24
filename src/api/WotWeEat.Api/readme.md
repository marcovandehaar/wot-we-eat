# EF migration commands:
Run all migration commands from WotWeEat.DataAccess.EFCore project

Generate initial create:	 
 dotnet ef migrations add InitialCreate -s ..\WotWeEat.Api\WotWeEat.Api.csproj
Generate new Migration:
 dotnet ef migrations add NewMigrationName -s ..\WotWeEat.Api\WotWeEat.Api.csproj
Update Databse:
 dotnet ef database update -s ..\WotWeEat.Api\WotWeEat.Api.csproj

# queries 
## Clear database
DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE ?'
GO

## Remove all data from database
-- disable referential integrity
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' 
GO 

EXEC sp_MSForEachTable 'DELETE FROM ?' 
GO 

-- enable referential integrity again 
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL' 
GO

## query Database
--query database

select * from MeatFish
select * from Vegetable
select * from Meal
select * from MealOption

select * from MealOptionMeatFish
select * from MealOptionVegetable

## select mealoption

# Example requests
## Clean MealOption
{
  "mealOptionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "description": "string",
  "mealBase": "Potato",
  "suitableForChildren": true,
  "amountOfWork": "PieceOfCake",
  "healthy": "Healthy",
  "vegetables": [
    {
      "vegetableId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "name": "string"
    }
  ],
  "meatFishes": [
    {
      "meatFishId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "name": "string",
      "type": "Meat"
    }
  ],
  "possibleVariations": [
    {
      "mealVariationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "description": "string",
      "makeSuitableForKids": true
    }
  ]
}

## totaal nieuwe meal option
{
  "description": "Witte bonen met gekookte aardappelen en worst",
  "mealBase": "Potato",
  "suitableForChildren": true,
  "amountOfWork": "PieceOfCake",
  "healthy": "Healthy",
  "vegetables": [
    {
      "name": "Witte bonen"
    }
  ],
  "meatFishes": [
    {
      "name": "Worst",
      "type": "Meat"
    }
  ],
  "possibleVariations": [
    {
      "description": "Met rode bieten",
      "makeSuitableForKids": true
    }
  ]
}



