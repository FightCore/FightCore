# Backend overview

Disclaimer: This section is only intended to give you a brief glimpse of how the backend works.
Other wiki sections may give a brief overview of the different patterns and frameworks, but it's up to you to have a fundamental understanding of them already.

## Overall Organization

If you open up /FightCore/Backend/FightCore.sln, you'll see 6 distinct sections:

![Folder Overview](https://i.imgur.com/OVBavAU.png?1)

The structure goes from data-centric to more so application-centric, in a way.

1. Models - Simply put, data models
2. Data - Data Access Layer, handles setting up and communicating directly with what stores our data (eg, a SQL database)
3. Repositories - Handles interacting with the data layer. This allows you to simply call ObjectRepository.Insert and not worry what's behind the scenes at all (not even what the database itself is)
4. Services - Handles application-level interactions with database level. This is what calls the repositories and also can handle other complex behavior, such as checking that inputs are appropriate before calling into the repository
5. Tests - Unit tests & the like live here
6. Api - Defines and handles API behavior. This ranges from defining configurations and API controllers to defining specific small classes used for requests + responses

As for specific frameworks and patterns...

## Entity Framework Core (EF)

_Primarily around `2 Data` layer_
This ORM framework is used to connect our models to the database and directly interact with the database.

Note that we are using the following patterns:

* Code First - In contrast to Database First, we define the database structure in code. EF takes the models we give it as well as any additional configuration information, then generates migrations that are applied to the database to generate what we need
* Fluent API - Advanced method of further configuring the database (rather than solely relying on EF to infer everything from models). Use this instead of the Data Annotations pattern
* LINQ & [Extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) - We primarily do queries via LINQ, which further abstracts away the underlying SQL layer. We highly prefer LINQ usage over direct SQL calls for several reasons (primary exception is if there's a highly complex SQL call that LINQ wouldn't perform well with). In addition, we prefer extension methods rather than LINQ syntax

## Unit of Work Pattern

This, in tandem with the Repository pattern, creates an abstraction layer between the data layer and the business logic layer. In particular, Unit of Work...
"maintains in-memory updates and then sends these in-memory updates as one transaction to the database" (borrowed from [this site](https://www.codeproject.com/Articles/581487/UNIT-of-Work-Design-Pattern)).

## Swagger / OpenAPI

This tool creates the interactive API documentation for our backend