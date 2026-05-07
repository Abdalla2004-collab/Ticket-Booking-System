using System;
using System.Windows.Forms;
using LMS.Models;

namespace LMS
{
    public partial class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            InitializeComponent();
            ThemeManager.ApplyLargeTheme(this);
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                if (GlobalManager.CurrentUser != null)
                {
                    textBoxName.Text = GlobalManager.CurrentUser.fullname;
                    textBoxEmail.Text = GlobalManager.CurrentUser.email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                string password = textBoxPassword.Text.Trim();
                string confirmPassword = textBoxConfirmPassword.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
                {
                    MessageBox.Show("All fields (Name, Email, Password, and Confirm Password) are required.");
                    return;
                }

                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Invalid email format.");
                    return;
                }

                if (!string.IsNullOrEmpty(password))
                {
                    if (password.Length < 8)
                    {
                        MessageBox.Show("Password must be at least 8 characters long.");
                        return;
                    }

                    if (password != confirmPassword)
                    {
                        MessageBox.Show("Passwords do not match.");
                        return;
                    }
                }

                bool success = GlobalManager.UpdateUserProfile(name, email, password);
                if (success)
                {
                    MessageBox.Show("Your profile has been updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The email address you entered is already in use by another account.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
