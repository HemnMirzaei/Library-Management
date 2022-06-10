using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.ViewModels
{
    public class UserViewModel
    {
        public Role Role { get; set; }

        [Required]
        public string Name { get; set; }

        public Gedner Gedner { get; set; }

        [Required]
        public string Birthday { get; set; }
    }
}
