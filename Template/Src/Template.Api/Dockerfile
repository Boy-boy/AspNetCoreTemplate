# 请参阅 https://aka.ms/customizecontainer 以了解如何自定义调试容器，以及 Visual Studio 如何使用此 Dockerfile 生成映像以更快地进行调试。

# 此阶段用于在快速模式(默认为调试配置)下从 VS 运行时
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


# 此阶段用于生成服务项目
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Template.Api/Template.Api.csproj", "Src/Template.Api/"]
COPY ["Src/Template.Adapter/Template.Adapter.csproj", "Src/Template.Adapter/"]
COPY ["Src/Template.Domain/Template.Domain.csproj", "Src/Template.Domain/"]
COPY ["Src/Template.Application/Template.Application.csproj", "Src/Template.Application/"]
COPY ["Src/Template.EntityFramework/Template.EntityFramework.csproj", "Src/Template.EntityFramework/"]
COPY ["Src/Template.Infrastructure/Template.Infrastructure.csproj", "Src/Template.Infrastructure/"]
RUN dotnet restore "./Src/Template.Api/Template.Api.csproj"
COPY . .
WORKDIR "/src/Src/Template.Api"
RUN dotnet build "./Template.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 此阶段用于发布要复制到最终阶段的服务项目
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Template.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 此阶段在生产中使用，或在常规模式下从 VS 运行时使用(在不使用调试配置时为默认值)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Api.dll"]