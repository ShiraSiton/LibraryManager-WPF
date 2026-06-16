using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BorrowingExplaningDB : BaseDB
    {
        public BorrowingExplaningDB() : base("BorrowingExplaning") { }
        public override BaseEntity CreateModel()
        {
            BorrowingExplaning item = new BorrowingExplaning();
            item.CodeBorrow =MyDB.tblBorrowing.GetBorrowingByCode (Convert.ToInt32(reader["CodeBorrow"]));
            item.BookToBorrow1 = MyDB.tblBookToBorrow.GetBookToBorrowByCode(Convert.ToInt32(reader["CodeBook"]), Convert.ToInt32(reader["CodeSidoory"]) );
         
            item.ReturningTime = Convert.ToDateTime(reader["ReturningTime"]);
            return item;
        }
        public List<BorrowingExplaning> GetList()
        {
            return base.list.Cast<BorrowingExplaning>().ToList();
        }
        public new List<BorrowingExplaning> GetBorrowingExplaningBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<BorrowingExplaning>().ToList();
        }
        public List<BorrowingExplaning> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<BorrowingExplaning>().ToList();
        }
        public BorrowingExplaning GetBorrowingExplaningByCode(int code, int cd, int cdd)
        {
            return GetList().FirstOrDefault(x => x.CodeBorrow.CodeBorrow == code && x.BookToBorrow1.CodeBook.CodeBook==cd && x.BookToBorrow1.CodeSidoory==cdd );
        }
    }
}
