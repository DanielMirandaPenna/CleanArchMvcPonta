using CleanArchMvcPonta.Domain.Enums;

namespace CleanArchMvcPonta.Application.AssignmentTasks.Commands
{
    public class AssignmentTaskUpdateCommand : AssignmentTaskCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
