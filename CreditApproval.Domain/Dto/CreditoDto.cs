using CreditApproval.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Dto
{
    public class CreditoDto
    {
        public decimal Valor { get; set; }
        public TipoCredito Tipo { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
    }
}
