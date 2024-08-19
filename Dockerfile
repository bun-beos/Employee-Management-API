FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./MISA.WebFresher07.MF1741.TTKIEN/MISA.WebFresher07.MF1741.TTKIEN.csproj", "src/MISA.WebFresher07.MF1741.TTKIEN/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/MISA.WebFresher07.MF1741.TTKIEN/MISA.WebFresher07.MF1741.TTKIEN.csproj"

COPY . .

# run build over the API project
WORKDIR "/src/MISA.WebFresher07.MF1741.TTKIEN/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app
EXPOSE 8011
COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "MISA.WebFresher07.MF1741.TTKIEN.dll" ]