using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = categoryRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category  category)
        {
            categoryRepository.Add(category);
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = categoryRepository.GetAll();
            return View("Create",categoryRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            categoryRepository.Update(category);
            return RedirectToAction("Create");
        }

        public IActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Create");
        }
    }
}
