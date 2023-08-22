FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5130

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Intotech.Wheelo.Chat.Api/Intotech.Wheelo.Chat.Api.csproj", "Intotech.Wheelo.Chat.Api/"]
RUN dotnet restore "Intotech.Wheelo.Chat.Api/Intotech.Wheelo.Chat.Api.csproj"
COPY . .
WORKDIR "/src/Intotech.Chat.Wheelo.Api"
RUN dotnet build "Intotech.Wheelo.Chat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intotech.Wheelo.Chat.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5130
ENTRYPOINT ["dotnet", "Intotech.Wheelo.Chat.Api.dll"]