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
    public partial class RebootReport : System.Web.UI.Page
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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select [Server Name],[Location],[Production / Non-Production],[Reboot / Patch Schedule],[Reboot Frequency],[Reboot Day],[Reboot Time (Central Time)] as tempTime,[Contact Name(s)] as tempContacts from DBARebootSchedule", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "DBARebootSchedule");
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
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
        //                String tmp = "select [Server Name],[Location],[Production / Non-Production],[Reboot / Patch Schedule],[Reboot Frequency],[Reboot Day],[Reboot Time (Central Time)] as tempTime,[Contact Name(s)] as tempContacts from DBARebootSchedule where [Server Name] like '%" + txt_search.Text + "%'";
        //                SqlDataAdapter da = new SqlDataAdapter(tmp, con);
        //                DataSet ds = new DataSet();
        //                da.Fill(ds, "DBARebootSchedule");
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

        protected void submit_Click_location(object sender, EventArgs e)
        {
            if (!txt_search_location.Text.Equals("") || !txt_search.Text.Equals(""))
            {
                if (!txt_search_location.Text.Equals(""))
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                    {
                        try
                        {
                            String tmp = "select [Server Name],[Location],[Production / Non-Production],[Reboot / Patch Schedule],[Reboot Frequency],[Reboot Day],[Reboot Time (Central Time)] as tempTime,[Contact Name(s)] as tempContacts from DBARebootSchedule where [Location] like '%" + txt_search_location.Text + "%'";
                            SqlDataAdapter da = new SqlDataAdapter(tmp, con);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "DBARebootSchedule");
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }
                        catch (Exception ex)
                        {
                            Logging.LogException(ex, "Error in data bind");
                        }
                    }
                }
                else if(!txt_search.Text.Equals(""))
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                    {
                        try
                        {
                            String tmp = "select [Server Name],[Location],[Production / Non-Production],[Reboot / Patch Schedule],[Reboot Frequency],[Reboot Day],[Reboot Time (Central Time)] as tempTime,[Contact Name(s)] as tempContacts from DBARebootSchedule where [Server Name] like '%" + txt_search.Text + "%'";
                            SqlDataAdapter da = new SqlDataAdapter(tmp, con);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "DBARebootSchedule");
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }
                        catch (Exception ex)
                        {
                            Logging.LogException(ex, "Error in data bind");
                        }
                    }
                }
            }
            else
            {
                bind();
            }
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            txt_search_location.Text = "";
            txt_search.Text = "";
            bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }
    }
}