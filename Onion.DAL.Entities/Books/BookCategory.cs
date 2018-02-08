using Onion.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DAL.Entities.Books
{
    public class BookCategory : EntityBase
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
