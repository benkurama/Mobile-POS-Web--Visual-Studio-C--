using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;
using System.Data;

namespace libPOS.DAL
{
    internal class FootTrafficDAL : BaseDAL
    {
        internal void InsertFootTrafficCount(FootTraffic ins)
        {
            base.com.CommandText = "spPostFootTrafficCounter";
            base.com.Parameters.AddWithValue("8am_", ins.i8am);
            base.com.Parameters.AddWithValue("9am_", ins.i9am);
            base.com.Parameters.AddWithValue("10am_", ins.i10am);
            base.com.Parameters.AddWithValue("11am_", ins.i11am);
            base.com.Parameters.AddWithValue("12pm_", ins.i12pm);

            base.com.Parameters.AddWithValue("1pm_", ins.i1pm);
            base.com.Parameters.AddWithValue("2pm_", ins.i2pm);
            base.com.Parameters.AddWithValue("3pm_", ins.i3pm);
            base.com.Parameters.AddWithValue("4pm_", ins.i4pm);
            base.com.Parameters.AddWithValue("5pm_", ins.i5pm);

            base.com.Parameters.AddWithValue("6pm_", ins.i6pm);
            base.com.Parameters.AddWithValue("7pm_", ins.i7pm);
            base.com.Parameters.AddWithValue("8pm_", ins.i8pm);
            base.com.Parameters.AddWithValue("9pm_", ins.i9pm);
            base.com.Parameters.AddWithValue("10pm_", ins.i10pm);

            base.com.Parameters.AddWithValue("TotalFT_", ins.TotalFT);
            base.com.Parameters.AddWithValue("KioskID_", ins.KioskID);
            base.com.Parameters.AddWithValue("EmpCode_", ins.EmpCode);

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

        internal DataTable GetFTByKioskAndToday(int kioskid, string date)
        {
            base.com.CommandText = "spSelectFootTrafficCounter";
            base.com.Parameters.AddWithValue("KioskID_", kioskid);
            base.com.Parameters.AddWithValue("Date_", date);

            return base.GetDataTable();
        }

        internal DataTable ReportFTByMonth()
        {
            base.com.CommandText = "spReportFootPrintByWeek";
            return base.GetDataTable();
        }

        internal DataTable ReportFTByDay(string from, string to, int kioskid)
        {
            base.com.CommandText = "spReportFootTrafficByDay";
            base.com.Parameters.AddWithValue("dateStart_", from);
            base.com.Parameters.AddWithValue("dateEnd_", to);
            base.com.Parameters.AddWithValue("KioskID_", kioskid);

            return base.GetDataTable();
        }
    }
}
