using CreditApproval.Domain.Dto;
using CreditApproval.Domain.Entities;
using CreditApproval.Domain.Enums;
using CreditApproval.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Service.Services
{
    public class ProcessamentoCreditoService: IProcessamentoCreditoService
    {
        public async Task<ResultadoProcessamentoDto> ProcessarCredito(CreditoDto credito)
        {
            // Realizar validações
            var (valido, mensagem) = ValidarCredito(credito);

            if (!valido)
                return new ResultadoProcessamentoDto { Status = "Recusado", Mensagem = mensagem };

            // Calcular juros
            decimal taxaJuros = ObterTaxaJuros(credito.Tipo);
            decimal valorJuros = credito.Valor * (taxaJuros / 100);
            decimal valorTotalComJuros = credito.Valor + valorJuros;

            return new ResultadoProcessamentoDto
            {
                Status = "Aprovado",
                ValorTotalComJuros = valorTotalComJuros,
                ValorJuros = valorJuros
            };
        }

        private (bool, string) ValidarCredito(CreditoDto credito)
        {
            // Realizar validações de acordo com as regras de negócio
            if (credito.Valor > 1000000)
                return (false, "O valor máximo permitido para o crédito é de R$ 1.000.000,00.");

            if (credito.QuantidadeParcelas < 5 || credito.QuantidadeParcelas > 72)
                return (false, "A quantidade de parcelas deve estar entre 5 e 72.");

            if (credito.Tipo == TipoCredito.CreditoPessoaJuridica && credito.Valor < 15000)
                return (false, "Para o crédito Pessoa Jurídica, o valor mínimo é de R$ 15.000,00.");

            DateTime dataMinimaVencimento = DateTime.Today.AddDays(15);
            DateTime dataMaximaVencimento = DateTime.Today.AddDays(40);

            if (credito.DataPrimeiroVencimento < dataMinimaVencimento || credito.DataPrimeiroVencimento > dataMaximaVencimento)
                return (false, $"A data do primeiro vencimento deve estar entre {dataMinimaVencimento.ToShortDateString()} e {dataMaximaVencimento.ToShortDateString()}.");

            return (true, "Crédito validado com sucesso.");
        }

        private decimal ObterTaxaJuros(TipoCredito tipo)
        {
            switch (tipo)
            {
                case TipoCredito.CreditoDireto:
                    return 2;
                case TipoCredito.CreditoConsignado:
                    return 1;
                case TipoCredito.CreditoPessoaJuridica:
                    return 5;
                case TipoCredito.CreditoPessoaFisica:
                    return 3;
                case TipoCredito.CreditoImobiliario:
                    return 9;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo de crédito inválido.");
            }
        }  
    }
}
