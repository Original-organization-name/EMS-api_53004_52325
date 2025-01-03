FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EMS.Employees/EMS.Employees.csproj", "EMS.Employees/"]
RUN dotnet restore "EMS.Employees/EMS.Employees.csproj"
COPY . .
WORKDIR "/src/EMS.Employees"
RUN dotnet build "EMS.Employees.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EMS.Employees.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMS.Employees.dll"]
