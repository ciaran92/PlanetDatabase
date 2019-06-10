# PlanetDatabase.com

### Setup Instructions
1. copy the project from the zip file
2. change the servername in the appsettings.json file under ConnectionsStrings
3. Open the package manager console and run "update database" cmd
4. Once db has been created, run the following to insert into the Planets table.

```sql
use PlanetDatabaseDb
go

insert into planets(PlanetName, DistFromSun)
values('Mercury', 57.9),
('Venus', 108.2),
('Earth', 149.6),
('Mars', 227.9),
('Jupiter', 778.3),
('Saturn', 1427.0),
('Uranus', 2871.0),
('Neptune', 4497.1),
('Pluto', 5913.0)
go
```
### Project Architecture (Backend)
The API has been separated into 4 separate layers
* PlanetDatabase is the main presentation layer and entry point into the API
* PlanetDatabase.Core is where all the Business Logic for the application is performed
* PlanetDatabase.Data is where the database context, Data Models & Entities / View Models for the application are kept
* PlanetDatabase.UnitTests is used to hold all unit tests for app. 

### Packages installed
* Microsoft.EntityFrameworkCore - For Data Access
* Microsoft.EntityFrameworkCore.SqlServer - To use SQL Server
* Microsoft.EntityFrameworkCore.SqlServer.Tools - Allows us to use the package manager console to perform database migrations
* AutoMapper - To map between our models and view models
* Moq - To create mock objects for our tests
