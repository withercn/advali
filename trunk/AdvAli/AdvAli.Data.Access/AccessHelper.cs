using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web;

namespace AdvAli.Data
{
    public sealed class AccessHelper
    {
        private static void CloseConnection(OleDbConnection Conn)
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        private static OleDbConnection CreateConn()
        {
            AppSettingsReader reader = new AppSettingsReader();
            return new OleDbConnection(reader.GetValue("ConnString", typeof(string)).ToString().Replace("Data Source=", "Data Source=" + HttpContext.Current.Server.MapPath("~/") + "/"));
        }

        public static OleDbDataReader ExecuteReader(string commandText)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            OleDbDataReader reader = null;
            try
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                OpenConnection(conn);
                reader = command.ExecuteReader();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
            }
            finally
            {
                CloseConnection(conn);
            }
            return reader;
        }

        public static OleDbDataReader ExecuteReader(string commandText, OleDbParameter[] parameters)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            OleDbDataReader reader = null;
            try
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                foreach (OleDbParameter parameter in parameters)
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
            finally
            {
                CloseConnection(conn);
            }
            return reader;
        }

        public static OleDbParameter MakeInParam(string ParamName, OleDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static OleDbParameter MakeParam(string ParamName, OleDbType DbType, int Size, ParameterDirection Direction, object Value)
        {
            OleDbParameter parameter = new OleDbParameter();
            if (Size > 0)
            {
                parameter = new OleDbParameter(ParamName, DbType, Size);
            }
            else
            {
                parameter = new OleDbParameter(ParamName, DbType);
            }
            parameter.Direction = Direction;
            if ((Direction != ParameterDirection.Output) || (Value != null))
            {
                parameter.Value = Value;
            }
            return parameter;
        }

        private static void OpenConnection(OleDbConnection Conn)
        {
            if (Conn.State != ConnectionState.Open)
            {
                Conn.Open();
            }
        }

        public static DataSet RunParamedSqlGetDataSet(string commandText, OleDbParameter[] parameters)
        {
            OleDbCommand selectCommand = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            try
            {
                selectCommand.Connection = conn;
                selectCommand.CommandType = CommandType.Text;
                selectCommand.CommandText = commandText;
                foreach (OleDbParameter parameter in parameters)
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

        public static object RunParamedSqlGetFirstCellValue(string commandText, OleDbParameter[] parameters)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            object obj2 = null;
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = commandText;
            foreach (OleDbParameter parameter in parameters)
            {
                parameter.Direction = ParameterDirection.Input;
                command.Parameters.Add(parameter);
            }
            OpenConnection(conn);
            obj2 = command.ExecuteScalar();
            command.Parameters.Clear();
            CloseConnection(conn);
            return obj2;
        }

        public static int RunParamedSqlReturnAffectedRowNum(string commandText, OleDbParameter[] parameters)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            int num = -100;
            command.CommandType = CommandType.Text;
            command.Connection = conn;
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = commandText;
            foreach (OleDbParameter parameter in parameters)
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
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            int num = 0;
            try
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                OpenConnection(conn);
                num = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
            }
            finally
            {
                CloseConnection(conn);
            }
            return num;
        }

        public static DataSet RunSqlGetDataSet(string commandText)
        {
            OleDbCommand selectCommand = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            try
            {
                selectCommand.Connection = conn;
                selectCommand.CommandType = CommandType.Text;
                selectCommand.CommandText = commandText;
                OpenConnection(conn);
                adapter.Fill(dataSet);
                selectCommand.Parameters.Clear();
            }
            catch (Exception)
            {
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
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = CreateConn();
            object obj2 = null;
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
            finally
            {
                CloseConnection(conn);
            }
            return obj2;
        }

        public static int RunSqlReturnAffectedRowNum(string commandText)
        {
            OleDbConnection conn = CreateConn();
            OleDbCommand command = new OleDbCommand();
            int num = -100;
            try
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                OpenConnection(conn);
                num = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (OleDbException)
            {
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
                        return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName + " where 1=1 " + strWhere);
                    }
                    return ("select top " + pagesize.ToString() + " " + columnList + "  from " + tableName);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("select top " + pagesize.ToString() + " " + columnList + " from " + tableName + " where AutoId>(");
            builder.Append("select max(AutoId) from (select top " + Convert.ToString((int)(pagesize * (pageindex - 1))) + " AutoId from " + tableName);
            if (string.IsNullOrEmpty(strWhere))
            {
                builder.Append(" order by [AutoId] asc))  order by [AutoId] asc");
            }
            else
            {
                builder.Append(" where 1=1 " + strWhere + " order by [AutoId] asc)) " + strWhere + " order by [AutoId] asc");
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
