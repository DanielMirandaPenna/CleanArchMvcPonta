using AutoMapper;
using CleanArchMvcPonta.Application.AssignmentTasks.Commands;
using CleanArchMvcPonta.Application.DTOs;

namespace CleanArchMvcPonta.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<AssignmentTaskDTO, AssignmentTaskCreateCommand>();
            CreateMap<AssignmentTaskDTO, AssignmentTaskUpdateCommand>();
        }
    }
}
