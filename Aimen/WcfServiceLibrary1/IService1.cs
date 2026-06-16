using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IService1
    { 
    #region Add Methods
        [OperationContract]
    void AddKindsOfBook(KindsOfBook kindsOfBook);
    [OperationContract]
    void AddTypesFORbook(TypesFORbook typesFORbook);
    [OperationContract]
    void AddClients(Clients clients);
    [OperationContract]
    void AddPublish(Publish publish);
    [OperationContract]
    void AddBooksList(BooksList booksList);
    [OperationContract]
    void AddBookToBorrow(BookToBorrow bookToBorrow);
    [OperationContract]
    void AddBorrowingExplaning(BorrowingExplaning borrowingExplaning);
    [OperationContract]
    void AddSignUp(SignUp signUp);
    [OperationContract]
    void AddBorrowimg(Borrowing borrowing);
    #endregion
    #region Update Methods
    [OperationContract]
    void UpdateKindsOfBook(KindsOfBook kindsOfBook);
    [OperationContract]
    void UpdateTypesFORbook(TypesFORbook typesFORbook);
    [OperationContract]
    void UpdateClients(Clients clients);
    [OperationContract]
    void UpdatePublish(Publish publish);
    [OperationContract]
    void UpdateBooksList(BooksList booksList);
    [OperationContract]
    void UpdateBookToBorrow(BookToBorrow bookToBorrow);
    [OperationContract]
    void UpdateBorrowingExplaning(BorrowingExplaning borrowingExplaning);
    [OperationContract]
    void UpdateSignUp(SignUp signUp);
    [OperationContract]
    void UpdateBorrowing(Borrowing borrowing);
    #endregion
    #region Delete Methods
    [OperationContract]
    void DeleteStatusKindsOfBook(KindsOfBook kindsOfBook);
    [OperationContract]
    void DeleteStatusTypesFORbook(TypesFORbook typesFORbook);
    [OperationContract]
    void DeleteStatusClients(Clients clients);
    [OperationContract]
    void DeleteStatusPublish(Publish publish);
    [OperationContract]
    void DeleteStatusBooksList(BooksList booksList);
    [OperationContract]
    void DeleteStatusBookToBorrow(BookToBorrow bookToBorrow);
    [OperationContract]
    void DeleteStatusBorrowingExplaning(BorrowingExplaning borrowingExplaning);
    [OperationContract]
    void DeleteStatusSignUp(SignUp signUp);
    [OperationContract]
    void DeleteStatusBorrowing(Borrowing borrowing);

    #endregion
    #region GetBySelect Methods
    [OperationContract]
    List<KindsOfBook> GetKindsOfBookBySelect(string nameField, string st);
    [OperationContract]
    List<TypesFORbook> GetTypesFORbookBySelect(string nameField, string st);
    [OperationContract]
    List<Clients> GetClientsBySelect(string nameField, string st);
    [OperationContract]
    List<Publish> GetPublishBySelect(string nameField, string st);
    [OperationContract]
    List<BooksList> GetBooksListBySelect(string nameField, string st);
    [OperationContract]
    List<BookToBorrow> GetBookToBorrowBySelect(string nameField, string st);
    [OperationContract]
    List<BorrowingExplaning> GetBorrowingExplaningBySelect(string nameField, string st);
    [OperationContract]
    List<SignUp> GetSignUpBySelect(string nameField, string st);
    [OperationContract]
    List<Borrowing> GetBorrowingBySelect(string nameField, string st);

    #endregion
    #region GetByCode Methods
    [OperationContract]
    KindsOfBook GetKindsOfBookByCode(int code);
    [OperationContract]
    TypesFORbook GetTypesFORbookByCode(int code, int cd);
    [OperationContract]
    Clients GetClientsByCode(string code);
    [OperationContract]
    Publish GetPublishByCode(int code);
    [OperationContract]
    BooksList GetBooksListByCode(int code);
    [OperationContract]
    BookToBorrow GetBookToBorrowByCode(int code, int cd);
    [OperationContract]
    BorrowingExplaning GetBorrowingExplaningByCode(int code, int cd, int cdd);
    [OperationContract]
    SignUp GetSignUpByCode(string code, DateTime cd);
    [OperationContract]
    Borrowing GetBorrowingByCode(int code);

    #endregion
    #region GetListBySelectedContain Methods
    [OperationContract]
    List<KindsOfBook> GetListKindsOfBookBySelectedContain(string nameField, string st);
    [OperationContract]
    List<TypesFORbook> GetListTypesFORbookBySelectedContain(string nameField, string st);
    [OperationContract]
    List<Clients> GetListClientsBySelectedContain(string nameField, string st);
    [OperationContract]
    List<Publish> GetListPublishBySelectedContain(string nameField, string st);
    [OperationContract]
    List<BooksList> GetListBooksListBySelectedContain(string nameField, string st);
    [OperationContract]
    List<BookToBorrow> GetListBookToBorrowBySelectedContain(string nameField, string st);
    [OperationContract]
    List<BorrowingExplaning> GetListBorrowingExplaningBySelectedContain(string nameField, string st);
    [OperationContract]
    List<SignUp> GetListSignUpBySelectedContain(string nameField, string st);
    [OperationContract]
    List<Borrowing> GetListBorrowingBySelectedContain(string nameField, string st);

    #endregion
    #region GetList Methods
    [OperationContract]
    List<KindsOfBook> GetListKindsOfBook();
    [OperationContract]
    List<TypesFORbook> GetListTypesFORbook();
    [OperationContract]
    List<Clients> GetListClients();
    [OperationContract]
    List<Publish> GetListPublish();
    [OperationContract]
    List<BooksList> GetListBooksList();
    [OperationContract]
    List<BookToBorrow> GetListBookToBorrow();
    [OperationContract]
    List<BorrowingExplaning> GetListBorrowingExplaning();
    [OperationContract]
    List<SignUp> GetListSignUp();
    [OperationContract]
    List<Borrowing> GetListBorrowing();


    #endregion
    #region GetNextKey Methods
    [OperationContract]
    int GetNextKeyKindsOfBook();
    [OperationContract]
    int GetNextKeyPublish();
    [OperationContract]
    int GetNextKeyBooksList();
    [OperationContract]
    int GetNextKeyBorrowing();
        [OperationContract]
    int GetNextKeyBookToBorrow();

        #endregion
    #region Images Methods
        [OperationContract]
        string GetCurrentPath();
        [OperationContract]
        void SaveImg(byte[] imageArr, string nameFile);
        [OperationContract]
        byte[] GetImage(string fileName);

        #endregion
    }
}
