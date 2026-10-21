

public class TaskRepository : ITaskRepository
{

    private List<TaskItem> _tasks = new();
    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public void Add(TaskItem task)
    {
        _tasks.Add(task);
    }

    public List<TaskItem> GetIncomplete()
    {
        return _tasks.Where(t => t.IsCompleted == false).ToList();
    
    }
}