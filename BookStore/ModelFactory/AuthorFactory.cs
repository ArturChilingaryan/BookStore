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
        private AuthorFactory instance;
        private AuthorFactory() { 
        }

        public AuthorFactory GetInstance() {
            if (instance == null) {
                instance = new AuthorFactory();
            }
            return instance;
        }

        public AuthorInfo CreateAuthor(ModelContext context, string AuthorName) {

            AuthorInfo author = context.AuthorInfos.FirstOrDefault(a => a.Name == AuthorName);
            if (author == null) { 
                author = new AuthorInfo { Name = AuthorName };
    
                context.AuthorInfos.Add(author);
                context.SaveChanges();
            }
            return author;

        }
    }
}
