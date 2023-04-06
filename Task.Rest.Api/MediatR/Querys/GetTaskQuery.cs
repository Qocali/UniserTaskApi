using Domain.Domain.Entities;
using MediatR;

namespace Task.Rest.Api.MediatR.Querys
{
    public class GetTaskQuery:IRequest<Tasks>
    {
        public readonly int id;
        public GetTaskQuery(int id)
        {
            this.id = id;
        }

    }
}
