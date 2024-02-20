using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Dto
{
    public class ResultadoProcessamentoDto
    {
        public string Status { get; set; }
        public decimal ValorTotalComJuros { get; set; }
        public decimal ValorJuros { get; set; }
        public string Mensagem { get; set; }
    }
}
