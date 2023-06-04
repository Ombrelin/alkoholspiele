# Alkoholspiele

## The app

Alkohospiele is a simple webapp that implements the drinking game "Piccolo" with the ability to create custom games with custom jokes.

## Tech Stack

Backend : 
- Ktor WebApi
- PostgreSQL

Frontend : ?

## Docker Deployment

With docker-compose :

```yml
  alkoholspiele:
    image: ombrelin/alkoholspiele:2.0
    container_name: alkoholspiele
    ports:
      - "80:80"
    environment:
      - DATABASE_URL=<Postgres database URL>
    restart: unless-stopped
```
