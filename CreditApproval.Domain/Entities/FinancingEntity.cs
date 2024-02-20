using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Entities
{
    public class FinancingEntity: BaseEntity
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string FinancingType { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime LastDueDate { get; set; }
        public List<InstallmentEntity> Installments { get; set; }
    }
}
