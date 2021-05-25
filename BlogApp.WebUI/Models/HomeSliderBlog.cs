using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Models
{
    public class HomeSliderBlog
    {
        public List<Blog> HomeBlog { get; set; }
        public List<Blog> SliderBlog { get; set; }
    }
}
