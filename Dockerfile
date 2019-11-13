FROM microsoft/dotnet:2.2-aspnetcore-runtime



ADD Publish /app

WORKDIR /app

EXPOSE 80


ENTRYPOINT ["dotnet", "capiacesskey.dll"]