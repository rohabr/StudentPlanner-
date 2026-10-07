# 📚 Student Planner

A web application that helps students keep track of their courses, tasks, deadlines and priorities in one place.

![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![MariaDB](https://img.shields.io/badge/MariaDB-003545?logo=mariadb&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=white)
![Status](https://img.shields.io/badge/status-in%20development-yellow)

Built as a personal learning and portfolio project, developed step by step: from a simple web app to a containerized application with a real database.

---

## ✨ Features

- View a list of tasks
- Create new tasks
- Delete tasks
- Mark tasks as completed / not completed
- Set a priority for each task (Low, Medium, High)
- Unit tests for core logic

## 🛠️ Tech Stack

| Area | Technology |
| --- | --- |
| Backend | C#, ASP.NET Core MVC (.NET 10) |
| Frontend | HTML, CSS, Razor views |
| Database | MariaDB |
| ORM | Entity Framework Core (Pomelo MySQL provider) |
| Testing | MSTest |
| Containers | Docker, Docker Compose |
| Version control | Git, GitHub |

## 📁 Project Structure

```
StudentPlanner/
├── StudentPlanner/          # Main web application
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   ├── DataAccess/          # DbContext
│   ├── Migrations/          # EF Core migrations
│   └── Program.cs
├── StudentPlannerTest/      # MSTest unit tests
├── docker-compose.yml
└── README.md
```

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- An IDE such as JetBrains Rider or Visual Studio

### 1. Create the Docker network and database container

```bash
docker network create appnet

docker run -d --name mariadbcontainer --network appnet \
  -e MARIADB_ROOT_PASSWORD=<your-password> \
  -p 3306:3306 \
  -v mariadbdata:/var/lib/mysql \
  mariadb:latest
```

### 2. Configure the connection string

Set the same password in the connection string used by the app:

```
Server=mariadbcontainer;Port=3306;Database=studentplannerdb;User=root;Password=<your-password>;
```

### 3. Apply database migrations

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update --connection "Server=localhost;Port=3306;Database=studentplannerdb;User=root;Password=<your-password>;"
```

### 4. Run the application

```bash
docker compose up --build
```

### 5. Run the tests

```bash
dotnet test
```

## 🗺️ Roadmap

- [x] **Phase 1:** Basic web app with a static task list
- [x] **Phase 2:** C# logic (create, delete, complete tasks) and unit tests
- [ ] **Phase 3:** Persistent storage with MariaDB and Entity Framework Core
- [ ] **Phase 4:** Full Docker setup
- [ ] **Phase 5:** Additional features (login, dashboard and more)
- [ ] **Deployment**

## 🎯 What I'm Learning

- Building MVC applications with ASP.NET Core
- Dependency injection and separation of concerns
- Working with a relational database through Entity Framework Core and migrations
- Containerizing an application and its database with Docker
- Writing unit tests
- Using Git and GitHub in a real project

## 👤 Author

**Rohab Khan**, student at the University of Agder
