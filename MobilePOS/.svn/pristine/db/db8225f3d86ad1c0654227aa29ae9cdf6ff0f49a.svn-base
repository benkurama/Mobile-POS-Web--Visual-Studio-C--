using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;
using System.Data;

namespace libPOS.BLL
{
    public class ProdIMEI
    {
        public int IMEIID { get; set; }
        public int InventoryID {get;set;}
        public string IMEI { get; set; }
        public string Out { get; set; }


        public ProdIMEI()
        {
            this.IMEIID = 0;
            this.InventoryID = 0;
            this.IMEI = "";
            this.Out = "";
        }

        public void Bind(DataRow row){
            //
            if(row != null){
                this.IMEIID = Utils.convInt("ImeiID", row);
                this.InventoryID = Utils.convInt("InventoryID", row);
                this.IMEI = Utils.convString("IMEI", row);
                this.Out = Utils.convString("Out", row);
            }
        }

        public static void InsertNewIMEI(List<ProdIMEI> prodIMEIList)
        {
            var dal = new ProdIMEIDAL();
            dal.InsertNewIMEI(prodIMEIList);
        }

        public static List<ProdIMEI> GetIMEIByKioskIDProdID(int kioskid, int prodid)
        {
            var dal = new ProdIMEIDAL();
            var collection = new List<ProdIMEI>();

            foreach (DataRow row in dal.GetIMEIByKioskIDProdID(kioskid, prodid).Rows)
            {
                var instance = new ProdIMEI();
                instance.Bind(row);

                collection.Add(instance);
            }

            return collection;
        }

        public static List<ProdIMEI> GetIMEIByInventoryID(int inventID)
        {
            var dal = new ProdIMEIDAL();
            var colletion = new List<ProdIMEI>();

            foreach (DataRow row in dal.GetIMEIByInventoryID(inventID).Rows)
            {
                var instance = new ProdIMEI();
                instance.Bind(row);

                colletion.Add(instance);
            }

            return colletion;
        }
    }
}
