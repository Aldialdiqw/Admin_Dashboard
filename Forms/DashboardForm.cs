using System;
using System.Drawing;
using System.Windows.Forms;
using AdminDashboard.Forms.Products;
using AdminDashboard.Forms.Orders;
using AdminDashboard.Forms.Users;
using AdminDashboard.Forms.Restaurants;
using AdminDashboard.Forms.Team;
using AdminDashboard.Models;

namespace AdminDashboard.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Load Montserrat Regular font from system or embed if necessary
            var montserratFont = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // Initialize components
            this.menuStrip = new MenuStrip();
            this.productsToolStripMenuItem = new ToolStripMenuItem();
            this.ordersToolStripMenuItem = new ToolStripMenuItem();
            this.usersToolStripMenuItem = new ToolStripMenuItem();
            this.restaurantsToolStripMenuItem = new ToolStripMenuItem();
            this.teamToolStripMenuItem = new ToolStripMenuItem();
            this.logoutToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.lblStatusUser = new ToolStripStatusLabel();
            this.panelContent = new Panel();

            // Form properties
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Font = montserratFont;
            this.BackColor = Color.FromArgb(255, 243, 230); // Warm cream background
            this.FormClosed += DashboardForm_FormClosed;
            this.Load += DashboardForm_Load;

            // MenuStrip styles
            this.menuStrip.Dock = DockStyle.Top;
            this.menuStrip.BackColor = Color.FromArgb(230, 126, 34); // Warm orange
            this.menuStrip.ForeColor = Color.White;
            this.menuStrip.Font = montserratFont;

            // Menu items common styling
            Action<ToolStripMenuItem> styleMenuItem = item =>
            {
                item.ForeColor = Color.White;
                item.Font = montserratFont;
                item.Padding = new Padding(10, 5, 10, 5);
                item.Margin = new Padding(3, 0, 3, 0);
                item.BackColor = Color.Transparent;
            };

            // Products Menu Item
            this.productsToolStripMenuItem.Text = "Products";
            styleMenuItem(this.productsToolStripMenuItem);
            this.productsToolStripMenuItem.Click += productsToolStripMenuItem_Click;

            // Orders Menu Item
            this.ordersToolStripMenuItem.Text = "Orders";
            styleMenuItem(this.ordersToolStripMenuItem);
            this.ordersToolStripMenuItem.Click += ordersToolStripMenuItem_Click;

            // Users Menu Item
            this.usersToolStripMenuItem.Text = "Users";
            styleMenuItem(this.usersToolStripMenuItem);
            this.usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;

            // Restaurants Menu Item
            this.restaurantsToolStripMenuItem.Text = "Restaurants";
            styleMenuItem(this.restaurantsToolStripMenuItem);
            this.restaurantsToolStripMenuItem.Click += restaurantsToolStripMenuItem_Click;

            // Team Menu Item
            this.teamToolStripMenuItem.Text = "Team";
            styleMenuItem(this.teamToolStripMenuItem);
            this.teamToolStripMenuItem.Click += teamToolStripMenuItem_Click;

            // Logout Menu Item (aligned right)
            this.logoutToolStripMenuItem.Text = "Logout";
            styleMenuItem(this.logoutToolStripMenuItem);
            this.logoutToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;

            // Add menu items to menuStrip
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.productsToolStripMenuItem,
                this.ordersToolStripMenuItem,
                this.usersToolStripMenuItem,
                this.restaurantsToolStripMenuItem,
                this.teamToolStripMenuItem,
                this.logoutToolStripMenuItem
            });

            // StatusStrip styling
            this.statusStrip.Dock = DockStyle.Bottom;
            this.statusStrip.BackColor = Color.FromArgb(214, 137, 16); // Darker warm orange
            this.statusStrip.ForeColor = Color.White;
            this.statusStrip.Font = montserratFont;

            // Status label
            this.lblStatusUser.ForeColor = Color.White;
            this.statusStrip.Items.Add(this.lblStatusUser);

            // Content panel styling
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.BackColor = Color.FromArgb(255, 247, 238); // Lighter cream

            // Add controls to the form
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem restaurantsToolStripMenuItem;
        private ToolStripMenuItem teamToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatusUser;
        private Panel panelContent;

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser.User != null)
            {
                lblStatusUser.Text = $"Logged in as: {CurrentUser.User.Name} ({CurrentUser.User.Role})";
            }
            LoadProductsForm();
        }

        private void LoadProductsForm()
        {
            panelContent.Controls.Clear();
            var productsForm = new ProductsForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Add(productsForm);
            productsForm.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProductsForm();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            var ordersForm = new OrdersForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Add(ordersForm);
            ordersForm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            var usersForm = new UsersForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Add(usersForm);
            usersForm.Show();
        }

        private void restaurantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            var restaurantsForm = new RestaurantsForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Add(restaurantsForm);
            restaurantsForm.Show();
        }

        private void teamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            var teamForm = new TeamForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Add(teamForm);
            teamForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CurrentUser.User != null)
            {
                Application.Exit();
            }
        }
    }
}
