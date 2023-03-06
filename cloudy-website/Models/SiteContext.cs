using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Cloudy.CMS.EntitySupport.Serialization;
using Microsoft.EntityFrameworkCore;

namespace cloudy_website.Models
{
    public class SiteContext : DbContext
    {

        private readonly IConfiguration configuration;

        public SiteContext(DbContextOptions<SiteContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer(configuration["CosmosContainer"] ?? throw new Exception("CosmosContainer needed"));

            modelBuilder.Entity<Page>().HasPartitionKey(o => o.Id);
            modelBuilder.Entity<Page>().Property(p => p.Teaser1).JsonBlockConversion();
            modelBuilder.Entity<Page>().Property(p => p.Teaser2).JsonBlockConversion();
            modelBuilder.Entity<Page>().Property(p => p.Teaser3).JsonBlockConversion();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Page> Pages { get; set; }

    }
}

