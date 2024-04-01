FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7179

ENV ASPNETCORE_URLS=http://+:7179
ENV ASPNETCORE_ENVIRONMENT=Development

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Cliente.API/Cliente.API.csproj", "Cliente.API/"]
RUN dotnet restore "Cliente.API/Cliente.API.csproj"
COPY . .
WORKDIR "/src/Cliente.API"
RUN dotnet build "Cliente.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Cliente.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cliente.API.dll"]
