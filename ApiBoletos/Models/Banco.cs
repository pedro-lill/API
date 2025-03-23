using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Models
{
    public class Banco
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do banco deve ter no máximo 100 caracteres.")]
        public string NomeBanco { get; set; }

        [Required(ErrorMessage = "O código do banco é obrigatório.")]
        public int CodigoBanco { get; set; }

        [Required(ErrorMessage = "O percentual de juros é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O percentual de juros deve estar entre 0 e 100.")]
        public decimal PercentualJuros { get; set; }
    }
}