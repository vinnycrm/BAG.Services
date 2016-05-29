using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAG.Admin.Dataobject;
using System.Data.SqlClient;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
namespace BAG.Admin.Dataaccess
{
    public class A_ADM_Coupon_RefDAL
    {
        private const string SQL_U_ADM_Coupon_Ref_V2 = "SELECT [Coupon_ID], [Coupon_Name], [Coupon_StartDate], [Coupon_EndDate], [Coupon_Status] FROM [BAG].[dbo].[U_ADM_Coupon_Ref]";
        private const string SQL_INSER_U_ADM_Coupon_Ref = "INSERT INTO U_ADM_Coupon_Ref VALUES(@Coupon_ID, @Coupon_Name, @Coupon_VendorName, @Coupon_Desc, @Coupon_StartDate, @Coupon_EndDate, @Coupon_Status, @Media_Id_Img, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
        private const string SQL_Select_Coupon_Details = "SELECT cou.Coupon_ID, cou.Coupon_Name, cou.Coupon_VendorName, cou.Coupon_Desc, cou.Coupon_StartDate, cou.Coupon_EndDate, cou.Coupon_Status, IMG.Media_File_Location, cou.Created_Date, cou.Updated_Date, cou.Created_by, cou.Updated_by FROM U_ADM_Coupon_Ref AS cou INNER JOIN U_ADM_MEDIA_MASTER AS IMG ON cou.Media_Id_Img = IMG.Media_Id WHERE cou.Coupon_ID = @Coupon_ID";
        private const string SQL_Block_Coupon = "UPDATE U_ADM_Coupon_Ref SET Coupon_Status = '0' WHERE Coupon_ID = @Coupon_ID";
        private const string SQL_Unblock_Coupon = "UPDATE U_ADM_Coupon_Ref SET Coupon_Status = '1' WHERE Coupon_ID = @Coupon_ID";
        private const string SQL_UpdateCoupon = "UPDATE U_ADM_Coupon_Ref SET Coupon_Name=@Coupon_Name, Coupon_VendorName=@Coupon_VendorName, Coupon_Desc=@Coupon_Desc, Coupon_StartDate=@Coupon_StartDate, Coupon_EndDate=@Coupon_EndDate, Coupon_Status=@Coupon_Status, Media_Id_Img=@Media_Id_Img, Created_Date=@Created_Date, Updated_Date=@Updated_Date, Created_by=@Created_by, Updated_by=@Updated_by where Coupon_ID=@Coupon_ID";
        private const string SQL_MediaId_Return = "select Media_Id_Img from U_ADM_Coupon_Ref WHERE Coupon_ID = @Coupon_ID";

        private const string PARAM_Coupon_ID = "@Coupon_ID";
        private const string PARAM_Coupon_Name = "@Coupon_Name";
        private const string PARAM_Coupon_VendorName = "@Coupon_VendorName";
        private const string PARAM_Coupon_Desc = "@Coupon_Desc";
        private const string PARAM_Coupon_StartDate = "@Coupon_StartDate";
        private const string PARAM_Coupon_EndDate = "@Coupon_EndDate";
        private const string PARAM_Coupon_Status = "@Coupon_Status";
        private const string PARAM_Media_Id_Img = "@Media_Id_Img";
        private const string PARAM_Created_Date = "@Created_Date";
        private const string PARAM_Updated_Date = "@Updated_Date";
        private const string PARAM_Created_by = "@Created_by";
        private const string PARAM_Updated_by = "@Updated_by";

        public A_ADM_Coupon_RefDAL() { }

        public bool InsertCouponDb(Coupons obj)
        {
            if (obj != null)
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
                    SQL_INSER_U_ADM_Coupon_Ref,
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

        public A_ADM_Coupon_Ref[] GetCouponsDetailsDb()
        {
            SqlConnection con = null;
            List<A_ADM_Coupon_Ref> Coupons = new List<A_ADM_Coupon_Ref>();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_U_ADM_Coupon_Ref_V2);
                while (reader.Read())
                {
                    Coupons.Add(new A_ADM_Coupon_Ref(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetString(4)));
                }
                reader.Close();
                return Coupons.ToArray();
            }
            catch(Exception e)
            {
                Console.Write(e);
                return null;
            }
            finally
            {
                if(con != null)
                {
                    con.Dispose();
                }
            }
        }

        public Coupons GetSingleCouponDetailDb(string id)
        {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Coupon_ID, id) };
            Coupons cou = new Coupons();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_Select_Coupon_Details, aParms);
                while (reader.Read())
                {
                    cou.Coupon_id = reader.GetString(0);
                    cou.Coupon_Name = reader.GetString(1);
                    cou.Coupon_VenderName = reader.GetString(2);
                    cou.Coupon_Desc = reader.GetString(3);
                    cou.Coupon_StartDate = reader.GetDateTime(4);
                    cou.Coupon_EndDate = reader.GetDateTime(5);
                    cou.Coupon_Status = reader.GetString(6);
                    cou.Coupon_PicUrl = reader.GetString(7);
                    cou.Create_Date = reader.GetDateTime(8);
                    cou.Update_Date = reader.GetDateTime(9);
                    cou.Create_By = reader.GetString(10);
                    cou.Update_By = reader.GetString(11);
                }
                reader.Close();
                return cou;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public bool GetBlockThisCouponDb(string Id)
        {
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Coupon_ID, Id) };
            bool status;
            using (SqlConnection conn = General.GetConnection())
            {
                // conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Block_Coupon, aParms);
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

        public bool GetUnblockThisCouponDb(string Id)
        {
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Coupon_ID, Id) };
            bool status;
            using (SqlConnection conn = General.GetConnection())
            {
                // conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Unblock_Coupon, aParms);
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

        public bool UpdateCouponMaster(Coupons cou)
        {
            SqlParameter[] aParms = GetParameters(cou);
            SetParameters(aParms, cou);
            using (SqlConnection conn = General.GetConnection())
            {
                bool status = false;
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UpdateCoupon, aParms);
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

        public string GetCouponMediaIdDb(string id)
        {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Coupon_ID, id) };
            string MediaId = string.Empty;
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_MediaId_Return, aParms);
                while (reader.Read())
                {
                    MediaId = reader.GetString(0);
                }
                reader.Close();
                return MediaId;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        private SqlParameter[] GetParameters(Coupons obj)
        {
            SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSER_U_ADM_Coupon_Ref);
            if (objParamArray == null)
            {
                objParamArray = new SqlParameter[]
            {
                new SqlParameter(PARAM_Coupon_ID, obj.Coupon_id ),
                new SqlParameter(PARAM_Coupon_Name, obj.Coupon_Name ),
                new SqlParameter(PARAM_Coupon_VendorName, obj.Coupon_VenderName),
                new SqlParameter(PARAM_Coupon_Desc, obj.Coupon_Desc ),
                new SqlParameter(PARAM_Coupon_StartDate, obj.Coupon_StartDate),
                new SqlParameter(PARAM_Coupon_EndDate, obj.Coupon_EndDate ),
                new SqlParameter(PARAM_Coupon_Status, obj.Coupon_Status ),
                new SqlParameter(PARAM_Media_Id_Img, obj.Coupon_PicUrl ),
                new SqlParameter(PARAM_Created_Date, obj.Create_Date ),
                new SqlParameter(PARAM_Updated_Date, obj.Update_Date ),
                new SqlParameter(PARAM_Created_by, obj.Create_By ),
                new SqlParameter(PARAM_Updated_by, obj.Update_By ),
            };
                SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSER_U_ADM_Coupon_Ref, objParamArray);
            }
            return objParamArray;
        }

        private void SetParameters(SqlParameter[] dataParam, Coupons obj)
        {
            dataParam[0].Value = obj.Coupon_id;
            dataParam[1].Value = obj.Coupon_Name;
            dataParam[2].Value = obj.Coupon_VenderName;
            dataParam[3].Value = obj.Coupon_Desc;
            dataParam[4].Value = obj.Coupon_StartDate;
            dataParam[5].Value = obj.Coupon_EndDate;
            dataParam[6].Value = obj.Coupon_Status;
            dataParam[7].Value = obj.Coupon_PicUrl;
            dataParam[8].Value = obj.Create_Date;
            dataParam[9].Value = obj.Update_Date;
            dataParam[10].Value = obj.Create_By;
            dataParam[11].Value = obj.Update_By;
        }
    }
}
