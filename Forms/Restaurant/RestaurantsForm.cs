using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AdminDashboard.Models;
using Admin_Dashboard.Services;

namespace AdminDashboard.Forms.Restaurants
{
    public partial class RestaurantsForm : Form
    {
        private readonly RestaurantService _restaurantService;
        private List<RestaurantDto> _restaurants;

        public RestaurantsForm()
        {
            InitializeComponent();
            _restaurantService = new RestaurantService();
        }

        private void InitializeComponent()
        {
            this.dgvRestaurants = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestaurants)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRestaurants
            // 
            this.dgvRestaurants.AllowUserToAddRows = false;
            this.dgvRestaurants.AllowUserToDeleteRows = false;
            this.dgvRestaurants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRestaurants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRestaurants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestaurants.Location = new System.Drawing.Point(12, 50);
            this.dgvRestaurants.MultiSelect = false;
            this.dgvRestaurants.Name = "dgvRestaurants";
            this.dgvRestaurants.ReadOnly = true;
            this.dgvRestaurants.RowHeadersWidth = 51;
            this.dgvRestaurants.RowTemplate.Height = 24;
            this.dgvRestaurants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRestaurants.Size = new System.Drawing.Size(1176, 592);
            this.dgvRestaurants.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(118, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(330, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(450, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 5;
            // 
            // RestaurantsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 654);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvRestaurants);
            this.Name = "RestaurantsForm";
            this.Text = "Restaurants Management";
            this.Load += new System.EventHandler(this.RestaurantsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestaurants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvRestaurants;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;

        private async void RestaurantsForm_Load(object sender, EventArgs e)
        {
            await LoadRestaurants();
        }

        private async System.Threading.Tasks.Task LoadRestaurants()
        {
            try
            {
                lblStatus.Text = "Loading restaurants...";
                
                _restaurants = await _restaurantService.GetRestaurantsAsync();
                
                dgvRestaurants.DataSource = null;
                dgvRestaurants.DataSource = _restaurants;
                
                lblStatus.Text = $"{_restaurants.Count} restaurants loaded.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addRestaurantForm = new AddEditRestaurantForm();
            if (addRestaurantForm.ShowDialog() == DialogResult.OK)
            {
                LoadRestaurants();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRestaurants.SelectedRows.Count > 0)
            {
                var selectedRestaurant = (RestaurantDto)dgvRestaurants.SelectedRows[0].DataBoundItem;
                var editRestaurantForm = new AddEditRestaurantForm(selectedRestaurant);
                if (editRestaurantForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRestaurants();
                }
            }
            else
            {
                MessageBox.Show("Please select a restaurant to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRestaurants.SelectedRows.Count > 0)
            {
                var selectedRestaurant = (RestaurantDto)dgvRestaurants.SelectedRows[0].DataBoundItem;
                
                var result = MessageBox.Show($"Are you sure you want to delete the restaurant at '{selectedRestaurant.Location}'?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        lblStatus.Text = "Deleting restaurant...";
                        
                        await _restaurantService.DeleteRestaurantAsync(selectedRestaurant.Id);
                        
                        lblStatus.Text = "Restaurant deleted successfully.";
                        await LoadRestaurants();
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = $"Error: {ex.Message}";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a restaurant to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadRestaurants();
        }
    }
}