# Use the official .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the solution and restore dependencies
COPY ["Portfolio.sln", "./"]
COPY ["Portfolio/Portfolio/Portfolio.Web.csproj", "Portfolio/Portfolio/"]
RUN dotnet restore "Portfolio/Portfolio/Portfolio.Web.csproj"

# Copy everything and build the project
COPY . .
WORKDIR /app/Portfolio/Portfolio
RUN dotnet publish -c Release -o /app/publish --self-contained false

# Use ASP.NET runtime for running the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose the app on port 8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Portfolio.Web.dll"]
