using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace Shekel
{
    /// <summary>
    /// Summary description for ShekelWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ShekelWS : System.Web.Services.WebService
    {
        [WebMethod]
        public int AddCustomer(string connStr, ShekelModel model)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerId", model.customerId);
                cmd.Parameters.AddWithValue("@customerName", model.customerName);
                cmd.Parameters.AddWithValue("@customerAddress", model.customerAddress);
                cmd.Parameters.AddWithValue("@customerPhone", model.customerPhone);
                cmd.Parameters.AddWithValue("@factoryCode", model.factoryCode);
                cmd.Parameters.AddWithValue("@groupCode", model.groupCode);
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return result;
        }

        [WebMethod]
        public DataTable GetCustomersAndGroups(string connStr, string groupId)
        {
            DataTable dt;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetCustomersAndGroups", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@groupId", groupId);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adpt.Fill(dt);
            }

            return dt;
        }
    }
}
