using MentoriaDevSTi3.Data.Entidades;
using MentoriaDevSTi3.Data.Mappings;
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
                .LogTo(x => Debug.WriteLine(x));

            base.OnConfiguring(optionsBuilder);
        }
        
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ItemPedido> ItensPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ItemPedidoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());


            base.OnModelCreating(modelBuilder);
        }
    }
}

