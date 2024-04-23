using CleanArchMvcPonta.Application.AssignmentTasks.Commands;
using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Interfaces;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Handlers
{
    public class AssignmentTaskRemoveCommandHandler : IRequestHandler<AssignmentTaskRemoveCommand, AssignmentTask>
    {
        private readonly IAssignmentTaskRepository _assignmentTaskRepository;
        public AssignmentTaskRemoveCommandHandler(IAssignmentTaskRepository assignmentTaskRepository)
        {
            _assignmentTaskRepository = assignmentTaskRepository;
        }

        public async Task<AssignmentTask> Handle(AssignmentTaskRemoveCommand request, CancellationToken cancellationToken)
        {
            var assignmentTask = await _assignmentTaskRepository.GetById(request.Id);

            if (assignmentTask != null)
                return await _assignmentTaskRepository.RemoveAsync(assignmentTask);
            else
            {
                throw new ApplicationException($"Entity could not be found.");
            }
        }
    }
}
