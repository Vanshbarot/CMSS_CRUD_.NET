using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Name.Text = Convert.ToString(Session["Username"]);
                Email.Text = Convert.ToString(Session["Email"]);
                Password.Text = Convert.ToString(Session["Password"]);
                string Gender = Convert.ToString(Session["Gender"]);
                string Qualification = Convert.ToString(Session["Qualification"]);

                if (Gender == "Male")
                {
                    MaleRadioBtn.Checked = true;
                }
                else if (Gender == "Female")
                {
                    FemaleRadioBtn.Checked = true;
                }

                if (Qualification == "Graduate")
                {
                    Graduate.Checked = true;
                }
                else if (Qualification == "Postgraduate")
                {
                    Postgraduate.Checked = true;
                }
                else if (Qualification == "Doctrate")
                {
                    Doctrate.Checked = true;
                }
            }
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
            if (!Password.Text.IsNullOrWhiteSpace())
            {
                bool regularExpression = Regex.IsMatch(Password.Text, "(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+={};:<>|\\./?,-])");
                bool hasMinLength = (Password.Text.Length >= 8);

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
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            string Gen = null;
            if (MaleRadioBtn.Checked)
            {
                Gen = MaleRadioBtn.Text;
            }
            else if (FemaleRadioBtn.Checked)
            {
                Gen = FemaleRadioBtn.Text;
            }

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

            if (Name.Text != null && PasswordValidationLabel.Text == "Password is Valid" && Gen != null && Qualify != null)
            {
                using (SqlConnection con = new SqlConnection("Server=DESKTOP-8MOU8RO;Database=CMDATA;Trusted_Connection=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE USERS SET name = @name, password = @password, gender = @gender, qualification = @qualification WHERE email = @email ", con))
                     {
                            cmd.Parameters.AddWithValue("@name", Name.Text);
                            cmd.Parameters.AddWithValue("@password", Password.Text);
                            cmd.Parameters.AddWithValue("@email", Email.Text);
                            cmd.Parameters.AddWithValue("@gender", Gen);
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