using AutoMapper;
using CleanArchMvcPonta.Application.AssignmentTasks.Commands;
using CleanArchMvcPonta.Application.AssignmentTasks.Queries;
using CleanArchMvcPonta.Application.DTOs;
using CleanArchMvcPonta.Application.UseCases.Interfaces;
using MediatR;

namespace CleanArchMvcPonta.Application.UseCases
{
    public class AssignmentTaskUseCase : IAssignmentTaskUseCase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AssignmentTaskUseCase(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<AssignmentTaskDTO> GetById(int? id)
        {
            var assignmentTaskByIdQuery = new GetAssignmentTaskByIdQuery(id.Value);

            if (assignmentTaskByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(assignmentTaskByIdQuery);

            return _mapper.Map<AssignmentTaskDTO>(result);
        }

        public async Task<IEnumerable<AssignmentTaskDTO>> GetByIdUser(string userID)
        {
            var getAssignmentTaskByIdUserQuery = new GetAssignmentTaskByIdUserQuery(userID);

            if (getAssignmentTaskByIdUserQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(getAssignmentTaskByIdUserQuery);

            return _mapper.Map<IEnumerable<AssignmentTaskDTO>>(result);
        }

        public async Task<IEnumerable<AssignmentTaskDTO>> GetByStatus(int? idStatus)
        {
            var getAssignmentTaskByIdStatusQuery = new GetAssignmentTaskByIdStatusQuery(idStatus.Value);

            if (getAssignmentTaskByIdStatusQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(getAssignmentTaskByIdStatusQuery);

            return _mapper.Map<IEnumerable<AssignmentTaskDTO>>(result);
        }

        public async Task<IEnumerable<AssignmentTaskDTO>> GetAssignmentTasks()
        {
            var getAssignmentsTasksQuery = new GetAssignmentsTasksQuery();

            if (getAssignmentsTasksQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(getAssignmentsTasksQuery);

            return _mapper.Map<IEnumerable<AssignmentTaskDTO>>(result);
        }
        public async Task<AssignmentTaskDTO> Add(AssignmentTaskDTO assignmentTask)
        {
            var assignmentTaskCommand = _mapper.Map<AssignmentTaskCreateCommand>(assignmentTask);
            var result = await _mediator.Send(assignmentTaskCommand);
            return _mapper.Map<AssignmentTaskDTO>(result);
        }

        public async Task Update(AssignmentTaskDTO assignmentTask)
        {
            var assignmentTaskUpdateCommand = _mapper.Map<AssignmentTaskUpdateCommand>(assignmentTask);
            await _mediator.Send(assignmentTaskUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var assignmentTaskRemoveCommand = new AssignmentTaskRemoveCommand(id.Value);

            if (assignmentTaskRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(assignmentTaskRemoveCommand);
        }

    }
}
