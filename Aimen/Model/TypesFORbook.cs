using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TypesFORbook : BaseEntity
    {
        private BooksList codeBook;
        private KindsOfBook codeKindOfBook;

        public BooksList CodeBook { get => codeBook; set => codeBook = value; }
        public KindsOfBook CodeKindOfBook { get => codeKindOfBook; set => codeKindOfBook = value; }
        public override string[] GetKeyFields()
        {
            return new string[] { "CodeBook", "CodeKindOfBook" };
        }
        public override string GetTableName()
        {
            return "TypesFORbook";
        }
        public override string ToString()
        {
            return CodeBook.ToString()+""+CodeKindOfBook.ToString();
        }
    }
}
