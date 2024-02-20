using CreditApproval.Domain.Enums;

namespace CreditApproval.API.Models
{
    public class CreditModel
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public CreditType Tipo { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public string ValidacaoEntrada { get; set; }
    }
}
