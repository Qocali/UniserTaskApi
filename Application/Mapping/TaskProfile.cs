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
            CreateMap<CreatenewTaskDto,Tasks > ().ForMember(dest => dest.TaskName, act => act.MapFrom(src => src.TaskName))
        .ForMember(dest => dest.Deadline, act => act.MapFrom(src => src.Deadline))
        .ForMember(dest => dest.Work, act => act.MapFrom(src => src.Work)) ;
            CreateMap<CreatenewTaskDto,DrugList>().ForMember(dest => dest.Infect, act => act.MapFrom(src => src.Infect))

       .ForMember(dest => dest.DrugName, act => act.MapFrom(src => src.DrugName))
       .ForMember(dest => dest.Usedvolumefor1l, act => act.MapFrom(src => src.Usedvolumefor1l)).
          ForMember(dest => dest.TaskId, act => act.MapFrom(src => src.id));
            CreateMap<CreatenewTaskDto, Instruments>().ForMember(dest => dest.FeatureName, act => act.MapFrom(src => src.FeatureName)).
                ForMember(dest => dest.TaskId, act => act.MapFrom(src => src.id));
            CreateMap<Tasks, GetTaskDto>().ForMember(dest => dest.TaskName, act => act.MapFrom(src => src.TaskName))

         .ForMember(dest => dest.Deadline, act => act.MapFrom(src => src.Deadline))
         .ForMember(dest => dest.TaskNumberId, act => act.MapFrom(src => src.TaskNumberId));
        }
    }
}
