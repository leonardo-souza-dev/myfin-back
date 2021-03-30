FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
ARG VERSION
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS final
ARG VERSION
WORKDIR /app
COPY --from=build /app .
ENV VERSION="${VERSION}"
ENTRYPOINT ["dotnet", "MyFin.Api.dll"]
