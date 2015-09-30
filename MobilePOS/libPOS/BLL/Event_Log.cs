using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Event_Log
    {
        public int EventLogID { get; set; }
        public string TableName { get; set; }
        public string Event { get; set; }
        public string Remarks { get; set; }
        public string ForeighKey { get; set; }
        public int KioskID { get; set; }
        public string CreatedBy { get; set; }
        public string Source { get; set; }

        public Event_Log()
        {
            this.EventLogID = 0;
            this.TableName = "";
            this.Event = "";
            this.Remarks = "";
            this.ForeighKey = "";
            this.KioskID = 0;
            this.CreatedBy = "";
            this.Source = "";
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                this.EventLogID = Utils.convInt("EventLogID", row);
                this.TableName = Utils.convString("TableName", row);
                this.Event = Utils.convString("Event", row);
                this.Remarks = Utils.convString("Remarks", row);
                this.ForeighKey = Utils.convString("FK", row);
                this.KioskID = Utils.convInt("KioskID", row);
                this.CreatedBy = Utils.convString("CreatedBy", row);
                this.Source = Utils.convString("Source", row);

            }
        }

        public static List<Event_Log> GetCurrentEvents()
        {
            var dal = new Event_LogDAL();
            var collection = new List<Event_Log>();

            foreach (DataRow row in dal.GetCurrentEvents().Rows)
            {
                var instance = new Event_Log();
                instance.Bind(row);
                collection.Add(instance);
            }

            return collection;
        }
    }
}
