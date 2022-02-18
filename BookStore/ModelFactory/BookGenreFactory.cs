using BookStore.Model;
using System;
using System.Linq;

namespace BookStore.ModelFactory
{
    public class BookGenreFactory
    {
        private static BookGenreFactory instance;
        private BookGenreFactory()
        {
        }

        public static BookGenreFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new BookGenreFactory();
            }
            return instance;
        }

        public BookGenre CreateBookGenre(ModelContext dbcontext, string bookGenreName)
        {

            BookGenre bookGenre = dbcontext.BookGenres.FirstOrDefault(a => a.Name == bookGenreName);
            if (bookGenre == null)
            {
                bookGenre = new BookGenre { Name = bookGenreName };

                dbcontext.BookGenres.Add(bookGenre);
                dbcontext.SaveChanges();
            }
            return bookGenre;

        }

        public BookGenre GetBookGenreByID(ModelContext dbcontext, int id)
        {

            BookGenre bookGenre = dbcontext.BookGenres.FirstOrDefault(a => a.ID == id);
            if (bookGenre == null)
            {
                throw new Exception("Element not found by id=" + id);
            }
            return bookGenre;

        }
    }
}
