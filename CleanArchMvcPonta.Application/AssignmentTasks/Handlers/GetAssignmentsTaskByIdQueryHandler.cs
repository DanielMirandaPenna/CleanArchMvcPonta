using CleanArchMvcPonta.Application.AssignmentTasks.Queries;
using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Interfaces;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Handlers
{
    public class GetAssignmentsTaskByIdQueryHandler : IRequestHandler<GetAssignmentTaskByIdQuery, AssignmentTask>
    {
        private readonly IAssignmentTaskRepository _assignmentTaskRepository;

        public GetAssignmentsTaskByIdQueryHandler(IAssignmentTaskRepository productRepository)
        {
            _assignmentTaskRepository = productRepository;
        }

        public async Task<AssignmentTask> Handle(GetAssignmentTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _assignmentTaskRepository.GetById(request.Id);
        }
    }
}
