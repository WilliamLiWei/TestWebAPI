FROM microsoft/aspnetcore:2.0 
WORKDIR /app
COPY ./ .
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

WORKDIR /app
ENTRYPOINT ["dotnet", "WebAPIDemo.dll"]