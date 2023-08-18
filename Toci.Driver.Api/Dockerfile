FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5105

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Toci.Driver.Bll.Porsche.Interfaces/test1/test1.csproj", "Toci.Driver.Bll.Porsche.Interfaces/test1/"]
RUN dotnet restore "Toci.Driver.Bll.Porsche.Interfaces/test1/test1.csproj"
COPY . .
WORKDIR "/src/Toci.Driver.Bll.Porsche.Interfaces/test1"
RUN dotnet build "test1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5015
ENTRYPOINT ["dotnet", "test1.dll"]
