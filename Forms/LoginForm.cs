using System;
using System.Drawing;
using System.Windows.Forms;
using Admin_Dashboard.Services;
using AdminDashboard.Models;

namespace AdminDashboard.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblStatus;

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void InitializeComponent()
        {
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblStatus = new Label();

            SuspendLayout();

            BackColor = Color.FromArgb(240, 240, 240);
            Font = new Font("Montserrat", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0); 
            ClientSize = new Size(380, 300);
            Text = "Admin Dashboard - Login";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            int commonX = (ClientSize.Width - 280) / 2;

            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(commonX, 40);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email:";

            txtEmail.Location = new Point(commonX, 65);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 28);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;

            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(commonX, 110);
            lblPassword.Name = "lblPassword";
            lblPassword.Text = "Password:";

            txtPassword.Location = new Point(commonX, 135);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(280, 28);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;

            btnLogin.Location = new Point(commonX, 185);
            btnLogin.Name = "btnLogin";
            btnLogin.Text = "Login";
            btnLogin.Size = new Size(280, 40);
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(214, 137, 16);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed to Montserrat
            btnLogin.Click += btnLogin_Click;

            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(commonX, 240);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "";

            Controls.Add(lblStatus);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);

            ResumeLayout(false);
            PerformLayout();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Logging in...";

                var loginDto = new LoginDto
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };

                var user = await _userService.LoginAsync(loginDto);

                if (user != null)
                {
                    CurrentUser.User = user;

                    var dashboardForm = new DashboardForm();
                    dashboardForm.Show();
                    Hide();
                }
                else
                {
                    lblStatus.Text = "Invalid email or password.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }
    }
}
