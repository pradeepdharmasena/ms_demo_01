FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app

COPY PlatformService.sln .

COPY PlatformService/PlatformService.csproj ./PlatformService/
COPY PlatformService.Repository/PlatformService.Repository.csproj ./PlatformService.Repository/
COPY PlatformService.Models/PlatformService.Models.csproj ./PlatformService.Models/
COPY PlatformService.Services/PlatformService.Services.csproj ./PlatformService.Services/

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "PlatformService.dll"]