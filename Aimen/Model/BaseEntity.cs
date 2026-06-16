using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class BaseEntity
    {
        public abstract string GetTableName();
        public abstract string[] GetKeyFields();
        public string GetKeyValues()
        {
            string result = "";
            foreach (var key in GetKeyFields())
            {

                if (result.Length > 0)
                    result += ", ";
                PropertyInfo keyProperty = this.GetType().GetProperty(key);
                object keyValue = keyProperty.GetValue(this);
                if (keyValue is string)
                    result += "'" + keyValue + "'";
                else
                    result += keyValue;
            }
            return result;
        }
    }
}
