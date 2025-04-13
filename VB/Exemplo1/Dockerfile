FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Exemplo1/Exemplo1.vbproj", "Exemplo1/"]
RUN dotnet restore "Exemplo1/Exemplo1.vbproj"
COPY . .
WORKDIR "/src/Exemplo1"
RUN dotnet build "Exemplo1.vbproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Exemplo1.vbproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exemplo1.dll"]
