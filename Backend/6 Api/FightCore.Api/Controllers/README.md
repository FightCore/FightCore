# Versioned API

The FightCore API is now versioned.
The folder structure allows to easily look at legacy code.
This versioning is inteded to help out third party devs or the frontend team when new implementations are wanting to be made.

## Versioning

The version is giving on the controller by adding `[Version()]`.
Versions can have Major, Minor and Fix version (3 layers as in 1.0.0).