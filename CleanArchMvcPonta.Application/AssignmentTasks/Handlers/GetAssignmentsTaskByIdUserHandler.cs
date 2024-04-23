using CleanArchMvcPonta.Application.AssignmentTasks.Queries;
using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Interfaces;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Handlers
{
    public class GetAssignmentsTaskByIdUserHandler : IRequestHandler<GetAssignmentTaskByIdUserQuery, IEnumerable<AssignmentTask>>
    {
        private readonly IAssignmentTaskRepository _assignmentTaskRepository;

        public GetAssignmentsTaskByIdUserHandler(IAssignmentTaskRepository productRepository)
        {
            _assignmentTaskRepository = productRepository;
        }

        public async Task<IEnumerable<AssignmentTask>> Handle(GetAssignmentTaskByIdUserQuery request, CancellationToken cancellationToken)
        {
            return await _assignmentTaskRepository.GetByUserId(request.CreatedBy);
        }
    }
}
