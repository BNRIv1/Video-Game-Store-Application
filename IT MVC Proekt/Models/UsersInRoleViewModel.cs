using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_MVC_Proekt.Models
{
    public class UsersInRoleViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}