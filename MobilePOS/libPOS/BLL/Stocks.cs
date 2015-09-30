using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Stocks
    {
        public int StockID { get; set; }
        public int ProdID { get; set; }
        public int KioskID { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Remarks { get; set; }

        public int StockList { get; set; }
        public string Reference { get; set; }
        public DateTime? DateReceive { get; set; }
        public string CreatedBy { get; set; }
        public string DistReciept { get; set; }
        public string CheckBy { get; set; }
        public string Checked { get; set; }

        // Sub
        public string ProdName { get; set; }

        public Stocks()
        {
            this.StockID = 0;
            this.ProdID = 0;
            this.KioskID = 0;
            this.StockIn = 0;
            this.StockOut = 0;
            
            this.DateCreated = null;
            this.Remarks = "";

            this.StockList = 0;
            this.Reference = "";
            this.DateReceive = null;
            this.CreatedBy = "";
            this.DistReciept = "";

            this.CheckBy = "";
            this.Checked = "";
        }

        public void Bind(DataRow row)
        {
            if (row != null)
            {
                this.StockID = Convert.ToInt32(row["StockID"]);
                this.KioskID = Convert.ToInt32(row["KioskID"]);
                this.ProdID = Convert.ToInt32(row["ProdID"]);
                this.StockIn = Convert.ToInt32(row["StockIn"]);
                
                this.Remarks = Convert.ToString(row["Remarks"]);
            }
        }

        public void Bind2(DataRow row)
        {
            if(row != null){
                this.StockID = Convert.ToInt32(row["StockID"]);
                this.KioskID = Convert.ToInt32(row["KioskID"]);
                this.ProdID = Convert.ToInt32(row["ProdID"]);
                this.StockIn = Convert.ToInt32(row["StockIn"]);
                this.ProdName = Convert.ToString(row["ProdName"]);
                this.Reference = Convert.ToString(row["Reference"]);
            }
        }

        public void Bind3(DataRow row)
        {
            if (row != null)
            {
                this.StockID = Convert.ToInt32(row["StockID"]);
                this.KioskID = Convert.ToInt32(row["KioskID"]);
                this.ProdID = Convert.ToInt32(row["ProdID"]);
                this.StockIn = Convert.ToInt32(row["StockIn"]);
                
                this.Remarks = Convert.ToString(row["Remarks"]);

                this.StockList = Convert.ToInt32(row["StockList"]);
                this.Reference = Convert.ToString(row["Reference"]);

                if (row["DateReceive"].ToString() != string.Empty)
                {
                    this.DateReceive = Convert.ToDateTime(row["DateReceive"]);
                }

                this.ProdName = Convert.ToString(row["ProdName"]);
                this.DistReciept = Utils.convString("DistReceipt", row);

                this.CheckBy = Utils.convString("CheckBy", row);
                this.Checked = Utils.convString("Checked", row);

            }
        }

        public static void InsertStocks(List<Stocks> collection){
            var dal = new StocksDAL();

            dal.InsertStocks(collection);
        }

        public static List<Stocks> GetKioskPhoneStocks(int id, int type)
        {
            var dal = new StocksDAL();
            var coll = new List<Stocks>();

            foreach (DataRow row in dal.GetKioskPhoneStocks(id, type).Rows)
            {
                var ins = new Stocks();

                ins.Bind2(row);
                coll.Add(ins);
            }

            return coll;
        }

        public static bool DeleteStocksByKiosk(int kioskID)
        {
            var dal = new StocksDAL();
            return dal.DeleteStocksByKiosk(kioskID);
        }

        public static Stocks GetStocksByKioskID_ProdID(int kioskid, int prodid)
        {
            var dal = new StocksDAL();
            DataRow row = dal.GetStocksByKioskID_ProdID(kioskid, prodid);

            var ins = new Stocks();
            ins.Bind(row);

            return ins;
        }

        public static void ModifyNewStocks(List<Stocks> newStocks, int type, int kioskid)
        {
            var dal = new StocksDAL();

            dal.ModifyNewStocks(newStocks, type, kioskid);
        }

        public static List<Stocks> GetStocksByReferenceAndKioskID(string directsupplier, int kioskid)
        {
            var dal = new StocksDAL();
            var collection = new List<Stocks>();

            foreach (DataRow row in dal.GetStocksByReferenceAndKioskID(directsupplier, kioskid).Rows)
            {
                var instance = new Stocks();
                instance.Bind3(row);
                collection.Add(instance);
            }

            return collection;
        }

        public static void SetStocksByRefKiosdidProdid(string dr, int kioskid, int stocklist, int prodid, string checkby)
        {
            var dal = new StocksDAL();

            dal.SetStocksByRefKiosdidProdid(dr, kioskid, stocklist, prodid, checkby);
            
        }
    }

}
