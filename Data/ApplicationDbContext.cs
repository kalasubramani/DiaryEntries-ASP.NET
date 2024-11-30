using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
