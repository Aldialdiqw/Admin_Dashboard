using System;
using System.Windows.Forms;
using Admin_Dashboard.Services;
using AdminDashboard.Models;

namespace AdminDashboard.Forms.Restaurants
{
    public partial class AddEditRestaurantForm : Form
    {
        private readonly RestaurantService _restaurantService;
        private readonly RestaurantDto _restaurant;
        private readonly bool _isEditMode;

        public AddEditRestaurantForm(RestaurantDto restaurant = null)
        {
            InitializeComponent();
            _restaurantService = new RestaurantService();
            _restaurant = restaurant;
            _isEditMode = restaurant != null;
        }

        private void InitializeComponent()
        {
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblOpeningHours = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtOpeningHours = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(30, 30);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(66, 17);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(30, 70);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(107, 17);
            this.lblPhoneNumber.TabIndex = 1;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(30, 110);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(106, 17);
            this.lblEmailAddress.TabIndex = 2;
            this.lblEmailAddress.Text = "Email Address:";
            // 
            // lblOpeningHours
            // 
            this.lblOpeningHours.AutoSize = true;
            this.lblOpeningHours.Location = new System.Drawing.Point(30, 150);
            this.lblOpeningHours.Name = "lblOpeningHours";
            this.lblOpeningHours.Size = new System.Drawing.Size(109, 17);
            this.lblOpeningHours.TabIndex = 3;
            this.lblOpeningHours.Text = "Opening Hours:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(150, 30);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(300, 22);
            this.txtLocation.TabIndex = 4;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(150, 70);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(300, 22);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(150, 110);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(300, 22);
            this.txtEmailAddress.TabIndex = 6;
            // 
            // txtOpeningHours
            // 
            this.txtOpeningHours.Location = new System.Drawing.Point(150, 150);
            this.txtOpeningHours.Name = "txtOpeningHours";
            this.txtOpeningHours.Size = new System.Drawing.Size(300, 22);
            this.txtOpeningHours.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(150, 230);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 10;
            // 
            // AddEditRestaurantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 263);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOpeningHours);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblOpeningHours);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRestaurantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Restaurant";
            this.Load += new System.EventHandler(this.AddEditRestaurantForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblOpeningHours;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtOpeningHours;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;

        private void AddEditRestaurantForm_Load(object sender, EventArgs e)
        {
            if (_isEditMode && _restaurant != null)
            {
                this.Text = "Edit Restaurant";
                
                txtLocation.Text = _restaurant.Location;
                txtPhoneNumber.Text = _restaurant.PhoneNumber;
                txtEmailAddress.Text = _restaurant.EmailAddress;
                txtOpeningHours.Text = _restaurant.OpeningHours;
            }
            else
            {
                this.Text = "Add New Restaurant";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    lblStatus.Text = "Location is required.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    lblStatus.Text = "Phone number is required.";
                    return;
                }

                lblStatus.Text = "Saving...";

                if (_isEditMode)
                {
                    // Update existing restaurant
                    var updateRestaurantDto = new UpdateRestaurantDto
                    {
                        Location = txtLocation.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        EmailAddress = txtEmailAddress.Text,
                        OpeningHours = txtOpeningHours.Text
                    };

                    await _restaurantService.UpdateRestaurantAsync(_restaurant.Id, updateRestaurantDto);
                }
                else
                {
                    // Create new restaurant
                    var createRestaurantDto = new CreateRestaurantDto
                    {
                        Location = txtLocation.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        EmailAddress = txtEmailAddress.Text,
                        OpeningHours = txtOpeningHours.Text
                    };

                    await _restaurantService.CreateRestaurantAsync(createRestaurantDto);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}