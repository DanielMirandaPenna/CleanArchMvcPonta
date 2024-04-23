using CleanArchMvcPonta.Domain.Entities;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Queries
{
    public class GetAssignmentsTasksQuery : IRequest<IEnumerable<AssignmentTask>>
    {
    }
}
