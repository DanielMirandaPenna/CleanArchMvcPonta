using CleanArchMvcPonta.Application.AssignmentTasks.Queries;
using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Interfaces;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Handlers
{
    public class GetAssignmentsTasksQueryHandler : IRequestHandler<GetAssignmentsTasksQuery, IEnumerable<AssignmentTask>>
    {
        private readonly IAssignmentTaskRepository _assignmentTaskRepository;

        public GetAssignmentsTasksQueryHandler(IAssignmentTaskRepository productRepository)
        {
            _assignmentTaskRepository = productRepository;
        }

        public async Task<IEnumerable<AssignmentTask>> Handle(GetAssignmentsTasksQuery request, CancellationToken cancellationToken)
        {
            return await _assignmentTaskRepository.GetAssignmentTasks();
        }
    }
}
