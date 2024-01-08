FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app

COPY CommandService.sln .

COPY /CommandService/CommandService.csproj ./CommandService/
COPY /CommandService.DataAccess/CommandService.DataAccess.csproj ./CommandService.DataAccess/
COPY /CommandService.Models/CommandService.Models.csproj ./CommandService.Models/
COPY /CommandService.Repository/CommandService.Repository.csproj ./CommandService.Repository/
COPY /CommandService.Services/CommandService.Services.csproj ./CommandService.Services/

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "CommandService.dll"]