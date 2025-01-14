# GardenGivers


GardenGivers is a community-driven platform that connects people who want to share or request homegrown produce. It aims to reduce food waste and promote a sharing economy within local communities.

## Features

- **User Management**: Register, login, and manage user profiles.
- **Produce Listingsv**: Create, view, and manage produce offers and requests.
- **Transactions**: Facilitate and track transactions between users.

## UML Diagram

The project includes a UML diagram to represent the database schema and relationships.


## Installation

To get started with GardenGivers, follow these steps:

    Clone the repository:
```bash
git clone https://github.com/estanislao-lexicon/GardenGivers.git
cd GardenGivers
```

## Install dependencies:
Navigate to the API project directory:
```bash
cd API
dotnet restore
```

## Setup database:

- Ensure you have the necessary database setup as per your configuration.
- Run migrations:

```bash
dotnet ef database update
```

## Seed the database:

```bash
dotnet run seeddata
```


# Run Application


## Run the API:

  1. Navigate to the API project directory:
```bash
cd API
```

2. Start the API:
```bash
dotnet run
```

## Run the Frontend:

1. Navigate to the frontend project directory:
```bash
cd frontend
```
2. Install frontend dependencies:
```bash
npm install
```
3. Start the frontend development server:
```bash
npm start
```
The API runs on http://localhost:5033 and the frontend runs on http://localhost:3000.

## Contribution

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.