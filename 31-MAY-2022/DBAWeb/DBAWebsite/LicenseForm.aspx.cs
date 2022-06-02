using DBAWebsite.APP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBAWebsite
{
    public partial class LicenseForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Application["LicenseInfo_Server_Name"] != null)
                    lblhead_servername.Text = Application["LicenseInfo_Server_Name"].ToString();

                licenseCategory_dropdownlist_dataBinding();
                contactPerson_dropdownlist_dataBinding();
                contactteam_dropdownlist_DataBinding();
                Location_dropdownlist_DataBinding();               
            }
            else
            {
                string datepickervalue = Request.Form["purchasedate"];
                Hidden1.Value = datepickervalue;
            }
        }

        protected void licenseCategory_dropdownlist_dataBinding()
        {
            DataTable inventoryType = new DataTable();


            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "licensecategory";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    inventoryType.Load(reader);

                    licenseCategory_dropdownlist.DataSource = inventoryType;
                    licenseCategory_dropdownlist.DataTextField = "License_Category";
                    licenseCategory_dropdownlist.DataValueField = "License_Category";
                    licenseCategory_dropdownlist.DataBind();

                    Logging.LogInfo("Successful binding on: License_Category Dropdown", true);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error in data bind -- License_Category dropdown");
                }

            }
        }

        protected void contactPerson_dropdownlist_dataBinding()
        {
            DataTable contact_person = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "itcontactperson";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    contact_person.Load(reader);

                    contactperson_dropdownlist.DataSource = contact_person;
                    contactperson_dropdownlist.DataTextField = "displayName";
                    contactperson_dropdownlist.DataValueField = "displayName";
                    contactperson_dropdownlist.DataBind();
                    //licensePurchaseby_dropdownlist
                    licensePurchaseby_dropdownlist.DataSource = contact_person;
                    licensePurchaseby_dropdownlist.DataTextField = "displayName";
                    licensePurchaseby_dropdownlist.DataValueField = "displayName";
                    licensePurchaseby_dropdownlist.DataBind();
                    Logging.LogInfo("Successful binding on: contactPerson Dropdown", true);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error in data bind -- contactPerson(LicenseReport) dropdown");
                }

            }
        }

        protected void contactteam_dropdownlist_DataBinding()
        {
            DataTable contact_team = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "itcontactteam";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    contact_team.Load(reader);

                    contactTeam_dropdownlist.DataSource = contact_team;
                    contactTeam_dropdownlist.DataTextField = "IT Contact Team";
                    contactTeam_dropdownlist.DataValueField = "IT Contact Team";
                    contactTeam_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void Location_dropdownlist_DataBinding()
        {
            DataTable location_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "location";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    location_info.Load(reader);

                    licenseLocation_dropdownlist.DataSource = location_info;
                    licenseLocation_dropdownlist.DataTextField = "Site Name";
                    licenseLocation_dropdownlist.DataValueField = "Site Name";
                    licenseLocation_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            string serverName = lblhead_servername.Text;

            string purchaseOrderNumber = license_purchaseorderNumber.Text;
            string purchaseDate = Hidden1.Value;
            string purchaseQuantity = license_purchaseQuantity.Text;
            string contactPerson = contactperson_dropdownlist.SelectedItem.Text;
            string contactTeam = contactTeam_dropdownlist.SelectedItem.Text;
            string license_Category = licenseCategory_dropdownlist.SelectedItem.Text;
            string license_Location = licenseLocation_dropdownlist.SelectedItem.Text;
            string license_PurchasedBy = licensePurchaseby_dropdownlist.SelectedItem.Text;
            string license_OtherNumber = licenseNumber_txt.Text;
            string numberofUsers = Noofusers_txt.Text;
            string overalllicense_notes = Request.Form["license_overall_notes"];

            int insertRowsAffected = 0;

            string connString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();               
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO licenseFORM ([ServerName],[PurchaseOrderNumber],[PurchaseDate],[PurchaseQuantity],[ContactPerson],[ContactTeam],[LicenseCategory],[LicenseLocation],[LicensePurchaseBy],[LicenseOtherNumber],[NumberofUsers],[OverallLicenseNotes]) Values (@ServerName,@PurchaseOrderNumber,@PurchaseDate,@PurchaseQuantity,@ContactPerson,@ContactTeam,@LicenseCategory,@LicenseLocation,@LicensePurchaseBy,@LicenseOtherNumber,@NumberofUsers,@OverallLicenseNotes)";

                        SqlParameter[] param = new SqlParameter[15];

                        param[3] = new SqlParameter("@ServerName", SqlDbType.NVarChar, 50);
                        param[4] = new SqlParameter("@PurchaseOrderNumber", SqlDbType.NVarChar, 50);
                        param[5] = new SqlParameter("@PurchaseDate", SqlDbType.DateTime);
                        param[6] = new SqlParameter("@PurchaseQuantity", SqlDbType.NVarChar, 50);
                        param[7] = new SqlParameter("@ContactPerson", SqlDbType.NVarChar, 50);
                        param[8] = new SqlParameter("@ContactTeam", SqlDbType.NVarChar, 50);
                        param[9] = new SqlParameter("@LicenseCategory", SqlDbType.NVarChar, 50);
                        param[10] = new SqlParameter("@LicenseLocation", SqlDbType.NVarChar, 50);
                        param[11] = new SqlParameter("@LicensePurchaseBy", SqlDbType.NVarChar, 50);
                        param[12] = new SqlParameter("@LicenseOtherNumber", SqlDbType.NVarChar, 50);
                        param[13] = new SqlParameter("@NumberofUsers", SqlDbType.NVarChar, 50);
                        param[14] = new SqlParameter("@OverallLicenseNotes", SqlDbType.NVarChar, 100);


                        param[3].Value = serverName;
                        param[4].Value = purchaseOrderNumber;
                        param[5].Value = purchaseDate;
                        param[6].Value = purchaseQuantity;
                        param[7].Value = contactPerson;
                        param[8].Value = contactTeam;
                        param[9].Value = license_Category;
                        param[10].Value = license_Location;
                        param[11].Value = license_PurchasedBy;
                        param[12].Value = license_OtherNumber;
                        param[13].Value = numberofUsers;
                        param[14].Value = overalllicense_notes;                        


                        for (int i = 3; i < param.Length; i++)
                        {
                            cmd.Parameters.Add(param[i]);
                        }


                        insertRowsAffected = cmd.ExecuteNonQuery();
                        Logging.LogInfo("Successful inserted records into: licenseFORM", true);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while inserting records into: licenseFORM  -- LicenseReport screen");
                }

                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE InventoryTracking set [PONumber]=@PurchaseOrderNumber,[PurchaseDate]=@PurchaseDate,[PurchaseQuantity]=@PurchaseQuantity,[ContactPerson]=@ContactPerson,[ContactTeam]=@ContactTeam,[LCatogery]=@LicenseCategory,[LLocation]=@LicenseLocation,[LPurchasedby]=@LicensePurchaseBy,[LOtherNo]=@LicenseOtherNumber,[Number of Users]=@NumberofUsers,[Notes]=@OverallLicenseNotes WHERE [ServerName]=@ServerName";

                        SqlParameter[] param = new SqlParameter[15];

                        param[3] = new SqlParameter("@ServerName", SqlDbType.NVarChar, 50);
                        param[4] = new SqlParameter("@PurchaseOrderNumber", SqlDbType.NVarChar, 50);
                        param[5] = new SqlParameter("@PurchaseDate", SqlDbType.DateTime);
                        param[6] = new SqlParameter("@PurchaseQuantity", SqlDbType.NVarChar, 50);
                        param[7] = new SqlParameter("@ContactPerson", SqlDbType.NVarChar, 50);
                        param[8] = new SqlParameter("@ContactTeam", SqlDbType.NVarChar, 50);
                        param[9] = new SqlParameter("@LicenseCategory", SqlDbType.NVarChar, 50);
                        param[10] = new SqlParameter("@LicenseLocation", SqlDbType.NVarChar, 50);
                        param[11] = new SqlParameter("@LicensePurchaseBy", SqlDbType.NVarChar, 50);
                        param[12] = new SqlParameter("@LicenseOtherNumber", SqlDbType.NVarChar, 50);
                        param[13] = new SqlParameter("@NumberofUsers", SqlDbType.NVarChar, 50);
                        param[14] = new SqlParameter("@OverallLicenseNotes", SqlDbType.NVarChar, 100);


                        param[3].Value = serverName;
                        param[4].Value = purchaseOrderNumber;
                        param[5].Value = purchaseDate;
                        param[6].Value = purchaseQuantity;
                        param[7].Value = contactPerson;
                        param[8].Value = contactTeam;
                        param[9].Value = license_Category;
                        param[10].Value = license_Location;
                        param[11].Value = license_PurchasedBy;
                        param[12].Value = license_OtherNumber;
                        param[13].Value = numberofUsers;
                        param[14].Value = overalllicense_notes;


                        for (int i = 3; i < param.Length; i++)
                        {
                            cmd.Parameters.Add(param[i]);
                        }


                        int rowsAffected = cmd.ExecuteNonQuery();
                        Logging.LogInfo("Successful updated records into: InventoryTracking", true);
                        string url = ResolveUrl("~/LicenseReport.aspx");
                        if (rowsAffected == 1 && insertRowsAffected == 1)
                            Response.Write(String.Format("<script>alert('The records are inserted in to database successfully!');window.location='{0}';</script>", url));
                        else
                            Response.Write(String.Format("<script>alert('OOps there was an error while inserting in to database!');window.location='{0}';</script>", url));
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while updating records into: InventoryTracking -- LicenseReport screen");
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
        }
    }
}