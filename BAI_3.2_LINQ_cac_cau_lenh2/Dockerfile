FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BAI_3.2_LINQ_cac_cau_lenh2/BAI_3.2_LINQ_cac_cau_lenh2.csproj", "BAI_3.2_LINQ_cac_cau_lenh2/"]
RUN dotnet restore "BAI_3.2_LINQ_cac_cau_lenh2/BAI_3.2_LINQ_cac_cau_lenh2.csproj"
COPY . .
WORKDIR "/src/BAI_3.2_LINQ_cac_cau_lenh2"
RUN dotnet build "BAI_3.2_LINQ_cac_cau_lenh2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BAI_3.2_LINQ_cac_cau_lenh2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BAI_3.2_LINQ_cac_cau_lenh2.dll"]
