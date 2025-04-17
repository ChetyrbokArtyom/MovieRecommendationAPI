FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["backend/MovieRecommendation.Domain/MovieRecommendation.Domain.csproj", "backend/MovieRecommendation.Domain/"]
COPY ["backend/MovieRecommendation.Core/MovieRecommendation.Core.csproj", "backend/MovieRecommendation.Core/"]
COPY ["backend/MovieRecommendation.Application/MovieRecommendation.Application.csproj", "backend/MovieRecommendation.Application/"]
COPY ["backend/MovieRecommendation.Infrastructure/MovieRecommendation.Infrastructure.csproj", "backend/MovieRecommendation.Infrastructure/"]
COPY ["backend/MovieRecommendationAPI/MovieRecommendationAPI.csproj", "backend/MovieRecommendationAPI/"]

RUN dotnet restore "backend/MovieRecommendationAPI/MovieRecommendationAPI.csproj"

COPY . .

WORKDIR "/src/backend/MovieRecommendationAPI"
RUN dotnet build "MovieRecommendationAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieRecommendationAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieRecommendationAPI.dll"]