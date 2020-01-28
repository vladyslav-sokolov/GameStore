FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["GameStore.WebUI/GameStore.WebUI.csproj", "GameStore.WebUI/"]
COPY ["GameStore.Application/GameStore.Application.csproj", "GameStore.Application/"]
COPY ["GameStore.Domain/GameStore.Domain.csproj", "GameStore.Domain/"]
COPY ["GameStore.Persistence/GameStore.Persistence.csproj", "GameStore.Persistence/"]
RUN dotnet restore "GameStore.WebUI/GameStore.WebUI.csproj"
COPY . .
WORKDIR /src/GameStore.WebUI

FROM build AS publish
RUN dotnet publish "GameStore.WebUI.csproj" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GameStore.WebUI.dll"]