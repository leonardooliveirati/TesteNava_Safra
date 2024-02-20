using CreditApproval.Domain.Dto;
using CreditApproval.Domain.Enums;
using CreditApproval.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApprovalTeste
{
    public class ProcessamentoCreditoServiceTest
    {
        [Fact]
        public async Task ProcessarCredito_ValidarCredito_Sucesso()
        {
            // Arrange
            var service = new ProcessamentoCreditoService();
            var credito = new CreditoDto
            {
                Valor = 50000,
                QuantidadeParcelas = 12,
                Tipo = TipoCredito.CreditoPessoaFisica,
                DataPrimeiroVencimento = DateTime.Today.AddDays(20)
            };

            // Act
            var resultado = await service.ProcessarCredito(credito);

            // Assert
            Assert.Equal("Aprovado", resultado.Status);
            Assert.True(resultado.ValorTotalComJuros > credito.Valor);
            Assert.True(resultado.ValorJuros > 0);
        }

        [Fact]
        public async Task ProcessarCredito_ValidarCredito_Falha()
        {
            // Arrange
            var service = new ProcessamentoCreditoService();
            var credito = new CreditoDto
            {
                Valor = 2000000,
                QuantidadeParcelas = 3,
                Tipo = TipoCredito.CreditoPessoaJuridica,
                DataPrimeiroVencimento = DateTime.Today.AddDays(10)
            };

            // Act
            var resultado = await service.ProcessarCredito(credito);

            // Assert
            Assert.Equal("Recusado", resultado.Status);
        }
    }
}
