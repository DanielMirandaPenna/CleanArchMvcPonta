using CleanArchMvcPonta.Domain.Entities;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Commands
{
    public class AssignmentTaskRemoveCommand : IRequest<AssignmentTask>
    {
        public int Id { get; set; }
        public AssignmentTaskRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
