# Alkoholspiele

## The app

Alkohospiele is a simple webapp that implements the drinking game "Piccolo" with the ability to create custom games with custom jokes.

## Tech Stack

Backend : 
- ASP .NET Core WebApi
- EF Core
- PostgreSQL

Frontend : 
- Angular 8
- Angular Material
- Chart.js

## Docker Deployment

With docker-compose :

```yml
  alkoholspiele:
    image: ombrelin/alkoholspiele:1.0
    container_name: alkoholspiele
    ports:
      - "80:80"
    environment:
      - DATABASE_URL=<Postgres database URL>
    restart: unless-stopped
```
