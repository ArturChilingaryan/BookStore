using System;
using System.Linq;
using BookStore.ModelFactory;

namespace BookStore
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (ModelContext context = new ModelContext())
            {
                //DatabaseFirstFilling.Fill(context);

                var list = PriceFactory.GetInstance().GetPrice(context, 1, 0);

                foreach (var book in list) 
                {
                    Console.WriteLine("Book: ID - {0}-{1}  {2}", book.BookID, book.Price, book.PriceDateTime);
                }

                //var author = AuthorFactory.GetInstance().GetAuthorByID(context, 2);
                //foreach (var item in author.Books) {
                //    Console.WriteLine("Author {0}, ID:{1} - book {2}", author.Name, author.ID, item.Name);
                //}

                //Console.WriteLine("Author {0}, ID:{1}", author.Name, author.ID);

                //foreach (var book in context.BookInfos) {
                //    Console.WriteLine("Book {0}, ID:{1}, Author:{2}, Genre:{3}", book.Name, book.Id, book.Author, book.Genre);
                //}

                //context.Configuration.LazyLoadingEnabled = false;
                //context.Sales.Include("BookInfo");

                //double price = PriceFactory.GetPrice(context, 1, 1);

                //var query = (from b in context.BookInfos
                //             select new
                //             {
                //                 ID = b.Id,
                //                 Name = b.Name,
                //                 Author = b.Author.Name,
                //                 Genre = b.Genre.Name
                //             }).ToList();

                //foreach (var item in query)
                //{
                //    Console.WriteLine("Book {0}, ID:{1}, Author:{2}, Genre:{3}", item.Name, item.ID, item.Author, item.Genre);
                //}
                //Console.WriteLine(authors);

                //var book = BookFactory.GetInstance().GetBookByID(context, 3);
                //Console.WriteLine("Book {0}, ID:{1}, Author:{2}, Genre:{3}", book.Name, book.Id, book.Author, book.Genre);

                Console.ReadKey();
            }
        }
    }
}
