using apidemo2.Models;
using Microsoft.EntityFrameworkCore;

namespace apidemo2
{
    public class AplicationDbcontext: DbContext
    {
        public DbSet<productos> Producto { get; set; }


        public AplicationDbcontext()
        {

        }
        public AplicationDbcontext(DbContextOptions options):base(options)
        {

        }


        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=UTECDB2022;Uid=root;Pwd=Pa$$w0rd");
            }
            

        }

    }
}
