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
                //context.AuthorInfos.Add(new AuthorInfo { Name = "Mark Twen" });

                //context.SaveChanges();

                var authors = context.AuthorInfos;

                foreach (var author in authors) {
                    Console.WriteLine(author.Name);
                }

                //Console.WriteLine(authors);

                Console.ReadKey();

                //var query = from context.Authors 

            }
        }
    }
}
