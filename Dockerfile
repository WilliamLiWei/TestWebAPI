FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY /var/lib/jenkins/workspace/DemoWebAPI/WebAPIDemo.sln ./
COPY /var/lib/jenkins/workspace/DemoWebAPI/WebAPIDemo/WebAPIDemo.csproj WebAPIDemo/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY /var/lib/jenkins/workspace/DemoWebAPI/ .
WORKDIR /src/WebAPIDemo
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPIDemo.dll"]
