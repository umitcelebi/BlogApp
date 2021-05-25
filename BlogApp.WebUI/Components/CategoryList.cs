using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Components
{
    public class CategoryList:ViewComponent
    {
        private ICategoryRepository categoryRepository;
        public CategoryList(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData.Values["id"];
            return View(categoryRepository.GetAll());
        }
    }
}
