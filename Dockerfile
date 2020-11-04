FROM nginx:alpine AS base

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS publish
WORKDIR /src

COPY ["pitch_tracker.csproj", ""]
RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o /app

FROM base AS final
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=publish /app/pitch_tracker/dist /usr/share/nginx/html/