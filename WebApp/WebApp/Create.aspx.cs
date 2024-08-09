using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Ajax.Utilities;
using System.Drawing;
using System.Text;


namespace WebApp
{
    public partial class Create : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
            if (!Password.Text.IsNullOrWhiteSpace())
            {
                // bool hasUpperCase = Regex.IsMatch(Password.Text, "[A-Z]");
                // bool hasLowerCase = Regex.IsMatch(Password.Text, "[a-z]");
                // bool hasNumericChar = Regex.IsMatch(Password.Text, "[0-9]");
                // bool hasSpecialChar = Regex.IsMatch(Password.Text, @"[\W_]");
                bool regularExpression = Regex.IsMatch(Password.Text, "(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+={};:<>|\\./?,-])");
                bool hasMinLength = (Password.Text.Length >= 8);

                // if (!hasUpperCase || !hasLowerCase || !hasNumericChar || !hasSpecialChar || !hasMinLength)
                if (!regularExpression || !hasMinLength)
                {
                    ValidationLabel.Text = "";
                    PasswordValidationLabel.Text = "Invalid Password Format";
                    PasswordValidationLabel.ForeColor = System.Drawing.Color.Red;
                }


                else
                {
                    ValidationLabel.Text = "";
                    PasswordValidationLabel.Text = "Password is valid";
                    PasswordValidationLabel.ForeColor = System.Drawing.Color.Green;
                }
            }
        }



        protected void Confirm_Password(object sender, EventArgs e)
        {
            if(Password.Text != ConfirmPass.Text)
            {
                ConfirmValidationLabel.Text = "Password doesn't match";
                ConfirmValidationLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ConfirmValidationLabel.Text = "";
            }
        }
        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            string Gender = null;
            if (MaleRadioBtn.Checked)
            {
                Gender = MaleRadioBtn.Text;
            }
            else if (FemaleRadioBtn.Checked)
            {
                Gender = FemaleRadioBtn.Text;
            }

            string Qualification = null;
            if (Graduate.Checked)
            {
                Qualification = Graduate.Text;
            }
            else if (Postgraduate.Checked)
            {
                Qualification = Postgraduate.Text;
            }
            else if (Doctrate.Checked)
            {
                Qualification = Doctrate.Text;
            }

            if (Name.Text != null && Email.Text != null && PasswordValidationLabel.Text == "Password is valid" && Gender != null && Qualification != null && Password.Text == ConfirmPass.Text)
            {
                using (SqlConnection con = new SqlConnection("Server=DESKTOP-8MOU8RO;Database=CMDATA;Trusted_Connection=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM USERS WHERE email = @email", con))
                    {
                        cmd.Parameters.AddWithValue("@email", Email.Text);
                        con.Open();

                        int emailCount = (int)cmd.ExecuteScalar();

                        if (emailCount == 0)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("INSERT INTO USERS (name, email, password, gender, qualification) VALUES (@name,@email,@password,@gender,@qualification)", con))
                            {
                                cmd1.Parameters.AddWithValue("@name", Name.Text);
                                cmd1.Parameters.AddWithValue("@email", Email.Text);
                                cmd1.Parameters.AddWithValue("@password", Password.Text);
                                cmd1.Parameters.AddWithValue("@gender", Gender);
                                cmd1.Parameters.AddWithValue("@qualification", Qualification);

                                cmd1.ExecuteNonQuery();

                                Response.Redirect("UserLogin.aspx");
                            }
                        }
                        else
                        {
                            ValidationLabel.Text = "Account already exists.";
                            ValidationLabel.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            else
            {
                ValidationLabel.Text = "Please fill all required fields.";
                ValidationLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}