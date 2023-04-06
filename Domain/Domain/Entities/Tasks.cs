using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Entities
{
    public class Tasks
    {
        [Key]
        public int TaskNumberId { get; set; }
        public string TaskName { get; set; }
        public string Work { get; set; }
        public int SubjectId { get; set; }
        public string FeatureName { get; set; }
        public DateTime Deadline { get; set; }
        public List<DrugList> Druglist { get; set; }
        public List<Instruments> Instruments { get; set; }
    }
}
