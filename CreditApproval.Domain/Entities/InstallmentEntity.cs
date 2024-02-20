using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Entities
{
    public class InstallmentEntity : BaseEntity
    {
        public int Id { get; set; }
        public int FinancingId { get; set; }
        public int InstallmentNumber { get; set; }
        public decimal InstallmentAmount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
