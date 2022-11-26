using CatalogoProdutos.Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProdutos.Web.Repositorio
{
    public class ProdutoRepositorio : IRepositorio<Produto>
    {
        private ProdutoContexto contexto;

        public ProdutoRepositorio(ProdutoContexto produtoContexto)
        {
            this.contexto = produtoContexto;
        }
        public IEnumerable<Produto> GetTodos()
        {
            return contexto.Produtos.ToList();
        }
    }
}
