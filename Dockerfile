FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY OrderManagement.sln ./
COPY OrderManagement.API/OrderManagement.API.csproj OrderManagement.API/
COPY OrderManagement.Application/OrderManagement.Application.csproj OrderManagement.Application/
COPY OrderManagement.Domain/OrderManagement.Domain.csproj OrderManagement.Domain/
COPY OrderManagement.Infrastructure/OrderManagement.Infrastructure.csproj OrderManagement.Infrastructure/

RUN dotnet restore OrderManagement.sln

COPY . .

WORKDIR /src/OrderManagement.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

RUN apt-get update && apt-get install -y curl

COPY --from=build /src/OrderManagement.API/out ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "OrderManagement.API.dll"]