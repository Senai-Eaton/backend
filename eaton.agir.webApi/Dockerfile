FROM microsoft/aspnetcore
WORKDIR /app
COPY ./bin/Debug/netcoreapp2.0/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet eaton.agir.webApi.dll