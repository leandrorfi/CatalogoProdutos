using System.Collections.Generic;

namespace CatalogoProdutos.Web.Repositorio
{
 public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetTodos();
    }
}

