# Use the official .NET SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project and restore dependencies
COPY *.sln ./
COPY Portfolio/*.csproj ./Portfolio/
RUN dotnet restore Portfolio/Portfolio.csproj

# Copy everything and build
COPY Portfolio/. ./Portfolio/
WORKDIR /app/Portfolio
RUN dotnet publish -c Release -o /app/publish

# Use a smaller runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "Portfolio.dll"]

