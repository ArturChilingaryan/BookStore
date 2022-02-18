using BookStore.Model;
using System;
using System.Linq;

namespace BookStore.ModelFactory
{
    public class BookFactory
    {
        private static BookFactory instance;
        private BookFactory()
        {
        }

        public static BookFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new BookFactory();
            }
            return instance;
        }

        public BookInfo CreateBook(ModelContext dbcontext, string bookName, BookGenre bookGenre, AuthorInfo authorInfo)
        {

            BookInfo book = dbcontext.BookInfos.FirstOrDefault(a => a.Name == bookName);
            if (book == null)
            {
                book = new BookInfo { Name = bookName, Genre = bookGenre, Author = authorInfo };

                dbcontext.BookInfos.Add(book);
                dbcontext.SaveChanges();
            }
            return book;

        }

        public BookInfo GetBookByID(ModelContext dbcontext, int id)
        {

            BookInfo book = dbcontext.BookInfos.FirstOrDefault(a => a.Id == id);
            if (book == null)
            {
                throw new Exception("No such book with ID: " + id);
            }
            return book;

        }
    }
}
