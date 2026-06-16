using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Publish : BaseEntity
    {
        private int codePublish;
        private string namePublish;

        public int CodePublish { get => codePublish; set => codePublish = value; }
        public string NamePublish { get => namePublish; set => namePublish = value; }
        public override string[] GetKeyFields()
        {
            return new string[] { "CodePublish" };
        }
        public override string GetTableName()
        {
            return "Publish";
        }
        public override string ToString()
        {
            return CodePublish.ToString();
        }
    }
}
