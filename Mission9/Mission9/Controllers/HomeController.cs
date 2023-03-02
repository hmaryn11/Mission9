using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9.Models;
using Mission9.Models.ViewModels;

namespace Mission9.Controllers
{
    public class HomeController : Controller
    {

        private IBookStore repo;

        public HomeController (IBookStore temp)
        {
            repo = temp;
        }

        public int BooksPerPage { get; private set; }
        public object CurrentPage { get; private set; }

        public IActionResult Index(int pageNum = 1) //if nothing else comes in, pagenum=1
        {
            int pageSize = 5;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                .OrderBy(p => p.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Projects.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
        //The below method does the same as the above method
        //public IActionResult Index() => View();
    }
}
//lamda jumps straight to the result of the method