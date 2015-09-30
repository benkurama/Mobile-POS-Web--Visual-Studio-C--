using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;
using System.Data;

namespace libPOS.DAL
{
    internal class SalesInfoDAL : BaseDAL
    {
        internal void InsertSalesInfo(SalesInfo instance)
        {
            base.com.CommandText = "spInsertSalesInfoByCustomer";
            base.com.Parameters.AddWithValue("_InvNo", instance.InvNo);
            base.com.Parameters.AddWithValue("_CustName", instance.CustName);
            base.com.Parameters.AddWithValue("_Address", instance.Address);
            base.com.Parameters.AddWithValue("_EmailAdd", instance.EmailAdd);
            base.com.Parameters.AddWithValue("_ContactNumber", instance.ContactNo);
            base.com.Parameters.AddWithValue("_CustNo", instance.CustNo);
            base.com.Parameters.AddWithValue("_TotalAmount", instance.TotalAmount);
            base.com.Parameters.AddWithValue("_EmpID", instance.EmpID);
            base.com.Parameters.AddWithValue("_Status", instance.Status);
            base.com.Parameters.AddWithValue("_Remarks", instance.Remarks);
            base.com.Parameters.AddWithValue("_KioskID", instance.KioskID);
            base.com.Parameters.AddWithValue("_TakenBy", instance._TakenBy);

            try{
                int res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception e)
            {
               throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }

        }

        internal DataTable GetAllSalesInfo()
        {
            base.com.CommandText = "spgetallsalesinfo";
            return base.GetDataTable();
        }

        internal void UpdateSalesInfo(SalesInfo si)
        {
            base.com.CommandText = "spUpdateSalesInfo";
            base.com.Parameters.AddWithValue("_InvNo", si.InvNo);
            base.com.Parameters.AddWithValue("_CustName", si.CustName);
            base.com.Parameters.AddWithValue("_Address", si.Address);
            base.com.Parameters.AddWithValue("_EmailAdd", si.EmailAdd);
            base.com.Parameters.AddWithValue("_ContactNumber", si.ContactNo);
            base.com.Parameters.AddWithValue("_CustNo", si.CustNo);
            base.com.Parameters.AddWithValue("_TotalAmount", si.TotalAmount);
            base.com.Parameters.AddWithValue("_Status", si.Status);
            base.com.Parameters.AddWithValue("_TakenBy", si._TakenBy);
            try
            {
                int res = Convert.ToInt32(base.com.ExecuteScalar());
            }catch(Exception e){
                throw new Exception(e.Message);
            }finally{
                closeConnection();
            }
        }

        internal void CancelledSalesInfo(string invno)
        {
            base.com.CommandText = "spUpdateSalesInfoToCancelled";
            base.com.Parameters.AddWithValue("_InvNo", invno);

            try
            {
                int res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        internal DataTable GetSalesByDateRange(string from, string to, string empid)
        {
            base.com.CommandText = "spGetSalesReport";
            base.com.Parameters.AddWithValue("_From", from);
            base.com.Parameters.AddWithValue("_To", to);
            base.com.Parameters.AddWithValue("_EmpID", empid);

            return base.GetDataTable();
        }

        internal DataTable GetSalesByKioskDateRange(string from, string to, int kioskid)
        {
            base.com.CommandText = "spGetSalesReportByKiosk";
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            base.com.Parameters.AddWithValue("_From", from);
            base.com.Parameters.AddWithValue("_To", to);

            return base.GetDataTable();
        }

        internal DataTable SelectInvoiceNo(string invno)
        {
            base.com.CommandText = "spSelectSalesInfoByInvNo";
            base.com.Parameters.AddWithValue("InvNo_", invno);

            return base.GetDataTable();
        }

        internal DataTable GetAllByInvDate(string invdate, int kioskid)
        {
            base.com.CommandText = "spGetSalesInfoByInvdate";
            base.com.Parameters.AddWithValue("InvDate_", invdate);
            base.com.Parameters.AddWithValue("KioskID_", kioskid);

            return base.GetDataTable();
        }
    }
}
