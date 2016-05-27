using BAGservice.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using System.Text;
using BAG.DataObject;
using BAG.Contacts.DataAccess;
using System.Web;
using System.IO;
using BAG.CustomObject;

namespace BAGservice.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode
        = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Contacts" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Contacts.svc or Contacts.svc.cs at the Solution Explorer and start debugging.
    public class Contacts : IContacts
    {
        public string ImportContacts(GoogleContacts[] obj)
        {
            try
            {
                U_USR_ContactsDAL ocontactsDAL = new U_USR_ContactsDAL();
                U_USR_Map_ContactDAL omapcntsDAL = new U_USR_Map_ContactDAL();
                foreach (var item in obj)
                {
                    if (string.IsNullOrEmpty(ocontactsDAL.CheckContact_Exist(item.EmailID)))
                    {
                        U_USR_Contacts ocontacts = new U_USR_Contacts();
                        ocontacts.Contact_Id = Guid.NewGuid().ToString();
                        ocontacts.Contact_Source = "Google";
                        ocontacts.Contact_Status = "1";
                        ocontacts.Created_by = "";
                        ocontacts.Created_Date = DateTime.Now;
                        ocontacts.Email_Id = item.EmailID;
                        if(!string.IsNullOrEmpty(item.ContactNo))
                          ocontacts.Mobile_Number = item.ContactNo;
                        else
                            ocontacts.Mobile_Number = "";
                        ocontacts.Person_Name = string.IsNullOrEmpty(item.Name) ? string.Empty : item.Name;
                        ocontacts.Updated_by = "";
                        ocontacts.Updated_Date = DateTime.Now;
                        ocontactsDAL.InsertU_USR_Contacts(ocontacts);
                    }

                }
                foreach (var item in obj)
                {
                    string contactId = ocontactsDAL.CheckContact_Exist(item.EmailID);
                    string mapingId = omapcntsDAL.CheckMaping_Exist(item.UserId,contactId);
                    if (!string.IsNullOrEmpty(contactId) & string.IsNullOrEmpty(mapingId))
                    {
                        U_USR_Map_Contact ocontacts = new U_USR_Map_Contact();
                        ocontacts.Id = Guid.NewGuid().ToString();
                        ocontacts.Contact_Id = contactId;
                        ocontacts.Usr_Id = item.UserId;
                        ocontacts.Comments = "";
                        ocontacts.Created_by = "";
                        ocontacts.Created_Date = DateTime.Now;
                        ocontacts.Updated_by = "";
                        ocontacts.Updated_Date = DateTime.Now;
                        bool status=  omapcntsDAL.InsertU_USR_Map_Contact(ocontacts);
                    }

                }
                return "1"; // 1 successfull
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "0"; // 0 indicates unsuccessfull
            }
        }

        public GoogleContacts[] GetContactDetails(string id)
        {
            try
            {
                U_USR_ContactsDAL ocontactsDAL = new U_USR_ContactsDAL();
                return ocontactsDAL.GetUser_Contacts(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public GroupDetails[] GetUserGroups(string id)
        {
            try
            {
                U_USR_GroupsDAL ocontactsDAL = new U_USR_GroupsDAL();
                return ocontactsDAL.Select_Groups(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public string CreateGroup(GroupDetails obj)
        {
            try
            {
                U_USR_GroupsDAL ocontactsDAL = new U_USR_GroupsDAL();
                U_USR_Groups ogroup = new U_USR_Groups();
                ogroup.Group_Id = Guid.NewGuid().ToString();
                ogroup.Group_Name = obj.Group_Name;
                ogroup.Group_Source = "";
                ogroup.Group_Status = "1";
                ogroup.Usr_Id = obj.User_Id;
                ogroup.Updated_by = "";
                ogroup.Updated_Date = DateTime.Now;
                ogroup.Created_by = "";
                ogroup.Created_Date = DateTime.Now;
                ogroup.Group_Desc = "";
                bool status= ocontactsDAL.InsertU_USR_Groups(ogroup);
                if (status == true)
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public string EditGroup(GroupDetails obj)
        {
            try
            {
                U_USR_GroupsDAL ocontactsDAL = new U_USR_GroupsDAL();
                bool status = ocontactsDAL.Edit_Groups(obj.Group_Id,obj.Group_Name);
                if (status == true)
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public string DeleteGroup(string id)
        {
            try
            {
                U_USR_GroupsDAL ocontactsDAL = new U_USR_GroupsDAL();
                bool status = ocontactsDAL.Delete_Group(id);
                if (status == true)
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public GoogleContacts[] GetGroupContact(string id)
        {
            try
            {
                U_USR_ContactsDAL ocontactsDAL = new U_USR_ContactsDAL();
                return ocontactsDAL.GetGroupContacts(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public string AddGroupContacts(ContactsSummary obj)
        {
            try
            {
                U_USR_Map_Usr_To_ContactDAL ocontactsDAL = new U_USR_Map_Usr_To_ContactDAL();
                U_USR_Map_Usr_To_Contact ocnts = new U_USR_Map_Usr_To_Contact();
                foreach(var items in obj.UserContacts)
                {
                    if (string.IsNullOrEmpty(ocontactsDAL.IsGroupContact_Exist(obj.groupId, items.UserId)))
                    {
                        ocnts.UsrMap_Seq_Id = Guid.NewGuid().ToString();
                        ocnts.Usr_Id = obj.createrId;
                        ocnts.Contact_Id = items.UserId;
                        ocnts.Group_Id = obj.groupId;
                        ocnts.Comments = "";
                        ocnts.Created_by = "";
                        ocnts.Created_Date = DateTime.Now;
                        ocnts.Updated_by = "";
                        ocnts.Updated_Date = DateTime.Now;
                        ocontactsDAL.InsertU_USR_Map_Usr_To_Contact(ocnts);
                    }
                }
                return "1"; // 1 successfull
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "0"; // 0 indicates unsuccessfull
            }
        }

        public string DeleteContact(DeleteContact obj)
        {
            try
            {
                U_USR_Map_ContactDAL ocontactsDAL = new U_USR_Map_ContactDAL();
                bool status = ocontactsDAL.Delete_UserContact(obj.Id,obj.Contact_Id);
                if (status == true)
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public string RemoveGroupContact(DeleteContact obj)
        {
            try
            {
                U_USR_Map_Usr_To_ContactDAL ocontactsDAL = new U_USR_Map_Usr_To_ContactDAL();
                bool status = ocontactsDAL.Delete_GroupContact(obj.Id,obj.Contact_Id);
                if (status == true)
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public string EditContact(EditContact obj)
        {
            try
            {
                U_USR_ContactsDAL ocontactsDAL = new U_USR_ContactsDAL();
                return ocontactsDAL.Edit_Contact(obj.Id, obj.Phone_No,obj.Name);
                
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }
    }
}
