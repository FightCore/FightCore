# Select the 2.1 SDK from .NET Core
FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /app
# # Copy over the csproj files
# COPY FightCore.Api/FightCore.Api.csproj ./
# RUN dotnet restore FightCore.Api.csproj

COPY . ./
RUN dotnet publish FightCore.Api/FightCore.Api.csproj -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY —-from=build /app/out ./
ENTRYPOINT [“dotnet”, FightCore.Api.dll”]`