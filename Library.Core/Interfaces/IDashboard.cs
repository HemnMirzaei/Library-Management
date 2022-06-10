using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IDashboard
    {
        bool IsExistId(int id);

        LibraryUser GetUser(int id);

        List<Reservation> BooksOnLoan(int id);

        Reservation GetReservation(int id);

        void RemoveReservation(int? id);
    }
}
