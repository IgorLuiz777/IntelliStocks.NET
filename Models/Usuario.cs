using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntelliStocks.Models
{
    [Table("IntelliStocks02_Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Column("Email", TypeName = "varchar(255)")]
        [EmailAddress]
        public string Email {  get; set; }

        [MaxLength(11, ErrorMessage = "O telefone deve conter no máximo 11 caracteres.")]
        public string Telefone { get; set; }

        [MaxLength(11, ErrorMessage = "O CNPJ deve conter no máximo 11 caracteres.")]
        public string CPF { get; set; }

        [MinLength(8, ErrorMessage = "A quantidade de caracteres minina é 8")]
        public string Senha { get; set; }
    }
}
