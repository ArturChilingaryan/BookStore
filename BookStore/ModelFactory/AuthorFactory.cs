using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ModelFactory
{
    public class AuthorFactory
    {
        private static AuthorFactory instance;
        private AuthorFactory() { 
        }

        public static AuthorFactory GetInstance() {
            if (instance == null) {
                instance = new AuthorFactory();
            }
            return instance;
        }

        public AuthorInfo CreateAuthor(ModelContext dbcontext, string authorName) {

            AuthorInfo author = dbcontext.AuthorInfos.FirstOrDefault(a => a.Name == authorName);
            if (author == null) { 
                author = new AuthorInfo { Name = authorName };

                dbcontext.AuthorInfos.Add(author);
                dbcontext.SaveChanges();
            }
            return author;

        }

        public AuthorInfo GetAuthorByID(ModelContext dbcontext, int id) {

            AuthorInfo author = dbcontext.AuthorInfos.FirstOrDefault(a => a.ID == id);
            if (author == null)
            {
                throw new Exception("Element not found by id=" + id);
            }
            return author;

        }
    }
}
