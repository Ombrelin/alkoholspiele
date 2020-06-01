FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
COPY ["alkoholspiele.csproj", "alkoholspiele/"]
RUN dotnet restore "alkoholspiele/alkoholspiele.csproj"

COPY ./ /src/alkoholspiele
WORKDIR "/src/alkoholspiele"
RUN ls
RUN dotnet build "alkoholspiele.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "alkoholspiele.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "alkoholspiele.dll"]