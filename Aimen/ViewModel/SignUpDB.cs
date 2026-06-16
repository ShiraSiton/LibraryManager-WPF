using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SignUpDB : BaseDB
    {
        public SignUpDB() : base("SignUp") { }
        public override BaseEntity CreateModel()
        {
          SignUp item = new SignUp();
          item.IdClient =MyDB.tblClients.GetClientsByCode((reader["IdClient"]).ToString());
          item.SignDate = Convert.ToDateTime(reader["SignDate"]);
          item.EndSignTime = Convert.ToDateTime(reader["EndSignTime"]);
          return item;
        }
        public List<SignUp> GetList()
        {
            return base.list.Cast<SignUp>().ToList();
        }
        public new List<SignUp> GetSignUpBySelect(string nameField, string st)
        {
            return base.GetListBySelect(nameField, st).Cast<SignUp>().ToList();
        }
        public List<SignUp> GetListBySelectContain(string nameField, string st)
        {
            return base.GetListBySelectContain(nameField, st).Cast<SignUp>().ToList();
        }
        public SignUp GetSignUpByCode(string code, DateTime cd)
        {
            return GetList().FirstOrDefault(x=> x.IdClient.IdClient == code && x.SignDate==cd);
        }
    }
}
