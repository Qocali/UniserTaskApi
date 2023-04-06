using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Tasks
{
    public class GetTaskDto
    {
        public int TaskNumberId { get; set; }
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
    }
}
