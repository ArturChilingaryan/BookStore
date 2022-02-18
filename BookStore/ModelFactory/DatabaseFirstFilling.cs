using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model;

namespace BookStore.ModelFactory
{
    public class DatabaseFirstFilling
    {
        public static void Fill(ModelContext dbcontext)
        {
            #region references
            BookGenre genre1 = BookGenreFactory.GetInstance().CreateBookGenre(dbcontext, "Action and adventure");
            BookGenre genre2 = BookGenreFactory.GetInstance().CreateBookGenre(dbcontext, "Drama");
            BookGenre genre3 = BookGenreFactory.GetInstance().CreateBookGenre(dbcontext, "Fantasy");
            BookGenre genre4 = BookGenreFactory.GetInstance().CreateBookGenre(dbcontext, "Classic");

            AuthorInfo author1 = AuthorFactory.GetInstance().CreateAuthor(dbcontext, "Mark Twen");
            AuthorInfo author2 = AuthorFactory.GetInstance().CreateAuthor(dbcontext, "William Shakespeare");
            AuthorInfo author3 = AuthorFactory.GetInstance().CreateAuthor(dbcontext, "Bernard Werber");
            AuthorInfo author4 = AuthorFactory.GetInstance().CreateAuthor(dbcontext, "Fyodor Dostoevsky");

            BranchInfo branch1 = BranchFactory.GetInstance().CreateBranch(dbcontext, "Zangak");
            BranchInfo branch2 = BranchFactory.GetInstance().CreateBranch(dbcontext, "Bookinist");

            BookInfo book1 = BookFactory.GetInstance().CreateBook(dbcontext, "The Adventures of Huckleberry Finn",  genre1, author1);
            BookInfo book2 = BookFactory.GetInstance().CreateBook(dbcontext, "The Adventures of Tom Sawyer",        genre1, author1);
            BookInfo book3 = BookFactory.GetInstance().CreateBook(dbcontext, "Life on the Mississippi",             genre1, author1);
            BookInfo book4 = BookFactory.GetInstance().CreateBook(dbcontext, "The Prince and the Pauper",           genre1, author1);

            BookInfo book5 = BookFactory.GetInstance().CreateBook(dbcontext, "Romeo and Juliet,",                   genre2, author2);
            BookInfo book6 = BookFactory.GetInstance().CreateBook(dbcontext, "Henry IV",                            genre2, author2);
            BookInfo book7 = BookFactory.GetInstance().CreateBook(dbcontext, "Hamlet",                              genre2, author2);
            BookInfo book8 = BookFactory.GetInstance().CreateBook(dbcontext, "Macbeth",                             genre2, author2);
            
            BookInfo book9  = BookFactory.GetInstance().CreateBook(dbcontext, "Les Thanatonautes",                  genre3, author3);
            BookInfo book10 = BookFactory.GetInstance().CreateBook(dbcontext, "Les Fourmis",                        genre3, author3);
            BookInfo book11 = BookFactory.GetInstance().CreateBook(dbcontext, "L'Empire des Anges",                 genre3, author3);
            BookInfo book12 = BookFactory.GetInstance().CreateBook(dbcontext, "Nous, les Dieux",                    genre3, author3);
            BookInfo book13 = BookFactory.GetInstance().CreateBook(dbcontext, "Troisième Humanité",                 genre3, author3);

            BookInfo book14 = BookFactory.GetInstance().CreateBook(dbcontext, "The Idiot",                          genre4, author4);
            BookInfo book15 = BookFactory.GetInstance().CreateBook(dbcontext, "The Gambler",                        genre4, author4);
            BookInfo book16 = BookFactory.GetInstance().CreateBook(dbcontext, "Crime and Punishment",               genre4, author4);
            BookInfo book17 = BookFactory.GetInstance().CreateBook(dbcontext, "The Brothers Karamazov",             genre4, author4);
            BookInfo book18 = BookFactory.GetInstance().CreateBook(dbcontext, "Poor Folk",                          genre4, author4);

            #endregion

            #region prices

            PriceFactory.GetInstance().SetPrice(dbcontext, book1.Id,  branch1.ID, 10000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book2.Id,  branch1.ID, 7000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book3.Id,  branch1.ID, 8000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book4.Id,  branch1.ID, 5000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book5.Id,  branch1.ID, 5500);
            PriceFactory.GetInstance().SetPrice(dbcontext, book6.Id,  branch1.ID, 6800);
            PriceFactory.GetInstance().SetPrice(dbcontext, book7.Id,  branch1.ID, 11000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book8.Id,  branch1.ID, 11200);
            PriceFactory.GetInstance().SetPrice(dbcontext, book9.Id,  branch1.ID, 5000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book10.Id, branch1.ID, 16400);
            PriceFactory.GetInstance().SetPrice(dbcontext, book11.Id, branch1.ID, 8900);
            PriceFactory.GetInstance().SetPrice(dbcontext, book12.Id, branch1.ID, 99000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book13.Id, branch1.ID, 99000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book14.Id, branch1.ID, 79000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book15.Id, branch1.ID, 11000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book16.Id, branch1.ID, 21000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book17.Id, branch1.ID, 18000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book18.Id, branch1.ID, 5000);
            
            PriceFactory.GetInstance().SetPrice(dbcontext, book1.Id,  branch2.ID, 9000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book2.Id,  branch2.ID, 8000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book3.Id,  branch2.ID, 9000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book4.Id,  branch2.ID, 6000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book5.Id,  branch2.ID, 7000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book6.Id,  branch2.ID, 6000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book7.Id,  branch2.ID, 10000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book8.Id,  branch2.ID, 11000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book9.Id,  branch2.ID, 6000);
            PriceFactory.GetInstance().SetPrice(dbcontext, book10.Id, branch2.ID, 17000);

            #endregion

            #region stock

            BalanceFactory.GetInstance().StockIn(dbcontext, book1.Id, branch1.ID, 3);
            BalanceFactory.GetInstance().StockIn(dbcontext, book2.Id, branch1.ID, 30);
            BalanceFactory.GetInstance().StockIn(dbcontext, book3.Id, branch1.ID, 5);
            BalanceFactory.GetInstance().StockIn(dbcontext, book4.Id, branch1.ID, 6);
            BalanceFactory.GetInstance().StockIn(dbcontext, book5.Id, branch1.ID, 7);
            BalanceFactory.GetInstance().StockIn(dbcontext, book6.Id, branch1.ID, 32);
            BalanceFactory.GetInstance().StockIn(dbcontext, book7.Id, branch1.ID, 26);
            BalanceFactory.GetInstance().StockIn(dbcontext, book8.Id, branch1.ID, 13);
            BalanceFactory.GetInstance().StockIn(dbcontext, book9.Id, branch1.ID, 14);
            BalanceFactory.GetInstance().StockIn(dbcontext, book10.Id, branch1.ID, 13);
            BalanceFactory.GetInstance().StockIn(dbcontext, book11.Id, branch1.ID, 55);
            BalanceFactory.GetInstance().StockIn(dbcontext, book12.Id, branch1.ID, 11);
            BalanceFactory.GetInstance().StockIn(dbcontext, book13.Id, branch1.ID, 1);
            BalanceFactory.GetInstance().StockIn(dbcontext, book14.Id, branch1.ID, 17);
            BalanceFactory.GetInstance().StockIn(dbcontext, book15.Id, branch1.ID, 5);
            BalanceFactory.GetInstance().StockIn(dbcontext, book16.Id, branch1.ID, 2);
            BalanceFactory.GetInstance().StockIn(dbcontext, book17.Id, branch1.ID, 4);
            BalanceFactory.GetInstance().StockIn(dbcontext, book18.Id, branch1.ID, 8);

            BalanceFactory.GetInstance().StockIn(dbcontext, book1.Id, branch2.ID, 1);
            BalanceFactory.GetInstance().StockIn(dbcontext, book4.Id, branch2.ID, 6);
            BalanceFactory.GetInstance().StockIn(dbcontext, book5.Id, branch2.ID, 9);
            BalanceFactory.GetInstance().StockIn(dbcontext, book6.Id, branch2.ID, 13);
            BalanceFactory.GetInstance().StockIn(dbcontext, book7.Id, branch2.ID, 10);
            BalanceFactory.GetInstance().StockIn(dbcontext, book8.Id, branch2.ID, 11);
            BalanceFactory.GetInstance().StockIn(dbcontext, book15.Id, branch2.ID, 16);
            BalanceFactory.GetInstance().StockIn(dbcontext, book16.Id, branch2.ID, 17);
            BalanceFactory.GetInstance().StockIn(dbcontext, book17.Id, branch2.ID, 20);
            BalanceFactory.GetInstance().StockIn(dbcontext, book18.Id, branch2.ID, 21);

            #endregion

            #region sales

            SalesFactory.GetInstance().SalesIn(dbcontext, book1.Id, branch1.ID, 1, 10000);
            SalesFactory.GetInstance().SalesIn(dbcontext, book2.Id, branch1.ID, 10, 7000);
            SalesFactory.GetInstance().SalesIn(dbcontext, book18.Id, branch1.ID, 3, 18000);

            SalesFactory.GetInstance().SalesIn(dbcontext, book5.Id, branch2.ID, 2, 5000);
            SalesFactory.GetInstance().SalesIn(dbcontext, book6.Id, branch2.ID, 5, 6800);
            SalesFactory.GetInstance().SalesIn(dbcontext, book9.Id, branch2.ID, 1, 6000);

            #endregion
        }
    }
}
