﻿using CityInfo_Core3_1_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo_Database_Core3_1.Context
{
    public class CityInfoContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<CityLanguage> CityLanguages { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options,
                               IConfiguration config)
           : base(options)
        {
            //  Database.EnsureCreated();
            this._configuration = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityLanguage>()
                .HasKey(cl => new
                {
                     cl.CityId,
                     cl.LanguageId
                });

            modelBuilder.Entity<City>()
                 .HasData(
                new City()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park."
                },
                new City()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished."
                },
                new City()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower."
                });


            modelBuilder.Entity<PointOfInterest>()
              .HasData(
                new PointOfInterest()
                {
                    Id = 1,
                    CityId = 1,
                    Name = "Central Park",
                    Description = "The most visited urban park in the United States."

                },
                new PointOfInterest()
                {
                    Id = 2,
                    CityId = 1,
                    Name = "Empire State Building",
                    Description = "A 102-story skyscraper located in Midtown Manhattan."
                },
                  new PointOfInterest()
                  {
                      Id = 3,
                      CityId = 2,
                      Name = "Cathedral",
                      Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                  },
                new PointOfInterest()
                {
                    Id = 4,
                    CityId = 2,
                    Name = "Antwerp Central Station",
                    Description = "The the finest example of railway architecture in Belgium."
                },
                new PointOfInterest()
                {
                    Id = 5,
                    CityId = 3,
                    Name = "Eiffel Tower",
                    Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                },
                new PointOfInterest()
                {
                    Id = 6,
                    CityId = 3,
                    Name = "The Louvre",
                    Description = "The world's largest museum."
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = this._configuration.GetConnectionString("cityInfoDBConnectionString");

#if USE_LAZY_LOADING
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
#endif
        }

    }
}
