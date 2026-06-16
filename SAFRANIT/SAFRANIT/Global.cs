using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace SAFRANIT
{
    public class Global
    {
        public static SHARAT.Service1Client proxy = new SHARAT.Service1Client();
        public static SHARAT.KindsOfBook currentKindsOfBook ;
        public static SHARAT.TypesFORbook currentTypesFORbook ;
        public static SHARAT.Clients currentClients ;
        public static SHARAT.Publish currentPublish;
        public static SHARAT.BooksList currentBooksList ;
        public static SHARAT.BookToBorrow currentBookToBorrow ;
        public static SHARAT.BorrowingExplaning currentBorrowingExplaning;
        public static SHARAT.SignUp currentSignUp ;
        public static SHARAT.Borrowing currentBorrowing;
        public static int countbooks;
    }
}
