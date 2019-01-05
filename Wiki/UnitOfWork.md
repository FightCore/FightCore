# UnitOfWork
The UnitOfWork class is used to create repositories automatically. An UnitOfWork will use a Entity Framework context to create generic _Repositories_. These can then be used to get and manipulate data, these changes will only be done locally until you call the SaveChanges method on the UnitOfWork. 

# Repository
The repository gets used to store and update data. You can see these as a table that you can request data from, put data in or edit data from. The repository should really never be used outside of services as you are playing with the data.