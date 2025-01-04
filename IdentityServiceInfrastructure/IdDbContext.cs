﻿using IdentityServiceDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using InfrastructureCommons.EFCore;


namespace IdentityServiceInfrastructure
{
    public class IdDbContext :  IdentityDbContext<User, Role, Guid> 
    {
        public IdDbContext(DbContextOptions<IdDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            //modelBuilder.EnableSoftDeletionGlobalFilter();
        }
    }
}
