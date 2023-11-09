#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SRSAppV2.API/SRSAppV2.API.csproj", "SRSAppV2.API/"]
COPY ["SRSAppV2.Domain/SRSAppV2.Domain.csproj", "SRSAppV2.Domain/"]
COPY ["SRSAppV2.Infra/SRSAppV2.Infra.csproj", "SRSAppV2.Infra/"]
RUN dotnet restore "SRSAppV2.API/SRSAppV2.API.csproj"
COPY . .
WORKDIR "/src/SRSAppV2.API"
RUN dotnet build "SRSAppV2.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SRSAppV2.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SRSAppV2.API.dll"]