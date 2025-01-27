# XIV Voices Service
This API's intention is to be brains behind maintaining player reports, character to voice associations, and voice line generation.

## Getting Started

1. Install dependencies:

   - [.Net SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
   - [Entity Framework .NET Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet):
     - `dotnet tool install --global dotnet-ef`
   - [Docker](https://www.docker.com/get-started/)
2. Create your `.env` by copying `.env.sample`. Change any variables as necessary. Both the postgres image and the API will reference the `POSTGRES_` variables for database connection information.
3. CD into the XivVoicesService Project:
   - `cd XivVoicesService`
4. Run the Postgres image to establish a database:
   - `docker-compose up -d postgres`
   - The `-d` runs the image in the background in a detached state.
5. Run the [DB Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli):
   - `dotnet ef database update`
6. Run the service:
   - `dotnet run --launch-profile http`

A swagger UI should open at this location: http://localhost:5260/swagger/index.html

## Migrations

This project uses [.Net Entity Framework](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli). To create a migration, simply make changes to or add a model and run:
```
dotnet ef migrations add NameOfYourMigration
```

**Note:** Please ensure your migration name is in `PascalCase`.

## Repository Pattern

This project uses the Repository Pattern. This level of abstraction may seem unnecessary but I use it as a self documenting tool about what an entity is allowed to do and not do. For instance, any authorization logic for adding/saving an entity should be encapsulated in the Repository for that entity's #save method, throwing an exception should the current user be prohibited from doing so (which is then caught by the controller to return a 403 response.)