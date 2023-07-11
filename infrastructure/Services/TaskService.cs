using Application.Interface.Repository;
using Application.Interface.Service;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _taskRepo;
        public TaskService(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }
        async public void Create(Tasks entity)
        {
            _taskRepo.CreateAsync(entity);
        }

        public void Delete(int? id)
        {
           _taskRepo.Delete(id);
        }

        public void Edit(int? Id, Tasks entity)
        {
          _taskRepo.Edit(Id);
            _taskRepo.CreateAsync(entity);
        }

        public async Task<Tasks> Get(int? id)
        {
           var task=await _taskRepo.Get(id);
            return task;
        }

       
    }
}
