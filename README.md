# BGG Explorer

Developer: [Matt Sherman](https://mg5.dev)

> **Note:** This project is far from complete. It is a work in progress that I am using to experiment with modern ASP.NET development and also as an outlet to keep my React development skills sharp. There are many missing features and bugs, and all preferences are currently hard-coded. Error handling is sparse, and there are no tests. The UI is very basic and not yet at the level of polish that I would require for a production application. Performance has not been optimized. The project is not yet ready for deployment to a production environment.

BGG Explorer is a web application that allows users to view collections of board games on [BoardGameGeek.com](https://boardgamegeek.com). This project is not affiliated with BoardGameGeek.com. It is a personal project for educational purposes.

The project consists of two parts:

- A server-side REST API
- A client-side web application

## REST API (BggJsonWebApi)

- Implemented in C# using [ASP.NET Core Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-9.0)
- Uses the [BoardGameGeek XML API](https://boardgamegeek.com/wiki/page/BGG_XML_API2) to retrieve board game data, and converts it to JSON

## Client-Side Web Application (BggReactApp)

- Implemented in TypeScript using [React](https://reactjs.org/)
- CSS is written as CSS Modules
- Uses [Vite](https://vite.dev) for development and build tooling
- Uses [Remix Icon](https://remixicon.com/) for icons

## Getting Started

To start the REST API server:

```bash
cd BggJsonWebApi
dotnet run
```

To start the client-side web application:

```bash
cd BggReactApp
npm install
npm run dev
```
