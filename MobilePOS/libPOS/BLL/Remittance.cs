using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Remittance
    {
        public string InvNo { get; set; }
        public decimal InvAmt { get; set; }
        public string TakenBy { get; set; }
        public int KioskID { get; set; }

        public Remittance()
        {
            this.InvNo = "";
            this.InvAmt = 0;
            this.TakenBy = "";
            this.KioskID = 0;
        }

        public static int InsertRemittanceData(Remittance instance)
        {
            var dal = new RemittanceDAL();
            return dal.InsertRemittanceData(instance);
        }
    }
}
