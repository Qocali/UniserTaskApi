using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Entities
{
    public class Instruments
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public Tasks Task { get; set; }
        public int TaskId { get; set; }
    }
}
