using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DBAWebsite.APP;

namespace DBAWebsite
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HomePage", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        DataSet ds = null;

                        ds = new DataSet();

                        //da.Fill(ds, "EmployeeDetails");
                        //GridView1.DataSource = ds.Tables["EmployeeDetails"];
                        //GridView1.DataBind();
                    }
                }
            }
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HomePage2", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        DataSet ds = null;

                        ds = new DataSet();

                       //da.Fill(ds, "EmployeeDetails");
                       //GridView2.DataSource = ds.Tables["EmployeeDetails"];
                       //GridView2.DataBind();
                    }
                }
            }
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HomePage1", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        DataSet ds = null;

                        ds = new DataSet();

                        da.Fill(ds, "EmployeeDetails");
                        GridView3.DataSource = ds.Tables["EmployeeDetails"];
                        GridView3.DataBind();
                    }
                }
            }
        }
    }

    }
