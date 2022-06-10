using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        
        public int BookId { get; set; }

        public int UserId { get; set; }

        public string Date { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [ForeignKey("UserId")]
        public LibraryUser User { get; set; }
    }
}
