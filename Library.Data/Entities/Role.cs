using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public enum Role
    {
        SuperAdmin,
        Admin,
        Librarian,
        Professor,
        Student
    }
}
