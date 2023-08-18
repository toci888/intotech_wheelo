FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5015

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Toci.Driver.Api/Intotech.Wheelo.Api.csproj", "Toci.Driver.Api/"]
RUN dotnet restore "Toci.Driver.Api/Intotech.Wheelo.Api.csproj"
COPY . .
WORKDIR "/src/Toci.Driver.Api"
RUN dotnet build "Intotech.Wheelo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intotech.Wheelo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5015
ENTRYPOINT ["dotnet", "Intotech.Wheelo.Api.dll"]