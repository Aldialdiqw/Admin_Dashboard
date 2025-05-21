using System;
using System.Windows.Forms;
using Admin_Dashboard.Services;
using AdminDashboard.Models;

namespace AdminDashboard.Forms.Products
{
    public partial class AddEditProductForm : Form
    {
        private readonly ProductService _productService;
        private readonly ProductDto _product;
        private readonly bool _isEditMode;

        public AddEditProductForm(ProductDto product = null)
        {
            InitializeComponent();
            _productService = new ProductService();
            _product = product;
            _isEditMode = product != null;
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblImageUrl = new System.Windows.Forms.Label();
            this.chkIsAvailable = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(30, 70);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(69, 17);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 110);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(30, 190);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(44, 17);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price:";
            // 
            // lblImageUrl
            // 
            this.lblImageUrl.AutoSize = true;
            this.lblImageUrl.Location = new System.Drawing.Point(30, 230);
            this.lblImageUrl.Name = "lblImageUrl";
            this.lblImageUrl.Size = new System.Drawing.Size(76, 17);
            this.lblImageUrl.TabIndex = 4;
            this.lblImageUrl.Text = "Image URL:";
            // 
            // chkIsAvailable
            // 
            this.chkIsAvailable.AutoSize = true;
            this.chkIsAvailable.Location = new System.Drawing.Point(130, 270);
            this.chkIsAvailable.Name = "chkIsAvailable";
            this.chkIsAvailable.Size = new System.Drawing.Size(100, 21);
            this.chkIsAvailable.TabIndex = 5;
            this.chkIsAvailable.Text = "Is Available";
            this.chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 22);
            this.txtName.TabIndex = 6;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(130, 70);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(300, 22);
            this.txtCategory.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(130, 110);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 60);
            this.txtDescription.TabIndex = 8;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(130, 190);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(150, 22);
            this.txtPrice.TabIndex = 9;
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(130, 230);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.Size = new System.Drawing.Size(300, 22);
            this.txtImageUrl.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(130, 350);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 13;
            // 
            // AddEditProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 383);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtImageUrl);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkIsAvailable);
            this.Controls.Add(this.lblImageUrl);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Product";
            this.Load += new System.EventHandler(this.AddEditProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblImageUrl;
        private System.Windows.Forms.CheckBox chkIsAvailable;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;

        private void AddEditProductForm_Load(object sender, EventArgs e)
        {
            if (_isEditMode && _product != null)
            {
                this.Text = "Edit Product";
                
                txtName.Text = _product.Name;
                txtCategory.Text = _product.Category;
                txtDescription.Text = _product.Description;
                txtPrice.Text = _product.Price.ToString();
                txtImageUrl.Text = _product.ImageUrl;
                chkIsAvailable.Checked = _product.IsAvailable;
            }
            else
            {
                this.Text = "Add New Product";
                chkIsAvailable.Checked = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    lblStatus.Text = "Name is required.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCategory.Text))
                {
                    lblStatus.Text = "Category is required.";
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    lblStatus.Text = "Price must be a valid number.";
                    return;
                }

                lblStatus.Text = "Saving...";

                if (_isEditMode)
                {
                    // Update existing product
                    var updateProductDto = new UpdateProductDto
                    {
                        Name = txtName.Text,
                        Category = txtCategory.Text,
                        Description = txtDescription.Text,
                        Price = price,
                        ImageUrl = txtImageUrl.Text,
                        IsAvailable = chkIsAvailable.Checked
                    };

                    await _productService.UpdateProductAsync(_product.Id, updateProductDto);
                }
                else
                {
                    // Create new product
                    var createProductDto = new CreateProductDto
                    {
                        Name = txtName.Text,
                        Category = txtCategory.Text,
                        Description = txtDescription.Text,
                        Price = price,
                        ImageUrl = txtImageUrl.Text,
                        IsAvailable = chkIsAvailable.Checked
                    };

                    await _productService.CreateProductAsync(createProductDto);
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