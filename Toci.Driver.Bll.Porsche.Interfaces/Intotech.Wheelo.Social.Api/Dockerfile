FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5154

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Intotech.Wheelo.Social.Api/Intotech.Wheelo.Social.Api.csproj", "Intotech.Wheelo.Social.Api/"]
RUN dotnet restore "Intotech.Wheelo.Social.Api/Intotech.Wheelo.Social.Api.csproj"
COPY . .
WORKDIR "/src/Intotech.Wheelo.Social.Api"
RUN dotnet build "Intotech.Wheelo.Social.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intotech.Wheelo.Social.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5154
ENTRYPOINT ["dotnet", "Intotech.Wheelo.Social.Api.dll"]