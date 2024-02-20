using CreditApproval.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Entities
{
    public class Credit : BaseEntity
    {    
        public decimal Valor { get; set; }
        public CreditType Tipo { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public string ValidacaoEntrada { get; set; }
    }
}
