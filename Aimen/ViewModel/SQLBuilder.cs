using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace ViewModel
{
    static class SQLConverter
    {
        public static string ToSQLString(this object value)
        {
            if (value is int || value is double || value is bool)
                return value.ToString();
            if (value is string)
                return "'" + value + "'";
            if (value is DateTime date)
                return date.ToString("#dd/MM/yyyy HH:mm:ss#");
            if (value is TimeSpan time)
                return "#" + time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + "#";
            return value.ToString();
        }
    }
}

class SQLBuilder
{
    public static (string sql, List<OleDbParameter> parameters) InsertSQLWithParams(BaseEntity entity)
    {
        Type type = entity.GetType();
        string command = "Insert Into " + entity.GetTableName() + " (";
        string values = " Values (";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        int paramIndex = 0;

        foreach (var item in type.GetProperties())
        {
            string name = item.Name;
            object value = item.GetValue(entity);

            if (value != null)
            {
                if (value is BaseEntity baseEntity)
                {
                    for (int i = 0; i < baseEntity.GetKeyFields().Length && i < 3; i++)
                    {
                        string k = baseEntity.GetKeyFields()[i];
                        command += k + ", ";
                        values += "?, ";
                        object keyValue = value.GetType().GetProperty(k).GetValue(value);
                        parameters.Add(new OleDbParameter("@p" + paramIndex++, keyValue ?? DBNull.Value));
                    }
                }
                else
                {
                    command += name + ", ";
                    values += "?, ";
                    parameters.Add(new OleDbParameter("@p" + paramIndex++, value ?? DBNull.Value));
                }
            }
        }

        command = command.Substring(0, command.Length - 2) + ")";
        values = values.Substring(0, values.Length - 2) + ")";
        return (command + values, parameters);
    }

    public static (string sql, List<OleDbParameter> parameters) UpdateSQLWithParams(BaseEntity entity)
    {
        Type type = entity.GetType();
        string command = "Update " + entity.GetTableName() + " set ";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        int paramIndex = 0;

        foreach (var item in type.GetProperties())
        {
            string name = item.Name;
            var value = item.GetValue(entity);

            if (value != null && !entity.GetKeyFields().Contains(name))
            {
                if (value is BaseEntity entityValue)
                {
                    string k = entityValue.GetKeyFields()[0];
                    command += k + " = ?, ";
                    object keyValue = value.GetType().GetProperty(k).GetValue(value);
                    parameters.Add(new OleDbParameter("@p" + paramIndex++, keyValue ?? DBNull.Value));
                }
                else
                {
                    command += name + " = ?, ";
                    parameters.Add(new OleDbParameter("@p" + paramIndex++, value ?? DBNull.Value));
                }
            }
        }

        string where = "";
        foreach (var item in entity.GetKeyFields())
        {
            if (where != "")
                where += " And ";

            object value = entity.GetType().GetProperty(item).GetValue(entity);
            if (value is BaseEntity entityValue)
            {
                string k = entityValue.GetKeyFields()[0];
                where += k + " = ?";
                object keyValue = value.GetType().GetProperty(k).GetValue(value);
                parameters.Add(new OleDbParameter("@p" + paramIndex++, keyValue ?? DBNull.Value));
            }
            else
            {
                where += item + " = ?";
                parameters.Add(new OleDbParameter("@p" + paramIndex++, value ?? DBNull.Value));
            }
        }

        command = command.Substring(0, command.Length - 2) + " Where " + where;
        return (command, parameters);
    }

    public static (string sql, List<OleDbParameter> parameters) DeleteSQLWithParams(BaseEntity entity)
    {
        string command = "Delete From " + entity.GetTableName() + " Where ";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        string where = "";
        int paramIndex = 0;

        foreach (var item in entity.GetKeyFields())
        {
            if (where != "")
                where += " And ";
            where += item + " = ?";
            object value = entity.GetType().GetProperty(item).GetValue(entity);
            parameters.Add(new OleDbParameter("@p" + paramIndex++, value ?? DBNull.Value));
        }

        return (command + where, parameters);
    }

    public static (string sql, List<OleDbParameter> parameters) DeleteStatusSQLWithParams(BaseEntity entity)
    {
        Type type = entity.GetType();
        string command = "Update " + entity.GetTableName() + " set ";
        List<OleDbParameter> parameters = new List<OleDbParameter>();
        int paramIndex = 0;

        foreach (var item in type.GetProperties())
        {
            string name = item.Name;
            var value = item.GetValue(entity);

            if (value != null && !entity.GetKeyFields().Contains(name))
            {
                if (value is BaseEntity entityValue)
                {
                    string k = entityValue.GetKeyFields()[0];
                    command += k + " = ?, ";
                    object keyValue = value.GetType().GetProperty(k).GetValue(value);
                    parameters.Add(new OleDbParameter("@p" + paramIndex++, keyValue ?? DBNull.Value));
                }
                else if (value is bool)
                {
                    command += name + " = ?, ";
                    parameters.Add(new OleDbParameter("@p" + paramIndex++, false));
                }
                else
                {
                    command += name + " = ?, ";
                    parameters.Add(new OleDbParameter("@p" + paramIndex++, value ?? DBNull.Value));
                }
            }
        }

        string where = "";
        foreach (var item in entity.GetKeyFields())
        {
            if (where != "")
                where += " And ";
            object value = entity.GetType().GetProperty(item).GetValue(entity);
            where += item + " = ?";
            parameters.Add(new OleDbParameter("@p" + paramIndex++, value ?? DBNull.Value));
        }

        command = command.Substring(0, command.Length - 2) + " Where " + where;
        return (command, parameters);
    }

    public static string InsertSQL(BaseEntity entity)
    {
        Type type = entity.GetType();
        string command = "Insert Into " + entity.GetTableName() + " (";
        string values = " Values (";
        foreach (var item in type.GetProperties())
        {
            string name = item.Name;
            object value = item.GetValue(entity);
            string k = "";

            if (value != null)
            {
                if (value is BaseEntity)
                {
                    k += (value as BaseEntity).GetKeyFields()[0];
                    if ((value as BaseEntity).GetKeyFields().Length > 1)
                        k += ", " + (value as BaseEntity).GetKeyFields()[1];
                    if ((value as BaseEntity).GetKeyFields().Length > 2)
                        k += ", " + ((value as BaseEntity).GetKeyFields()[2]);
                    command += k + ", ";
                    values += (value as BaseEntity).GetKeyValues();
                }
                else
                {
                    command += name + ", ";
                    values += value.ToSQLString();
                }
                values += ", ";
            }
        }
        command = command.Substring(0, command.Length - 2) + ")";
        values = values.Substring(0, values.Length - 2) + ")";
        return command + values;
    }

    public static string UpdateSQL(BaseEntity entity)
    {
        Type type = entity.GetType();
        string command = "Update " + entity.GetTableName() + " set ";
        foreach (var item in type.GetProperties())
        {
            string name = item.Name;
            var value = item.GetValue(entity);

            if (value != null)
            {
                if (!entity.GetKeyFields().Contains(name))
                {
                    if (value is BaseEntity entityValue)
                    {
                        string k = entityValue.GetKeyFields()[0];
                        command += k + " = ";

                        object keyValue = value.GetType().GetProperty(k).GetValue(value);

                        if (keyValue is string)
                            value = "'" + keyValue + "'";
                        else
                            value = keyValue;

                        command += value + ", ";
                    }
                    else
                    {
                        command += name + " = " + value.ToSQLString() + " , ";
                    }
                }
            }
        }

        string where = string.Empty;
        foreach (var item in entity.GetKeyFields())
        {
            if (where != string.Empty)
                where += " And ";

            object value;
            value = entity.GetType().GetProperty(item).GetValue(entity);

            if (value is BaseEntity entityValue)
            {
                string k = entityValue.GetKeyFields()[0];
                where += k + " = ";

                object keyValue = value.GetType().GetProperty(k).GetValue(value);

                if (keyValue is string)
                    value = "'" + keyValue + "'";
                else
                    value = keyValue.ToSQLString();

                where += value + "";
            }
            else
            {
                where += item + " = " + value.ToSQLString() + "";
            }
        }
        command = command.Substring(0, command.Length - 2) + " Where " + where;
        return command;
    }

    public static string DeleteSQL(BaseEntity entity)
    {
        Type type = entity.GetType();
        string command = "Delete From " + entity.GetTableName() + " Where ";
        string where = string.Empty;
        foreach (var item in entity.GetKeyFields())
        {
            if (where != string.Empty)
                where += " And ";
            object value = entity.GetType().GetProperty(item).GetValue(entity);
            where += item + " = " + value.ToSQLString();
        }
        command += where;
        return command;
    }

    public static string DeleteStatusSQL(BaseEntity entity)
    {
        Type type = entity.GetType();
        string command = "Update " + entity.GetTableName() + " set ";
        foreach (var item in type.GetProperties())
        {
            string name = item.Name;
            var value = item.GetValue(entity);

            if (value != null)
            {
                if (!entity.GetKeyFields().Contains(name))
                {
                    if (value is BaseEntity entityValue)
                    {
                        string k = entityValue.GetKeyFields()[0];
                        command += k + " = ";

                        object keyValue = value.GetType().GetProperty(k).GetValue(value);

                        if (keyValue is string)
                            value = "'" + keyValue + "'";
                        else
                            value = keyValue;

                        command += value + ", ";
                    }
                    else
                        if (value is bool)
                        command += name + " = " + false + ", ";
                    else
                    {
                        command += name + " = " + value.ToSQLString() + " , ";
                    }
                }
            }
        }

        string where = string.Empty;
        foreach (var item in entity.GetKeyFields())
        {
            if (where != string.Empty)
                where += " And ";
            object value = entity.GetType().GetProperty(item).GetValue(entity);
            if (value is string)
                where += item + " = '" + value + "' ";
            else
                where += item + " = " + value;
        }
        command = command.Substring(0, command.Length - 2) + " Where " + where;
        return command;
    }
}
