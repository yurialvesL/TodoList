using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.DTOs.Request;
using TodoList.Application.DTOs.Result;
using TodoList.Domain.Entities;

namespace TodoList.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Tasks, TasksResultDTO>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.EditedAt, opt => opt.MapFrom(src => src.EditedAt))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => src.Completed)).ReverseMap();

        CreateMap<Tasks,TaskRequestDTO>().ReverseMap();

        CreateMap<TaskRequestDTO, TasksResultDTO>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => src.Completed)).ReverseMap() ; 
    }
}
 