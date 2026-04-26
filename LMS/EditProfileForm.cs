using System;
using System.Windows.Forms;
using LMS.Models;
// will be created
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
            if (GlobalManager.CurrentUser != null)
            {
                textBoxName.Text = GlobalManager.CurrentUser.fullname;
                textBoxEmail.Text = GlobalManager.CurrentUser.email;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string confirmPassword = textBoxConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Name and Email are required.");
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
                MessageBox.Show("Profile updated successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update profile. Email might already be in use.");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
