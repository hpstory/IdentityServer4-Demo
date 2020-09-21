# IdentityServer4-Demo

参考杨旭老师视频https://www.bilibili.com/video/BV16b411k7yM

修改为.net core 3.1版本, angular为9.1.9版本

已完结，不包括第三方登陆和单点登陆内容

根据官方文档，额外增加efcore和asp.net core identity的简单配置

数据库使用mysql,需要安装dotnet add package Pomelo.EntityFrameworkCore.MySql

1.分别在AspDotNetCoreApi和IdInMemory项目下的appsettings.json中配置连接字符串

2.安装Microsoft.EntityFrameworkCore.Tools,执行迁移命令（powershell或着包管理器控制台均可,自行选择）
  a. IdInMemory
    powershell：
      dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
      dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
    package console:
      add-migration InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb 
      add-migration InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
      update-database -c PersistedGrantDbContext
      update-database -c ConfigurationDbContext
  b. AspDotNetCoreApi
    powershell:
      dotnet ef migrations add AppDbMigration -c IdentityServerDbContext -o Data
    package console:
      add-migration AppDbMigration -c IdentityServerDbContext -o Data
      update-database -c IdentityServerDbContext
