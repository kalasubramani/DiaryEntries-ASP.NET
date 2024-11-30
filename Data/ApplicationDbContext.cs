using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
            
        }
        //Steps to add a table to DB
        //1. Create a model class
        //2. Add DB Set
        //3. add-migration AddDiaryEntryTable -> an instruction on how to modify the DB
        //4. update-database

        //create a table in DB with name Diary entry and creates columns relative to the properties in model class
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        //To seed database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //checks if there is data. Adds seed data to entity
            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { Id = 1, Title = "Went Hiking", Content = "Went hiking with my dog!", Created = DateTime.Now },
                new DiaryEntry { Id = 2, Title = "Went Shopping", Content = "Went shopping with my friend Joe!", Created = DateTime.Now },
                new DiaryEntry { Id = 3, Title = "Went Diving", Content = "Went diving with my family!", Created = DateTime.Now }
                );

        }



        //to suppress 'Microsoft.EntityFrameworkCore.Migrations.PendingModelChangesWarning' 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));

        }

    }
}
