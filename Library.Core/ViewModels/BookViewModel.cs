using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.ViewModels
{
    public class BookViewModel
    {

        [Required]
        public string Name { get; set; }

        public int TopicId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Pages { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Existing { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PublishYear { get; set; }

    }
}
