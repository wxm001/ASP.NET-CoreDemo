using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    using AspNetCoreTodo.Models;
    using AspNetCoreTodo.Services;

    public class TodoController : Controller
    {
        private readonly ITodoItemService TodoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            this.TodoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            //从数据库获取todo项目
            var items = await this.TodoItemService.GetIncompleteItemsAsync();
            //把条目置于model中
            var model = new TodoViewModel() { Items =items };
            //使用model渲染视图
            return View(model);
        }

        
        [ValidateAntiForgeryToken] //查找验证隐藏的验证标记，防止跨站请求伪造
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            var successful = await this.TodoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return this.BadRequest(new { error = "Could not add item" });
            }

            return this.RedirectToAction("Index");
        }
    }
}