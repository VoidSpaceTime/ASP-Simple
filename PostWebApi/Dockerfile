# 请参阅 https://aka.ms/customizecontainer 以了解如何自定义调试容器，以及 Visual Studio 如何使用此 Dockerfile 生成映像以更快地进行调试。

# 此阶段用于在快速模式(默认为调试配置)下从 VS 运行时
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# 此阶段用于生成服务项目
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["PostWebApi/PostWebApi.csproj", "PostWebApi/"]
#COPY ["ASPNETCore/ASPNETCore.csproj", "ASPNETCore/"]
#COPY ["CommonsDomain/CommonsDomain.csproj", "CommonsDomain/"]
#COPY ["CommonsInitializer/CommonsInitializer.csproj", "CommonsInitializer/"]
#COPY ["DbConfigurationProvider/DbConfigurationProvider.csproj", "DbConfigurationProvider/"]
#COPY ["JWT/JWT.csproj", "JWT/"]
#COPY ["Commons/Commons.csproj", "Commons/"]
#COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
#COPY ["PostServiceDomain/PostServiceDomain.csproj", "PostServiceDomain/"]
#COPY ["PostServicInfrastructure/PostServicInfrastructure.csproj", "PostServicInfrastructure/"]
#RUN dotnet restore "./PostWebApi/PostWebApi.csproj"
COPY . .
#WORKDIR "/src/PostWebApi"
#RUN dotnet build "./PostWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 此阶段用于发布要复制到最终阶段的服务项目
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./PostWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 此阶段在生产中使用，或在常规模式下从 VS 运行时使用(在不使用调试配置时为默认值)
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENV TimeZone=Asia/Shanghai
# 使用软连接，并且将时区配置覆盖/etc/timezone
RUN ln -snf /usr/share/zoneinfo/$TimeZone /etc/localtime && echo $TimeZone > /etc/timezone
ENTRYPOINT ["dotnet", "PostWebApi.dll"]