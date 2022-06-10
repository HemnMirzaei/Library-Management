using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class LibraryUser
    {
        [Key]
        public int Id { get; set; }

        public Role Role { get; set; }

        [Required]
        public string Name { get; set; }

        public Gedner Gedner { get; set; }

        [Required]
        public string Birthday { get; set; }


    }
}
