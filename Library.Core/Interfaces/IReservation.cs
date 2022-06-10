using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IReservation
    {
        List<Book> GetAllBooks();
        List<LibraryUser> GetAllUsers();

        void AddNewReservation(Reservation reservation);
    }
}
