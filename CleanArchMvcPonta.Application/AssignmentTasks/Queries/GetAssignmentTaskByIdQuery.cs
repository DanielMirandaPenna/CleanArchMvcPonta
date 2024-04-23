using CleanArchMvcPonta.Domain.Entities;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Queries
{
    public class GetAssignmentTaskByIdQuery : IRequest<AssignmentTask>
    {
        public int Id { get; set; }

        public GetAssignmentTaskByIdQuery(int id)
        {
            Id = id;
        }
    }
}
