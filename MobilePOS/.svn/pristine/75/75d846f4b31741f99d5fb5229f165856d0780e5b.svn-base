using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class ReturnDetails
    {
        public int RTID { get; set; }
        public int RetNo { get; set; }
        public string InvNo { get; set; }
        public int ProdID { get; set; }
        public int RetQty { get; set; }

        public string Unit { get; set; }
        public decimal UnitPx { get; set; }
        public string Reason { get; set; }

        public ReturnDetails()
        {
            this.RTID = 0;
            this.RetNo = 0;
            this.InvNo = "";
            this.ProdID = 0;
            this.RetQty = 0;

            this.Unit = "";
            this.UnitPx = 0;
            this.Reason = "";
        }



        public static int InsertReturnDetails(ReturnDetails rd)
        {
            var dal = new ReturnDetailsDAL();
            return dal.InsertReturnDetails(rd);
        }
    }
}
