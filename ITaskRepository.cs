public interface ITaskRepository
{
    List<TaskItem> GetAll();
    void Add(TaskItem task);
    List<TaskItem> GetIncomplete();
}