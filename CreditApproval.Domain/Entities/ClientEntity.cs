using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Domain.Entities
{
    public class ClientEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public string Cellphone { get; set; }
        public List<FinancingEntity> Financings { get; set; }
    }
}
