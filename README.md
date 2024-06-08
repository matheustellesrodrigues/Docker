# Docker

Este é um arquivo README para descrever o projeto e o Dockerfile associado.

## Descrição do Projeto

Este projeto utiliza o Docker para criar um ambiente de desenvolvimento e implantação para uma aplicação .NET.

## Dockerfile

O Dockerfile neste projeto contém instruções para construir e executar a aplicação .NET em um contêiner Docker.

```dockerfile
# Utiliza a imagem oficial do .NET SDK versão 8.0 para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Limpa todos os caches locais do NuGet
RUN dotnet nuget locals all --clear

# Copia o arquivo de projeto (.csproj) para o diretório de trabalho
COPY *.csproj ./

# Restaura as dependências do projeto
RUN dotnet restore

# Copia todos os arquivos do diretório atual para o diretório de trabalho no contêiner
COPY . ./

# Publica a aplicação em modo Release para a pasta 'out'
RUN dotnet publish -c Release -o out

# Utiliza a imagem oficial do .NET ASP.NET Core runtime versão 8.0 para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos publicados da etapa de build para o diretório de trabalho no contêiner
COPY --from=build /app/out .

# Cria um novo usuário chamado 'myuser'
RUN useradd -m myuser

# Define o usuário 'myuser' para executar os comandos seguintes
USER myuser

# Define uma variável de ambiente com valor padrão 'Production'
ARG ENVIRONMENT=Production

# Define a variável de ambiente ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=${ENVIRONMENT}

# Expõe a porta 80 para permitir acessos HTTP
EXPOSE 80

# Define o ponto de entrada do contêiner para rodar a aplicação
ENTRYPOINT ["dotnet", "GS.dll"]

version: '3.9'

services:
  web:
    build: .
    ports:
      - "8080:80"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__OracleDbConnection=User Id=RM551353;Password=190204;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=db)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))
    depends_on:
      - db

  db:
    image: gvenzl/oracle-xe:21-slim
    environment:
      ORACLE_PASSWORD: "190204"
      APP_USER: "RM551353"
      APP_USER_PASSWORD: "190204"
    ports:
      - "1521:1521"
      - "5500:5500"
    volumes:
      - oracle-data:/opt/oracle/oradata

volumes:
  oracle-data:
