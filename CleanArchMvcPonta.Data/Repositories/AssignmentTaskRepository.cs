using CleanArchMvcPonta.Domain.Entities;
using CleanArchMvcPonta.Domain.Enums;
using CleanArchMvcPonta.Domain.Interfaces;
using CleanArchMvcPonta.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvcPonta.Infra.Data.Repositories
{
    public class AssignmentTaskRepository : IAssignmentTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignmentTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentTask> CreateAsync(AssignmentTask assignmentTask)
        {
            _context.Add(assignmentTask);
            await _context.SaveChangesAsync();
            return assignmentTask;
        }

        public async Task<IEnumerable<AssignmentTask>> GetAssignmentTasks()
        {
            return await _context.AssignmentTasks.ToListAsync();
        }

        public async Task<AssignmentTask> GetById(int id)
        {
            return await _context.AssignmentTasks.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<AssignmentTask>> GetByStatus(int status)
        {
            return await _context.AssignmentTasks.Where(p => p.Status == (Status)status).ToListAsync();
        }

        public async Task<IEnumerable<AssignmentTask>> GetByUserId(string userId)
        {
            return await _context.AssignmentTasks.Where(p => p.CreatedBy == userId).ToListAsync();
        }

        public async Task<AssignmentTask> RemoveAsync(AssignmentTask assignmentTask)
        {
            _context.Remove(assignmentTask);
            await _context.SaveChangesAsync();
            return assignmentTask;
        }

        public async Task<AssignmentTask> UpdateAsync(AssignmentTask assignmentTask)
        {
            _context.Update(assignmentTask);
            await _context.SaveChangesAsync();
            return assignmentTask;

        }
    }
}
