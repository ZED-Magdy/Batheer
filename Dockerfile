
# working doc.

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app


COPY ./Batheer.sln .
COPY ./src/Batheer.Domain/Batheer.Domain.csproj ./src/Batheer.Domain/Batheer.Domain.csproj
COPY ./src/Batheer.Application/Batheer.Application.csproj ./src/Batheer.Application/Batheer.Application.csproj
COPY ./src/Batheer.Infrastructure/Batheer.Infrastructure.csproj ./src/Batheer.Infrastructure/Batheer.Infrastructure.csproj
COPY ./src/Batheer.DataMigration/Batheer.DataMigration.csproj ./src/Batheer.DataMigration/Batheer.DataMigration.csproj
COPY ./src/Batheer.WebUI/Batheer.WebUI.csproj ./src/Batheer.WebUI/Batheer.WebUI.csproj

RUN dotnet restore

COPY ./test ./test
COPY ./src ./src

RUN dotnet build -c Release --no-restore

#RUN dotnet test "./test/AspNetCoreInDocker.Web.Tests/AspNetCoreInDocker.Web.Tests.csproj" -c Release --no-build --no-restore

RUN dotnet publish "./src/Batheer.WebUI/Batheer.WebUI.csproj" -c Release -o "./out" --no-restore


################################################

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

RUN mkdir -p Keys
EXPOSE 80
ENTRYPOINT ["dotnet", "Batheer.WebUI.dll"]