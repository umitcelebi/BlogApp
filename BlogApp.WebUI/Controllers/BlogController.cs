using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository blogRepository;
        private ICategoryRepository categoryRepository;
        public BlogController(IBlogRepository _blogRepository, ICategoryRepository _categoryRepository)
        {
            blogRepository = _blogRepository;
            categoryRepository = _categoryRepository;
        }
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                return View("Index", blogRepository.GetByCategory((int)id));
            }
            return View(blogRepository.GetAll().Where(b=>b.IsApproved));
        }

        public IActionResult List() => View(blogRepository.GetAll());

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(categoryRepository.GetAll(),"CategoryId","CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog,IFormFile file)
        {
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                blog.Image = file.FileName;
            }
            blogRepository.Add(blog);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(categoryRepository.GetAll(),"CategoryId","CategoryName");
            return View(blogRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Blog blog,IFormFile file)
        {
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",file.FileName);
                using(var stream=new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                blog.Image = file.FileName;
            }
            blogRepository.Update(blog);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            blogRepository.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            return View(blogRepository.GetById(id));
        }

        public IActionResult ListByCategory(int id)
        {
            return View("Index",blogRepository.GetByCategory(id));
        }
        public IActionResult Search(string q)
        {
            return View("Index", blogRepository.Search(q));
        }
    }
}
