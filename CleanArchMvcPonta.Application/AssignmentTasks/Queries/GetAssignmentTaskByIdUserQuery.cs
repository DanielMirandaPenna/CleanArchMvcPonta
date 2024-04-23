using CleanArchMvcPonta.Domain.Entities;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Queries
{
    public class GetAssignmentTaskByIdUserQuery : IRequest<IEnumerable<AssignmentTask>>
    {
        public string CreatedBy { get; set; }
        public GetAssignmentTaskByIdUserQuery(string userId)
        {
            CreatedBy = userId;
        }
    }
}
