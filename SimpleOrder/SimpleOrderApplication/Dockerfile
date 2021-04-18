#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SimpleOrderApplication/SimpleOrder.API.csproj", "SimpleOrderApplication/"]
COPY ["../SimpleOrder.Application/SimpleOrder.Application/SimpleOrder.Application.csproj", "../SimpleOrder.Application/SimpleOrder.Application/"]
COPY ["../SimpleOrder.Infra.Data/SimpleOrder.Infra.Data/SimpleOrder.Infra.Data.csproj", "../SimpleOrder.Infra.Data/SimpleOrder.Infra.Data/"]
RUN dotnet restore "SimpleOrderApplication/SimpleOrder.API.csproj"
COPY . .
WORKDIR "/src/SimpleOrderApplication"
RUN dotnet build "SimpleOrder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleOrder.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleOrder.API.dll"]