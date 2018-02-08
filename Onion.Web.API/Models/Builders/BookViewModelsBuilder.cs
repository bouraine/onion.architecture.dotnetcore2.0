using Onion.DAL.Entities.Books;
using Onion.Web.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.API.Builders
{
    public static class BookViewModelsBuilder
    {
        public static BookViewModel GetBookViewModel(Book book)
        {
            BookViewModel bvm = new BookViewModel
            {
                Book = book
            };

            return bvm;
        }

        public static List<BookViewModel> GetListBookViewModel(List<Book> books)
        {
            List<BookViewModel> booksVM = new List<BookViewModel>();
            books.ForEach(t => {
                booksVM.Add(BookViewModelsBuilder.GetBookViewModel(t));
            });
            return booksVM;
        }
    }
}
