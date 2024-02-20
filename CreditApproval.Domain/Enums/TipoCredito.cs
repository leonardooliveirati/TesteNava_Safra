using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Enums
{
    public enum TipoCredito
    {
        CreditoDireto = 0,
        CreditoConsignado = 1,
        CreditoPessoaJuridica = 2,
        CreditoPessoaFisica = 3,
        CreditoImobiliario = 4
    }
}
