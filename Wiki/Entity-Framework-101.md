# What is Entity Framework
Entity Framework is an ORM (Object Relationship Manager), which means it will manage objects within the database from code. EF is made by Microsoft and is widely used, there is plenty of documentation about how to work with EF and Microsoft still updates the framework in a rapid tempo.

# Basic terminology
* ***Context:*** A context can be seen as a database, there will be defined what tables the database has and what database provider it is using
* ***Model:*** A Model is used to form the database. These are simple classes with data inside of them.
* ***Migration:*** The difference in models between timeframes, these are used to update or downgrade databases throughout time.

# Including data
When gathering data you have to keep in mind that all objects aren't included by default.
Let's say that a character has FrameData as a child object. Because this is not part of the object itself, it will have to be included. This can be done to simply call `.Include(char => char.FrameData);`. Once the list is made or the object is finalized, the FrameData will also be build. If the character does not have FrameData, it will simply be NULL.

# When to call ToListAsync/FirstOrDefaultAsync
When you've made your query you would want to execute it but when is it best to call ToListAsync or FirstOrDefaultAsync?
It's best to call ToListAsync when you have as little data there as possible. So lets go for our character example again. Let's say we are making a search function and want to return a list when the name is the same. The following would be the query:
`queryable.Where(char => char.Name.equals(name)).ToListAsync();` `name` being the variable given by the user. We first do the where so we only get the results where the name is correct and then we make it into a list. EF will make this into a SQL query first that gets the characters with that name and then convert it into the correct object.

We nearly always call Async to improve performance.

# Many To Many relationships
Many to Many relationships aren't actually supported by EF Core natively but we can work around that. This is done by creating a new table which will simply take the two objects you want to bind together.