using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntelliStocks.Models
{
    [Table("IntelliStocks_Fornecedor")]
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [ForeignKey("EnderecoId")]
        public int EnderecoId { get; set; }

        [MaxLength(11, ErrorMessage = "O telefone deve conter no máximo 11 caracteres.")]
        public string Telefone { get; set; }
    }
}
