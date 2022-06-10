using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public int TopicId { get; set; }


        public string Name { get; set; }


        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }
    }
}
