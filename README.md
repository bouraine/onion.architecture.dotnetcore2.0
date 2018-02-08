# Onion.architecture.dotnetcore2.0
Onion architecture implementation with dotnet core 2.X

I recommand Full Rename Project to rename projets : 
  https://marketplace.visualstudio.com/items?itemName=KuanyshNabiyev.FullRenameProject
  
After projects renaming using Full Name Project extension, you have to change obj/project.assets.json of each project.

# Prerequisites
- Dotnet core 2.0 or higher : https://www.microsoft.com/net/download/windows
- PostgreSQL 9.5 or higher :
    - https://www.pgadmin.org/download/pgadmin-3-windows/
    - https://www.postgresql.org/download/
- Visual studio 2017 15.15.4 or higher only on Windows : https://blogs.msdn.microsoft.com/benjaminperkins/2017/09/20/how-to-install-net-core-2-0/
- Visual studio code on Linux and Mac : https://code.visualstudio.com/

# Before starting solution
- run this entity framework command on PM console to create database : Add-Migration "InitialMigration" after selecting "Onion.DAL.Persistance" as default projet
- You can find some help here for EF Core .NET Command-line : https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet

# Onion.DAL.Entities





