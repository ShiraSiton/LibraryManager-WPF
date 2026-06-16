using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class PublishDB : BaseDB
    {
        public PublishDB() : base("Publish") { }
        public override BaseEntity CreateModel()
        {
           Publish item= new Publish();
            item.CodePublish = Convert.ToInt32(reader["CodePublish"]);
            item.NamePublish = reader["NamePublish"].ToString();
            return item;
        }
        public List<Publish> GetList()
        {
            return base.list.Cast<Publish>().ToList();
        }
        public new List<Publish> GetPublishBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<Publish>().ToList();
        }
        public List<Publish> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<Publish>().ToList();
        }
        public Publish GetPublishByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.CodePublish == code);
        }
    }
}
