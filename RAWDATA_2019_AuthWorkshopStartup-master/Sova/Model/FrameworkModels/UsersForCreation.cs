using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Model.FrameworkModels
{
    public class UsersForCreation
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
    }
}
