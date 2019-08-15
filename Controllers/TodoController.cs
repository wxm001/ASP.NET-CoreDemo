using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            //从数据库获取todo项目

            //把条目置于model中
            
            //使用model渲染视图
            return View();
        }
    }
}