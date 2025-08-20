using Microsoft.AspNetCore.Components;
using TodoListApp.Models;
using TodoListApp.Services;



namespace TodoList.Pages
{

    public partial class Todos : ComponentBase
    {
        [Inject]
        private ITodoService TodoService { get; set; } = default!;
        protected IReadOnlyList<TodoItem> Items { get; private set; } = Array.Empty<TodoItem>();
        protected override async Task OnInitializedAsync()
        {
            Items = await TodoService.GetAllAsync();

        }

    }

}
