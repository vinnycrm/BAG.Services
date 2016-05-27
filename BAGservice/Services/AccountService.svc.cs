using BAGservice.ServiceInterface;
using BAG.DataInterface;
using System;
using System.ServiceModel.Activation;
using BAG.Account.DataAccess;
using BAG.DataObject;
using BAG.CustomObject;

namespace BAGservice.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode
        = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IAccountService
    {
        
        public string AddMembers(Registration obj)
        {
            try
            {
                U_USR_LgnDAL ologonDAL = new U_USR_LgnDAL();
                U_USR_MASTERDAL oMstDAL = new U_USR_MASTERDAL();
                U_USR_Lgn Lgnobj = new U_USR_Lgn();
                U_USR_MASTER Mstobj = new U_USR_MASTER();
                if (string.IsNullOrEmpty(ologonDAL.CheckEmail_Exist(obj.Email_Id)))
                {
                    Mstobj.Usr_Id = Guid.NewGuid().ToString();
                    Mstobj.Usr_role_Id = "";
                    Mstobj.Date_Of_Birth = DateTime.Now;
                    Mstobj.First_Name = obj.First_Name;
                    Mstobj.Alt_Email_Id = string.Empty;
                    Mstobj.Gender = string.Empty;
                    Mstobj.Is_married = 0;
                    Mstobj.Last_Name = string.Empty;
                    Mstobj.Media_Id_Img = "1";
                    Mstobj.Address_Id = "1";
                    Mstobj.Rating = string.Empty;
                    Mstobj.Updated_by = string.Empty;
                    Mstobj.Updated_Date = DateTime.Now;
                    Mstobj.Wed_anniversary = DateTime.Now;
                    Mstobj.About_member = string.Empty;
                    Mstobj.Created_by = string.Empty;
                    Mstobj.Created_Date = DateTime.Now;
                    var status = oMstDAL.InsertU_USR_MASTER(Mstobj);
                    if (status)
                    {
                        Lgnobj.Login_Id = Guid.NewGuid().ToString();
                        Lgnobj.Login_status = 0;
                        Lgnobj.Email_ID = obj.Email_Id;
                        Lgnobj.Mobile_Number = obj.Phone_No;
                        Lgnobj.Pwd = obj.Password;
                        Lgnobj.Created_by = string.Empty;
                        Lgnobj.Updated_by = string.Empty;
                        Lgnobj.Updated_Date = DateTime.Now;
                        Lgnobj.Created_Date = DateTime.Now;
                        Lgnobj.Last_Login_Date = DateTime.Now;
                        Lgnobj.Ip_Address = string.Empty;
                        Lgnobj.Usr_Mst_Id = Mstobj.Usr_Id;
                        status = ologonDAL.InsertU_USR_Lgn(Lgnobj);
                    }
                    if(status==true)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0"; // 0 indicates unsuccessfull
                    }
                }
                else
                {
                    return "2";  // 2 indicates email id already exists
                }
            }
            catch
            {
                return "0"; // 0 indicates unsuccessfull
            }
        }

        public Login AddMembers_ThirdParty(SocialRegistration obj)
        {
            try
            {
                U_USR_LgnDAL ologonDAL = new U_USR_LgnDAL();
                U_USR_MASTERDAL oMstDAL = new U_USR_MASTERDAL();
                U_USR_Lgn Lgnobj = new U_USR_Lgn();
                U_USR_MASTER Mstobj = new U_USR_MASTER();
                string user_id = ologonDAL.CheckLoginId_Exist(obj.Id);
                if (string.IsNullOrEmpty(user_id))
                {
                    Mstobj.Usr_Id = Guid.NewGuid().ToString();
                    Mstobj.Usr_role_Id = "";
                    Mstobj.Date_Of_Birth = DateTime.Now;
                    Mstobj.First_Name = obj.First_Name;
                    Mstobj.Alt_Email_Id = string.Empty;
                    Mstobj.Gender = string.Empty;
                    Mstobj.Is_married = 0;
                    Mstobj.Last_Name = string.Empty;
                    Mstobj.Media_Id_Img = "1";
                    Mstobj.Address_Id = "1";
                    Mstobj.Rating = string.Empty;
                    Mstobj.Updated_by = string.Empty;
                    Mstobj.Updated_Date = DateTime.Now;
                    Mstobj.Wed_anniversary = DateTime.Now;
                    Mstobj.About_member = string.Empty;
                    Mstobj.Created_by = string.Empty;
                    Mstobj.Created_Date = DateTime.Now;
                    var status = oMstDAL.InsertU_USR_MASTER(Mstobj);
                    if (status)
                    {
                        Lgnobj.Login_Id = obj.Id;
                        Lgnobj.Login_status = 2;
                        Lgnobj.Email_ID = obj.Email_Id;
                        Lgnobj.Mobile_Number = obj.Phone_No;
                        Lgnobj.Pwd = string.Empty;
                        Lgnobj.Created_by = string.Empty;
                        Lgnobj.Updated_by = string.Empty;
                        Lgnobj.Updated_Date = DateTime.Now;
                        Lgnobj.Created_Date = DateTime.Now;
                        Lgnobj.Last_Login_Date = DateTime.Now;
                        Lgnobj.Ip_Address = string.Empty;
                        Lgnobj.Usr_Mst_Id = Mstobj.Usr_Id;
                        status = ologonDAL.InsertU_USR_Lgn(Lgnobj);
                    }
                    if (status == true)
                    {
                        Login ologin = new Login();
                        user_id= ologonDAL.CheckLoginId_Exist(obj.Id);
                        ologin.First_Name = obj.First_Name;
                        ologin.Id = user_id;
                        return ologin;
                    }
                    else
                    {
                        return null;  //  indicates unsuccessfull
                    }
                }
                else
                {
                    Login ologin = new Login();
                    ologin.First_Name = obj.First_Name;
                    ologin.Id = user_id;
                    return ologin;   //  indicates LoginId already exists
                }
            }
            catch
            {
                return null; //  indicates unsuccessfull
            }
        }


        public Login GetMemberDetails(string EmailId, string password)
        {
            U_USR_LgnDAL olgnDAL = new U_USR_LgnDAL();
            return olgnDAL.GetLoginDetails(EmailId, password); 
        }

        public string ActivateMember(string member_id)
        {
            try
            {
                U_USR_LgnDAL olgnDAL = new U_USR_LgnDAL();
                olgnDAL.ActivateMember(member_id);
                return "1";
            }
            catch
            {
                return "0";
            }
        }

        public Profile GetUserProfile(string UserId)
        {
            U_USR_MASTERDAL odal = new U_USR_MASTERDAL();
            return odal.Select_UserProfile(UserId);
        }

        public string UpdateProfile(Profile odetails)
        {
            try
            {
                string mediaId = string.Empty;
                var userprofile=GetUserProfile(odetails.Usr_Id);
                if(!string.IsNullOrEmpty(odetails.Media_Id_Img))
                {
                    mediaId = Guid.NewGuid().ToString();
                    U_ADM_MEDIA_MASTERDAL omediaDAL = new U_ADM_MEDIA_MASTERDAL();
                    U_ADM_MEDIA_MASTER omaster = new U_ADM_MEDIA_MASTER();
                    omaster.Media_Id = mediaId;
                    omaster.Media_Oth_Dtl = "";
                    omaster.Media_Source = "";
                    omaster.Media_Type = "Image";
                    omaster.Updated_by = odetails.Usr_Id;
                    omaster.Updated_Date = DateTime.Now;
                    omaster.Created_by = odetails.Usr_Id;
                    omaster.Created_Date = DateTime.Now;
                    omaster.Media_File_Location = odetails.Media_Id_Img;
                    omediaDAL.InsertU_ADM_MEDIA_MASTER(omaster);
                }
                U_USR_MASTERDAL ousrDAL = new U_USR_MASTERDAL();
                U_USR_MASTER ousr = new U_USR_MASTER();
                ousr.Usr_Id = odetails.Usr_Id;
                ousr.About_member = string.IsNullOrEmpty(odetails.About_member)?userprofile.About_member:odetails.About_member;
                ousr.First_Name = string.IsNullOrEmpty(odetails.First_Name)?userprofile.First_Name:odetails.First_Name;
                ousr.Last_Name = string.IsNullOrEmpty(odetails.Last_Name)?userprofile.Last_Name:odetails.Last_Name;
                ousr.Gender = string.IsNullOrEmpty(odetails.Gender)?userprofile.Gender:odetails.Gender;
                ousr.Is_married = odetails.Is_married;
                ousr.Wed_anniversary = string.IsNullOrEmpty(Convert.ToString(odetails.Wed_anniversary))?userprofile.Wed_anniversary:odetails.Wed_anniversary;
                ousr.Updated_by = odetails.Usr_Id;
                ousr.Updated_Date = DateTime.Now;
                ousr.Date_Of_Birth = string.IsNullOrEmpty(Convert.ToString(odetails.Date_Of_Birth))?DateTime.Now:odetails.Date_Of_Birth;
                ousr.Created_Date = DateTime.Now;
                ousr.Alt_Email_Id = string.IsNullOrEmpty(odetails.Alt_Email_Id)?userprofile.Alt_Email_Id:odetails.Alt_Email_Id;
                ousr.Address_Id = string.IsNullOrEmpty(odetails.Address_Id)?userprofile.Address_Id:odetails.Address_Id;
                ousr.Media_Id_Img = string.IsNullOrEmpty(mediaId)?userprofile.Extn:mediaId;
                ousrDAL.Update_UserProfile(ousr);
                return "1";

            }
            catch
            {
                return "0"; // 0 indicates unsuccessfull
            }
        }

        public string ChangePassword(ProfileSecurity obj)
        {
            try
            {
                U_USR_LgnDAL odal = new U_USR_LgnDAL();
                return Convert.ToString(odal.ChangePassword(obj.Usr_Id, obj.New_Password, obj.Old_Password));
            }
            catch
            {
                return "";
            }
        }

        public string CheckUserId(string EmailId)
        {
            try
            {
                U_USR_LgnDAL odal = new U_USR_LgnDAL();
                return odal.CheckEmail_Exist(EmailId);
            }
            catch
            {
                return "";
            }
        }

        public string Reset_Password(string LoginId,string Pwd)
        {
            try
            {
                U_USR_LgnDAL odal = new U_USR_LgnDAL();
                return odal.ResetPassword(LoginId,Pwd).ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
