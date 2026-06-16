
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TypesFORbookDB : BaseDB
    {
        public TypesFORbookDB() : base("TypesFORbook") { }
        public override BaseEntity CreateModel()
        {
            TypesFORbook item = new TypesFORbook();
            item.CodeBook = MyDB.tblBooksList.GetBooksListByCode (Convert.ToInt32(reader["CodeBook"]));
            item.CodeKindOfBook =MyDB.tblKindsOfBook.GetKindsOfBookByCode( Convert.ToInt32(reader["CodeKindOfBook"]));
            return item;
        }
        public List<TypesFORbook> GetList()
        {
            return base.list.Cast<TypesFORbook>().ToList();
        }
        public new List<TypesFORbook> GetTypesFORbookBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<TypesFORbook>().ToList();
        }
        public List<TypesFORbook> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<TypesFORbook>().ToList();
        }
        public TypesFORbook GetTypesFORbookByCode(int code, int cd)
        {
            return GetList().FirstOrDefault(x => x.CodeBook.CodeBook == code && x.CodeKindOfBook.CodeKindOfBook==cd);
        }
    }
}
