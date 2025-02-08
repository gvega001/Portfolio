# Use the official .NET SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app# Use the official .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the solution and restore dependencies
COPY ["Portfolio.sln", "./"]
COPY ["Portfolio/Portfolio/Portfolio.csproj", "Portfolio/Portfolio/"]
RUN dotnet restore "Portfolio/Portfolio/Portfolio.csproj"

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
ENTRYPOINT ["dotnet", "Portfolio.dll"]


# Copy the project and restore dependencies
COPY *.sln ./
COPY Portfolio/*.csproj ./Portfolio/
RUN dotnet restore Portfolio/Portfolio.csproj

# Copy everything and build
COPY Portfolio/. ./Portfolio/
WORKDIR /app/Portfolio
RUN dotnet publish -c Release -o /app/publish

# Use a smaller runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "Portfolio.dll"]
