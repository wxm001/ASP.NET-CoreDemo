namespace AspNetCoreTodo.Services
{
    using System.Threading.Tasks;

    using AspNetCoreTodo.Models;

    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(TodoItem newItem);
    }
}