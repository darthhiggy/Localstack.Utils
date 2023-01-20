FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Localstack.Utils.UI/Localstack.Utils.UI.csproj", "Localstack.Utils.UI/"]
RUN dotnet restore "Localstack.Utils.UI/Localstack.Utils.UI.csproj"
COPY . .
WORKDIR "/src/Localstack.Utils.UI"
RUN dotnet build "Localstack.Utils.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Localstack.Utils.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Localstack.Utils.UI.dll"]
