using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must not be more than {1}")]
        [MinLength(2, ErrorMessage = "The {0} must not be less than {1}")]
        public string Name { get; set; }

          
        public ICollection<Book> Books { get; set; }
    }
}
