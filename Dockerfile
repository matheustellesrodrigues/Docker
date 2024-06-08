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


