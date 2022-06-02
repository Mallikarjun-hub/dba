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
    public partial class ApplicationsReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }


        public void bind()
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Report_Applications", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        DataSet ds = null;

                        ds = new DataSet();

                        da.Fill(ds, "InventoryForm");
                        GridView1.DataSource = ds.Tables["InventoryForm"];
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void submit_Click_ApplicationInfo(object sender, EventArgs e)
        {
            if (!txt_search.Text.Equals(""))
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString)) 
                {
                    try
                    {
                        String tmp = " EXEC [dbo].[usp_Report_Applications] @appinfo = '%" + txt_search_ApplicationInfo.Text + "%',@servername = '%" + txt_search.Text + "%'";
                        SqlDataAdapter da = new SqlDataAdapter(tmp, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "LicenseFORM");
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error in data bind");
                    }
                }
            }
            else
            {
                bind();
            }
        }
        //protected void submit_Click_ApplicationInfo(object sender, EventArgs e)
        //{
        //    if (!txt_search_ApplicationInfo.Text.Equals("") || !txt_search.Text.Equals(""))
        //    {
        //        if (!txt_search_ApplicationInfo.Text.Equals(""))
        //        {
        //            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        //            {
        //                try
        //                {
        //                    String tmp = "EXEC [dbo].[usp_Report_Applications_Search2] @appinfo = '%" + txt_search_ApplicationInfo + "%'";
        //                    SqlDataAdapter da = new SqlDataAdapter(tmp, con);
        //                    DataSet ds = new DataSet();
        //                    da.Fill(ds, "InventoryForm");
        //                    GridView1.DataSource = ds.Tables[0];
        //                    GridView1.DataBind();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Logging.LogException(ex, "Error in data bind");
        //                }
        //            }
        //        }
        //        else if(!txt_search.Text.Equals(""))
        //        {
        //            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        //            {
        //                try
        //                {
        //                    String tmp = "EXEC [dbo].[usp_Report_Applications_Search2] @servername = '%" + txt_search.Text + "%'";

        //                    SqlDataAdapter da = new SqlDataAdapter(tmp, con);
        //                    DataSet ds = new DataSet();
        //                    da.Fill(ds, "InventoryForm");
        //                    GridView1.DataSource = ds.Tables[0];
        //                    GridView1.DataBind();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Logging.LogException(ex, "Error in data bind");
        //                }
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
            txt_search_ApplicationInfo.Text = "";
            txt_search.Text = "";
            bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}