using Onion.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DAL.Entities.Books
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
