using Application.Dtos.Tasks;
using Application.Interface.Service;
using AutoMapper;
using Domain.Domain.Entities;
using MediatR;
using Task.Rest.Api.MediatR.Querys;

namespace Task.Rest.Api.MediatR.Handlers
{
    public class GetTaskHandler : IRequestHandler<GetTaskQuery,Tasks>
    {
        private readonly ITaskService _taskService;
       
        public GetTaskHandler(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
          
        }

        public async Task<Tasks> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskService.Get(request.id);
            return task;
        }

        
    }
}
