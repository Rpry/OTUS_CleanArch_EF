FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5100
EXPOSE 5101

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["Infrastructure/Infrastructure.EntityFramework/Infrastructure.EntityFramework.csproj", "Infrastructure/Infrastructure.EntityFramework/"]
COPY ["Domain/Domain.Entities/Domain.Entities.csproj", "Domain/Domain.Entities/"]
COPY ["Infrastructure/Infrastructure.Repositories.Implementations/Infrastructure.Repositories.Implementations.csproj", "Infrastructure/Infrastructure.Repositories.Implementations/"]
COPY ["Services/Services.Repositories.Abstractions/Services.Repositories.Abstractions.csproj", "Services/Services.Repositories.Abstractions/"]
COPY ["Services/Services.Contracts/Services.Contracts.csproj", "Services/Services.Contracts/"]
COPY ["Services/Services.Abstractions/Services.Abstractions.csproj", "Services/Services.Abstractions/"]
COPY ["Services/Services.Implementations/Services.Implementations.csproj", "Services/Services.Implementations/"]
RUN dotnet restore "WebApi/WebApi.csproj"
COPY ../ .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
