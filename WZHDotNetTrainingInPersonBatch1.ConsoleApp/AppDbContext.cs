using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingInPersonBatch1.ConsoleApp
{
    public class AppDbContext : DbContext
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@@123",
            TrustServerCertificate =true,
        };   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog = DotNetTrainingBatch1; User ID =sa; Password = sa@@123; TrustServerCertificate = true ");
           optionsBuilder.UseSqlServer(sb.ConnectionString);
        }
        public DbSet<StudentDto> Students { get; set; }
    }
}
