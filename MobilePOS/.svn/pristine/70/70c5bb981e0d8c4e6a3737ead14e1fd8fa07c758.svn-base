using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;
using System.Data;
using MySql.Data.MySqlClient;

namespace libPOS.DAL
{
    internal class StocksDAL: BaseDAL
    {

        internal void InsertStocks(List<BLL.Stocks> collection)// temp
        {
            foreach(Stocks ins in collection){
                //
                try
                {
                    base.com.CommandText = "spInsertStocks";

                    base.com.Parameters.Clear();
                    base.com.Parameters.AddWithValue("_ProdID", ins.ProdID);
                    base.com.Parameters.AddWithValue("_KioskID", ins.KioskID);
                    base.com.Parameters.AddWithValue("_StockIn", ins.StockIn);
                    base.com.Parameters.AddWithValue("_Remarks", ins.Remarks);
                    base.com.ExecuteScalar();
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            closeConnection();
        }

        internal DataTable GetKioskPhoneStocks(int id, int type)
        {
            base.com.CommandText = "spGetKioskStockByType";
            base.com.Parameters.AddWithValue("_KioskID", id);
            base.com.Parameters.AddWithValue("_Type", type);
            return base.GetDataTable();
        }
        
        internal bool DeleteStocksByKiosk(int kioskID)// temp
        {
            bool isDeleted = true;
            try
            {
                base.com.CommandText = "spDeleteKioskStockByType";
                base.com.Parameters.AddWithValue("_KioskID", kioskID);
                base.com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                isDeleted = false;                
            }

            return isDeleted;
        }

        internal DataRow GetStocksByKioskID_ProdID(int kioskid, int prodid)
        {
            base.com.CommandText = "spGetStocksByKioskIDProdID";
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            base.com.Parameters.AddWithValue("_ProdID", prodid);

            return base.GetFirstRow();
        }

        internal void ModifyNewStocks(List<Stocks> newStocks, int type, int kioskid)
        {
            #region RESERVED OLD CODES
            //var coll = GetKioskStockByType(kioskid, type);

            //#region Deleting Command
            //// from new Stocks
            //var newStks = newStocks.Select(o => new { o.KioskID, o.ProdID }).ToList();
            //// from old Stocks
            //var oldStks = coll.Select(o => new { o.KioskID, o.ProdID }).ToList();
            ////
            //var notInNewStocks = from oldS in oldStks
            //                     where !(from newS in newStks select newS).Contains(oldS)
            //                     select oldS;
            ////
            //var indxDelete = notInNewStocks.ToList();
            ////
            //foreach (var inx in indxDelete)
            //{
            //    List<Stocks> insDel = coll.Where(o => o.KioskID == inx.KioskID && o.ProdID == inx.ProdID).ToList();
            //    DeleteStocksByKioskID_ProdID(insDel[0]);
            //} 
            //#endregion
            ////

            //#region Insert Update Command
            //foreach(Stocks stocks in newStocks){
            //    //
            //    bool isExist = CheckStocksIfExist(stocks.KioskID, stocks.ProdID);

            //    if(isExist){
            //        UpdateStocks(stocks);
            //    } else{
            //        InsertStocks2(stocks);
            //    }
            //}
            //#endregion

            //closeConnection();
            #endregion
            //
            //bool isInsert = false;

           

            foreach(Stocks stocks in newStocks){
                //
                 InsertStocks2(stocks);
            }

            closeConnection();
        }

        private List<Stocks> GetKioskStockByType(int kioskid, int type)
        {
            base.com.CommandText = "spGetKioskStockByType";
            base.com.Parameters.Clear();
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            base.com.Parameters.AddWithValue("_Type", type);
            // 
            MySqlDataAdapter da = new MySqlDataAdapter(base.com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var coll = new List<Stocks>();

            foreach (DataRow row in dt.Rows)
            {
                var ins = new Stocks();
                ins.Bind2(row);
                coll.Add(ins);
            }

            return coll;
        }

        private void DeleteStocksByKioskID_ProdID(Stocks ins)
        {
            base.com.CommandText = "spDeleteKioskStockByProdIDKioskID";
            base.com.Parameters.Clear();
            base.com.Parameters.AddWithValue("_KioskID", ins.KioskID);
            base.com.Parameters.AddWithValue("_ProdID", ins.ProdID);
            base.com.ExecuteNonQuery();
        }

        private bool CheckStocksIfExist(int kioskid, int prodid)
        {
            bool isExist = false;
            base.com.CommandText = "spGetStocksByKioskIDProdID";
            base.com.Parameters.Clear();
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            base.com.Parameters.AddWithValue("_ProdID", prodid);
            // 
            MySqlDataAdapter da = new MySqlDataAdapter(base.com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //
            if (dt.Rows.Count != 0)
            {
                isExist = true;
            }

            return isExist;
        }

        private bool InsertStocks2(Stocks ins)
        {
            base.com.CommandText = "spInsertStocks";
            base.com.Parameters.Clear();
            base.com.Parameters.AddWithValue("_ProdID", ins.ProdID);
            base.com.Parameters.AddWithValue("_KioskID", ins.KioskID);
            base.com.Parameters.AddWithValue("_StockIn", ins.StockIn);
            base.com.Parameters.AddWithValue("_Remarks", ins.Remarks);
            base.com.Parameters.AddWithValue("_CreatedBy", ins.CreatedBy);
            base.com.Parameters.AddWithValue("_Reference", ins.Reference);
            base.com.Parameters.AddWithValue("_DistRec", ins.DistReciept);

            int res;
            
             res = Convert.ToInt32(base.com.ExecuteScalar());
            

            return res > 0;
        }

        private void UpdateStocks(Stocks ins)
        {
            base.com.CommandText = "spUpdateStocks";
            base.com.Parameters.Clear();
            base.com.Parameters.AddWithValue("_ProdID", ins.ProdID);
            base.com.Parameters.AddWithValue("_KioskID", ins.KioskID);
            base.com.Parameters.AddWithValue("_StockIn", ins.StockIn);
            base.com.Parameters.AddWithValue("_Remarks", ins.Remarks);
            base.com.Parameters.AddWithValue("_CreatedBy", ins.CreatedBy);
            base.com.Parameters.AddWithValue("_Reference", ins.Reference);
            base.com.ExecuteScalar();
        }

        internal DataTable GetStocksByReferenceAndKioskID(string directsupplier, int kioskid)
        {
            base.com.CommandText = "spGetStockForRecieve";
            base.com.Parameters.AddWithValue("_DirectSupplier", directsupplier);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            return base.GetDataTable();
        }

        internal void SetStocksByRefKiosdidProdid(string dr, int kioskid, int stocklist, int prodid, string checkby)
        {
            base.com.CommandText = "spUpdateStocksForReceive";
            base.com.Parameters.AddWithValue("_DirSupp", dr);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            base.com.Parameters.AddWithValue("_StockList", stocklist);
            base.com.Parameters.AddWithValue("_ProdID", prodid);
            base.com.Parameters.AddWithValue("_CheckBy", checkby);

            try
            {
                int res = Convert.ToInt32(base.com.ExecuteScalar());

                if (res <= 0)
                {
                    throw new ArgumentException("Failed");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
