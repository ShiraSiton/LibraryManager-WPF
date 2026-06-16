using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Borrowing:BaseEntity
    {
        private int codeBorrow;
        private Clients idClient;
        private DateTime dateBorrow;

        public int CodeBorrow { get => codeBorrow; set => codeBorrow = value; }
        public Clients IdClient { get => idClient; set => idClient = value; }
        public DateTime DateBorrow { get => dateBorrow; set => dateBorrow = value; }

        public override string[] GetKeyFields()
        {
            return new string[] { "CodeBorrow" };
        }
        public override string GetTableName()
        {
            return "Borrowing";
        }
        public override string ToString()
        {
            return CodeBorrow.ToString();
        }
    }
}
