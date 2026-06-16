using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Clients : BaseEntity
    {
        private string idClient;
        private int children;
        private string fone;
        private string fname;
        private string lname;

        public string IdClient { get => idClient; set => idClient = value; }
        public int Children { get => children; set => children = value; }
        public string Fone { get => fone; set => fone = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }

        public override string[] GetKeyFields()
        {
            return new string[] { "IdClient" };
        }
        public override string GetTableName()
        {
            return "Clients";
        }
        public override string ToString()
        {
            return IdClient.ToString();
        }
    }
}
