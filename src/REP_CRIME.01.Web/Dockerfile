#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/REP_CRIME.01.Web/REP_CRIME.01.Web.csproj", "src/REP_CRIME.01.Web/"]
RUN dotnet restore "src/REP_CRIME.01.Web/REP_CRIME.01.Web.csproj"
COPY . .
WORKDIR "/src/src/REP_CRIME.01.Web"
RUN dotnet build "REP_CRIME.01.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REP_CRIME.01.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REP_CRIME.01.Web.dll"]