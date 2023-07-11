using Application.Interface.Repository;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Task.Domain.Domain.Entities;
using Dapper;
namespace infrastructure.Repository
{
    public class TaskRepo : ITaskRepo
    {
        private readonly IDbConnection _dbConnection;

        public TaskRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Tasks> Get(int? id)
        {
            string query = "SELECT * FROM Tasks WHERE TaskNumberId = @TaskNumberId";
            return await _dbConnection.QueryFirstOrDefaultAsync<Tasks>(query, new { TaskNumberId = id });
        }

        public void CreateAsync(Tasks entity)
        {
            string query = @"INSERT INTO Tasks (TaskName, Work, FeatureName, Deadline)
                         VALUES (@TaskName, @Work, @FeatureName, @Deadline)";
            _dbConnection.Execute(query, entity);
        }

        public void Edit(int? id)
        {
            // Implement edit logic
        }

        public void Delete(int? id)
        {
            string query = "DELETE FROM Tasks WHERE TaskNumberId = @TaskNumberId";
            _dbConnection.Execute(query, new { TaskNumberId = id });
        }


       
    }
}
