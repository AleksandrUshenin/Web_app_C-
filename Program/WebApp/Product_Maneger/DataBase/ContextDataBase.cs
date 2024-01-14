using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Product_Maneger.Models;

namespace Product_Maneger.DataBase
{
    public class ContextDataBase : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=Product_Maneger_DB.db");
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\sasha\\GitProgect\\AllGitProgect\\Web_app_C-\\Program\\WebApp\\Product_Maneger\\bin\\Debug\\net7.0\\Product_Maneger_DB.db");
            //C:\Users\sasha\GitProgect\AllGitProgect\Web_app_C-\Program\WebApp\Product_Maneger\bin\Debug\net7.0\
        }
    }
}
