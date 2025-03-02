﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigurationProvider
{

    // 定义一个密封类 EntityConfigurationContext，继承自 DbContext
    // 使用 C# 12.0 的记录类语法，接收一个可空的连接字符串参数
    public sealed class EntityConfigurationContext(string? connectionString) : DbContext
    {
        public DbSet<Config> Settings => Set<Config>();

        public EntityConfigurationContext(DbContextOptions<EntityConfigurationContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Config>().HasKey(e => e.Key);
            modelBuilder.Entity<Config>().Property(e => e.Value).IsRequired(false);
        }
    }
}
