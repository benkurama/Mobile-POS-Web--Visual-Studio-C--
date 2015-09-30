using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libPOS.DAL
{
    internal class ColorsDAL : BaseDAL
    {

        internal bool InsertNewColor(string colorcode, string colorname)
        {
            base.com.CommandText = "spInsertColor";
            base.com.Parameters.AddWithValue("ColorCode_", colorcode);
            base.com.Parameters.AddWithValue("ColorName_", colorname);

            int res = 0;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }

            catch
            {
                res = 0;
            }

            finally
            {
                closeConnection();
            }
            return res > 0;
        }
    }
}
