#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG FEED_URL
ARG PAT
WORKDIR /src

# download and install latest credential provider. Not required after https://github.com/dotnet/dotnet-docker/issues/878
RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash

COPY ["nuget.config", "Gcsb.Connect.SAP.WriteJsdnFile/"]
COPY ["Gcsb.Connect.SAP.WriteJsdnFile/Gcsb.Connect.SAP.WriteJsdnFile.csproj", "Gcsb.Connect.SAP.WriteJsdnFile/"]
COPY ["Gcsb.Connect.SAP.Domain/Gcsb.Connect.SAP.Domain.csproj", "Gcsb.Connect.SAP.Domain/"]
COPY ["Gcsb.Connect.SAP.Application/Gcsb.Connect.SAP.Application.csproj", "Gcsb.Connect.SAP.Application/"]
COPY ["Gcsb.Connect.SAP.Infrastructure/Gcsb.Connect.SAP.Infrastructure.csproj", "Gcsb.Connect.SAP.Infrastructure/"]

ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS {\"endpointCredentials\": [{\"endpoint\":\"${FEED_URL}\", \"username\":\"ArtifactsDocker\", \"password\":\"${PAT}\"}]}

RUN dotnet restore --configfile "Gcsb.Connect.SAP.WriteJsdnFile/nuget.config" "Gcsb.Connect.SAP.WriteJsdnFile/Gcsb.Connect.SAP.WriteJsdnFile.csproj"
COPY . .
WORKDIR "/src/Gcsb.Connect.SAP.WriteJsdnFile"
RUN dotnet build "Gcsb.Connect.SAP.WriteJsdnFile.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gcsb.Connect.SAP.WriteJsdnFile.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gcsb.Connect.SAP.WriteJsdnFile.dll"]