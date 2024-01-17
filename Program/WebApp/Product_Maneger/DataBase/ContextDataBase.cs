using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Product_Maneger.Models;

namespace Product_Maneger.DataBase
{
    public class ContextDataBase : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        private readonly string _sourceDB;
        public ContextDataBase(string sourceDB)
        {
            _sourceDB = sourceDB;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=Product_Maneger_DB.db");
            optionsBuilder.UseSqlite($"Data Source={_sourceDB}");
        }
    }
}
