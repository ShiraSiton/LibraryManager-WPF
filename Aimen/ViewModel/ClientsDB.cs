using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ClientsDB : BaseDB
    {
        public ClientsDB() : base("Clients") { }
        public override BaseEntity CreateModel()
        {
            Clients item = new Clients();
            item.IdClient = reader["IdClient"].ToString();
            item.Children = Convert.ToInt32(reader["children"]);
            item.Fone = reader["Fone"].ToString();
            item.Lname = reader["Lname"].ToString();
            item.Fname = reader["Fname"].ToString();
            return item;
        }
        public List<Clients> GetList()
        {
             return base.list.Cast<Clients>().ToList();
        }
        public new List<Clients> GetClientsBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<Clients>().ToList();
        }
        public List<Clients> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<Clients>().ToList();
        }
        public Clients GetClientsByCode(string code) 
        {
            return GetList().FirstOrDefault(x =>  x.IdClient== code);
        }
    }
}
