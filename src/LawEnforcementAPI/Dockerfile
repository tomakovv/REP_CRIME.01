#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/LawEnforcementAPI/LawEnforcement.API.csproj", "src/LawEnforcementAPI/"]
COPY ["src/LawEnforcement.Persistance/LawEnforcement.Persistence.csproj", "src/LawEnforcement.Persistance/"]
COPY ["src/LawEnforcement.Application/LawEnforcement.Application.csproj", "src/LawEnforcement.Application/"]
COPY ["src/LawEnforcement.Domain/LawEnforcement.Domain.csproj", "src/LawEnforcement.Domain/"]
RUN dotnet restore "src/LawEnforcementAPI/LawEnforcement.API.csproj"
COPY . .
WORKDIR "/src/src/LawEnforcementAPI"
RUN dotnet build "LawEnforcement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LawEnforcement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LawEnforcement.API.dll"]