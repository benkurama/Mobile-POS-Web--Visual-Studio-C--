using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class ReturnInfo
    {
        public int RetNo { get; set; }
        public string CustNo { get; set; }
        public string CustName { get; set; }
        public DateTime? RetDate { get; set; }
        public string Adress { get; set; }
        public string Notes { get; set; }
        public string EmpID { get; set; }
        public int KioskID { get; set; }

        public ReturnInfo()
        {
            this.RetNo = 0;
            this.CustNo = "";
            this.CustName = "";
            this.RetDate = null;
            this.Notes = "";
            this.EmpID = "";
            this.KioskID = 0;
        }

        public static int InsertReturnInfo(ReturnInfo ri)
        {
            var dal = new ReturnInfoDAL();
            return dal.InsertReturnInfo(ri);
        }
    }
}
