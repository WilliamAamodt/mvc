using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models.Entites
{
    //TODO: Make this class inherit IdentityUser. Remove overlapsing fields, right now the class itself is redundant. https://stackoverflow.com/questions/43810032/add-column-to-aspnetusers-table

    public class User : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual IEnumerable<Blog> FavoriteBlogs { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Role { get; set; }
    }

}
