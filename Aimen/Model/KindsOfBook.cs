using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KindsOfBook : BaseEntity
    {
        private int codeKindOfBook;
        private string nameKindOfBook;

        public int CodeKindOfBook { get => codeKindOfBook; set => codeKindOfBook = value; }
        public string NameKindOfBook { get => nameKindOfBook; set => nameKindOfBook = value; }
        public override string[] GetKeyFields()
        {
            return new string[] { "CodeKindOfBook" };
        }
        public override string GetTableName()
        {
            return "KindsOfBook";
        }
        public override string ToString()
        {
            return CodeKindOfBook.ToString();
        }
    }
}
