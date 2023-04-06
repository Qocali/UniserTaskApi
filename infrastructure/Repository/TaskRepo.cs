using Application.Interface.Repository;
using Domain.Domain.Entities;
using infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace infrastructure.Repository
{
    public class TaskRepo : ITaskRepo
    {
        private readonly AppDbContext _Db;
        public TaskRepo(AppDbContext Db)
        {
            _Db= Db;
        }
        public void Create(Tasks entity)
        {
            _Db.Tasks.Add(entity);
        }

        public void Delete(int? id)
        {
            var task = _Db.Tasks.FirstOrDefault(x => x.TaskNumberId == id);
            _Db.Tasks.Remove(task); ;
        }

        public async void Edit(int? Id)
        {
            var task = _Db.Tasks.FirstOrDefault(x => x.TaskNumberId == Id);
            task.TaskNumberId = (int)Id;
            _Db.Tasks.Remove(task);
 }

        public async Task<Tasks> Get(int? id)
        {
           var task= _Db.Tasks.FirstOrDefault(x=>x.TaskNumberId==id);
            return task;
        }

        public void Savachange()
        {
            _Db.SaveChanges();
        }
    }
}
