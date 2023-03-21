using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; init; }
        [Required(ErrorMessage = "Password is reuired")]
        public string Password { get; init; }
    }
}
