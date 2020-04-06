FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /src
COPY NuGet.config ./

COPY ["src/Vix.V1.Juros.Calculo.WebApi/Vix.V1.Juros.Calculo.WebApi.csproj", "src/Vix.V1.Juros.Calculo.WebApi/"]
COPY ["src/Vix.V1.Juros.Infrastructure/Vix.V1.Juros.Infrastructure.csproj", "src/Vix.V1.Juros.Infrastructure/"]
COPY ["src/Vix.V1.Juros.Application/Vix.V1.Juros.Application.csproj", "src/Vix.V1.Juros.Application/"]
COPY ["src/Vix.V1.Juros.Domain/Vix.V1.Juros.Domain.csproj", "src/Vix.V1.Juros.Domain/"]
RUN dotnet restore "src/Vix.V1.Juros.Calculo.WebApi/Vix.V1.Juros.Calculo.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Vix.V1.Juros.Calculo.WebApi"
RUN dotnet build "Vix.V1.Juros.Calculo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vix.V1.Juros.Calculo.WebApi.csproj" -c Release -o /app/publish

FROM base AS final

ENV TZ=America/Sao_Paulo
ENV LANG pt-BR
ENV LANGUAGE pt-BR
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vix.V1.Juros.Calculo.WebApi.dll"]