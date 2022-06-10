using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUser
    {
        void AddNewUser (LibraryUser libraryUser);

        List<LibraryUser> GetAllUsers ();   

        LibraryUser GetUserById (int id);

        void EditUser(int id,LibraryUser modal);

        void DeleteUser(int? id);    
    }
}
