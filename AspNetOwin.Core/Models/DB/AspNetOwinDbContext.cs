namespace AspNetOwin.Core.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AspNetOwinDbContext : DbContext
    {
        // Your context has been configured to use a 'AspNetOwinDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AspNetOwin.Core.Models.DB.AspNetOwinDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AspNetOwinDbContext' 
        // connection string in the application configuration file.
        public AspNetOwinDbContext()
            : base("name=AspNetOwinDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Dado> Dados { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes");

            modelBuilder.Entity<Dado>()
                .ToTable("Dados");

            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

            // FK de Dado para Cliente
            modelBuilder.Entity<Cliente>()
                .HasOptional(x => x.Dado) // Dado opcional para Cliente
                .WithRequired(x => x.Cliente) // Cliente obrigatorio para Dado
                .WillCascadeOnDelete(); // Se Cliente deletado, deleta todos Dados associados

            // FK de Endereco para Cliente
            modelBuilder.Entity<Cliente>()
                .HasOptional(x => x.Endereco) // Endereco opcional para Cliente
                .WithRequired(x => x.Cliente) // Cliente obrigatorio para Endereco
                .WillCascadeOnDelete(); // Se Cliente deletado, deleta todos Enderecos associados
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}