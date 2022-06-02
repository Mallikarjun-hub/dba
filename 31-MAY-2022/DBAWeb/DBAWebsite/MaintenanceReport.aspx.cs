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
    public partial class MaintenanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_LinkTable", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        DataSet ds = null;

                        ds = new DataSet();

                        da.Fill(ds, "EmployeeDetails");
                        GridView2.DataSource = ds.Tables["EmployeeDetails"];
                        GridView2.DataBind();
                    }
                }
            }
            if (!IsPostBack)
            {
                bind();
            }
        }


        public void bind()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select ServerName,Maint01_type,Maint01_frequency,Maint01_starttime,RecordUpdateDate from MaintenanceTracking", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "MaintenanceTracking");
                    //GridView1.DataSource = ds.Tables[0];
                    //GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error in data bind");
                }
            }
        }

        //protected void submit_Click(object sender, EventArgs e)
        //{
        //    if (!txt_search.Text.Equals(""))
        //    {
        //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        //        {
        //            try
        //            {
        //                String tmp = "select ServerName,Maint01_type,Maint01_frequency,Maint01_starttime,RecordUpdateDate from MaintenanceTracking where ServerName like '%" + txt_search.Text + "%'";
        //                SqlDataAdapter da = new SqlDataAdapter(tmp, con);
        //                DataSet ds = new DataSet();
        //                da.Fill(ds, "MaintenanceTracking");
        //                GridView1.DataSource = ds.Tables[0];
        //                GridView1.DataBind();
        //            }
        //            catch (Exception ex)
        //            {
        //                Logging.LogException(ex, "Error in data bind");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        bind();
        //    }
        //}

        protected void clear_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            bind();
        }
    }
}