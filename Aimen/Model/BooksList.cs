using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BooksList : BaseEntity
    {
        private int codeBook;
        private string nameBook;
        private Publish codePublish;
        private int copies;
        private bool statusBook;
        private string imagb;

        public int CodeBook { get => codeBook; set => codeBook = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public Publish CodePublish { get => codePublish; set => codePublish = value; }
        public int Copies { get => copies; set => copies = value; }
        public bool StatusBook { get => statusBook; set => statusBook = value; }
        public string Imagb { get => imagb; set => imagb = value; }

        public override string[] GetKeyFields()
        {
            return new string[] { "CodeBook" };
        }
        public override string GetTableName()
        {
            return "BooksList";
        }
        public override string ToString()
        {
            return CodeBook.ToString();
        }
    }
}
