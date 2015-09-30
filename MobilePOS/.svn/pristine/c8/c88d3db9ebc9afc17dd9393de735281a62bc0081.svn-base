using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Colors
    {
        public int VariantID { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }

        public Colors()
        {
            this.VariantID = 0;
            this.ColorCode = "";
            this.ColorName = "";
        }

        public static bool InsertNewColor(string colorcode, string colorname)
        {
            var dal = new ColorsDAL();
             return dal.InsertNewColor(colorcode, colorname);
        }
    }

    
}
