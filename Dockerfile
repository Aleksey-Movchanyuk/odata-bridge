# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Install git
RUN apt-get update && apt-get install -y git

# Clone the repository
RUN git clone https://github.com/Aleksey-Movchanyuk/odata-bridge.git .

# Restore as distinct layers
RUN dotnet restore

# Build
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "ODataBridge.dll"]
ENTRYPOINT ["dotnet run"]
