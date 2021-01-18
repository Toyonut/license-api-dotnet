FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS builder

ARG BUILD_CONFIGURATION=Debug

COPY . /build

WORKDIR /build

RUN dotnet publish -o=/app


FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim

COPY --from=builder /app /app

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /app

EXPOSE 8080

CMD ["dotnet", "LicenseAPI.dll"]
