using Application.Dtos.Tasks;
using Application.Interface.Service;
using AutoMapper;
using Domain.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Rest.Api.Filters;
using Task.Rest.Api.MediatR.Commands;
using Task.Rest.Api.MediatR.Querys;
using static Domain.Domain.Enums.SelectionEnums;

namespace Task.Rest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMediator mediator, IMapper mapper)
        {
            _taskService = taskService;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("id")]
        [ServiceFilter(typeof(ActioFilter))]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = _mediator.Send(new GetTaskQuery(id));
            throw new Exception("Resolve Error");
            return Ok(_mapper.Map<GetTaskDto>(task));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(CreatenewTaskDto task)
        {
            var data = _mapper.Map<Tasks>(task);
            var data2 = _mapper.Map<DrugList>(task);
            var data3 = _mapper.Map<Instruments>(task);
            _mediator.Send(new CreatetaskCommand { Deadline=task.Deadline,Work=task.Work});
            var taskread = _mapper.Map<GetTaskDto>(data);
            return Accepted(taskread);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateTaskAsync(int? id, CreatenewTaskDto task)
        {
            var data = _mapper.Map<Tasks>(task);
            _taskService.Edit(id, data);
            var taskread = _mapper.Map<GetTaskDto>(data);
            return CreatedAtRoute(nameof(GetTask), new { id = taskread.TaskNumberId }, taskread);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            _taskService.Delete(id);
            return Ok();
        }

      
    }
}
