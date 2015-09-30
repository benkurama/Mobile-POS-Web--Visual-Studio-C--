using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public decimal Value { get; set; }
        public DateTime? ValidFrom {get;set;}
        public DateTime? ValidTo {get;set;}
        public string KioskAssign { get; set; }
        
        public string ProductAssign { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Discount()
        {
            this.DiscountID = 0;
            this.Value = 0;
            this.ValidFrom = null;
            this.ValidTo = null;
            this.KioskAssign = null;
            
            this.ProductAssign = null;
            this.Remarks = "";
            this.CreatedBy = "";
            this.CreatedDate = null;
            this.UpdatedBy = "";

            this.UpdateDate = null;
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                this.DiscountID = Utils.convInt("DiscountID", row);
                this.Value = Utils.convDecimal("Value", row);
                this.ValidFrom = Utils.convDateTime("ValidFrom", row);
                this.ValidTo = Utils.convDateTime("ValidTo", row);
                this.KioskAssign = Utils.convString("KioskAssign", row);

                this.ProductAssign = Utils.convString("ProductAssign", row);
                this.Remarks = Utils.convString("Remarks", row);
                this.CreatedBy = Utils.convString("CreatedBy", row);
                this.CreatedDate =  Utils.convDateTime("CreatedDate", row);
                this.UpdatedBy = Utils.convString("UpdatedBy", row);
                this.UpdateDate = Utils.convDateTime("UpdatedDate", row);
            }
        }

        public static List<Discount> GetAllData()
        {
            var dal = new DiscountDAL();
            var collection = new List<Discount>();

            foreach (DataRow row in dal.GetAllData().Rows)
            {
                var instance = new Discount();
                instance.Bind(row);

                collection.Add(instance);
            }

            return collection;
        }

        public static bool InsertNewDiscount(Discount instance)
        {
            var dal = new DiscountDAL();

            return dal.InsertNewDiscount(instance);
        }
    }
}
