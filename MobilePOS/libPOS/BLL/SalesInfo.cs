﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;
using System.Data;

namespace libPOS.BLL
{
    public class SalesInfo
    {
        public string InvNo { get; set; }
        public string CustName { get; set; }
        public string Address { get; set; }
        public string EmailAdd { get; set; }
        public string ContactNo { get; set; }
        public string CustNo { get; set; }
        public decimal TotalAmount { get; set; }
        public string EmpID { get; set; }
        public DateTime? InvDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int KioskID { get; set; }

        public string _EmpName { get; set; }
        public string _TakenBy { get; set; }
        public string _Remit { get; set; }

        public SalesInfo()
        {
            this.InvNo = "";
            this.CustName = "";
            this.Address = "";
            this.EmailAdd = "";
            this.ContactNo = "";
            this.CustNo = "";
            this.TotalAmount = 0;
            this.EmpID = "";
            this.InvDate = null;
            this.Status = "";
            this.Remarks = "";
            this.KioskID = 0;

            this._EmpName = "";
            this._TakenBy = "";
            this._Remit = "";
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                this.InvNo = Convert.ToString(row["InvNo"]);
                this.CustName = Convert.ToString(row["CustName"]);
                this.Address = Convert.ToString(row["Address"]);
                this.EmailAdd = Convert.ToString(row["EmailAdd"]);
                this.ContactNo = Convert.ToString(row["ContactNumber"]);
                this.CustNo = Convert.ToString(row["CustNo"]);
                this.TotalAmount = Convert.ToDecimal(row["TotalAmount"]);
                this.EmpID = Convert.ToString(row["EmpID"]);
                this.InvDate = Convert.ToDateTime(row["InvDate"]);
                this.Status = Convert.ToString(row["Status"]);
                this.Remarks = Convert.ToString(row["Remarks"]);
                //
                this._TakenBy = Utils.convString("TakenBy", row);
                this._Remit = Utils.convString("Remit", row);
            }
        }

        public void Bind2(DataRow row)
        {
            if (row != null)
            {
                this.InvNo = Convert.ToString(row["InvNo"]);
                this.CustName = Convert.ToString(row["CustName"]);
                this.Address = Convert.ToString(row["Address"]);
                this.EmailAdd = Convert.ToString(row["EmailAdd"]);
                this.ContactNo = Convert.ToString(row["ContactNumber"]);
                this.CustNo = Convert.ToString(row["CustNo"]);
                this.TotalAmount = Convert.ToDecimal(row["TotalAmount"]);
                this.EmpID = Convert.ToString(row["EmpID"]);
                this.InvDate = Convert.ToDateTime(row["InvDate"]);
                this.Status = Convert.ToString(row["Status"]);
                this.Remarks = Convert.ToString(row["Remarks"]);
                //
                this._EmpName = Convert.ToString(row["EmpName"]);
            }
        }

        public void NewBind001(DataRow row)
        {
            this.InvNo = Utils.convString("InvNo", row);
            ///  
            this.CustName = Utils.convString("CustName", row);
            this.Address = Utils.convString("Address", row);
            this.EmailAdd = Utils.convString("EmailAdd", row);
            this.ContactNo = Utils.convString("ContactNumber", row);
            this.CustNo = Utils.convString("CustNo", row);
            this.TotalAmount = Utils.convDecimal("TotalAmount", row);
            this.EmpID = Utils.convString("EmpID", row);
            this.InvDate = Utils.convDateTime("InvDate", row);
            this.Status = Utils.convString("Status", row);
            this.Remarks = Utils.convString("Remarks", row);
        }

        public static void InsertSalesInfo(SalesInfo instance)
        {
            var dal = new SalesInfoDAL();
            dal.InsertSalesInfo(instance);
        }

        public static List<SalesInfo> GetAllSalesInfo()
        {
            var dal = new SalesInfoDAL();
            var collection = new List<SalesInfo>();

            foreach(DataRow row in dal.GetAllSalesInfo().Rows){
                var instance = new SalesInfo();
                instance.Bind(row);
                collection.Add(instance);
            }

            return collection;
        }

        public static List<SalesInfo> GetRemarkedSales(string empid, int kioskid)
        {
            var dal = new SalesDetailsDAL();
            var collection = new List<SalesInfo>();

            foreach (DataRow row in dal.GetRemarkedSales(empid, kioskid).Rows)
            {
                var instance = new SalesInfo();
                instance.Bind(row);
                collection.Add(instance);
            }

            return collection;
        }

        public static void UpdateSalesInfo(SalesInfo si)
        {
            var dal = new SalesInfoDAL();
            dal.UpdateSalesInfo(si);
        }

        public static void CancelledSalesInfo(string invno)
        {
            var dal = new SalesInfoDAL();

            dal.CancelledSalesInfo(invno);
        }

        public static List<SalesInfo> GetSalesByDateRange(string from, string to, string empid)
        {
            var dal = new SalesInfoDAL();

            var collection = new List<SalesInfo>();

            foreach (DataRow row in dal.GetSalesByDateRange(from, to, empid).Rows)
            {
                var ins = new SalesInfo();
                ins.Bind(row);
                collection.Add(ins);

            }

            return collection;
        }

        public static List<SalesInfo> GetSalesByKioskDateRange(string from, string to, int kioskid)
        {
            var dal = new SalesInfoDAL();
            var collection = new List<SalesInfo>();

            foreach (DataRow row in dal.GetSalesByKioskDateRange(from, to, kioskid).Rows)
            {
                var ins = new SalesInfo();

                ins.Bind2(row);
                collection.Add(ins);
            }

            return collection;
        }

        public static SalesInfo SelectInvoiceNo(string invno)
        {
            var dal = new SalesInfoDAL();
            var instance = new SalesInfo();

            foreach (DataRow row in dal.SelectInvoiceNo(invno).Rows)
            {
                instance.NewBind001(row);
            }

            return instance;
        }

        public static List<SalesInfo> GetAllByInvDate(string invdate, int kioskid)
        {
            var dal = new SalesInfoDAL();
            var collection = new List<SalesInfo>();

            foreach (DataRow row in dal.GetAllByInvDate(invdate, kioskid).Rows)
            {
                var instance = new SalesInfo();
                instance.Bind(row);
                collection.Add(instance);
            }

            return collection;
        }
    }
}
