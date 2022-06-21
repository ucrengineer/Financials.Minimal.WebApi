#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Financials.Minimal.WebApi.csproj", "Financials.Minimal.WebApi/"]
# COPY ["Financials.Minimal.Application/Financials.Minimal.Application.csproj", "Financials.Minimal.Application/"]

RUN dotnet restore "Financials.Minimal.WebApi/Financials.Minimal.WebApi.csproj"
COPY . .
WORKDIR "/src/Financials.Minimal.WebApi"
RUN dotnet build "Financials.Minimal.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Financials.Minimal.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Financials.Minimal.WebApi.dll"]