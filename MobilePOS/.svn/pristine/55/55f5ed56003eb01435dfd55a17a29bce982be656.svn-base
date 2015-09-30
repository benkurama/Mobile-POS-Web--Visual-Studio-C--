using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;
using System.Data;

namespace libPOS.BLL
{
    public class Common
    {
        public static DataTable GetAllProductTypes(){

            var dal = new CommonDAL();

            return dal.GetAllProductTypes();
        }

        public static string InsertDataset(DataSet ds)
        {
            var dal = new CommonDAL();
            string res = dal.InsertDataset(ds);

            return res;
        }

        public static DataTable GetUserLevel()
        {
            var dal = new CommonDAL();

            return dal.GetUserLevel();
        }

        public static DataTable GetColorTypes()
        {
            var dal = new CommonDAL();
            return dal.GetColorTypes();
        }

        public static DataTable GetUnitTypes()
        {
            var dal = new CommonDAL();
            return dal.GetUnitTypes();
        }

        public static DataTable GetMonthlyReport(string from, string to, int kioskid)
        {
            var dal = new CommonDAL();
            return dal.GetMonthlyReport(from, to, kioskid);
        }

        public static DataTable GetMonthRangeReport()
        {
            var dal = new CommonDAL();
            return dal.GetMonthRangeReport();
        }

        public static DataTable GetWeeklyReport(string year, int kioskid)
        {
            var dal = new CommonDAL();
            return dal.GetWeeklyReport(year, kioskid);
        }

        public static DataTable GetWeekRangeReport()
        {
            var dal = new CommonDAL();
            return dal.GetWeekRangeReport();
        }

        public static DataTable GetDailyReport(string year, int classid)
        {
            var dal = new CommonDAL();
            return dal.GetDailyReport(year, classid);
        }

        public static DataTable GetSalesReport(string from, string to, int kioskid)
        {
            var dal = new CommonDAL();
            return dal.GetSalesReport(from, to, kioskid);
        }

        public static DataTable GetVolumeWeekReport(string datefrom, string dateto, int kioskid)
        {
            var dal = new CommonDAL();
            return dal.GetVolumeWeekReport(datefrom, dateto, kioskid);
        }

        public static DataTable GetFootTrafficReport(int kioskid)
        {
            var dal = new CommonDAL();
            return dal.GetFootTrafficReport(kioskid);
        }
    }
}
