namespace AspNetCoreTodo.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTodo.Data;
    using AspNetCoreTodo.Models;

    using Microsoft.EntityFrameworkCore;

    public class TodoItemService:ITodoItemService
    {
        private readonly ApplicationDbContext DbContext;

        public TodoItemService(ApplicationDbContext context)
        {
            this.DbContext = context; //需要注入,(内置已经注入，不需自己注入)
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            var items = await this.DbContext.Items.Where(x => x.IsDone == false).ToArrayAsync();
            return items;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.Id=Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt=DateTimeOffset.Now.AddDays(3);
            this.DbContext.Add(newItem);
            var saveResult = await this.DbContext.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}