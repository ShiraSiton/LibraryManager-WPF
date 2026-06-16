using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class KindsOfBookDB :BaseDB
    {
        public KindsOfBookDB() : base("KindsOfBook") { }
        public override BaseEntity CreateModel()
        {
            KindsOfBook item = new KindsOfBook();
            item.CodeKindOfBook = Convert.ToInt32(reader["CodeKindOfBook"]);
            item.NameKindOfBook = reader["NameKindOfBook"].ToString();
            return item;
        }
        public List<KindsOfBook> GetList() 
        {
            return base.list.Cast<KindsOfBook>().ToList();
        }
        public new List<KindsOfBook> GetKindsOfBookBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<KindsOfBook>().ToList();
        }
        public List<KindsOfBook> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<KindsOfBook>().ToList() ;
        }
        public KindsOfBook GetKindsOfBookByCode(int code) 
        {
            return GetList().FirstOrDefault(x => x.CodeKindOfBook == code);
        }
    }
}
