using Domain.Domain.Entities;
using MediatR;
using System.Windows.Input;

namespace Task.Rest.Api.MediatR.Commands
{
    public class CreatetaskCommand:IRequest<Tasks>
    {
        public int TaskNumberId { get; set; }
        public string TaskName { get; set; }
        public string Work { get; set; }
        public string FeatureName { get; set; }
        public DateTime Deadline { get; set; }
    }
}
