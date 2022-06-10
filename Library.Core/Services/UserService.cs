using Library.Core.Interfaces;
using Library.Data.Context;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class UserService : IUser
    {
        private readonly LibDbContext _context;
        public UserService(LibDbContext context)
        {
            _context = context;
        }

        public void AddNewUser(LibraryUser libraryUser)
        {
            _context.LibraryUsers.Add(libraryUser);
            _context.SaveChanges();
        }

        public void DeleteUser(int? id)
        {
            LibraryUser userForDelete = _context.LibraryUsers.Find(id);
            _context.LibraryUsers.Remove(userForDelete);
            _context.SaveChanges();
        }

        public void EditUser(int id,LibraryUser modal)
        {
            LibraryUser userForEdit = _context.LibraryUsers.Find(id);

            userForEdit.Name = modal.Name;
            userForEdit.Birthday = modal.Birthday;
            userForEdit.Role = modal.Role;
            userForEdit.Gedner = modal.Gedner;
            _context.SaveChanges();
        }

        public List<LibraryUser> GetAllUsers()
        {
            return _context.LibraryUsers.ToList();
        }

        public LibraryUser GetUserById(int id)
        {
            return _context.LibraryUsers.Find(id);
        }
    }
}
