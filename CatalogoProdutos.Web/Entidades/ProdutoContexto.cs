using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProdutos.Web.Entidades
{
    public class ProdutoContexto : DbContext
    {
        public ProdutoContexto()
            : base("name=ConexaoProdutos")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProdutoContexto>(new CreateDatabaseIfNotExists<ProdutoContexto>());
        }

        public DbSet<Produto> Produtos { get; set; }

    }
}