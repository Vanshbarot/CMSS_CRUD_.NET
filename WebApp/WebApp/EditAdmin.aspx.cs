using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApp
{
    public partial class EditAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfoEdit.Style.Add("Display", "none");
            UserInfoView.Style.Add("Display", "none");
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if(SearchBox.Text != null)
            {
                using (SqlConnection con = new SqlConnection("Server=DESKTOP-8MOU8RO;Database=CMDATA;Trusted_Connection=True"))
                {
                    using(SqlCommand cmd = new SqlCommand("SELECT name, email, password, gender, qualification FROM USERS WHERE email = @email", con))
                    {
                        cmd.Parameters.AddWithValue("@email", SearchBox.Text);

                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if(reader.HasRows)
                        {
                            reader.Read();

                            ValidationLabel.Text = "";
                            UserInfoEdit.Style.Add("Display", "none");
                            UserInfoView.Style.Add("Display", "block");

                            NameLabel.Text = reader["name"].ToString();
                            EmailLabel.Text = reader["email"].ToString();
                            PasswordLabel.Text = reader["password"].ToString();
                            GenderLabel.Text = reader["gender"].ToString();
                            QualificationLabel.Text = reader["qualification"].ToString();

                            NameEdit.Text = reader["name"].ToString();
                            EmailEdit.Text = reader["email"].ToString();
                            PasswordEdit.Text = reader["password"].ToString();
                            GenderEdit.Text = reader["gender"].ToString();
                            string Qualification = reader["qualification"].ToString();
                        }
                        else
                        {
                            ValidationLabel.Text = "No results found";
                            ValidationLabel.ForeColor = System.Drawing.Color.Red;
                        }
                        
                    }
                }
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            UserInfoEdit.Style.Add("Display", "block");
            UserInfoView.Style.Add("Display", "none");

            if(QualificationLabel.Text == "Graduate")
            {
                Graduate.Checked = true;
            }
            else if(QualificationLabel.Text == "Postgraduate")
            {
                Postgraduate.Checked = true;
            }
            else if(QualificationLabel.Text == "Doctrate")
            {
                Doctrate.Checked = true;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-8MOU8RO;Database=CMDATA;Trusted_Connection=True"))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM USERS WHERE email = @email", con))
                {
                    cmd.Parameters.AddWithValue("@email", SearchBox.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void SubmitOnEdit_Click(object sender, EventArgs e)
        {
            string Qualify = null;
            if (Graduate.Checked)
            {
                Qualify = Graduate.Text;
            }
            else if (Postgraduate.Checked)
            {
                Qualify = Postgraduate.Text;
            }
            else if (Doctrate.Checked)
            {
                Qualify = Doctrate.Text;
            }

            if(!PasswordEdit.Text.IsNullOrWhiteSpace())
            {
                bool regularExpression = Regex.IsMatch(PasswordEdit.Text, "(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+={};:<>|\\./?,-])");
                bool hasMinLength = (PasswordEdit.Text.Length >= 8);

                if (!regularExpression || !hasMinLength)
                {
                    PasswordValidationLabel.Text = "Invalid Password Format";
                    PasswordValidationLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    PasswordValidationLabel.Text = "Password is Valid";
                }
            }

            if (NameEdit.Text != null && PasswordValidationLabel.Text == "Password is Valid" && Qualify != null)
            {
                using (SqlConnection con = new SqlConnection("Server=DESKTOP-8MOU8RO;Database=CMDATA;Trusted_Connection=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE USERS SET name = @name, password = @password, qualification = @qualification WHERE email = @email ", con))
                    {
                        cmd.Parameters.AddWithValue("@name", NameEdit.Text);
                        cmd.Parameters.AddWithValue("@password", PasswordEdit.Text);
                        cmd.Parameters.AddWithValue("@email", SearchBox.Text);
                        cmd.Parameters.AddWithValue("@qualification", Qualify);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        ValidationLabel.Text = "Details have been updated";
                        //Response.Redirect("UserLogin.aspx");                       
                    }
                }
            }


        }
    }
}