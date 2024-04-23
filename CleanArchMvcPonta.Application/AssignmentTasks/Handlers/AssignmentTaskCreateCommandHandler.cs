﻿using CleanArchMvcPonta.Application.AssignmentTasks.Commands;
using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Interfaces;
using MediatR;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Handlers
{
    public class AssignmentTaskCreateCommandHandler : IRequestHandler<AssignmentTaskCreateCommand, AssignmentTask>
    {
        private readonly IAssignmentTaskRepository _assignmentTaskRepository;
        public AssignmentTaskCreateCommandHandler(IAssignmentTaskRepository assignmentTaskRepository)
        {
            _assignmentTaskRepository = assignmentTaskRepository;
        }

        public async Task<AssignmentTask> Handle(AssignmentTaskCreateCommand request, CancellationToken cancellationToken)
        {
            var assignmentTask = new AssignmentTask(request.Title, request.Description, request.CreatedBy);

            if (assignmentTask != null)
                return await _assignmentTaskRepository.CreateAsync(assignmentTask);
            else
            {
                throw new ApplicationException($"Error creating entity.");
            }
        }
    }
}
