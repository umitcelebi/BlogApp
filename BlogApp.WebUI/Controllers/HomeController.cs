using BlogApp.Data.Abstract;
using BlogApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;
        public HomeController(IBlogRepository _blogRepository)
        {
            blogRepository = _blogRepository;
        }
        public IActionResult Index()
        {
            var model = new HomeSliderBlog
            {
                HomeBlog= blogRepository.GetAll().Where(b => b.IsApproved && b.IsHome).ToList(),
                SliderBlog= blogRepository.GetAll().Where(b => b.IsApproved && b.IsSlider).ToList()
            };

            return View(model);
        }
    }
}
