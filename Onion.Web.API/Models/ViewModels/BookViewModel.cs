using Onion.DAL.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.API.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }

        public bool IsTitleValide
        {
            get
            {
                return Book.Title.Length > 1;
            }
        }
    }
}
