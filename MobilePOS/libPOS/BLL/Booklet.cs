using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Booklet
    {
        public int BookletID { get; set; }
        public string Prefix { get; set; }
        public string DigitFrom { get; set; }
        public string DigitTo { get; set; }
        public int KioskID { get; set; }
        public string CreatedBy {get;set;}
        public DateTime? CreatedDate { get; set; }
        public int Pages { get; set; }
        public string _KioskName { get; set; }

        public Booklet()
        {
            this.BookletID = 0;
            this.Prefix = "";
            this.DigitFrom = "";
            this.DigitTo = "";
            this.KioskID = 0;
            this.CreatedBy = "";
            this._KioskName = "";
            this.CreatedDate = null;
            this.Pages = 0;
        }

        public void Bind(DataRow row)
        {
            if(row != null){

                this.BookletID = Utils.convInt("BookletID", row);
                this.Prefix = Utils.convString("Prefix", row);
                this.DigitFrom = Utils.convString("DigitFrom", row);
                this.DigitTo = Utils.convString("DigitTo", row);
                this.KioskID = Utils.convInt("KioskID", row);
                this.CreatedBy = Utils.convString("CreatedBy", row);
                this._KioskName = Utils.convString("KioskName", row);
                this.CreatedDate = Utils.convDateTime("CreatedDate", row);
                this.Pages = Utils.convInt("Pages", row);
            }
        }

        public static List<Booklet> GetAllData()
        {
            var dal = new BookletDAL();
            var collection = new List<Booklet>();

            foreach(DataRow row in dal.GetAllData().Rows){
                var instance = new Booklet();

                instance.Bind(row);
                collection.Add(instance);
            }


            return collection;
        }

        public static bool InsertNewSeries(Booklet instance)
        {
            var dal = new BookletDAL();

            return dal.InsertNewSeries(instance);
        }

        public static Booklet SelectByID(int id)
        {
            var dal = new BookletDAL();

            DataRow row = dal.SelectByID(id);

            var instance = new Booklet();

            instance.Bind(row);

            return instance;
        }

        public static bool UpdateSelectedSeries(Booklet instance)
        {
            var dal = new BookletDAL();

            return dal.UpdateSelectedSeries(instance);
        }

        public static int ValidateSeries(string prefix, string digits, int kioskid)
        {
            var dal = new BookletDAL();

            return dal.ValidateSeries(prefix, digits, kioskid);
        }
    }
}
