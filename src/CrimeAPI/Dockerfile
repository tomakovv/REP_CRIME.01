#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CrimeAPI/Crime.API.csproj", "src/CrimeAPI/"]
COPY ["src/Crime.Application/Crime.Application.csproj", "src/Crime.Application/"]
COPY ["src/Crime.Domain/Crime.Domain.csproj", "src/Crime.Domain/"]
COPY ["src/REP_CRIME.01.Common/REP_CRIME.01.Common.csproj", "src/REP_CRIME.01.Common/"]
COPY ["src/Crime.Persistance/Crime.Persistence.csproj", "src/Crime.Persistance/"]
RUN dotnet restore "src/CrimeAPI/Crime.API.csproj"
COPY . .
WORKDIR "/src/src/CrimeAPI"
RUN dotnet build "Crime.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Crime.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Crime.API.dll"]