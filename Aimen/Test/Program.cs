using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // לְהַשְׁאִיל - להסיר הערה כדי לבדוק חיבור לבסיס הנתונים:
            //KindsOfBook k = new KindsOfBook() { CodeKindOfBook = 1, NameKindOfBook = " חינוכי" };
            //Clients c = new Clients() { IdClient = "329172514", Children = 10, Fone = "0583294936" };
            //Publish p = new Publish() { CodePublish = 110, NamePublish = "יפה נוף" };
            //BookToBorrow b = new BookToBorrow() { CodeBook = 202, CodeSidoory = 3, StatusToBorrow = false };
            //BooksList b2 = new BooksList() { CodeBook = 5, NameBook = "מהללאל", CodePublish = p, Copies = 50, StatusBook = true };
            //SignUp s = new SignUp() { IdClient = c, SignDate = DateTime.Today, EndSignTime = DateTime.Today };
            //Borrowing b3 = new Borrowing() { CodeBorrow = 5, IdClient = c, DateBorrow = DateTime.Today };
            //TypesFORbook t = new TypesFORbook() { CodeBook = b2, CodeKindOfBook = k };
            //BorrowingExplaning b4 = new BorrowingExplaning() { CodeBorrow = b3, BookToBorrow1 = b, ReturningTime = DateTime.Today };
            //MyDB.tblKindsOfBook.Insert(k);
            //MyDB.tblClients.Insert(c);
            //MyDB.tblPublish.Insert(p);
            //MyDB.tblBookToBorrow.Insert(b);
            //MyDB.tblBooksList.Insert(b2);
            //MyDB.tblSignUp.Insert(s);
            //MyDB.tblBorrowing.Insert(b3);
            //MyDB.tblTypesFORbook.Insert(t);
            //MyDB.tblBorrowingExplaning.Insert(b4);
            //Print(MyDB.tblKindsOfBook.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblClients.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblPublish.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblBookToBorrow.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblBooksList.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblSignUp.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblBorrowing.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblTypesFORbook.GetList().Cast<BaseEntity>().ToList());
            //Print(MyDB.tblBorrowingExplaning.GetList().Cast<BaseEntity>().ToList());

            Console.WriteLine("Test project is ready. Uncomment the code above to test.");
            Console.ReadLine();
        }

        //public static void Print(List<BaseEntity> lst)
        //{
        //    foreach (var item in lst)
        //    {
        //        Console.WriteLine(item);
        //        Console.WriteLine("************");
        //        Console.ReadLine();
        //    }
        //}
    }
}
