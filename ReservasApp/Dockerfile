FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReservasApp/ReservasApp.csproj", "ReservasApp/"]
RUN dotnet restore "ReservasApp/ReservasApp.csproj"
COPY . .
WORKDIR "/src/ReservasApp"
RUN dotnet build "ReservasApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReservasApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservasApp.dll"]
