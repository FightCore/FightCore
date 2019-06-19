# Models

Models are used by Entity Framework and are used to set up the database, all fields (unless annotated with [NotMapped]) will be copied over one to one.
When a Model gets mutated and is saved in the proper way, these changes will also gets pushed to the database.

There are currently no classes inheritable to make creating models easier, this will come in the future