#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["NET5.JWT.CustomUser/NET5.JWT.CustomUser.csproj", "NET5.JWT.CustomUser/"]
RUN dotnet restore "NET5.JWT.CustomUser/NET5.JWT.CustomUser.csproj"
COPY . .
WORKDIR "/src/NET5.JWT.CustomUser"
RUN dotnet build "NET5.JWT.CustomUser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NET5.JWT.CustomUser.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NET5.JWT.CustomUser.dll"]