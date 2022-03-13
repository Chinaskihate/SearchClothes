#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SearchClothes.WebApi/SearchClothes.WebApi.csproj", "SearchClothes.WebApi/"]
COPY ["SearchClothes.Persistence/SearchClothes.Persistence.csproj", "SearchClothes.Persistence/"]
COPY ["SearchClothes.Application/SearchClothes.Application.csproj", "SearchClothes.Application/"]
COPY ["SearchClothes.Domain/SearchClothes.Domain.csproj", "SearchClothes.Domain/"]
RUN dotnet restore "SearchClothes.WebApi/SearchClothes.WebApi.csproj"
COPY . .
WORKDIR "/src/SearchClothes.WebApi"
RUN dotnet build "SearchClothes.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SearchClothes.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchClothes.WebApi.dll"]