using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS
{
    public class Utils
    {
        public static int convInt(string col, DataRow row)
        {
            int value;

            try
            {
                value = Convert.ToInt32(row[col]);
            }
            catch (Exception e)
            {
                return -1;
            }

            return value;
        }

        public static string convString(string col, DataRow row)
        {
            string value;

            try
            {
                value = Convert.ToString(row[col]);
            }
            catch (Exception e)
            {
                return "null";
            }

            return value;
        }

        public static DateTime? convDateTime(string col, DataRow row)
        {
            DateTime dt;

            try
            {
                dt = Convert.ToDateTime(row[col]);
            }catch(Exception e){
                return null;
            }

            return dt;
        }

        public static decimal convDecimal(string col, DataRow row)
        {
            decimal dec;

            try
            {
                dec = Convert.ToDecimal(row[col]);
            }
            catch (Exception e)
            {
                return (decimal)(-1.00);
            }

            return dec;
        }
    }
}
