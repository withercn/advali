using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using AdvAli.Log;

namespace AdvAli.Data
{
    public sealed class SqlHelper
    {
        private static void CloseConnection(SqlConnection Conn)
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        private static SqlConnection CreateConn()
        {
            AppSettingsReader reader = new AppSettingsReader();
            return new SqlConnection(reader.GetValue("ConnString", typeof(string)).ToString().Replace("Data Source=", "Data Source=" + HttpContext.Current.Server.MapPath("~/") + "/"));
        }

        public static SqlDataReader ExecuteReader(string commandText)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = CreateConn();
            SqlDataReader reader = null;
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

        public static SqlDataReader ExecuteReader(string commandText, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = CreateConn();
            SqlDataReader reader = null;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    foreach (SqlParameter parameter in parameters)
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

        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, ParameterDirection Direction, object Value)
        {
            SqlParameter parameter = new SqlParameter();
            if (Size > 0)
            {
                parameter = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                parameter = new SqlParameter(ParamName, DbType);
            }
            parameter.Direction = Direction;
            if ((Direction != ParameterDirection.Output) || (Value != null))
            {
                parameter.Value = Value;
            }
            return parameter;
        }

        private static void OpenConnection(SqlConnection Conn)
        {
            if (Conn.State != ConnectionState.Open)
            {
                Conn.Open();
            }
        }

        public static DataSet RunParamedSqlGetDataSet(string commandText, SqlParameter[] parameters)
        {
            SqlCommand selectCommand = new SqlCommand();
            SqlConnection conn = CreateConn();
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            selectCommand.Connection = conn;
            selectCommand.CommandType = CommandType.Text;
            selectCommand.CommandText = commandText;
            foreach (SqlParameter parameter in parameters)
            {
                parameter.Direction = ParameterDirection.Input;
                selectCommand.Parameters.Add(parameter);
            }
            try
            {
                OpenConnection(conn);
                adapter.Fill(dataSet);
                selectCommand.Parameters.Clear();
                CloseConnection(conn);
            }
            catch
            {
                //LogManager.WriteLog(LogFile.Trace,string.Format("cmd={0}\r\n
                string loggis = string.Format("SqlCommand = {0}\r\n", selectCommand.CommandText);
                int i = 0;
                foreach (SqlParameter sp in parameters)
                {
                    loggis += string.Format("SqlParamters[{0}] = {1}, Values = {2}",i,sp.ParameterName,sp.Value);
                }
                LogManager.WriteLog(LogFile.Trace, loggis);
            }
            if (dataSet == null)
            {
                HttpContext.Current.Response.Write("RunParamedSqlGetDataSet|" + commandText.ToString() + "|空值");
            }
            return dataSet;
        }

        public static object RunParamedSqlGetFirstCellValue(string commandText, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = CreateConn();
            object obj2 = null;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
                    foreach (SqlParameter parameter in parameters)
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

        public static int RunParamedSqlReturnAffectedRowNum(string commandText, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = CreateConn();
            int num = -100;
            command.CommandType = CommandType.Text;
            command.Connection = conn;
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = commandText.Replace("[", "").Replace("]", "");
            foreach (SqlParameter parameter in parameters)
            {
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);
            }
            OpenConnection(conn);
            num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            CloseConnection(conn);
            return num;
        }

        public static int RunSqlExecuteNonQuery(string commandText)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection conn = CreateConn();
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
            SqlCommand selectCommand = new SqlCommand();
            SqlConnection conn = CreateConn();
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
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
            SqlCommand command = new SqlCommand();
            SqlConnection conn = CreateConn();
            object obj2 = null;
            try
            {
                try
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText.Replace("[", "").Replace("]", "");
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
            SqlConnection conn = CreateConn();
            SqlCommand command = new SqlCommand();
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
                catch (SqlException)
                {
                }
            }
            finally
            {
                CloseConnection(conn);
            }
            return num;
        }

        public static string SqlBuilder(string tableName, string columnList, string strWhere, int pagesize, int pageindex, string orderCol)
        {
            switch (pageindex)
            {
                case 0:
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        return ("select " + columnList + "  from " + tableName + " where 1=1 " + strWhere);
                    }
                    return ("select " + columnList + "  from " + tableName);

                case 1:
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        if (string.IsNullOrEmpty(orderCol))
                        {
                            return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " where 1=1 " + strWhere);
                        }
                        if (columnList == "count(*)")
                        {
                            return ("select " + columnList + "  from " + tableName + " where 1=1 " + strWhere);
                        }
                        return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " where 1=1 " + strWhere + " order by " + orderCol + " desc");
                    }
                    if (!string.IsNullOrEmpty(orderCol))
                    {
                        if (columnList == "count(*)")
                        {
                            return ("select " + columnList + "  from " + tableName);
                        }
                        return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " order by " + orderCol + " desc");
                    }
                    return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("select top ");
            builder.Append(pagesize.ToString());
            builder.Append(" ");
            builder.Append(columnList);
            builder.Append(" from ");
            builder.Append(tableName);
            builder.Append(" where AutoId not in");
            builder.Append("(select top ");
            builder.Append((pagesize * (pageindex - 1)).ToString());
            builder.Append(" AutoId from ");
            builder.Append(tableName);
            builder.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(orderCol))
            {
                builder.Append(" order by ");
                builder.Append(orderCol);
                builder.Append(" desc");
            }
            builder.Append(") and AutoId in");
            builder.Append("(select top ");
            builder.Append((pagesize * pageindex).ToString());
            builder.Append(" AutoId from ");
            builder.Append(tableName);
            builder.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(orderCol))
            {
                builder.Append(" order by ");
                builder.Append(orderCol);
                builder.Append(" desc");
            }
            builder.Append(")");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(orderCol))
            {
                builder.Append(" order by ");
                builder.Append(orderCol);
                builder.Append(" desc");
            }
            return builder.ToString();
        }

        public static string SqlBuilder(string tableName, string columnList, string strWhere, int pagesize, int pageindex, string orderCol, bool isAsc)
        {
            switch (pageindex)
            {
                case 0:
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        return ("select " + columnList + "  from " + tableName + " where 1=1 " + strWhere);
                    }
                    return ("select " + columnList + "  from " + tableName);

                case 1:
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        if (string.IsNullOrEmpty(orderCol))
                        {
                            return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " where 1=1 " + strWhere);
                        }
                        if (columnList == "count(*)")
                        {
                            return ("select " + columnList + "  from " + tableName + " where 1=1 " + strWhere);
                        }
                        if (!isAsc)
                        {
                            return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " where 1=1 " + strWhere + " order by " + orderCol + " desc");
                        }
                        return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " where 1=1 " + strWhere + " order by " + orderCol + " asc");
                    }
                    if (!string.IsNullOrEmpty(orderCol))
                    {
                        if (columnList == "count(*)")
                        {
                            return ("select " + columnList + "  from " + tableName);
                        }
                        if (!isAsc)
                        {
                            return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " order by " + orderCol + " desc");
                        }
                        return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " order by " + orderCol + " asc");
                    }
                    return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("select top ");
            builder.Append(pagesize.ToString());
            builder.Append(" ");
            builder.Append(columnList);
            builder.Append(" from ");
            builder.Append(tableName);
            builder.Append(" where AutoId not in");
            builder.Append("(select top ");
            builder.Append((pagesize * (pageindex - 1)).ToString());
            builder.Append(" AutoId from ");
            builder.Append(tableName);
            builder.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(orderCol))
            {
                if (!isAsc)
                {
                    builder.Append(" order by ");
                    builder.Append(orderCol);
                    builder.Append(" desc");
                }
                else
                {
                    builder.Append(" order by ");
                    builder.Append(orderCol);
                    builder.Append(" asc");
                }
            }
            builder.Append(") and AutoId in");
            builder.Append("(select top ");
            builder.Append((pagesize * pageindex).ToString());
            builder.Append(" AutoId from ");
            builder.Append(tableName);
            builder.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(orderCol))
            {
                if (!isAsc)
                {
                    builder.Append(" order by ");
                    builder.Append(orderCol);
                    builder.Append(" desc");
                }
                else
                {
                    builder.Append(" order by ");
                    builder.Append(orderCol);
                    builder.Append(" asc");
                }
            }
            builder.Append(")");
            if (!string.IsNullOrEmpty(strWhere))
            {
                builder.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(orderCol))
            {
                if (!isAsc)
                {
                    builder.Append(" order by ");
                    builder.Append(orderCol);
                    builder.Append(" desc");
                }
                else
                {
                    builder.Append(" order by ");
                    builder.Append(orderCol);
                    builder.Append(" asc");
                }
            }
            return builder.ToString();
        }
    }
}
