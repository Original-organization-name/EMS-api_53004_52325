FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG PROJECT_CATALOG=Microservices/EMS.Gateway/EMS.Gateway
ARG PROJECT_NAME=EMS.Gateway

WORKDIR /src
COPY ["${PROJECT_CATALOG}/${PROJECT_NAME}.csproj", "${PROJECT_CATALOG}/"]
RUN dotnet restore "${PROJECT_CATALOG}/${PROJECT_NAME}.csproj"
COPY . .
WORKDIR "/src/${PROJECT_CATALOG}/"
RUN dotnet build "${PROJECT_NAME}.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "${PROJECT_NAME}.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMS.Gateway.dll"]

