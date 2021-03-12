FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY ["DataHoarder.Bootstrapper/DataHoarder.Bootstrapper.csproj", "DataHoarder.Bootstrapper/"]
COPY ["DataHoarder.Modules.Air.Api/DataHoarder.Modules.Air.Api.csproj", "DataHoarder.Modules.Air.Api/"]
COPY ["DataHoarder.Modules.Air.Core/DataHoarder.Modules.Air.Core.csproj", "DataHoarder.Modules.Air.Core/"]
COPY ["DataHoarder.Shared.Infrastructure/DataHoarder.Shared.Infrastructure.csproj", "DataHoarder.Shared.Infrastructure/"]

RUN dotnet restore "DataHoarder.Bootstrapper/DataHoarder.Bootstrapper.csproj"

COPY . .

WORKDIR "/src/DataHoarder.Bootstrapper"
RUN dotnet build "DataHoarder.Bootstrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataHoarder.Bootstrapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataHoarder.Bootstrapper.dll"]