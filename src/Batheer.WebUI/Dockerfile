#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Batheer.WebUI.csproj", "BaSaleh/"]
COPY ["../BaSaleh.Application/Batheer.Application.csproj", "BaSaleh.Application/"]
#COPY ["BaSaleh.Domain/Batheer.Domain.csproj", "BaSaleh.Domain/"]
#COPY ["Batheer.DataMigration/Batheer.DataMigration.csproj", "Batheer.DataMigration/"]
#COPY ["BaSaleh.Infrastructure/Batheer.Infrastructure.csproj", "BaSaleh.Infrastructure/"]
RUN dotnet restore "BaSaleh/Batheer.WebUI.csproj"
COPY . .
WORKDIR "/src/BaSaleh"
RUN dotnet build "Batheer.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Batheer.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Batheer.WebUI.dll"]