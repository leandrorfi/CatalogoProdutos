using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Dominio.Entidades
{
    [Table("Produtos")]
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required(ErrorMessage ="Informe o número do SKU do produto")]
        public int SKU { get; set; }
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public string ImagemTipo { get; set; }
    }
}
