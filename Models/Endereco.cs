using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntelliStocks.Models
{
    [Table("IntelliStocks_Endereco")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnderecoId {  get; set; }

        [Required(ErrorMessage = "A rua é obrigatória.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O numero é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Cidade { get; set; }

    }
}
