# dotnet-rpg
 
This is an implementation of REST API's.
For this implementation I used a "Code-first migration" approach for implementing the relationship between code and the database. That means that before creating the db, I've created the Character model first, I've installed the EFCore, made a DataContext(for abstracting the data that comes from db) and inside the DataContext created the DBSet (the model given to the DbSet will be followed accordingly by the EFcore migration when the db table will be created - the header of the table will include all the props from the model).
For creating the connection to the Database, in the appsettings.json file I've defined ConnectionString and added the initialization of this contex to startup.cs.
Now, to migrate the db to SqlServer, there are two commands required after installing the EF migration tool: dotnet ef migrations add InitialCreate (this will generate the C# migration files that specify the needed PK, the header, the types etc.), dotnet ef database update builds the table.

I've also used Data Transfer Objects and AutoMapper, for having more control on the models that are received and sent to the db.

For interogating the db and modifying the data from the db I've used the repository pattern. So inside the Data folder, I've created the Repositories folder, each repository implements it's specific interface for DI and the methods here make CRUD operation on the Db like getting the tables, inserting new entries, updating entries, deleting entries.
