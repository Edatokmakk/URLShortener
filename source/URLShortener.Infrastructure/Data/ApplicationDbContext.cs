
using URLShortener.Core;
using URLShortener.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using URLShortener.Application.Interfaces;

namespace URLShortener.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Redirection> Redirections { get; set; }        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {         
        }      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Redirection>().HasIndex(b => b.Slug).IsUnique();
            base.OnModelCreating(builder);
        }      
    }
}
