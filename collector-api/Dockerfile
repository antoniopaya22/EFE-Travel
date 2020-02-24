#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["REST.Collector.Server/REST.Collector.Server.csproj", "REST.Collector.Server/"]
COPY ["REST.Collector.Client/REST.Collector.Client.csproj", "REST.Collector.Client/"]
RUN dotnet restore "REST.Collector.Server/REST.Collector.Server.csproj"
COPY . .
WORKDIR "/src/REST.Collector.Server"
RUN dotnet build "REST.Collector.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REST.Collector.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REST.Collector.Server.dll"]