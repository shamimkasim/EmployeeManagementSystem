# Use Microsoft's official .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore any dependencies (via NuGet)
COPY src/EmployeeManagementSystem/EmployeeManagementSystem.csproj src/EmployeeManagementSystem/
RUN dotnet restore src/EmployeeManagementSystem/EmployeeManagementSystem.csproj

# Copy the rest of the project files and build the release
COPY src/EmployeeManagementSystem/ ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "EmployeeManagementSystem.dll"]
