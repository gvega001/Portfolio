# Use the official .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the solution file and project file
COPY ["Portfolio.sln", "./"]
COPY ["Portfolio/Portfolio.Web.csproj", "Portfolio/"]

# Restore dependencies
RUN dotnet restore "Portfolio/Portfolio.Web.csproj"

# Copy everything and build the project
COPY . .
WORKDIR /app/Portfolio
RUN dotnet publish -c Release -o /app/publish --self-contained false

# Use ASP.NET runtime for running the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose the app on port 8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Portfolio.Web.dll"]
