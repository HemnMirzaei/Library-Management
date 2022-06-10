using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Library.Core.ViewModels
{
    public class TopicViewModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must not be more than {1}")]
        [MinLength(2, ErrorMessage = "The {0} must not be less than {1}")]
        public string Title { get; set; }
    }
}
