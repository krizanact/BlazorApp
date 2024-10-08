#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM nginx AS base
EXPOSE 8080
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Client.csproj ./
RUN dotnet restore ./Client.csproj
COPY . .
WORKDIR "/src/."
RUN dotnet build ./Client.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish ./Client.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM  base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY  nginx.conf /etc/nginx/nginx.conf