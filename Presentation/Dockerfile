FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 44126
EXPOSE 44366

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Presentation/Presentation.csproj Presentation/
COPY Domain/Domain.csproj Domain/
COPY IoC/IoC.csproj IoC/
COPY Data/Data.csproj Data/
COPY Identity/Identity.csproj Identity/
COPY Logger/Logger.csproj Logger/
COPY Email/Email.csproj Email/
RUN dotnet restore Presentation/Presentation.csproj
COPY . .
WORKDIR /src/Presentation
RUN dotnet build Presentation.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Presentation.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Presentation.dll"]
