using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web;

namespace AdvAli.Data
{
    public sealed class MySqlHelper
    {
        private static void CloseConnection(MySqlConnection Conn)
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        private static MySqlConnection CreateConn()
        {
            AppSettingsReader reader = new AppSettingsReader();
            return new MySqlConnection(reader.GetValue("ConnString", typeof(string)).ToString().Replace("Data Source=", "Data Source=" + HttpContext.Current.Server.MapPath("~/") + "/"));
        }

        public static MySqlDataReader ExecuteReader(string commandText)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            MySqlDataReader reader = null;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    OpenConnection(conn);
                    reader = command.ExecuteReader();
                    command.Parameters.Clear();
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return reader;
        }

        public static MySqlDataReader ExecuteReader(string commandText, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            MySqlDataReader reader = null;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    foreach (MySqlParameter parameter in parameters)
                    {
                        parameter.Direction = ParameterDirection.Input;
                        command.Parameters.Add(parameter);
                    }
                    OpenConnection(conn);
                    reader = command.ExecuteReader();
                    command.Parameters.Clear();
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return reader;
        }

        public static MySqlParameter MakeInParam(string ParamName, MySqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static MySqlParameter MakeParam(string ParamName, MySqlDbType DbType, int Size, ParameterDirection Direction, object Value)
        {
            MySqlParameter parameter = new MySqlParameter();
            if (Size > 0)
            {
                parameter = new MySqlParameter(ParamName, DbType, Size);
            }
            else
            {
                parameter = new MySqlParameter(ParamName, DbType);
            }
            parameter.Direction = Direction;
            if ((Direction != ParameterDirection.Output) || (Value != null))
            {
                parameter.Value = Value;
            }
            return parameter;
        }

        private static void OpenConnection(MySqlConnection Conn)
        {
            if (Conn.State != ConnectionState.Open)
            {
                Conn.Open();
            }
        }

        public static DataSet RunParamedSqlGetDataSet(string commandText, MySqlParameter[] parameters)
        {
            MySqlCommand selectCommand = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            try
            {
                try
                {
                    selectCommand.Connection = conn;
                    selectCommand.CommandType = CommandType.Text;
                    selectCommand.CommandText = commandText.Replace("[", "").Replace("]", "");
                    foreach (MySqlParameter parameter in parameters)
                    {
                        parameter.Direction = ParameterDirection.Input;
                        selectCommand.Parameters.Add(parameter);
                    }
                    OpenConnection(conn);
                    adapter.Fill(dataSet);
                    selectCommand.Parameters.Clear();
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            if (dataSet == null)
            {
                HttpContext.Current.Response.Write("RunParamedSqlGetDataSet|" + commandText.ToString() + "|空值");
            }
            return dataSet;
        }

        public static object RunParamedSqlGetFirstCellValue(string commandText, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            object obj2 = null;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    foreach (MySqlParameter parameter in parameters)
                    {
                        parameter.Direction = ParameterDirection.Input;
                        command.Parameters.Add(parameter);
                    }
                    OpenConnection(conn);
                    obj2 = command.ExecuteScalar();
                    command.Parameters.Clear();
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return obj2;
        }

        public static int RunParamedSqlReturnAffectedRowNum(string commandText, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            int num = -100;
            command.CommandType = CommandType.Text;
            command.Connection = conn;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    foreach (MySqlParameter parameter in parameters)
                    {
                        parameter.Direction = ParameterDirection.Input;
                        command.Parameters.Add(parameter);
                    }
                    OpenConnection(conn);
                    num = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                catch (MySqlException)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return num;
        }

        public static int RunSqlExecuteNonQuery(string commandText)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            int num = 0;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    OpenConnection(conn);
                    num = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return num;
        }

        public static DataSet RunSqlGetDataSet(string commandText)
        {
            MySqlCommand selectCommand = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            try
            {
                try
                {
                    selectCommand.Connection = conn;
                    selectCommand.CommandType = CommandType.Text;
                    selectCommand.CommandText = commandText.Replace("[", "").Replace("]", "");
                    OpenConnection(conn);
                    adapter.Fill(dataSet);
                    selectCommand.Parameters.Clear();
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            if (dataSet == null)
            {
                HttpContext.Current.Response.Write("RunSqlGetDataSet|" + commandText.ToString() + "|空值");
            }
            return dataSet;
        }

        public static object RunSqlGetFirstCellValue(string commandText)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection conn = CreateConn();
            object obj2 = null;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    OpenConnection(conn);
                    obj2 = command.ExecuteScalar();
                    command.Parameters.Clear();
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return obj2;
        }

        public static int RunSqlReturnAffectedRowNum(string commandText)
        {
            MySqlConnection conn = CreateConn();
            MySqlCommand command = new MySqlCommand();
            int num = -100;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    OpenConnection(conn);
                    num = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                catch (MySqlException)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return num;
        }
    }
}
