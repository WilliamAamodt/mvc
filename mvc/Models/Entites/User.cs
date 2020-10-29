using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models.Entites
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public virtual IdentityUser Owner { get; set; }
        // user ID from AspNetUser table.
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual IEnumerable<Blog> FavoriteBlogs { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Role { get; set; }
    }

}
