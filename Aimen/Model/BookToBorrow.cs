using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookToBorrow : BaseEntity
    {
        private BooksList codeBook;
        private int codeSidoory;
        private bool statusToBorrow;

        public BooksList CodeBook { get => codeBook; set => codeBook = value; }
        public int CodeSidoory { get => codeSidoory; set => codeSidoory = value; }
        public bool StatusToBorrow { get => statusToBorrow; set => statusToBorrow = value; }
        

        public override string[] GetKeyFields()
        {
            return new string[] { "CodeBook", "CodeSidoory" };
        }
        public override string GetTableName()
        {
            return "BookToBorrow";
        }
        public override string ToString()
        {
            return  CodeBook.ToString();
        }
    }
}
