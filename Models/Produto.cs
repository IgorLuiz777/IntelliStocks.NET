using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntelliStocks.Models
{
    [Table("IntelliStocks_Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preco é obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca é obrigatório.")]
        public string Marca { get; set; }

        [ForeignKey("CategoriaId")]
        public int Categoria { get; set; }

        [ForeignKey("FornecedorId")]
        public int Fornecedor { get; set; }
    }
}
