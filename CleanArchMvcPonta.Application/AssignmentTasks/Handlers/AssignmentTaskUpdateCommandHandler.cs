using CleanArchMvcPonta.Application.AssignmentTasks.Commands;
using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Interfaces;
using CleanArchMvcPonta.Domain.Validation;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Handlers
{
    public class AssignmentTaskUpdateCommandHandler : IRequestHandler<AssignmentTaskUpdateCommand, AssignmentTask>
    {
        private readonly IAssignmentTaskRepository _assignmentTaskRepository;
        public AssignmentTaskUpdateCommandHandler(IAssignmentTaskRepository assignmentTaskRepository)
        {
            _assignmentTaskRepository = assignmentTaskRepository;
        }

        public async Task<AssignmentTask> Handle(AssignmentTaskUpdateCommand request, CancellationToken cancellationToken)
        {
            var assignmentTask = await _assignmentTaskRepository.GetById(request.Id);

            if (assignmentTask.CreatedBy != request.CreatedBy)
                throw new DomainExceptionValidation("Only the owner can edit");
            if (assignmentTask == null)
                throw new ApplicationException($"Entity could not be found.");

            assignmentTask.Update(request.Id, request.Title, request.Description, request.Status);
            return await _assignmentTaskRepository.UpdateAsync(assignmentTask);

        }
    }
}
