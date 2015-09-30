using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.BLL;

namespace libPOS.DAL
{
    internal class ProductsDAL :BaseDAL
    {

        internal DataTable GetAllProducts()
        {
            base.com.CommandText = "spGetAllProducts";
            return base.GetDataTable();
        }

        internal DataTable GetAllPhones()
        {
            base.com.CommandText = "spGetAllPhones";
            return base.GetDataTable();
        }

        internal DataTable GetPhoneByTypeByKiosk(int type, int kioskid)
        {
            base.com.CommandText = "spGetProductsByTypeByKiosk";
            base.com.Parameters.AddWithValue("_Type", type);
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            return base.GetDataTable();
        }

        internal DataTable GetAllTablets()
        {
            base.com.CommandText = "spGetAllTablets";
            return base.GetDataTable();
        }

        internal bool InsertNewItem(Products ins, int Type, string admin)
        {
            base.com.CommandText = "spInsertProductbyType";
            base.com.Parameters.AddWithValue("_Name", ins.Name);
            base.com.Parameters.AddWithValue("_Price", ins.Price);
            base.com.Parameters.AddWithValue("_Categ", Type);
            base.com.Parameters.AddWithValue("_UnitCode", ins.UnitCode);
            base.com.Parameters.AddWithValue("_ImgUrl", ins.ImgUrl);
            base.com.Parameters.AddWithValue("_ImgWidth", ins.ImgWidth);
            base.com.Parameters.AddWithValue("_ImgHeight", ins.ImgHeight);
            base.com.Parameters.AddWithValue("_Specs", ins.Specs);
            base.com.Parameters.AddWithValue("_DateCreated", ins.DateCreated);
            base.com.Parameters.AddWithValue("_DateUpdated", ins.DateUpdated);
            base.com.Parameters.AddWithValue("_EmpID", ins.EmpID);
            base.com.Parameters.AddWithValue("_ProdCode", ins.ProdCode);
            base.com.Parameters.AddWithValue("_ColorCode", ins.ColorCode);
            base.com.Parameters.AddWithValue("_IMEI", "");
            base.com.Parameters.AddWithValue("_Active", ins.Active);
            base.com.Parameters.AddWithValue("_CreatedBy", admin);

            //int res = Convert.ToInt32(base.com.ExecuteScalar());
            int res;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception ee)
            {
                //throw new Exception("Insert Data Failed");
                throw new Exception(ee.Message);
            }
            finally
            {
                closeConnection();
            }

            return (res > 0);
        }

        internal bool UpdatedSelItem(Products ins, int Type, string admin)
        {
            base.com.CommandText = "spUpdateProductByType";
            base.com.Parameters.AddWithValue("_ID", ins.ID);
            base.com.Parameters.AddWithValue("_Name", ins.Name);
            base.com.Parameters.AddWithValue("_Price", ins.Price);
            base.com.Parameters.AddWithValue("_Categ", Type);
            base.com.Parameters.AddWithValue("_UnitCode", ins.UnitCode);
            base.com.Parameters.AddWithValue("_ImgUrl", ins.ImgUrl);
            base.com.Parameters.AddWithValue("_ImgWidth", ins.ImgWidth);
            base.com.Parameters.AddWithValue("_ImgHeight", ins.ImgHeight);
            base.com.Parameters.AddWithValue("_Specs", ins.Specs);
            base.com.Parameters.AddWithValue("_EmpID", ins.EmpID);
            base.com.Parameters.AddWithValue("_ProdCode", ins.ProdCode);
            base.com.Parameters.AddWithValue("_ColorCode", ins.ColorCode);
            base.com.Parameters.AddWithValue("_IMEI", "");
            base.com.Parameters.AddWithValue("_Active", ins.Active);
            base.com.Parameters.AddWithValue("_CreatedBy", admin);

            int res;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }

            return (res > 0);
        }

        internal DataTable GetAllProductsFilterByType(int type, string filter)
        {
            base.com.CommandText = "spGetAllProductsFilterByType";
            base.com.Parameters.AddWithValue("_type", type);
            base.com.Parameters.AddWithValue("_namefilter", filter);
            return base.GetDataTable();
        }

        internal DataTable GetAllAccessories()
        {
            base.com.CommandText = "spGetAllAccessories";
            return base.GetDataTable();
        }

        internal void UpdateActiveStatus(string status, int id, string admin)
        {
            base.com.CommandText = "spUpdateProductActive";
            base.com.Parameters.AddWithValue("_Active", status);
            base.com.Parameters.AddWithValue("_ProdID", id);
            base.com.Parameters.AddWithValue("_CreatedBy", admin);

            try
            {

                base.com.ExecuteScalar();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

        }
    }
}
