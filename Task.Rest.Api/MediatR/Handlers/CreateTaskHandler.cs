using Application.Interface.Service;
using AutoMapper;
using Domain.Domain.Entities;
using MediatR;
using Task.Rest.Api.MediatR.Commands;

namespace Task.Rest.Api.MediatR.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreatetaskCommand, Tasks>
    {
        private readonly ITaskService _taskService;

        public CreateTaskHandler(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;

        }
        public async Task<Tasks> Handle(CreatetaskCommand request, CancellationToken cancellationToken)
        {
            Tasks task=new Tasks() { Deadline = request.Deadline, Work = request.Work };
           _taskService.Create(task);
            return task;
            
        }

      
    }
}
