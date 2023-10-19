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

## query Database
--query database

select * from MeatFishes
select * from Vegetables
select * from Meal
select * from MealOptions

select * from MealOptionMeatFish
select * from MealOptionVegetable

## select mealoption

