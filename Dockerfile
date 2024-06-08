# Utiliza a imagem oficial do .NET SDK vers�o 8.0 para construir a aplica��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diret�rio de trabalho dentro do cont�iner
WORKDIR /app

# Limpa todos os caches locais do NuGet
RUN dotnet nuget locals all --clear

# Copia o arquivo de projeto (.csproj) para o diret�rio de trabalho
COPY *.csproj ./

# Restaura as depend�ncias do projeto
RUN dotnet restore

# Copia todos os arquivos do diret�rio atual para o diret�rio de trabalho no cont�iner
COPY . ./

# Publica a aplica��o em modo Release para a pasta 'out'
RUN dotnet publish -c Release -o out

# Utiliza a imagem oficial do .NET ASP.NET Core runtime vers�o 8.0 para rodar a aplica��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Define o diret�rio de trabalho dentro do cont�iner
WORKDIR /app

# Copia os arquivos publicados da etapa de build para o diret�rio de trabalho no cont�iner
COPY --from=build /app/out .

# Cria um novo usu�rio chamado 'myuser'
RUN useradd -m myuser

# Define o usu�rio 'myuser' para executar os comandos seguintes
USER myuser

# Define uma vari�vel de ambiente com valor padr�o 'Production'
ARG ENVIRONMENT=Production

# Define a vari�vel de ambiente ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=${ENVIRONMENT}

# Exp�e a porta 80 para permitir acessos HTTP
EXPOSE 80

# Define o ponto de entrada do cont�iner para rodar a aplica��o
ENTRYPOINT ["dotnet", "GS.dll"]


