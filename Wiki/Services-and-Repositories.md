# Repositories
Repositories are used to gather, update or remove data from the database. In the normal flow, the Controller class calls the Service, the service calls the repository. Repositories are only meant to output lists and entities, a repository should NEVER expose its Queryable (this is only for Entity Framework). 

# Services
Services are used to regulate what gets send back to the user. All parameters and return values should be check in the service instead of the controller or repository (for throwing exceptions). Services sometimes only forward the methods that the repository has. This is a thing that happens and it's fine to happen.

## Injection
Services and Repositories should ALWAYS be injected using Dependency Injection. Only during big taxing queries we can create our own context and services/repositories.