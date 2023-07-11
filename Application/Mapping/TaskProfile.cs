using Application.Dtos.Tasks;
using AutoMapper;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Mapping
{
    public class TaskProfile:Profile
    {
        public TaskProfile()
        {
            CreateMap<CreatenewTaskDto, Tasks>();
            CreateMap<Tasks, GetTaskDto>();
        }
    }
}
