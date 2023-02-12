using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DataContext:DbContext
    {
        //Vous pouvez utiliser un DbContext associé
        //à un modèle pour : Écrire et exécuter des requêtes
        
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //POUR CREER LA TABLE Owner avec une valeur de Id default valeur 1
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            //initialisation de valeur


            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id=Guid.NewGuid(),
                    Avatar="avatar.PNG",
                    FullName="taibi zouhir",
                    Profil=".net Developer"
                }
                );


        }
        //creation des tables
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

    }
}
