using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.App_Start
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if(Email.Text.IsNullOrWhiteSpace() && Password.Text.IsNullOrWhiteSpace())
            {
                ValidationLabel.Text = "Please fill all required fields";
                ValidationLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                using(SqlConnection con = new SqlConnection("Server=DESKTOP-8MOU8RO;Database=CMDATA;Trusted_Connection=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT email,password FROM ADMIN WHERE email = @email AND password = @password",con))
                    {
                        cmd.Parameters.AddWithValue("@email",Email.Text);
                        cmd.Parameters.AddWithValue("@password",Password.Text);

                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            Response.Redirect("EditAdmin.aspx");
                        }
                        else
                        {
                            ValidationLabel.Text = "Invalid email or password.";
                            ValidationLabel.ForeColor = System.Drawing.Color.Red;
                        }

                    }
                }
            }
        }
    }
}