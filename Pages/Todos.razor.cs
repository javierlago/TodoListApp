using Microsoft.AspNetCore.Components;
using TodoListApp.Models;
using TodoListApp.Services;



namespace TodoListApp.Pages
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

        private TodoItem newItem = new();

        private async Task AddTodo()
        {

            await TodoService.AddAsync(newItem.Title);
            newItem = new TodoItem();
            Items = await TodoService.GetAllAsync();

        }
        private async Task ToggleDone(int id)
        {
            await TodoService.ToggleDoneAsync(id);       // ahora sí: guardamos en el servicio
            Items = await TodoService.GetAllAsync();     // recargamos la lista actualizada
        }

        private async Task DeleteTodo(int id)
        {
            await TodoService.DeleteAsync(id);
            Items = await TodoService.GetAllAsync();
        }

    }

}
