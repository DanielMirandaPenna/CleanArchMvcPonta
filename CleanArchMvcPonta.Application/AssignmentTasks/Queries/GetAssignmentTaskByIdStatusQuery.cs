using CleanArchMvcPonta.Domain.Entities;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Queries
{

    public class GetAssignmentTaskByIdStatusQuery : IRequest<IEnumerable<AssignmentTask>>
    {
        public int IdStatus { get; set; }

        public GetAssignmentTaskByIdStatusQuery(int idStatus)
        {
            IdStatus = idStatus;
        }
    }
}
