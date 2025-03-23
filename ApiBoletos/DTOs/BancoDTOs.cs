using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.DTOs
{
    public class BancoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do banco deve ter no máximo 100 caracteres.")]
        public string NomeBanco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O código do banco é obrigatório.")]
        public int CodigoBanco { get; set; }

        [Required(ErrorMessage = "O percentual de juros é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O percentual de juros deve estar entre 0 e 100.")]
        public decimal PercentualJuros { get; set; }
    }
}