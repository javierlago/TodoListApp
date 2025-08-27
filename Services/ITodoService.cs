using TodoListApp.Models;


namespace TodoListApp.Services
{

    public interface ITodoService
    {

        Task<IReadOnlyList<TodoItem>> GetAllAsync();
        Task<TodoItem> AddAsync(string Title);
        Task ToggleDoneAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateTitleAsync(int id, string Title);
        

    }
}