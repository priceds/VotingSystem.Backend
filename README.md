# VotingSystem Backend Setup

This guide will walk you through setting up the database for the VotingSystem backend project.

## Prerequisites

- **SQL Server:** Make sure you have SQL Server installed locally. 
- **.NET SDK:** Ensure you have the .NET SDK installed (version matching the project's target framework).

## Steps

1. **Create Database:**
   - Open SQL Server Management Studio (SSMS).
   - Create a new database named "TESTDB".

2. **Update Connection String:**
   - Open the `appsettings.json` or `appsettings.Development.json` file in the `VotingSystem.Infrastructure` project.
   - Replace the existing connection string with the correct connection string for your "TESTDB" database. It should look something like this:
   
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TESTDB;Trusted_Connection=True;"
     }
     ```

3. **Open Package Manager Console:**
   - In Visual Studio, go to **Tools** -> **NuGet Package Manager** -> **Package Manager Console**.
   - Make sure the `VotingSystem.Infrastructure` project is selected as the default project in the console.

4. **Apply Migrations:**
   - Run the following commands in the Package Manager Console:

     ```bash
     Add-Migration InitialCreate --OutputDir Data/Migrations
     Update-Database
     ```
     If the migrations folder does not exist, run the `dotnet ef migrations add InitialCreate` command in your terminal/console to generate the migrations folder.

     This will create the necessary tables in your "TESTDB" database based on your Entity Framework model.

## Running the Backend

Now that the database is set up, you can run the `VotingSystem` backend project:

1. **Set as Startup Project:** Right-click on the `VotingSystem` project in the Solution Explorer and select "Set as Startup Project".
2. **Run:** Press **F5** or click the **Start** button in Visual Studio to run the project.


## Troubleshooting

- **Migrations Errors:** If you encounter errors during the migration process, double-check your connection string and the EF Core model in the `VotingSystem.Infrastructure` project.
- **Port Conflicts:** If the default port (usually 5000 or 5001) is already in use, you can configure a different port in `launchSettings.json` or `Properties/launchSettings.json`. 
- **Package Missing:** If you get an error stating that the package `Microsoft.EntityFrameworkCore.Tools` is missing.
Run the following command in your terminal/console to install the package:
 ```bash
 dotnet add package Microsoft.EntityFrameworkCore.Tools
