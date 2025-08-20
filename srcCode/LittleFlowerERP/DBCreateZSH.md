Erstmalige Erstellung DB

```zsh
dotnet new console -n LittleFlowerERP
cd LittleFlowerERP
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet ef migrations add InitialCreate
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Erweiterungen DB:

```zsh
dotnet ef migrations add TEXT
dotnet ef database update
```

migration nicht durchführen

```zsh
dotnet ef migrations remove

```
