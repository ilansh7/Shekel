using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Shekel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //SqlConnection conn;
        string connetionString;
        String sql;
        Shekel.ShekelWS webService;
        protected void Page_Load(object sender, EventArgs e)
        {
            webService = new Shekel.ShekelWS();
            connetionString = ConfigurationManager.ConnectionStrings["ShekelConnStr"].ConnectionString;

            if (Page.IsPostBack)
            {
                return;
            }

            // Fill Groups and Factory ddls
            using (SqlConnection conn = new SqlConnection(connetionString))
            {
                // Groups
                SqlCommand cmd = new SqlCommand("sp_GetListValues", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@listName", "G");
                cmd.Parameters.AddWithValue("@gId", "0");
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                
                ddlGroups.DataSource = dt;
                ddlGroups.DataBind();
                ddlGroups.DataTextField = "Name";// "groupName";
                ddlGroups.DataValueField = "ID";// "groupCode";
                ddlGroups.DataBind();
                ddlGroups.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlGroups.SelectedIndex = 0;

                ddlGroups1.DataSource = dt;
                ddlGroups1.DataBind();
                ddlGroups1.DataTextField = "Name";
                ddlGroups1.DataValueField = "ID";
                ddlGroups1.DataBind();
                ddlGroups1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlGroups1.SelectedIndex = 0;

                // Factories
                cmd = new SqlCommand("sp_GetListValues", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@listName", "F");
                cmd.Parameters.AddWithValue("@gId", "0");
                adpt = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adpt.Fill(dt);

                ddlFactory.DataSource = dt;
                ddlFactory.DataBind();
                ddlFactory.DataTextField = "Name";// "groupName";
                ddlFactory.DataValueField = "ID";// "groupCode";
                ddlFactory.DataBind();
                ddlFactory.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFactory.SelectedIndex = 0;
            }
        }

        protected void btnCustomersAndGroups_Click(object sender, EventArgs e)
        {
            string groupId = ddlGroups.SelectedValue.ToString();
            //groupId = (groupId == "0" ? "NULL" : groupId);
            DataTable dt = webService.GetCustomersAndGroups(connetionString, groupId);
            gvCustomersAndGroups.DataSource = dt;
            gvCustomersAndGroups.DataBind();
            lblGv.Text = String.Empty;
            if (dt.Rows.Count <= 0)
            {
                lblGv.Text = "No results found for Group " + ddlGroups.SelectedItem;
            }
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string groupId = ddlGroups.SelectedValue.ToString();
            //groupId = (groupId == "0" ? "NULL" : groupId);
            ShekelModel shekel = new ShekelModel();
            shekel.customerId = txtId.Text;
            shekel.customerName = txtName.Text;
            shekel.customerAddress = txtAddress.Text;
            shekel.customerPhone = TxtPhone.Text;
            shekel.factoryCode = int.Parse(ddlFactory.SelectedValue);
            shekel.groupCode = int.Parse(ddlGroups1.SelectedValue);
            int res = webService.AddCustomer(connetionString, shekel);

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + res.ToString() + "');", true);
        }

        protected void ddlGroups1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string message = ddlGroups1.SelectedItem.Text + " - " + ddlGroups.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            using (SqlConnection conn = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetListValues", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@listName", "F");
                cmd.Parameters.AddWithValue("@gId", ddlGroups1.SelectedValue.ToString());
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                ddlFactory.ClearSelection();
                ddlFactory.DataSource = dt;
                ddlFactory.DataBind();
                ddlFactory.DataTextField = "Name";
                ddlFactory.DataValueField = "ID";
                ddlFactory.DataBind();
                ddlFactory.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFactory.SelectedIndex = 0;
            }
        }

    }
}