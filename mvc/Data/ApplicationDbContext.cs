using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models.Entites;
using mvc.Models.ViewModels;

namespace mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
       

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Comments> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SubscribedBlogs> SubscribedBlogses { get; set; }


        public DbSet<mvc.Models.ViewModels.PostViewModel> PostViewModel { get; set; }

    }
}
