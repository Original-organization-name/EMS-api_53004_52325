FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EMS.Contracts/EMS.Contracts.csproj", "EMS.Contracts/"]
RUN dotnet restore "EMS.Contracts/EMS.Contracts.csproj"
COPY . .
WORKDIR "/src/EMS.Contracts"
RUN dotnet build "EMS.Contracts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EMS.Contracts.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMS.Contracts.dll"]
