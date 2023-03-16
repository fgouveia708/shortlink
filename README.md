# Shortlink

## Getting started

### Required

- [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
- [Docker](https://www.docker.com/)

### Clone project

Clone the project and run `dotnet restore`

### Installing the dependencies to run locally

We use the following services for data storage:

- PostgreSQL
- RabbitMQ

To provision these resources locally go to default folder and run `docker-compose up -d`

### Run project

To run `dotnet run`

### RabbitMQ

Access your browser:

```bash
http://localhost:15672
```

And set values:

```bash
USER="admin"
PASSWORD="admin"
```

### PgAdmin

Access your browser:

```bash
http://localhost:16543
```

And set values:

```bash
USER="admin@admin.com"
PASSWORD="admin"
```

### Postgres


Credentials to connection DB:

```bash
USER="admin"
PASSWORD="numsey*Password!"
```

## Entity Relationship Diagram

![alt text](https://github.com/fgouveia708/shortlink/blob/main/Api/Contents/erd.png?raw=true)
