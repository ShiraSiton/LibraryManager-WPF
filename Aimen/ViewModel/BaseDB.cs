using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using  Model;
namespace ViewModel
{
    public abstract class BaseDB
    {
        protected string connectionString;
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;
        protected List<BaseEntity> list=null;
        protected string tableName;
        protected List<BaseEntity> lstInserted = new List<BaseEntity>();
        protected List<BaseEntity> lstChanged = new List<BaseEntity>();
        protected List<BaseEntity> lstDeleted = new List<BaseEntity>();
        protected List<BaseEntity> lstDeleteStaus = new List<BaseEntity>();
        public BaseDB(string tableName)
        {
            //פעולה בונה
            this.tableName = tableName;
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + GetCurrentPath() ;
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand
            {
                Connection = connection,
                CommandText = "Select * From " + tableName
            };
            list = Select();
           
        }

        public List<BaseEntity> GetListBySelectContain(string nameField, string st)
        {
            //פעולה המחזירה רשימה של כל העצמים  שבשדה הנבחר מכילים את הטקסט שבמחרוזת
            List<BaseEntity> listResult = new List<BaseEntity>();

            foreach (BaseEntity item in list)
            {
                object value = item.GetType().GetProperty(nameField).GetValue(item);

            
                    if (value.ToString().Contains(st))
                        listResult.Add(item);
               
            }
            return listResult;
        }



        public List<BaseEntity> GetListBySelect(string nameField, string st)
        {


            //פעולה המחזירה רשימה של כל העצמים  שהשדה הנבחר מתחיל בטקסט שבמחרוזת
            object value = "";
            List<BaseEntity> listResult = new List<BaseEntity>();

            foreach (BaseEntity item in list)
            {

               
                value = item.GetType().GetProperty(nameField).GetValue(item, null);

                if (value.ToString().StartsWith(st))
                    listResult.Add(item);

            }
            return listResult;
        }
       public List<BaseEntity> List()
        {
            //פעולה המחזירה רשימה של כל העצמים 
            command.CommandText = "Select * From " + tableName;
           list =Select();
            return list;
        }
        private List<BaseEntity> Select()
        {
            //פעולת עזר השופכת את רשומות הטבלה של בסיס הנתונים לרשימה 
            List<BaseEntity> lst = new List<BaseEntity>();
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                    lst.Add(CreateModel());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Select Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return lst;
          
        }
        public abstract BaseEntity CreateModel();
        private string GetCurrentPath()
        {
            //פעולה המחזירה את המסלול של בסיס הנתונים היכן שהוא נשמר בפרויקט
            string path = System.IO.Directory.GetCurrentDirectory();
                int x = path.IndexOf("\\Host");
                path = path.Substring(0, x) + "\\Data\\MyAccess.accdb";
                return path;
            
        }
       
        public void Insert(BaseEntity item)
        {
            // שמירת כל העצמים שיש להוסיף לבסיס הנתונים ברשימת עזר 
            if (item != null)
            {
                lstInserted.Add(item);
                list.Add(item);
            }
        }
        public void Update(BaseEntity item)
        {
            // שמירת כל העצמים שיש לעדכן בבסיס הנתונים ברשימת עזר 
            if (item != null)
                lstChanged.Add(item);
        }

        public void Delete(BaseEntity item)
        {
            // שמירת כל העצמים שיש למחוק מבסיס הנתונים ברשימת עזר 
            if (item != null)
                lstDeleted.Add(item);
        }

        public void DeleteStatus(BaseEntity item)
        {
            // שמירת כל העצמים שיש לשנות להם את הסטטוס בבסיס הנתונים ברשימת עזר 
            if (item != null)
                lstDeleteStaus.Add(item);
        }
        public int SaveChanges()
        {
            // ביצוע כל השינויים שנשמרו ברשימות העזר בתוך בסיס הנתונים השמור חיצונית  
            int records = 0;
            
                try
                {
                    command.Connection = connection;
                    connection.Open();

                    foreach (var item in lstInserted)
                    {
                        var (sql, parameters) = SQLBuilder.InsertSQLWithParams(item);
                        command.CommandText = sql;
                        command.Parameters.Clear();
                        foreach (var p in parameters)
                            command.Parameters.Add(p);
                        records += command.ExecuteNonQuery();
                       
                    }
                    lstInserted.Clear();

                    foreach (var item in lstChanged)
                    {
                        var (sql, parameters) = SQLBuilder.UpdateSQLWithParams(item);
                        command.CommandText = sql;
                        command.Parameters.Clear();
                        foreach (var p in parameters)
                            command.Parameters.Add(p);
                        records += command.ExecuteNonQuery();

                  
                    }
                    lstChanged.Clear();

                    foreach (var item in lstDeleted)
                    {
                        var (sql, parameters) = SQLBuilder.DeleteSQLWithParams(item);
                        command.CommandText = sql;
                        command.Parameters.Clear();
                        foreach (var p in parameters)
                            command.Parameters.Add(p);
                        records += command.ExecuteNonQuery();
                        
                    }
                    lstDeleted.Clear();
                    foreach (var item in lstDeleteStaus)
                    { 
                        var (sql, parameters) = SQLBuilder.DeleteStatusSQLWithParams(item);
                        command.CommandText = sql;
                        command.Parameters.Clear();
                        foreach (var p in parameters)
                            command.Parameters.Add(p);
                        records += command.ExecuteNonQuery();
                   
                       
                    }
                lstDeleteStaus.Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "\n DataBase:" + command.CommandText);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            list = List();
            return records;
        }
       
    }
}
