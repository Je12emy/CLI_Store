# CLI Store

This is a GraphQL server built with [dotNet 5](https://dotnet.microsoft.com/download) using the [Hot Chocolate framework](https://chillicream.com/docs/hotchocolate), please visit the [original tutorial](https://youtu.be/HuN94qNwQmM)

## Usage

You may start a Postgress database,a PGAdmin and the server itself with the included `dockercompose` file.

```console
docker-compose up
```
_Note:_ This will use port 8080, 8081 and 5000 for each container.

You may also cd into the server directory and modify the connection string located at `launchSettings`

```console
dotnet run
```
Run the migrations if needed, you may need to create the database itself (The database name in the connection string is expected to be `commander`).

```console
dotnet ef database update
```

Visit the "Banana Cake Pop" GraphQL playground at http://localhost:5000/graphql

![GraphQL Playground](assets/graphql_playground.png)

_Note:_ Postman collection included in project files, Insomnia is recommended for better GraphQL support.

Explore the schema with [GraphQL Voyager](https://github.com/APIs-guru/graphql-voyager) at http://localhost5000/graphql-voyager

![GraphQL Voyager](assets/graphql_voyager.png)

## Todo

- [x] Dockerize server app.
- [x] Add server image to docker-compose.
- [ ] Vuejs frontend, maybe Vite.
