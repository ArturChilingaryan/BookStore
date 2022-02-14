using BookStore.Model;
using System;

namespace BookStore
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            using (ModelContext context = new ModelContext())
            {
                Console.WriteLine("Entity TEST");

                //AuthorInfo authorInfo = new AuthorInfo { Name = "Mark Twen" };
                //context.AuthorInfos.Add(authorInfo);

                //BookGenre adventureGenre = new BookGenre { Name = "Adventure" };
                //AuthorInfo dyuma = new AuthorInfo { Name = "Alexandre Dumas"};
                //context.BookInfos.Add(new BookInfo {Name = "The Three Musketeers", Genre = adventureGenre, Author = dyuma});
                //context.BookInfos.Add(new BookInfo { Name = "The Count of Monte Cristo", Genre = adventureGenre, Author = dyuma });

                //context.SaveChanges();

                foreach (var book in context.BookInfos) {
                    Console.WriteLine(book.Name);
                }

                //Console.WriteLine(authors);

                Console.ReadKey();

                //var query = from context.Authors 

            }
        }
    }
}
