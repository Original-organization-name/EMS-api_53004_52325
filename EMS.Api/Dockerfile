FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EMS.Api/EMS.Api.csproj", "EMS.Api/"]
RUN dotnet restore "EMS.Api/EMS.Api.csproj"
COPY . .
WORKDIR "/src/EMS.Api"
RUN dotnet build "EMS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EMS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMS.Api.dll"]
