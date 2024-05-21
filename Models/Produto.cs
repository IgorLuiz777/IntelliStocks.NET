using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntelliStocks.Models
{
    [Table("IntelliStocks02_Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória.")]
        public string Marca { get; set; }

        [ForeignKey("CategoriaId")]
        public int Categoria { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        public int Quantidade { get; set; }
    }
}
