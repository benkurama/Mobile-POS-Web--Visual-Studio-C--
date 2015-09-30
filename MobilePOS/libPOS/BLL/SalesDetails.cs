using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;
using System.Data;

namespace libPOS.BLL
{
    public class SalesDetails
    {
        public string InvNo { get; set; }
        public int ProdID { get; set; }
        public int Qty { get; set; }
        public decimal UnitPx { get; set; }
        public decimal Discount { get; set; }

        public string ProdName_ { get; set; }
        public string IMEI_ { get; set; }

        public SalesDetails()
        {
            this.InvNo = "";
            this.ProdID = 0;
            this.Qty = 0;
            this.UnitPx = 0;
            this.Discount = 0;

            this.ProdName_ = "";
            this.IMEI_ = "";
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                this.InvNo = Convert.ToString(row["InvNo"]);
                this.ProdID = Convert.ToInt32(row["ProdID"]);
                this.Qty = Convert.ToInt32(row["Qty"]);
                this.UnitPx = Convert.ToDecimal(row["UnitPx"]);
                this.ProdName_ = Convert.ToString(row["prodname"]);
                this.Discount = Utils.convDecimal("Discount", row);
            }
        }

        public static void InsertSalesDetails(SalesDetails instance, string invstatus)
        {
            var dal = new SalesDetailsDAL();

            dal.InsertSalesDetails(instance, invstatus);
        }

        public static List<SalesDetails> GetSalesDetailsByInvno(string invno)
        {
            var dal = new SalesDetailsDAL();
            var collection = new List<SalesDetails>();

            foreach(DataRow row in dal.GetSalesDetailsByInvno(invno).Rows){
                var instance = new SalesDetails();
                instance.Bind(row);

                collection.Add(instance);
            }

            return collection;
        }


    }
}
