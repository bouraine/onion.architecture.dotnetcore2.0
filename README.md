# Onion.architecture.dotnetcore2.0
Onion architecture implementation with dotnet core 2.X

I recommand Visual studio 2017 "Full Rename Project" extention to rename projets to meet your needs : 
  https://marketplace.visualstudio.com/items?itemName=KuanyshNabiyev.FullRenameProject
  
After projects renaming using Full Name Project extension, you have to change obj/project.assets.json of each project.

# Prerequisites
- Dotnet core 2.0 or higher : https://www.microsoft.com/net/download/windows
- PostgreSQL 9.5 or higher :
    - https://www.pgadmin.org/download/pgadmin-3-windows/
    - https://www.postgresql.org/download/
- Visual studio 2017 15.15.4 or higher only on Windows : 
    - https://blogs.msdn.microsoft.com/benjaminperkins/2017/09/20/how-to-install-net-core-2-0/
- Visual studio code on Linux and Mac : https://code.visualstudio.com/

# Before starting 
- Run this entity framework command on PM console to create database : Update-Database 
    - Be sure "Onion.DAL.Persistance" is selected as default projet
    - You can find some help here for EF Core .NET Command-line : https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet

# Sammary

Onion Architecture sets a clear dependency rule between layers, making it a more restrictive variant of Layered and Hexagonal Architectures. At the very center of our application sits a domain model, surrounded by domain services and application services. Those 3 layers form the application core – no relevant application logic should reside outside of it and it should be independent of all peripheral concerns like UI or databases (Grzegorz Ziemoński).


![Onion architecture](http://blog.thedigitalgroup.com/chetanv/wp-content/uploads/sites/23/2015/07/image_thumb1.png)





