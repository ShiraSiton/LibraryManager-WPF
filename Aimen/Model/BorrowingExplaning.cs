using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BorrowingExplaning : BaseEntity
    {
        private Borrowing codeBorrow;
        private BookToBorrow bookToBorrow1;
        
        private DateTime returningTime;

        public Borrowing CodeBorrow { get => codeBorrow; set => codeBorrow = value; }

        public BookToBorrow BookToBorrow1 { get => bookToBorrow1; set => bookToBorrow1 = value; }
        
        public DateTime ReturningTime { get => returningTime; set => returningTime = value; }
       

        public override string[] GetKeyFields()
        {
            return new string[] { "CodeBorrow", "BookToBorrow1" };
        }
        public override string GetTableName()
        {
            return "BorrowingExplaning";
        }
        public override string ToString()
        {
            return CodeBorrow.ToString();
        }
    }
}
