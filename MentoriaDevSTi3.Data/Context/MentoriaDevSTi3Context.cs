using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MentoriaDevSTi3.Data.Context
{
    public class MentoriaDevSTi3Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=mentoriadev;database=mentoria_dev;")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .LogTo(x => Debug.WriteLine(x))

            base.OnConfiguring(optionsBuilder);
        }
    }
}

