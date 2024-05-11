FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5121

ENV ASPNETCORE_URLS=http://+:5121

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["PokemonsAPI/PokemonsAPI.WEB/PokemonsAPI.WEB.csproj", "PokemonsAPI/PokemonsAPI.WEB/"]
RUN dotnet restore "PokemonsAPI\PokemonsAPI.WEB\PokemonsAPI.WEB.csproj"
COPY . .
WORKDIR "/src/PokemonsAPI/PokemonsAPI.WEB"
RUN dotnet build "PokemonsAPI.WEB.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "PokemonsAPI.WEB.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokemonsAPI.WEB.dll"]
