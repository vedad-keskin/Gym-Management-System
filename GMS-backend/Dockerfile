FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY GMS/ GMS/
RUN dotnet publish GMS/GMS.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
# PORT is set by Render at runtime; Program.cs reads it and binds to 0.0.0.0:PORT
ENTRYPOINT ["dotnet", "GMS.dll"]
