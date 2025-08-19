using TodoListApp.Models;


namespace TodoListApp.Services
{

    public interface ITodoService
    {

        Task<IReadOnlyList<TodoItem>> GetAllAsyn();
        Task<TodoItem> AddAsync(string Title);


    }
}