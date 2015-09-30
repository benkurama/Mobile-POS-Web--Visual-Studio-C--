using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace libPOS.DAL
{
    internal class CommonDAL : BaseDAL
    {
        public DataTable GetAllProductTypes()
        {
            base.com.CommandText = "spGetAllProductType";
            return base.GetDataTable();
        }

        internal string InsertDataset(DataSet ds)
        {
            int insertCount = 0;
            int duplicateCount = 0;
            string lastInsertItem = "";
            try
            {
                

                using(TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1,0,0))){

                    if(ds.Tables["Product"].Rows.Count > 0){
                        // start looping on DataTable {...}
                        foreach(DataRow dr in ds.Tables["Product"].Rows){
                            // first find a Existing ProductCode
                            base.com.CommandType = CommandType.Text;
                            base.com.CommandText = "select * from product where ProdCode = '" + dr["ProdCode"]+"'";
                            
                            MySqlDataAdapter da = new MySqlDataAdapter(base.com);
                            DataTable dtRes = new DataTable();
                            da.Fill(dtRes);

                            // if not exist insert is apply {...}
                            if (dtRes.Rows.Count == 0)
                            {
                                ////
                                base.com.CommandType = CommandType.StoredProcedure;
                                base.com.CommandText = "spInsertProduct";

                                base.com.Parameters.Clear();

                                base.com.Parameters.AddWithValue("_ProdCode", dr["ProdCode"]);
                                base.com.Parameters.AddWithValue("_Name", dr["ProdName"]);
                                base.com.Parameters.AddWithValue("_IMEI", 0);
                                base.com.Parameters.AddWithValue("_ImgUrl", dr["ImgUrl"]);
                                base.com.Parameters.AddWithValue("_ImgHeight", dr["Height"]);
                                
                                base.com.Parameters.AddWithValue("_ImgWidth", dr["Width"]);
                                base.com.Parameters.AddWithValue("_Specs", dr["Specs"]);
                                base.com.Parameters.AddWithValue("_Categ", dr["ProdCateg"]);
                                base.com.Parameters.AddWithValue("_UnitCode", dr["UnitCode"]);
                                base.com.Parameters.AddWithValue("_ColorCode", dr["ColorCode"]);

                                base.com.Parameters.AddWithValue("_Price", dr["Price"]);
                                base.com.Parameters.AddWithValue("_Active", dr["Active"]);
                                base.com.Parameters.AddWithValue("_EmpID", dr["EmpID"]);
                                base.com.ExecuteScalar();
                                
                                ////
                                //
                                insertCount++;
                                lastInsertItem = Convert.ToString(dr["ProdCode"]);
                            }
                            else
                            {
                                duplicateCount++;
                            }
                        }
                    }
                    // finally close any open transactions {...}
                    closeConnection();
                    //
                    scope.Complete();
                }
                

                return "Success_"+insertCount+"_"+duplicateCount;
            }catch(Exception e){

                lastInsertItem = lastInsertItem == "" ? "none": lastInsertItem ;

                return "Status: Insert Count " + insertCount + "."
                    + "<br /> Last Item inserted: " + lastInsertItem
                    +"<br /> Error: " +e.Message;
            }
            
        }

        internal DataTable GetUserLevel()
        {
            base.com.CommandText = "spGetAllUserLevel";
            return base.GetDataTable();
        }

        internal DataTable GetColorTypes()
        {
            base.com.CommandText = "spGetAllColorTypes";
            return base.GetDataTable();
        }

        internal DataTable GetUnitTypes()
        {
            base.com.CommandText = "spGetUnitTypes";
            return base.GetDataTable();
        }

        internal DataTable GetMonthlyReport(string from, string to, int kioskid)
        {
            base.com.CommandText = "spReportMonthly";
            base.com.Parameters.AddWithValue("_From", from);
            base.com.Parameters.AddWithValue("_To", to);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            return base.GetDataTable();
        }

        internal DataTable GetMonthRangeReport()
        {
            base.com.CommandText = "spGetMonthRangeReport";
            return base.GetDataTable();
        }

        internal DataTable GetWeeklyReport(string year, int kioskid)
        {
            base.com.CommandText = "spReportWeekly";
            base.com.Parameters.AddWithValue("_Year", year);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            return base.GetDataTable();
        }

        internal DataTable GetWeekRangeReport()
        {
            base.com.CommandText = "spGetWeeklyRangeReport";
            return base.GetDataTable();
        }

        internal DataTable GetDailyReport(string year, int classid)
        {
            base.com.CommandText = "spReportDaily";
            base.com.Parameters.AddWithValue("_Year", year);
            base.com.Parameters.AddWithValue("_ClassID", classid);

            return base.GetDataTable();
        }

        internal DataTable GetSalesReport(string from, string to, int kioskid)
        {
            base.com.CommandText = "spSalesReport";
            base.com.Parameters.AddWithValue("_From", from);
            base.com.Parameters.AddWithValue("_To", to);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);

            return base.GetDataTable();
        }

        internal DataTable GetVolumeWeekReport(string datefrom, string dateto, int kioskid)
        {
            base.com.CommandText = "spReportVolumeWeek";
            base.com.Parameters.AddWithValue("_DateStart", datefrom);
            base.com.Parameters.AddWithValue("_DateEnd", dateto);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);

            return base.GetDataTable();
        }

        internal DataTable GetFootTrafficReport(int kioskid)
        {
            base.com.CommandText = "spReportFootPrintByWeek";
            base.com.Parameters.AddWithValue("KioskID_", kioskid);
            return base.GetDataTable();
        }
    }
}
