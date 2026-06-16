using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BookToBorrowDB : BaseDB
    {
        public BookToBorrowDB() : base("BookToBorrow") { }
        public override BaseEntity CreateModel()
        {
            BookToBorrow item = new BookToBorrow();
            item.CodeBook = MyDB.tblBooksList.GetBooksListByCode(Convert.ToInt32 (reader["CodeBook"]));
            item.CodeSidoory = Convert.ToInt32(reader["CodeSidoory"]);
            item.StatusToBorrow = (bool)reader["StatusToBorrow"];
            return item;
        }
        public List<BookToBorrow> GetList()
        {
            return base.list.Cast<BookToBorrow>().ToList();
        }
        public new List<BookToBorrow> GetBookToBorrowBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<BookToBorrow>().ToList();
        }
        public List<BookToBorrow> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<BookToBorrow>().ToList();
        }
        public BookToBorrow GetBookToBorrowByCode(int code, int cd)
        {
            return GetList().FirstOrDefault(x => x.CodeBook.CodeBook == code && x.CodeSidoory==cd);
        }

    }
}
