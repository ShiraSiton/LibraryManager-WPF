using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BorrowingDB : BaseDB
    {
        public BorrowingDB() : base("Borrowing") { }
        public override BaseEntity CreateModel()
        {
          Borrowing item = new Borrowing();
            item.CodeBorrow = Convert.ToInt32(reader["CodeBorrow"]);
            item.IdClient =MyDB.tblClients.GetClientsByCode ((reader["IdClient"]).ToString());
            item.DateBorrow = Convert.ToDateTime(reader["DateBorrow"]);
            return item;
        }
        public List<Borrowing> GetList()
        {
            return base.list.Cast<Borrowing>().ToList();
        }
        public new List<Borrowing> GetBorrowingBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<Borrowing>().ToList();
        }
        public List<Borrowing> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<Borrowing>().ToList();
        }
        public Borrowing GetBorrowingByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.CodeBorrow == code);
        }
    }
}
