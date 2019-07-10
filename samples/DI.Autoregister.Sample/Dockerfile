FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 56932
EXPOSE 44369

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY samples/DI.Autoregister.Sample/DependencyInjection.Autoregister.Sample.csproj samples/DI.Autoregister.Sample/
RUN dotnet restore samples/DI.Autoregister.Sample/DependencyInjection.Autoregister.Sample.csproj
COPY . .
WORKDIR /src/samples/DI.Autoregister.Sample
RUN dotnet build DependencyInjection.Autoregister.Sample.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DependencyInjection.Autoregister.Sample.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DependencyInjection.Autoregister.Sample.dll"]
