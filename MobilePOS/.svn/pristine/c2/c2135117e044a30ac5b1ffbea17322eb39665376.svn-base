using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;

namespace libPOS.DAL
{
    internal class ReturnInfoDAL : BaseDAL
    {

        internal int InsertReturnInfo(ReturnInfo ri)
        {
            base.com.CommandText = "spInsertReturnInfo";
            base.com.Parameters.AddWithValue("CustNo_", ri.CustNo);
            base.com.Parameters.AddWithValue("CustName_", ri.CustName);
            base.com.Parameters.AddWithValue("RetDate_", ri.RetDate);
            base.com.Parameters.AddWithValue("Address_", ri.Adress);
            base.com.Parameters.AddWithValue("Notes_", ri.Notes);
            base.com.Parameters.AddWithValue("EmpID_", ri.EmpID);
            base.com.Parameters.AddWithValue("KioskID_", ri.KioskID);

            //try 
            //{
            //    int res = Convert.ToInt32(base.com.ExecuteScalar());
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
            //finally
            //{
            //    closeConnection();
            //}
            int res = 0;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }catch(Exception e){
                res = 0;
            }

            return res;
        }
    }
}
