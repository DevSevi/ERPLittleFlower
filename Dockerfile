# --- Build Stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projektdateien kopieren und Abhängigkeiten auflösen
COPY *.csproj ./
RUN dotnet restore

# Restlichen Code kopieren und App bauen
COPY . .
RUN dotnet publish -c Release -o /app

# --- Runtime Stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ERPLittleFlower.dll"]