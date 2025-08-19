using System.Collections.Concurrent;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public class TodoService : ITodoService
    {
        // Almacén en memoria (thread-safe)
        private readonly ConcurrentDictionary<int, TodoItem> _items = new();
        private int _nextId = 1;

        public Task<IReadOnlyList<TodoItem>> GetAllAsync()
        {
            var list = _items.Values
                             .OrderByDescending(t => t.CreatedAt)
                             .ToList()
                             .AsReadOnly();
            return Task.FromResult((IReadOnlyList<TodoItem>)list);
        }

        public Task<TodoItem> AddAsync(string title)
        {
            var id = Interlocked.Increment(ref _nextId);
            var item = new TodoItem
            {
                Id = id,
                Title = title.Trim(),
                IsDone = false,
                CreatedAt = DateTime.UtcNow
            };

            _items.TryAdd(item.Id, item);
            return Task.FromResult(item);
        }
    }
}
