using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public static class MyDB
    {
        public static KindsOfBookDB tblKindsOfBook = new KindsOfBookDB();
        public static ClientsDB tblClients = new ClientsDB();
        public static PublishDB tblPublish = new PublishDB();
        public static BooksListDB tblBooksList = new BooksListDB();
        public static BookToBorrowDB tblBookToBorrow = new BookToBorrowDB();
        public static SignUpDB tblSignUp = new SignUpDB();
        public static BorrowingDB tblBorrowing = new BorrowingDB();
        public static TypesFORbookDB tblTypesFORbook = new TypesFORbookDB();
        public static BorrowingExplaningDB tblBorrowingExplaning = new BorrowingExplaningDB();
       
       
    }
}
