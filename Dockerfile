# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto
COPY . ./ 

# Restaurar as dependências e publicar a aplicação
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out . 

# Expor a porta padrão
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "GitHubApi.dll"]
