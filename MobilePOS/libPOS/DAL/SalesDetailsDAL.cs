﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;
using System.Data;

namespace libPOS.DAL
{
    internal class SalesDetailsDAL : BaseDAL
    {

        internal void InsertSalesDetails(SalesDetails instance, string invstatus)
        {
            base.com.CommandText = "spInsertSalesDetailsByItem";
            base.com.Parameters.AddWithValue("_InvNo", instance.InvNo);
            base.com.Parameters.AddWithValue("_ProdID", instance.ProdID);
            base.com.Parameters.AddWithValue("_Qty", instance.Qty);
            base.com.Parameters.AddWithValue("_UnitPx", instance.UnitPx);
            base.com.Parameters.AddWithValue("_Prodname", instance.ProdName_);
            base.com.Parameters.AddWithValue("_IMEI", instance.IMEI_);
            base.com.Parameters.AddWithValue("_Discount", instance.Discount);
            base.com.Parameters.AddWithValue("_InvStatus", invstatus);

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

        internal DataTable GetSalesDetailsByInvno(string invno)
        {
            base.com.CommandText = "spGetSalesDetailsByInvno";
            base.com.Parameters.AddWithValue("_InvNo", invno);

            return base.GetDataTable();
        }

        internal DataTable GetRemarkedSales(string empid, int kioskid)
        {
            base.com.CommandText = "spGetAllSalesInfoRemarked";
            base.com.Parameters.AddWithValue("_EmpId", empid);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            return base.GetDataTable();
        }
    }
}
