using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Id { get; set; } 
    }
}
