using CreditApproval.Domain.Dto;
using CreditApproval.Domain.Entities;
using CreditApproval.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Service.Validators
{
    public class CreditValidator : AbstractValidator<CreditoDto>
    {
        public CreditValidator()
        {
            RuleFor(credito => credito.Valor).LessThanOrEqualTo(1000000).WithMessage("O valor máximo permitido para o crédito é de R$ 1.000.000,00.");

            RuleFor(credito => credito.QuantidadeParcelas).InclusiveBetween(5, 72).WithMessage("A quantidade de parcelas deve estar entre 5 e 72.");

            RuleFor(credito => credito.Tipo).NotEmpty().WithMessage("O tipo de crédito não pode estar vazio.");

            RuleFor(credito => credito.DataPrimeiroVencimento)
                .GreaterThanOrEqualTo(DateTime.Today.AddDays(15))
                .LessThanOrEqualTo(DateTime.Today.AddDays(40))
                .WithMessage("A data do primeiro vencimento deve estar entre 15 e 40 dias a partir da data atual.");
        }
    }
}
