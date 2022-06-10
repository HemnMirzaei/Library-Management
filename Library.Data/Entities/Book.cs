using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

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
