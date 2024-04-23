using CleanArchMvcPonta.Domain.Entities;

namespace CleanArchMvcPonta.Domain.Interfaces
{
    public interface IAssignmentTaskRepository
    {
        Task<AssignmentTask> CreateAsync(AssignmentTask task);
        Task<AssignmentTask> UpdateAsync(AssignmentTask task);
        Task<AssignmentTask> RemoveAsync(AssignmentTask task);
        Task<AssignmentTask> GetById(int id);
        Task<IEnumerable<AssignmentTask>> GetByUserId(string userId);
        Task<IEnumerable<AssignmentTask>> GetByStatus(int status);
        Task<IEnumerable<AssignmentTask>> GetAssignmentTasks();
    }
}
