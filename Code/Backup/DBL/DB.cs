using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBL
{
    public class DB
    {
        SqlConnection SqlCon;
        SqlCommand SqlCmd;
        SqlDataAdapter SqlDa;
        SqlDataReader SqlDr;
        DataTable Dt;
        DataSet Ds;

        private static String ConnectionString = @"Data Source=.;Initial Catalog=DB_Agency;Integrated Security=True";

        public DB(String ConnectionString)
        {
            try
            {
                DB.ConnectionString = "";

                if (!String.IsNullOrEmpty(ConnectionString))
                    DB.ConnectionString = ConnectionString;

                SqlCon = new SqlConnection();
                SqlCon.ConnectionString = DB.ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//Class Constructor
        public DB()
        {
            try
            {
                SqlCon = new SqlConnection();
                SqlCon.ConnectionString = DB.ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ~DB()
        {
            SqlCon = null;
            SqlCmd = null;
            SqlDa = null;
            SqlDr = null;
            Ds = null;
        }// Class Destructor
        public void Open()
        {
            try
            {
                if (SqlCon.State != ConnectionState.Open)
                    SqlCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//Open
        public void Close()
        {
            try
            {
                if (SqlCon.State != ConnectionState.Closed)
                {
                    SqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //SqlCon.Dispose();
            }
        }//Close
        public Int32 ExecuteNonQuery(string SP, SqlParameter[] Parameters)
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                SqlCmd.Parameters.AddRange(Parameters);
                SqlParameter RetVal = SqlCmd.Parameters.Add("@@identity", SqlDbType.Int);
                RetVal.Direction = ParameterDirection.ReturnValue;
                SqlCmd.ExecuteNonQuery();
                Int32 ID = Int32.Parse(SqlCmd.Parameters["@@identity"].Value.ToString());
                Close();
                return ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }// ExecuteNonQuery

        public Int32 ExecuteNonQuery(string SP)
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                SqlParameter RetVal = SqlCmd.Parameters.Add("@@identity", SqlDbType.Int);
                RetVal.Direction = ParameterDirection.ReturnValue;
                SqlCmd.ExecuteNonQuery();
                Int32 ID = Int32.Parse(SqlCmd.Parameters["@@identity"].Value.ToString());
                Close();
                return ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }// ExecuteNonQuery

        public object ExecuteScalar(String SP, SqlParameter[] Parameters)
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                SqlCmd.Parameters.AddRange(Parameters);
                object RetVal = SqlCmd.ExecuteScalar();
                Close();
                return RetVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // ExecuteScalar
        public object ExecuteScalar(String SP)
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                object RetVal = SqlCmd.ExecuteScalar();
                Close();
                return RetVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // ExecuteScalar
        public SqlDataReader ReturnDataReader(string SP, SqlParameter[] Parameters)
        {
            try
            {
                Open();

                //Define Command
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddRange(Parameters); //Add Parameters To Command

                SqlDr = SqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return SqlDr;
        } // ReturnDataReader
        public SqlDataReader ReturnDataReader(string SP)
        {
            try
            {
                Open();

                //Define Command
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDr = SqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return SqlDr;
        } // ReturnDataReader
        public DataSet ReturnDataSet(string SP, SqlParameter[] Parameters)//Return DataSet with parameters
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                SqlCmd.Parameters.AddRange(Parameters);
                Ds = new DataSet();
                SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(Ds, "Table");
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //SqlDa.Dispose();
                //SqlCmd.Dispose();
                //Ds.Dispose();
                Close();
            }
        }
        public DataSet ReturnDataSet(string SP, SqlParameter[] Parameters, ref int _retValue)//Return DataSet with parameters
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                SqlCmd.Parameters.AddRange(Parameters);
                Ds = new DataSet();
                SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(Ds, "Table");
                object retValue = SqlCmd.Parameters[SqlCmd.Parameters.Count - 1].Value;
                _retValue = Convert.ToInt32(retValue);
                return Ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //SqlDa.Dispose();
                //SqlCmd.Dispose();
                //Ds.Dispose();
                Close();
            }
        }
        public DataSet ReturnDataSet(string SP)//Return DataSet Without parameters
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                Ds = new DataSet();
                SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(Ds, "Table");
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //SqlDa.Dispose();
                //SqlCmd.Dispose();
                //Ds.Dispose();
                Close();
            }
        } // Return DataSet Without parameters
        public SqlCommand readdata(string SpName, SqlParameter[] Parameters)
        {
            try
            {
                Open();

                //Define Command
                SqlCmd = new SqlCommand(SpName, SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddRange(Parameters); //Add Parameters To Command

                Ds = new DataSet();
                SqlDa = new SqlDataAdapter(SqlCmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Con.Dispose();
            }


            //con.Close();
            return SqlCmd;
        }
        public SqlCommand readdata(string SpName)
        {
            try
            {
                Open();
                SqlCommand Cmd = new SqlCommand(SpName, SqlCon);
                Cmd.CommandType = CommandType.StoredProcedure;
                return Cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Con.Close();
            }
        }
        //******************************************************
        public DataSet readdata2(string SpName, SqlParameter[] value)
        {
            try
            {
                Open();
                SqlCommand cmd = new SqlCommand(SpName, SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.Parameters.AddRange(value);
                adp.Fill(ds, "tb_groups");
                Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //******************************************************
        public DataTable RetToDataTable(string SP, SqlParameter[] Parameters)
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                SqlCmd.Parameters.AddRange(Parameters);
                Dt = new DataTable();
                SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(Dt);
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //SqlDa.Dispose();
                //SqlCmd.Dispose();
                //Dt.Dispose();
                Close();
            }
        }
        //******************************************************
        public DataTable RetToDataTable(string SP)
        {
            try
            {
                Open();
                SqlCmd = new SqlCommand(SP, SqlCon);
                SqlCmd.CommandType = SP.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;
                Dt = new DataTable();
                SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(Dt);
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //SqlDa.Dispose();
                //SqlCmd.Dispose();
                //Dt.Dispose();
                Close();
            }
        }
    }
}

