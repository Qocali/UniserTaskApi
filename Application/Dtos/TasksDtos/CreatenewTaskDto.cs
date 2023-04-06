using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Tasks
{
    public class CreatenewTaskDto
    {
        public int id { get; set; }
        public string TaskName { get; set; }
        public string Work { get; set; }
        public DateTime Deadline { get; set; }
        public string DrugName { get; set; }
        public string Infect { get; set; }
        public Decimal Usedvolumefor1l { get; set; }
        public string FeatureName { get; set; }
        public int SubjectId { get; set; }
    }
}
