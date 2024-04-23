using CleanArchMvcPonta.Application.DTOs;

namespace CleanArchMvcPonta.Application.UseCases.Interfaces
{
    public interface IAssignmentTaskUseCase
    {
        Task<IEnumerable<AssignmentTaskDTO>> GetAssignmentTasks();
        Task<IEnumerable<AssignmentTaskDTO>> GetByIdUser(string userID);
        Task<IEnumerable<AssignmentTaskDTO>> GetByStatus(int? idStatus);
        Task<AssignmentTaskDTO> GetById(int? id);
        Task<AssignmentTaskDTO> Add(AssignmentTaskDTO assignmentTask);
        Task Update(AssignmentTaskDTO assignmentTask);
        Task Remove(int? id);
    }
}
