
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5108

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Intotech.Wheelo.Integration.Api/Intotech.Wheelo.Integration.Api.csproj", "Intotech.Wheelo.Integration.Api"]
RUN dotnet restore "Intotech.Wheelo.Integration.Api/Intotech.Wheelo.Integration.Api.csproj"
COPY . .
WORKDIR "/src/Intotech.Wheelo.Integration.Api"
RUN dotnet build "Intotech.Wheelo.Integration.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intotech.Wheelo.Integration.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5108
ENTRYPOINT ["dotnet", "Intotech.Wheelo.Integration.Api.dll"]