using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS.DAL
{
    internal class UserDAL : BaseDAL
    {
        public DataTable GetAllUserData()
        {
            base.com.CommandText = "spGetAllUser";
            return base.GetDataTable();
        }

        public DataRow GetUserByUserID(string username)
        {
            base.com.CommandText = "spGetUserByUserID";
            base.com.Parameters.AddWithValue("_UserName", username);

            return base.GetFirstRow();
        }
    }
}
