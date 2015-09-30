using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace libPOS.DAL
{
    internal abstract class BaseDAL
    {
        // =========================================================================
        // Variables
        // =========================================================================
        protected MySqlConnection conn;
        protected MySqlCommand com;

        public BaseDAL()
        {
            //this.conn = new MySqlConnection("server=192.168.1.20; database=mobiledata; uid=root; password=N3wP@$$w0rd; Convert Zero Datetime=True");
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            this.conn = new MySqlConnection(connection);
            this.com = new MySqlCommand();
            this.com.CommandType = CommandType.StoredProcedure;

            try
            {
                if (this.conn.State == ConnectionState.Closed) this.conn.Open();
                this.com.Connection = conn;
            }
            catch (Exception ex)
            {
                #if DEBUG
                    throw new Exception(ex.Message);
                #else
                    throw new Exception(ex.Message);
                    //throw new Exception("error");
                #endif
            }
        }

        protected DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            try
            {
                dt.Load(this.com.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                //throw ex.Message;
            }

            conn.Close();
            conn.Dispose();
            conn = null;
            com = null;

            return dt;
        }

        protected DataRow GetFirstRow()
        {
            DataTable dt = this.GetDataTable();

            if (dt.Rows.Count > 0) return dt.Rows[0];
            else return null;
            
        }

        protected void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
                com.Dispose();
                com = null;
            }
        }
    }
}
