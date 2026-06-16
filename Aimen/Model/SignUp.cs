using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SignUp : BaseEntity
    {
        private Clients idClient;
        private DateTime signDate;
        private DateTime endSignTime;

        public Clients IdClient { get => idClient; set => idClient = value; }
        public DateTime SignDate { get => signDate; set => signDate = value; }
        public DateTime EndSignTime { get => endSignTime; set => endSignTime = value; }
       

        public override string[] GetKeyFields()
        {
            return new string[] { "IdClient" , "SignDate" };
        }
        public override string GetTableName()
        {
            return "SignUp";
        }
        public override string ToString()
        {
            return IdClient.ToString() +""+ SignDate.ToString();
        }
    }
}
