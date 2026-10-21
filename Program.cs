

string name = "Task Manager";
int version = 1;
List<TaskItem> tasks = new List<TaskItem>();


tasks.Add(new TaskItem{ Title = "Do Homework", IsCompleted = true, DueDate = DateTime.Now.AddDays(1) });
tasks.Add(new TaskItem{ Title = "Buy groceries", IsCompleted = false, DueDate = DateTime.Now.AddDays(2) });
tasks.Add(new TaskItem{ Title = "Walk the dog", IsCompleted = false, DueDate = DateTime.Now.AddDays(3) });
tasks.Add(new TaskItem{ Title = "Clean the house", IsCompleted = true });
tasks.Add(new TaskItem{ Title = "Pay bills", IsCompleted = false });

Console.WriteLine($"Welcome to {name} v{version}");

foreach (var task in tasks)
{
    Console.WriteLine($"Task: {task.Title}, is it completed? {task.IsCompleted}, due on: {task.DueDate?.ToString() ?? "No due date"}");
    
}

var incompleteTasks = tasks.Where(t => t.IsCompleted == false);
foreach (var task in incompleteTasks)
{
    Console.WriteLine($"Incomplete Task: {task.Title}, due on: {task.DueDate?.ToString() ?? "No due date"}");
}

    

var earliestTask = incompleteTasks.MinBy(t => t.DueDate);
if (earliestTask != null)
{
    Console.WriteLine($"Earliest due task: {earliestTask.Title}, due on: {earliestTask.DueDate?.ToString() ?? "No due date"}");
}



TaskItem task1 = new TaskItem
{
    Title = "Finish project report",
    IsCompleted = false,
    DueDate = DateTime.Now.AddDays(3)
};


Console.WriteLine($"Task: {task1.Title}, is it completed? {task1.IsCompleted}, due on: {task1.DueDate?.ToString() ?? "No due date"}");
TaskItem original = new TaskItem { Title = "Original Task", IsCompleted = false };
TaskItem copy = original;
copy.Title = "Modified Task";

Console.WriteLine(original.Title); 

async Task<List<TaskItem>> GetIncompleteTasksAsync(List<TaskItem> allTasks)
{
    await Task.Delay(500); // pretend this is a database call
    return allTasks.Where(t => t.IsCompleted == false).ToList();
}

var result = await GetIncompleteTasksAsync(tasks);
Console.WriteLine($"Found {result.Count} incomplete tasks");

/// Interface Instatiation
ITaskRepository repo = new TaskRepository();

repo.Add(new TaskItem{Title = "Dummy Task", IsCompleted = true});
repo.Add(new TaskItem{Title = "Another Dummy Task", IsCompleted = false, DueDate = DateTime.Now.AddDays(3)});

var allTasks = repo.GetAll();
var allIncompleteTasks = repo.GetIncomplete();

Console.WriteLine($"All total tasks: {allTasks.Count}");
Console.WriteLine($"Total imcomplete tasks: {allIncompleteTasks.Count}");