# Server Dockerfile for .NET 9 (build context: ./4gaDailyWorkReview.Server)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# install procps so `pgrep` is available for the healthcheck
RUN apt-get update && apt-get install -y --no-install-recommends procps \
    && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# copy project file(s) from the build context root
COPY ["4gaDailyWorkReview.Server.csproj", "./"]
RUN dotnet restore "4gaDailyWorkReview.Server.csproj"

# copy remaining source and build
COPY . .
RUN dotnet build "4gaDailyWorkReview.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "4gaDailyWorkReview.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "4gaDailyWorkReview.Server.dll"]
