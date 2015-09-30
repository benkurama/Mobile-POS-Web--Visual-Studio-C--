using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.BLL;

namespace libPOS.DAL
{
    internal class BookletDAL:BaseDAL
    {

        internal DataTable GetAllData()
        {
            base.com.CommandText = "spGetAllBookletSeries";

            return base.GetDataTable();
        }

        internal bool InsertNewSeries(Booklet instance)
        {
            base.com.CommandText = "spInsertBooklet";
            base.com.Parameters.AddWithValue("_Prefix", instance.Prefix);
            base.com.Parameters.AddWithValue("_DigitFrom", instance.DigitFrom);
            base.com.Parameters.AddWithValue("_DigitTo", instance.DigitTo);
            base.com.Parameters.AddWithValue("_KioskID", instance.KioskID);
            base.com.Parameters.AddWithValue("_CreatedBy", instance.CreatedBy);
            base.com.Parameters.AddWithValue("_Pages", instance.Pages);

            int res = 0;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception ee)
            {
                res = 0;
                
            }
            finally
            {
                closeConnection();
            }

            return res > 0;
        }

        internal DataRow SelectByID(int id)
        {
            base.com.CommandText = "spSelectBoolketByID";
            base.com.Parameters.AddWithValue("_BookletID", id);

            return base.GetFirstRow();
        }

        internal bool UpdateSelectedSeries(Booklet instance)
        {
            base.com.CommandText = "spUpdateBooklet";
            base.com.Parameters.AddWithValue("_BookletID", instance.BookletID);
            base.com.Parameters.AddWithValue("_DigitFrom", instance.DigitFrom);
            base.com.Parameters.AddWithValue("_DigitTo", instance.DigitTo);
            base.com.Parameters.AddWithValue("_KioskID", instance.KioskID);
            base.com.Parameters.AddWithValue("_CreatedBy", instance.CreatedBy);
            base.com.Parameters.AddWithValue("_Pages", instance.Pages);

            int res = 0;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception ee)
            {
                res = 0;
            }
            finally
            {
                base.closeConnection();
            }

            return res > 0;

        }

        internal int ValidateSeries(string prefix, string digits, int kioskid)
        {
            base.com.CommandText = "spValidateSeries";
            base.com.Parameters.AddWithValue("_Prefix", prefix);
            base.com.Parameters.AddWithValue("_Digits", digits);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);

            int res = 0;
            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }catch(Exception ee){

            }finally{
                closeConnection();
            }

            return res;
        }
    }
}
