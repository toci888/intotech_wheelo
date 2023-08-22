FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5072

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Intotech.ImageService/Intotech.Wheelo.ImageService.csproj", "Intotech.ImageService/"]
RUN dotnet restore "Intotech.ImageService/Intotech.Wheelo.ImageService.csproj"
COPY . .
WORKDIR "/src/Intotech.ImageService"
RUN dotnet build "Intotech.Wheelo.ImageService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intotech.Wheelo.ImageService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5072
ENTRYPOINT ["dotnet", "Intotech.Wheelo.Api.dll"]