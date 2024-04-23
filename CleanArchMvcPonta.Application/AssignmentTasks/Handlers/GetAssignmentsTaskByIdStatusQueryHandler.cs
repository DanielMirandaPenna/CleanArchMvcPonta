using CleanArchMvcPonta.Application.AssignmentTasks.Queries;
using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Interfaces;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Handlers
{
    public class GetAssignmentsTaskByIdStatusQueryHandler : IRequestHandler<GetAssignmentTaskByIdStatusQuery, IEnumerable<AssignmentTask>>
    {
        private readonly IAssignmentTaskRepository _assignmentTaskRepository;

        public GetAssignmentsTaskByIdStatusQueryHandler(IAssignmentTaskRepository productRepository)
        {
            _assignmentTaskRepository = productRepository;
        }
        public async Task<IEnumerable<AssignmentTask>> Handle(GetAssignmentTaskByIdStatusQuery request, CancellationToken cancellationToken)
        {
            return await _assignmentTaskRepository.GetByStatus(request.IdStatus);
        }
    }
}
