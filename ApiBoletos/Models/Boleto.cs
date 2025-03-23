using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Models
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do Ppagador é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do pagador deve ter no máximo 100 caracteres.")]
        public string NomePagador { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF/CNPJ do pagador é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CPF/CNPJ do pagador deve ter no máximo 14 caracteres.")]
        public string CpfCnpjPagador { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do beneficiário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do beneficiário deve ter no máximo 100 caracteres.")]
        public string NomeBeneficiario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF/CNPJ do beneficiário é obrigatório.")]
        [StringLength(14, ErrorMessage = "O CPF/CNPJ do beneficiário deve ter no máximo 14 caracteres.")]
        public string CpfCnpjBeneficiario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor do boleto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do boleto deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data de vencimento do boleto é obrigatórioa.")]
        public DateTime DataVencimento { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O Id do banco é obrigatório.")]
        public int BancoId { get; set; }

        public Banco? Banco { get; set; }
    }
}