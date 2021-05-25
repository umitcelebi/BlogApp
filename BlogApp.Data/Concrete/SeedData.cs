using BlogApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Concrete
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            BlogContext context = app.ApplicationServices.GetRequiredService<BlogContext>();

            context.Database.Migrate();
        
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category() { CategoryName = "Category 1" },
                    new Category() { CategoryName = "Category 2" },
                    new Category() { CategoryName = "Category 3" },
                    new Category() { CategoryName = "Category 4" }
                );
                context.SaveChanges();
            }

            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Blog()
                    {
                        Title = "Title 1",
                        Description = "Description 1",
                        Body = "Body 1",
                        Image = "01.jpg",
                        AddedDate = DateTime.Now.AddDays(-1),
                        IsApproved = true,
                        CategoryId = 1
                    },
                    new Blog()
                    {
                        Title = "Title 2",
                        Description = "Description 2",
                        Body = "Body 2",
                        Image = "02.jpg",
                        AddedDate = DateTime.Now.AddDays(-5),
                        IsApproved = true,
                        CategoryId = 2
                    },
                    new Blog()
                    {
                        Title = "Title 3",
                        Description = "Description 3",
                        Body = "Body 3",
                        Image = "03.jpg",
                        AddedDate = DateTime.Now.AddDays(-2),
                        IsApproved = true,
                        CategoryId = 3
                    },
                    new Blog()
                    {
                        Title = "Title 4",
                        Description = "Description 4",
                        Body = "Body 4",
                        Image = "04.jpg",
                        AddedDate = DateTime.Now.AddDays(-4),
                        IsApproved = true,
                        CategoryId = 3
                    },
                    new Blog()
                    {
                        Title = "Title 5",
                        Description = "Description 5",
                        Body = "Body 5",
                        Image = "05.jpg",
                        AddedDate = DateTime.Now.AddDays(-5),
                        IsApproved = true,
                        CategoryId = 4
                    }
                    );
                context.SaveChanges();
            }
        
        
        }
    }
}
