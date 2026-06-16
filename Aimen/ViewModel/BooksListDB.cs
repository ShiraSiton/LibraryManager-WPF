using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BooksListDB : BaseDB
    {
        public BooksListDB() : base("BooksList") { }
        public override BaseEntity CreateModel()
        {
          BooksList item = new BooksList();
            item.CodeBook = Convert.ToInt32(reader["CodeBook"]);
            item.NameBook = reader["NameBook"].ToString();
            item.CodePublish =MyDB.tblPublish.GetPublishByCode (Convert.ToInt32(reader["CodePublish"]));
            item.Copies = Convert.ToInt32(reader["Copies"]);
            item.StatusBook = (bool)reader["StatusBook"];
            item.Imagb = reader["Imagb"].ToString ();
            return item;
        }
        public List<BooksList> GetList()
        {
            return base.list.Cast<BooksList>().ToList();
        }
        public new List<BooksList> GetBooksListBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<BooksList>().ToList();
        }
        public List<BooksList> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<BooksList>().ToList();
        }
        public BooksList GetBooksListByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.CodeBook == code);
        }
    }
}
