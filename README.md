# ASP.NET Core 2.2 Playground

Project created to explore the structure of APIs using ASP.NET Core 2, helping to implement resources and understand them.

### Roadmap 1 (on branch [master](https://github.com/gabrielrigon/aspnet_core_playground))

- [x] Initialize the project with `dotnet` CLI
- [x] Create a model and context
- [x] Implement `InMemoryDatabase` for `TodoItems`
- [x] Create controller with CRUD actions

### Roadmap 2 (on branch [feat/mongo-db](https://github.com/gabrielrigon/aspnet_core_playground/tree/feat/mongo-db))

- [x] Remove `InMemoryDatabase`
- [x] Implement `TodoService` which provides a MongoDB methods (CRUD)

### Requirements

- macOS, Linux or Windows
- [SDK .NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [MongoDB 4.2](https://www.mongodb.com/download-center/community)

### Running the project

To run this project, you just need to install the dependencies and execute the following command:

```sh
$ dotnet run
```

After that, you can send requests to `TodoController` and interact with actions.
