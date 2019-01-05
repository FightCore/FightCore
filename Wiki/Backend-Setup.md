_Note that this wiki is not complete. Please request changes as you go or make edits directly!_

1. Install [SQL Server](https://www.microsoft.com/en-us/sql-server/default.aspx), easiest to set default server name now to "SQLExpress". Recommended to install [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) afterwards as well

2. Install [Visual Studio IDE](https://visualstudio.microsoft.com/)

3. Clone the repo. Download ASP.Net Core 2.0 (2.1?) and install any packages required by the package manager
    * **Please add or request clarifying info here**

4. Rename your SQL Server to "SQLExpress" if didn't do so earlier
    * Alternatively, open FightCore.Api > appsettings.json and change `.\\SQLExpress` part of the DefaultConnection string to the name of your server instance. You can find this via either SQL Server Management Studio or in Visual Studio (View > Server Explorer)

5. Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) then run `Update-Database`

6. Assure FightCore.Api is set as your StartUp Project. If not, right click it then select "Set as StartUp Project"

7. Finally, run and everything should work!