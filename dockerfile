FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 7090

ENV ASPNETCORE_URLS=http://+:7090

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src

COPY ["*.sln", "."]
COPY ["ToDo.WebApi.Interface/ToDo.WebApi.Interface.csproj", "ToDo.WebApi.Interface/"]
COPY ["ToDo.WebApi.Infrastructure/ToDo.WebApi.Infrastructure.csproj", "ToDo.WebApi.Infrastructure/"]
COPY ["ToDo.WebApi.Application/ToDo.WebApi.Application.csproj", "ToDo.WebApi.Application/"]
COPY ["ToDo.WebApi.Domain/ToDo.WebApi.Domain.csproj", "ToDo.WebApi.Domain/"]
COPY ["WebApi.Framework/WebApi.Framework.csproj", "WebApi.Framework/"]

RUN dotnet restore "ToDo.WebApi.Interface/ToDo.WebApi.Interface.csproj"

COPY . .
WORKDIR "/src"
RUN dotnet build "ToDo.WebApi.Interface/ToDo.WebApi.Interface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo.WebApi.Interface/ToDo.WebApi.Interface.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo.WebApi.Interface/ToDo.WebApi.Interface.dll"]
