## Steps to create and initialize the database.

1. Tools -> NuGet Package Manager -> Package Manager Console
2. In the Package Manager Console set on default project src\TitanGate.Website.DAL
3. Execute command `update-database`

## Steps to prepare the source code to build/run properly

1. Navigate to the root folder
2. Navigate to WebApi project - `cd ./src/TitanGate.Website.Api`
3. Build the project - `dotnet build`
4. Run the project - `dotnet run`
5. The application is running locally at `https://localhost:5001`

## Feedback and assumptions 

1. I think you should adding requirement for using IoC container
2. As additional task which is not mandatory, you could add CI
