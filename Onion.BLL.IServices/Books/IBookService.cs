using Onion.DAL.Entities.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.BLL.IServices.Books
{
    public interface IBookService
    {
        Book GetById(int Id);
    }
}
