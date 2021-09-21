#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ECommerceW8/ECommerceW8.csproj", "ECommerceW8/"]
RUN dotnet restore "ECommerceW8/ECommerceW8.csproj"
COPY . .
WORKDIR "/src/ECommerceW8"
RUN dotnet build "ECommerceW8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerceW8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ECommerceW8.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ECommerceW8.dll