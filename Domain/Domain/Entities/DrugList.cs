using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Entities
{
    public class DrugList
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public string Infect { get; set; }
        public Decimal Usedvolumefor1l { get; set; }
        public Tasks Task { get; set; }
        public int TaskId { get; set; }
    }
}
