using System.Reflection.Metadata.Ecma335;
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
        private int? editingId = null;
        private string editedTitle = string.Empty;
        private int PendingCount => Items?.Count(t => !t.IsDone) ?? 0;
        private enum ViewFilter {All,Active,Completed }
        private ViewFilter currentFilter = ViewFilter.All;


        private IEnumerable<TodoItem> GetFilteredItems() { 
            if(Items is null) return Enumerable.Empty<TodoItem>();
            return currentFilter switch
            {
                ViewFilter.Active => Items.Where(t => !t.IsDone),
                ViewFilter.Completed => Items.Where(t => t.IsDone),
                _ => Items


            };
        
        
        
        
        
        }




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
        private void StartEdit(TodoItem item)
        {
            editingId = item.Id;
            editedTitle = item.Title;

        }

        private async Task SaveEdit(int id)
        {
            if (!string.IsNullOrWhiteSpace(editedTitle))
            {
                await TodoService.UpdateTitleAsync(id, editedTitle.Trim());
                editingId = null;
                editedTitle = string.Empty;
                Items = await TodoService.GetAllAsync();

            }


        }

        private void CancelEdit() {
            editingId = null;
            editedTitle = string.Empty;
        
        }


    }

}
