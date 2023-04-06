using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Service
{
    public interface IGenericService<T>
    {
        public Task<T> Get(int? id);
        public void Create(T entity);
        public void Edit(int? Id, T entity);
        public void Delete(int? id);
       
    }
}
