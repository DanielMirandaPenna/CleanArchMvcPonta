using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Enums;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Commands
{
    public abstract class AssignmentTaskCommand : IRequest<AssignmentTask>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Status Status { get; set; }
    }
}
