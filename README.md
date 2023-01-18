# Warehouse
### General info

Warehouse is a small company that has *departments*, *workers* and *products*.

Relationships:
- One worker can work in multiple departments.
- One product can be placed in only one department.

The project includes all necessary endpoints (*Full description of the endpoints you will find in swagger*):
- CRUD Product
- CRUD Worker
- CRUD Department

### Technical tools
- FastEndpoints
- .NET 7
- ASP.NET Web API
- C# 11
- Entity Framework Core
- Entity Framework Migrations
- Swagger
- MS SQL Server
- xUnit

### Setup
To get started, you need to copy the *release* branch of the repository
```
$ git clone --branch release https://github.com/Finka95/Warehouse.git
```

If you are using a unique connection string to your mssql database, you should specify it in the Warehouse/appsettings.json file in the MsSqlConnection field
```
  "ConnectionStrings": {
    "MsSqlConnection": "Server=(localdb)\\mssqllocaldb;Database=warehouse;Trusted_Connection=True;"
  }
```
let’s build and test the project
```
dotnet build
dotnet test
```

If there is no problem at the last stage, you need to publish and run the project.
```
dotnet publish
dotnet ~\Warehouse\Warehouse\bin\Debug\net7.0\publish\Warehouse.dll
```
By default the project is launched at http://localhost:5000 .
You can use the http://localhost:5000/swagger/index.html to access swagger and all endpoints.
Or you can use Postman.

![image](https://user-images.githubusercontent.com/92907361/213163156-7d6ecd64-5069-4c72-98d5-1f54452fc9e3.png)
