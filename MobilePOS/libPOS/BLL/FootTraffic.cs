using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class FootTraffic
    {
        public int FTID { get; set; }
        public int i8am { get; set; }
        public int i9am { get; set; }
        public int i10am { get; set; }
        public int i11am { get; set; }
        public int i12pm { get; set; }

        public int i1pm { get; set; }
        public int i2pm { get; set; }
        public int i3pm { get; set; }
        public int i4pm { get; set; }
        public int i5pm { get; set; }
        public int i6pm { get; set; }
        public int i7pm { get; set; }
        public int i8pm { get; set; }
        public int i9pm { get; set; }
        public int i10pm { get; set; }

        public int TotalFT { get; set; }
        public int KioskID { get; set; }
        public string EmpCode { get; set; }

        public string ClassName_ { get; set; }
        public string KioskName_ { get; set; }
        public int WeekIn_ { get; set; }
        public int TrafficCounter_ { get; set; }
        public string DaysIn_ { get; set; }

        public FootTraffic()
        {
            this.FTID = 0;
            this.i8am = 0;
            this.i9am = 0;
            this.i10am = 0;
            this.i11am = 0;
            this.i12pm = 0;
            this.i1pm = 0;
            this.i2pm = 0;
            this.i3pm = 0;
            this.i4pm = 0;
            this.i5pm = 0;
            this.i6pm = 0;
            this.i7pm = 0;
            this.i8pm = 0;
            this.i9pm = 0;
            this.i10pm = 0;

            this.TotalFT = 0;
            this.KioskID = 0;
            this.EmpCode = "";

            this.ClassName_ = "";
            this.KioskName_ = "";
            this.WeekIn_ = 0;
            this.TrafficCounter_ = 0;
            this.DaysIn_ = "";
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                //
                this.FTID = Utils.convInt("FTID", row);
                this.i8am = Utils.convInt("8AM", row);
                this.i9am = Utils.convInt("9AM", row);
                this.i10am = Utils.convInt("10AM", row);
                this.i11am = Utils.convInt("11AM", row);
                this.i12pm = Utils.convInt("12PM", row);

                this.i1pm = Utils.convInt("1PM", row);
                this.i2pm = Utils.convInt("2PM", row);
                this.i3pm = Utils.convInt("3PM", row);
                this.i4pm = Utils.convInt("4PM", row);
                this.i5pm = Utils.convInt("5PM", row);
                this.i6pm = Utils.convInt("6PM", row);
                this.i7pm = Utils.convInt("7PM", row);
                this.i8pm = Utils.convInt("8PM", row);
                this.i9pm = Utils.convInt("9PM", row);
                this.i10pm = Utils.convInt("10PM", row);

                this.TotalFT = Utils.convInt("TotalFT", row);
                this.KioskID = Utils.convInt("KioskID", row);
                this.EmpCode = Utils.convString("EmpCode", row);
                /////
                this.ClassName_ = Utils.convString("ClassName", row);
                this.KioskName_ = Utils.convString("KioskName", row);
                this.WeekIn_ = Utils.convInt("WeekIn", row);
                this.TrafficCounter_ = Utils.convInt("TrafficByWeek", row);
                this.DaysIn_ = Utils.convString("DaysIn", row);
            }
            //
        }


        public static void InsertFootTrafficCount(FootTraffic ins)
        {
            var dal = new FootTrafficDAL();
            dal.InsertFootTrafficCount(ins);
        }

        public static FootTraffic GetFTByKioskAndToday(int kioskid, string date)
        {
            var dal = new FootTrafficDAL();

            var ins = new FootTraffic();

            foreach (DataRow dr in dal.GetFTByKioskAndToday(kioskid, date).Rows)
            {
                ins.Bind(dr);
            }

            return ins;
        }

        public static List<FootTraffic> ReportFTByMonth()
        {
            var dal = new FootTrafficDAL();
            var collection = new List<FootTraffic>();

            foreach (DataRow row in dal.ReportFTByMonth().Rows)
            {
                var instance = new FootTraffic();
                instance.Bind(row);
                collection.Add(instance);
            }

            return collection;
        }

        public static List<FootTraffic> ReportFTByDay(string from, string to, int kioskid)
        {
            var dal = new FootTrafficDAL();
            var collection = new List<FootTraffic>();

            foreach (DataRow row in dal.ReportFTByDay(from, to, kioskid).Rows)
            {
                var ins = new FootTraffic();
                ins.Bind(row);
                collection.Add(ins);
            }

            return collection;
        }
    }

}
