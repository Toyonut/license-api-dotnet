FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder

ARG BUILD_CONFIGURATION=Debug

COPY . /build

WORKDIR /build

RUN dotnet publish -o=/app


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY --from=builder /app /app

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /app

EXPOSE 8080

CMD ["dotnet", "LicenseAPI.dll"]
