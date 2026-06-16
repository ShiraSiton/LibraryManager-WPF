using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace WcfServiceLibrary1
{
   
    public class Service1 : IService1
    {
        #region Add Methods
        public void AddKindsOfBook(KindsOfBook kindsOfBook)
        {
            MyDB.tblKindsOfBook.Insert(kindsOfBook);
            MyDB.tblKindsOfBook.SaveChanges();
        }
        public void AddTypesFORbook(TypesFORbook typesFORbook)
        {
            MyDB.tblTypesFORbook.Insert(typesFORbook);
            MyDB.tblTypesFORbook.SaveChanges();
        }
        public void AddClients(Clients clients)
        {
            MyDB.tblClients.Insert(clients);
            MyDB.tblClients.SaveChanges();
        }
        public void AddPublish(Publish publish)
        {
            MyDB.tblPublish.Insert(publish);
            MyDB.tblPublish.SaveChanges();
        }
        public void AddBooksList(BooksList booksList)
        {
            MyDB.tblBooksList.Insert(booksList);
            MyDB.tblBooksList.SaveChanges();
        }
        public void AddBookToBorrow(BookToBorrow bookToBorrow)
        {
            MyDB.tblBookToBorrow.Insert(bookToBorrow);
            MyDB.tblBookToBorrow.SaveChanges();
        }
        public void AddBorrowingExplaning(BorrowingExplaning borrowingExplaning)
        {
            MyDB.tblBorrowingExplaning.Insert(borrowingExplaning);
            MyDB.tblBorrowingExplaning.SaveChanges();
        }
        public void AddSignUp(SignUp signUp)
        {
            MyDB.tblSignUp.Insert(signUp);
            MyDB.tblSignUp.SaveChanges();
        }
        public void AddBorrowimg(Borrowing borrowing)
        {
            MyDB.tblBorrowing.Insert(borrowing);
            MyDB.tblBorrowing.SaveChanges();
        }
        #endregion
        #region Update Methods
        public void UpdateKindsOfBook(KindsOfBook kindsOfBook)
        {
            MyDB.tblKindsOfBook.Update(kindsOfBook);
            MyDB.tblKindsOfBook.SaveChanges();
        }
        public void UpdateTypesFORbook(TypesFORbook typesFORbook)
        {
            MyDB.tblTypesFORbook.Update(typesFORbook);
            MyDB.tblTypesFORbook.SaveChanges();
        }
        public void UpdateClients(Clients clients)
        {
            MyDB.tblClients.Update(clients);
            MyDB.tblClients.SaveChanges();
        }
        public void UpdatePublish(Publish publish)
        {
            MyDB.tblPublish.Update(publish);
            MyDB.tblPublish.SaveChanges();
        }
        public void UpdateBooksList(BooksList booksList)
        {
            MyDB.tblBooksList.Update(booksList);
            MyDB.tblBooksList.SaveChanges();
        }
        public void UpdateBookToBorrow(BookToBorrow bookToBorrow)
        {
            MyDB.tblBookToBorrow.Update(bookToBorrow);
            MyDB.tblBookToBorrow.SaveChanges();
        }
        public void UpdateBorrowingExplaning(BorrowingExplaning borrowingExplaning)
        {
            MyDB.tblBorrowingExplaning.Update(borrowingExplaning);
            MyDB.tblBorrowingExplaning.SaveChanges();
        }
        public void UpdateSignUp(SignUp signUp)
        {
            MyDB.tblSignUp.Update(signUp);
            MyDB.tblSignUp.SaveChanges();
        }
        public void UpdateBorrowing(Borrowing borrowing)
        {
            MyDB.tblBorrowing.Update(borrowing);
            MyDB.tblBorrowing.SaveChanges();
        }

        #endregion
        #region Delete Methods
        public void DeleteStatusKindsOfBook(KindsOfBook kindsOfBook)
        {
            MyDB.tblKindsOfBook.DeleteStatus(kindsOfBook);
            MyDB.tblKindsOfBook.SaveChanges();
        }
        public void DeleteStatusTypesFORbook(TypesFORbook typesFORbook)
        {
            MyDB.tblTypesFORbook.DeleteStatus(typesFORbook);
            MyDB.tblTypesFORbook.SaveChanges();
        }
        public void DeleteStatusClients(Clients clients)
        {
            MyDB.tblClients.DeleteStatus(clients);
            MyDB.tblClients.SaveChanges();
        }
        public void DeleteStatusPublish(Publish publish)
        {
            MyDB.tblPublish.DeleteStatus(publish);
            MyDB.tblPublish.SaveChanges();
        }
        public void DeleteStatusBooksList(BooksList booksList)
        {
            MyDB.tblBooksList.DeleteStatus(booksList);
            MyDB.tblBooksList.SaveChanges();
        }
        public void DeleteStatusBookToBorrow(BookToBorrow bookToBorrow)
        {
            MyDB.tblBookToBorrow.DeleteStatus(bookToBorrow);
            MyDB.tblBookToBorrow.SaveChanges();
        }
        public void DeleteStatusBorrowingExplaning(BorrowingExplaning borrowingExplaning)
        {
            MyDB.tblBorrowingExplaning.DeleteStatus(borrowingExplaning);
            MyDB.tblBorrowingExplaning.SaveChanges();
        }
        public void DeleteStatusSignUp(SignUp signUp)
        {
            MyDB.tblSignUp.DeleteStatus(signUp);
            MyDB.tblSignUp.SaveChanges();
        }
        public void DeleteStatusBorrowing(Borrowing borrowing)
        {
            MyDB.tblBorrowing.DeleteStatus(borrowing);
            MyDB.tblBorrowing.SaveChanges();
        }
        #endregion
        #region GetBySelect Methods
        public List<KindsOfBook> GetKindsOfBookBySelect(string nameField, string st)
        {
            return MyDB.tblKindsOfBook.GetListBySelect(nameField, st).Cast<KindsOfBook>().ToList();
        }
        public List<TypesFORbook> GetTypesFORbookBySelect(string nameField, string st)
        {
            return MyDB.tblTypesFORbook.GetListBySelect(nameField, st).Cast<TypesFORbook>().ToList();
        }
        public List<Clients> GetClientsBySelect(string nameField, string st)
        {
            return MyDB.tblClients.GetListBySelect(nameField, st).Cast<Clients>().ToList();
        }
        public List<Publish> GetPublishBySelect(string nameField, string st)
        {
            return MyDB.tblPublish.GetListBySelect(nameField, st).Cast<Publish>().ToList();
        }
        public List<BooksList> GetBooksListBySelect(string nameField, string st)
        {
            return MyDB.tblBooksList.GetListBySelect(nameField, st).Cast<BooksList>().ToList();
        }
        public List<BookToBorrow> GetBookToBorrowBySelect(string nameField, string st)
        {
            return MyDB.tblBookToBorrow.GetListBySelect(nameField, st).Cast<BookToBorrow>().ToList();
        }
        public List<BorrowingExplaning> GetBorrowingExplaningBySelect(string nameField, string st)
        {
            return MyDB.tblBorrowingExplaning.GetListBySelect(nameField, st).Cast<BorrowingExplaning>().ToList();
        }
        public List<SignUp> GetSignUpBySelect(string nameField, string st)
        {
            return MyDB.tblSignUp.GetListBySelect(nameField, st).Cast<SignUp>().ToList();
        }
        public List<Borrowing> GetBorrowingBySelect(string nameField, string st)
        {
            return MyDB.tblBorrowing.GetListBySelect(nameField, st).Cast<Borrowing>().ToList();
        }
        #endregion
        #region GetByCode Methods
        public KindsOfBook GetKindsOfBookByCode(int code)
        {
            return MyDB.tblKindsOfBook.GetKindsOfBookByCode(code);
        }
        public TypesFORbook GetTypesFORbookByCode(int code, int cd)
        {
            return MyDB.tblTypesFORbook.GetTypesFORbookByCode(code, cd);
        }
        public Clients GetClientsByCode(string code)
        {
            return MyDB.tblClients.GetClientsByCode(code);
        }
        public Publish GetPublishByCode(int code)
        {
            return MyDB.tblPublish.GetPublishByCode(code);
        }
        public BooksList GetBooksListByCode(int code)
        {
            return MyDB.tblBooksList.GetBooksListByCode(code);
        }
        public BookToBorrow GetBookToBorrowByCode(int code, int cd)
        {
            return MyDB.tblBookToBorrow.GetBookToBorrowByCode(code, cd);
        }
        public BorrowingExplaning GetBorrowingExplaningByCode(int code, int cd, int cdd)
        {
            return MyDB.tblBorrowingExplaning.GetBorrowingExplaningByCode(code, cd, cdd);
        }
        public SignUp GetSignUpByCode(string code, DateTime cd)
        {
            return MyDB.tblSignUp.GetSignUpByCode(code, cd);
        }
        public Borrowing GetBorrowingByCode(int code)
        {
            return MyDB.tblBorrowing.GetBorrowingByCode(code);
        }
        #endregion
        #region GetListBySelectedContain Methods
        public List<KindsOfBook> GetListKindsOfBookBySelectedContain(string nameField, string st)
        {
            return MyDB.tblKindsOfBook.GetListBySelectContain(nameField, st).Cast<KindsOfBook>().ToList();
        }
        public List<TypesFORbook> GetListTypesFORbookBySelectedContain(string nameField, string st)
        {
            return MyDB.tblTypesFORbook.GetListBySelectContain(nameField, st).Cast<TypesFORbook>().ToList();
        }
        public List<Clients> GetListClientsBySelectedContain(string nameField, string st)
        {
            return MyDB.tblClients.GetListBySelectContain(nameField, st).Cast<Clients>().ToList();
        }
        public List<Publish> GetListPublishBySelectedContain(string nameField, string st)
        {
            return MyDB.tblPublish.GetListBySelectContain(nameField, st).Cast<Publish>().ToList();
        }
        public List<BooksList> GetListBooksListBySelectedContain(string nameField, string st)
        {
            return MyDB.tblBooksList.GetListBySelectContain(nameField, st).Cast<BooksList>().ToList();
        }
        public List<BookToBorrow> GetListBookToBorrowBySelectedContain(string nameField, string st)
        {
            return MyDB.tblBookToBorrow.GetListBySelectContain(nameField, st).Cast<BookToBorrow>().ToList();
        }
        public List<BorrowingExplaning> GetListBorrowingExplaningBySelectedContain(string nameField, string st)
        {
            return MyDB.tblBorrowingExplaning.GetListBySelectContain(nameField, st).Cast<BorrowingExplaning>().ToList();
        }
        public List<SignUp> GetListSignUpBySelectedContain(string nameField, string st)
        {
            return MyDB.tblSignUp.GetListBySelectContain(nameField, st).Cast<SignUp>().ToList();
        }
        public List<Borrowing> GetListBorrowingBySelectedContain(string nameField, string st)
        {
            return MyDB.tblBorrowing.GetListBySelectContain(nameField, st).Cast<Borrowing>().ToList();
        }
        #endregion
        #region GetList Methods
        public List<KindsOfBook> GetListKindsOfBook()
        {
            return MyDB.tblKindsOfBook.GetList().OrderBy(x => x.CodeKindOfBook).ToList();
        }
        public List<TypesFORbook> GetListTypesFORbook()
        {
            return MyDB.tblTypesFORbook.GetList().ToList();
        }
        public List<Clients> GetListClients()
        {
            return MyDB.tblClients.GetList().OrderBy(x => x.IdClient).ToList();
        }
        public List<Publish> GetListPublish()
        {
            return MyDB.tblPublish.GetList().OrderBy(x => x.CodePublish).ToList();
        }
        public List<BooksList> GetListBooksList()
        {
            return MyDB.tblBooksList.GetList().OrderBy(x => x.CodeBook).ToList();
        }
        public List<BookToBorrow> GetListBookToBorrow()
        {
            return MyDB.tblBookToBorrow.GetList().ToList();
        }
        public List<BorrowingExplaning> GetListBorrowingExplaning()
        {
            return MyDB.tblBorrowingExplaning.GetList().ToList();
        }
        public List<SignUp> GetListSignUp()
        {
            return MyDB.tblSignUp.GetList().OrderBy(x => x.SignDate).ToList();
        }
        public List<Borrowing> GetListBorrowing()
        {
            return MyDB.tblBorrowing.GetList().OrderBy(x => x.CodeBorrow).ToList();
        }
        #endregion
        #region GetNextKey Methods
        public int GetNextKeyKindsOfBook()
        {
            KindsOfBook k = MyDB.tblKindsOfBook.GetList().OrderBy(x => x.CodeKindOfBook).LastOrDefault();
            if (k == null)
            {
                return 1;
            }
            return k.CodeKindOfBook + 1;
        }
        public int GetNextKeyPublish()
        {
            Publish p = MyDB.tblPublish.GetList().OrderBy(x => x.CodePublish).LastOrDefault();
            if (p == null)
            {
                return 1;
            }
            return p.CodePublish + 1;
        }
        public int GetNextKeyBooksList()
        {
            BooksList b = MyDB.tblBooksList.GetList().OrderBy(x => x.CodeBook).LastOrDefault();
            if (b == null)
            {
                return 1;
            }
            return b.CodeBook + 1;
        }
        public int GetNextKeyBorrowing()
        {
            Borrowing b = MyDB.tblBorrowing.GetList().OrderBy(x => x.CodeBorrow).LastOrDefault();
            if (b == null)
            {
                return 1;
            }
            return b.CodeBorrow + 1;
        }
        public int GetNextKeyBookToBorrow()
        {
            BookToBorrow b = MyDB.tblBookToBorrow.GetList().LastOrDefault();
            if (b == null)
            {
                return 1;
            }
            return b.CodeSidoory + 1;
        }
          

        #endregion
        #region Images Methods

        public string GetCurrentPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            int X = path.IndexOf(@"\Host");
            path = path.Substring(0, X);
            return path;

        }

        public void SaveImg(byte[] imageArr, string nameFile)
        {
            var stream = new MemoryStream(imageArr);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            string path = GetCurrentPath() + @"\Images\" + nameFile;
            img.Save(path);
        }
        public byte[] GetImage(string fileName)
        {
            string path = GetCurrentPath() + @"\Images\" + fileName;
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }
        #endregion
    }
}
