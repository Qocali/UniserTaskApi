using Domain.Domain.Entities;
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
        public string FeatureName { get; set; }
        public DateTime Deadline { get; set; }
    }
}
