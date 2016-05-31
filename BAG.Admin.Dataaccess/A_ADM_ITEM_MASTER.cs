using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAG.Admin.Dataobject;
using BAG.CommonConstants;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

using System.Data;

namespace BAG.Admin.Dataaccess
{
    public class A_ADM_ITEM_MASTERDAL
    {
        private const string SQL_U_ADM_ITEM_MASTER_V2 = "SELECT i.Item_Id, img.Media_File_Location, img.Media_Source, i.Item_Name, i.Item_Tentative_Cost, i.Item_Status from U_ADM_ITEM_MASTER as i inner join U_ADM_MEDIA_MASTER as img on i.Media_Id_Img = img.Media_Id";
        private const string SQL_Select_Single_Item = "SELECT i.Item_Id, img.Media_File_Location, i.Item_Name, i.Item_Desc, i.Item_Status, i.Item_Tentative_Cost, i.Item_Source from U_ADM_ITEM_MASTER as i inner join U_ADM_MEDIA_MASTER as img on i.Media_Id_Img = img.Media_Id  where i.Item_Id =@Item_Id";
        private const string SQL_SELECT_ALL = "SELECT Item_Id, Item_Name, Item_Desc, Item_Status, Item_Tentative_Cost, Item_Source, Media_Id_Img, Media_Id_Video, Created_Date, Updated_Date, Created_by, Updated_by FROM U_ADM_ITEM_MASTER where Item_Id=@Item_Id";
        private const string SQL_INSERT_U_ADM_ITEM_MASTER = "INSERT INTO U_ADM_ITEM_MASTER VALUES(@Item_Id, @Item_Name, @Item_Desc, @Item_Status, @Item_Tentative_Cost, @Item_Source, @Media_Id_Img, @Media_Id_Video, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
        private const string SQL_BlockThisItem = "UPDATE U_ADM_ITEM_MASTER SET Item_Status='0' WHERE Item_Id=@Item_Id";
        private const string SQL_UnblockThisItem = "UPDATE U_ADM_ITEM_MASTER SET Item_Status='1' WHERE Item_Id=@Item_Id";
        private const string SQL_UPDATE_U_ADM_ITEM_MASTER = "Update U_ADM_ITEM_MASTER SET Item_Name=@Item_Name, Item_Desc=@Item_Desc, Item_Status=@Item_Status, Item_Tentative_Cost=@Item_Tentative_Cost, Item_Source=@Item_Source, Media_Id_Img=@Media_Id_Img, Media_Id_Video=@Media_Id_Video, Created_Date=@Created_Date, Updated_Date=@Updated_Date, Created_by=@Created_by, Updated_by=@Updated_by where Item_Id=@Item_Id";
        private const string SQL_Items_Count = "select COUNT(*) from U_ADM_ITEM_MASTER";

        private const string PARAM_Item_Id = "@Item_Id";
        private const string PARAM_Item_Name = "@Item_Name";
        private const string PARAM_Item_Desc = "@Item_Desc";
        private const string PARAM_Item_Status = "@Item_Status";
        private const string PARAM_Item_Tentative_Cost = "@Item_Tentative_Cost";
        private const string PARAM_Item_Source = "@Item_Source";
        private const string PARAM_Media_Id_Img = "@Media_Id_Img";
        private const string PARAM_Media_Id_Video = "@Media_Id_Video";
        private const string PARAM_Created_Date = "@Created_Date";
        private const string PARAM_Updated_Date = "@Updated_Date";
        private const string PARAM_Created_by = "@Created_by";
        private const string PARAM_Updated_by = "@Updated_by";

        public Dataobject.A_ADM_ITEM_MASTER[] GetItemsDetailsDb()
        {
            SqlConnection con = null;
            List<Dataobject.A_ADM_ITEM_MASTER> Items = new List<Dataobject.A_ADM_ITEM_MASTER>();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_U_ADM_ITEM_MASTER_V2);
                while (reader.Read())
                {
                    Items.Add(new A_ADM_ITEM_MASTER(reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetDecimal(4), reader.GetString(5),null,null,null,null));
                }
                reader.Close();
                return Items.ToArray();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
            }

        }

        public bool InsertU_ADM_ITEM_MASTER(U_ADM_ITEM_MASTER obj)
        {
            if(obj != null)
            {
                SqlParameter[] lParamArray = GetParameters(obj);
                SetParameters(lParamArray, obj);
                SqlConnection con = General.GetConnection();
                if (con == null)
                    //Connection is not created 
                    return false;
                //Execute the insertion
                int i = SqlHelper.ExecuteNonQuery(
                    con,
                    CommandType.Text,
                    SQL_INSERT_U_ADM_ITEM_MASTER,
                    lParamArray);
                //Dispose the Sql connection 
                con.Dispose();
                if (i == 1)
                    //Done and insert the object to the table
                    return true;
                else
                    //Fail to execute the insertion
                    return false;
            }
            else
                //No object found to insert
                return false;
        }

        public A_ADM_ITEM_MASTER GetSingleItemDetailsDb(string id)
        {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Item_Id, id) };
            A_ADM_ITEM_MASTER item = new A_ADM_ITEM_MASTER();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_Select_Single_Item, aParms);
                while (reader.Read())
                {
                    item.Item_ID = reader.GetString(0);
                    item.Item_PicUrl = reader.GetString(1);
                    item.Item_Name = reader.GetString(2);
                    item.Item_Desc = reader.GetString(3);
                    item.Item_Status = reader.GetString(4);
                    item.Item_Price = reader.GetDecimal(5);
                    item.Item_Source = reader.GetString(6);
                }
                reader.Close();
                return item;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public U_ADM_ITEM_MASTER SelectItemDetailsDb(string id)
        {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Item_Id, id) };
            U_ADM_ITEM_MASTER item = new U_ADM_ITEM_MASTER();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_SELECT_ALL, aParms);
                while (reader.Read())
                {

                    item.Item_Id = reader.GetString(0);
                    item.Item_Name = reader.GetString(1);
                    item.Item_Desc = reader.GetString(2);
                    item.Item_Status = reader.GetString(3);
                    item.Item_Tentative_Cost = reader.GetDecimal(4);
                    item.Item_Source = reader.GetString(5);
                    item.Media_Id_Img = reader.GetString(6);
                    item.Media_Id_Video = reader.GetString(7);
                    item.Created_Date = reader.GetDateTime(8);
                    item.Updated_Date = reader.GetDateTime(9);
                    item.Created_by = reader.GetString(10);
                    item.Updated_by = reader.GetString(11);
                }
                reader.Close();
                return item;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public bool GetBlockThisItemDb(string Id)
        {
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Item_Id, Id) };
            bool status;
            using (SqlConnection conn = General.GetConnection())
            {
                // conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_BlockThisItem, aParms);
                        trans.Commit();
                        status = true;
                    }
                    catch (System.Exception e)
                    {
                        Console.Write(e);
                        trans.Rollback();
                        throw;
                    }
                }
            }
            return status;
        }

        public bool GetUnblockThisItemDb(string Id)
        {
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Item_Id, Id) };
            bool status;
            using (SqlConnection conn = General.GetConnection())
            {
                // conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UnblockThisItem, aParms);
                        trans.Commit();
                        status = true;
                    }
                    catch (System.Exception e)
                    {
                        Console.Write(e);
                        trans.Rollback();
                        throw;
                    }
                }
            }
            return status;
        }

        public bool UpdateItemMaster(U_ADM_ITEM_MASTER item)
        {
            SqlParameter[] aParms = GetParameters(item);
            SetParameters(aParms, item);
            using (SqlConnection conn = General.GetConnection())
            {
                bool status = false;
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_U_ADM_ITEM_MASTER, aParms);
                        trans.Commit();
                        status = true;
                    }
                    catch (System.Exception e)
                    {
                        Console.Write(e);
                        trans.Rollback();
                        //log.Error(lobjError, e);
                        throw;
                    }
                }
                return status;
            }
        }

        public string GetItemsCountDb()
        {
            SqlConnection con = null;

            string ItemsCount = string.Empty;
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_Items_Count);
                while (reader.Read())
                {
                    ItemsCount = Convert.ToString(reader.GetInt32(0));
                }
                reader.Close();
                return ItemsCount;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        private SqlParameter[] GetParameters(U_ADM_ITEM_MASTER toObjU_ADM_ITEM_MASTER)
        {
            SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_ADM_ITEM_MASTER);
            if (objParamArray == null)
            {
                objParamArray = new SqlParameter[]
            {
                new SqlParameter(PARAM_Item_Id, toObjU_ADM_ITEM_MASTER.Item_Id),
                new SqlParameter(PARAM_Item_Name, toObjU_ADM_ITEM_MASTER.Item_Name),
                new SqlParameter(PARAM_Item_Desc, toObjU_ADM_ITEM_MASTER.Item_Desc),
                new SqlParameter(PARAM_Item_Status, toObjU_ADM_ITEM_MASTER.Item_Status),
                new SqlParameter(PARAM_Item_Tentative_Cost, toObjU_ADM_ITEM_MASTER.Item_Source),
                new SqlParameter(PARAM_Item_Source, toObjU_ADM_ITEM_MASTER.Item_Source),
                new SqlParameter(PARAM_Media_Id_Img, toObjU_ADM_ITEM_MASTER.Media_Id_Img),
                new SqlParameter(PARAM_Media_Id_Video, toObjU_ADM_ITEM_MASTER.Media_Id_Video),
                new SqlParameter(PARAM_Created_Date, toObjU_ADM_ITEM_MASTER.Created_Date),
                new SqlParameter(PARAM_Updated_Date, toObjU_ADM_ITEM_MASTER.Updated_Date),
                new SqlParameter(PARAM_Created_by, toObjU_ADM_ITEM_MASTER.Created_by),
                new SqlParameter(PARAM_Updated_by, toObjU_ADM_ITEM_MASTER.Updated_by),
            };
                SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_ADM_ITEM_MASTER, objParamArray);
            }
            return objParamArray;
        }

        private void SetParameters(SqlParameter[] U_ADM_MEDIA_MASTERParms, U_ADM_ITEM_MASTER toObjU_ADM_ITEM_MASTER)
        {
            U_ADM_MEDIA_MASTERParms[0].Value = toObjU_ADM_ITEM_MASTER.Item_Id;
            U_ADM_MEDIA_MASTERParms[1].Value = toObjU_ADM_ITEM_MASTER.Item_Name;
            U_ADM_MEDIA_MASTERParms[2].Value = toObjU_ADM_ITEM_MASTER.Item_Desc;
            U_ADM_MEDIA_MASTERParms[3].Value = toObjU_ADM_ITEM_MASTER.Item_Status;
            U_ADM_MEDIA_MASTERParms[4].Value = toObjU_ADM_ITEM_MASTER.Item_Tentative_Cost;
            U_ADM_MEDIA_MASTERParms[5].Value = toObjU_ADM_ITEM_MASTER.Item_Source;
            U_ADM_MEDIA_MASTERParms[6].Value = toObjU_ADM_ITEM_MASTER.Media_Id_Img;
            U_ADM_MEDIA_MASTERParms[7].Value = toObjU_ADM_ITEM_MASTER.Media_Id_Video;
            U_ADM_MEDIA_MASTERParms[8].Value = toObjU_ADM_ITEM_MASTER.Created_Date;
            U_ADM_MEDIA_MASTERParms[9].Value = toObjU_ADM_ITEM_MASTER.Updated_Date;
            U_ADM_MEDIA_MASTERParms[10].Value = toObjU_ADM_ITEM_MASTER.Created_by;
            U_ADM_MEDIA_MASTERParms[11].Value = toObjU_ADM_ITEM_MASTER.Updated_by;
        }
    }
}
