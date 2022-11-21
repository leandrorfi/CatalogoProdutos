using System.Collections.Generic;

namespace CatalogoProdutos.Dominio.Repositorio
{
 public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetTodos();
    }
}

