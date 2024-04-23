using AutoMapper;
using CleanArchMvcPonta.Application.DTOs;
using CleanArchMvcPonta.Domain.Entities;

namespace CleanArchMvcPonta.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<AssignmentTask, AssignmentTaskDTO>().ReverseMap()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
