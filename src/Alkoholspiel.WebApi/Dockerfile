FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY src/ /app/
WORKDIR "/app/Alkoholspiel.WebApi"
RUN dotnet build "Alkoholspiel.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alkoholspiel.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alkoholspiel.WebApi.dll"]