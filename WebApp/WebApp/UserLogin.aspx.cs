﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.Ajax.Utilities;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if(Email.Text.IsNullOrWhiteSpace()  && Password.Text.IsNullOrWhiteSpace())
            {
                ValidationLabel.Text = "Please fill all required fields";
                ValidationLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                using (SqlConnection con = new SqlConnection("Server=DESKTOP-8MOU8RO;Database=CMDATA;Trusted_Connection=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT id,name,email,password,gender,qualification FROM USERS WHERE email = @email AND password = @password", con))
                    {
                        cmd.Parameters.AddWithValue("@email", Email.Text);
                        cmd.Parameters.AddWithValue("@password", Password.Text);   

                        con.Open();
                         
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            Session["User_Id"] = Convert.ToInt64(reader["id"]);
                            Session["Username"] = reader["name"];
                            Session["Email"] = reader["email"];
                            Session["Password"] = reader["password"];
                            Session["Gender"] = reader["gender"];
                            Session["Qualification"] = reader["qualification"];
                        
                            Response.Redirect("EditUser.aspx");
                        }
                        else
                        {
                            ValidationLabel.Text = "Invalid email or password.";
                            ValidationLabel.ForeColor = System.Drawing.Color.Red;
                        }

                        con.Close();
                    }
                }
            }
        }
    }
}