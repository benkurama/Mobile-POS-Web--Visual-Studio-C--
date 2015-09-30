using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Top10Product
    {
        public int ProdID { get; set; }
        public string ProdName {get;set;}
        public int TotalQty { get; set; }
        public decimal TotalAmt { get; set; }

        public Top10Product()
        {
            this.ProdID = 0;
            this.ProdName = "";
            this.TotalQty = 0;
            this.TotalAmt = 0;
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                //
                this.ProdID = Convert.ToInt32(row["Prodid"]);
                this.ProdName = Convert.ToString(row["ProdName"]);
                this.TotalQty = Convert.ToInt32(row["TotalQty"]);
                this.TotalAmt = Convert.ToDecimal(row["TotalAmt"]);
            }

        }

        public static List<Top10Product> GetTop10Products(string from, string to)
        {
            var dal = new Top10ProductDAL();
            var collection = new List<Top10Product>();

            foreach (DataRow row in dal.GetTop10Products(from, to).Rows)
            {
                var instance = new Top10Product();
                instance.Bind(row);
                collection.Add(instance);
            }

            return collection;
        }
    }
}
