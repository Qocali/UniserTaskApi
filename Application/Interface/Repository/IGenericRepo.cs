using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repository
{
    public interface IGenericRepo<T>
    {
        public Task<T> Get(int? id);
        public void CreateAsync(T entity);
        public void Edit(int? Id);
        public void Delete(int? id);
    }
}
