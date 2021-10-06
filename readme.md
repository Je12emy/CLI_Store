# CLI Store

This is a GraphQL server built with [dotNet 5](https://dotnet.microsoft.com/download) using the [Hot Chocolate framework](https://chillicream.com/docs/hotchocolate), please visit the [original tutorial](https://youtu.be/HuN94qNwQmM)

## Usage

You may start a Postgress instance and PGAdmin with the included `dockercompose` file.

```console
docker-compose up
```
_Note:_ This will use port 8080 and 8081 for each container.

cd into the server directory and run the app.

```console
dotnet run
```

Visit the "Banana Cake Pop" GraphQL playground at http://localhost:5000/graphql

![GraphQL Playground](assets/graphql_playground.png)

_Note:_ Postman collection included in project files, Insomnia is recommended for better GraphQL support.

Explore the schema with [GraphQL Voyager](https://github.com/APIs-guru/graphql-voyager) at http://localhost5000/graphql-voyager

![GraphQL Voyager](assets/graphql_voyager.png)

## Todo

- [ ] Dockerize server app.
- [ ] Add server image to docker-compose.
- [ ] Vuejs frontend, maybe Vite.
