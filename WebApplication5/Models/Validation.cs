using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Validation
    {
        string login;
        string password;
        string usertype;
        [Required(ErrorMessage = "username is required")]
        public string Login { get => login; set => login = value; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get => password; set => password = value; }
        [Required(ErrorMessage = "usertype is required")]
        public string Usertype { get => usertype; set => usertype = value; }
    }
}