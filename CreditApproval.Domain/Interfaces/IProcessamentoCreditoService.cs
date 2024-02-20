using CreditApproval.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Interfaces
{
    public interface IProcessamentoCreditoService
    {
        Task<ResultadoProcessamentoDto> ProcessarCredito(CreditoDto credito);
    }
}
