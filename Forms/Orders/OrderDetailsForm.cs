using System;
using System.Windows.Forms;
using AdminDashboard.Models;

namespace AdminDashboard.Forms.Orders
{
    public partial class OrderDetailsForm : Form
    {
        private readonly OrderDto _order;

        public OrderDetailsForm(OrderDto order)
        {
            InitializeComponent();
            _order = order;
        }

        private void InitializeComponent()
        {
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblUserIdValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblCreatedAtValue = new System.Windows.Forms.Label();
            this.lblUpdatedAt = new System.Windows.Forms.Label();
            this.lblUpdatedAtValue = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(30, 30);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(65, 17);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Order ID:";
            // 
            // lblOrderIdValue
            // 
            this.lblOrderIdValue.AutoSize = true;
            this.lblOrderIdValue.Location = new System.Drawing.Point(150, 30);
            this.lblOrderIdValue.Name = "lblOrderIdValue";
            this.lblOrderIdValue.Size = new System.Drawing.Size(0, 17);
            this.lblOrderIdValue.TabIndex = 1;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(30, 60);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(59, 17);
            this.lblUserId.TabIndex = 2;
            this.lblUserId.Text = "User ID:";
            // 
            // lblUserIdValue
            // 
            this.lblUserIdValue.AutoSize = true;
            this.lblUserIdValue.Location = new System.Drawing.Point(150, 60);
            this.lblUserIdValue.Name = "lblUserIdValue";
            this.lblUserIdValue.Size = new System.Drawing.Size(0, 17);
            this.lblUserIdValue.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(30, 90);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 17);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(150, 90);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(0, 17);
            this.lblTotalValue.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Location = new System.Drawing.Point(150, 120);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(0, 17);
            this.lblStatusValue.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(30, 150);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 17);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(150, 150);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(300, 60);
            this.txtAddress.TabIndex = 9;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Location = new System.Drawing.Point(30, 230);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(80, 17);
            this.lblCreatedAt.TabIndex = 10;
            this.lblCreatedAt.Text = "Created At:";
            // 
            // lblCreatedAtValue
            // 
            this.lblCreatedAtValue.AutoSize = true;
            this.lblCreatedAtValue.Location = new System.Drawing.Point(150, 230);
            this.lblCreatedAtValue.Name = "lblCreatedAtValue";
            this.lblCreatedAtValue.Size = new System.Drawing.Size(0, 17);
            this.lblCreatedAtValue.TabIndex = 11;
            // 
            // lblUpdatedAt
            // 
            this.lblUpdatedAt.AutoSize = true;
            this.lblUpdatedAt.Location = new System.Drawing.Point(30, 260);
            this.lblUpdatedAt.Name = "lblUpdatedAt";
            this.lblUpdatedAt.Size = new System.Drawing.Size(85, 17);
            this.lblUpdatedAt.TabIndex = 12;
            this.lblUpdatedAt.Text = "Updated At:";
            // 
            // lblUpdatedAtValue
            // 
            this.lblUpdatedAtValue.AutoSize = true;
            this.lblUpdatedAtValue.Location = new System.Drawing.Point(150, 260);
            this.lblUpdatedAtValue.Name = "lblUpdatedAtValue";
            this.lblUpdatedAtValue.Size = new System.Drawing.Size(0, 17);
            this.lblUpdatedAtValue.TabIndex = 13;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(30, 300);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(86, 17);
            this.lblItems.TabIndex = 14;
            this.lblItems.Text = "Order Items:";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(30, 330);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.RowTemplate.Height = 24;
            this.dgvOrderItems.Size = new System.Drawing.Size(600, 200);
            this.dgvOrderItems.TabIndex = 15;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(530, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 600);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lblUpdatedAtValue);
            this.Controls.Add(this.lblUpdatedAt);
            this.Controls.Add(this.lblCreatedAtValue);
            this.Controls.Add(this.lblCreatedAt);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblUserIdValue);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblOrderIdValue);
            this.Controls.Add(this.lblOrderId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderIdValue;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblUserIdValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblCreatedAtValue;
        private System.Windows.Forms.Label lblUpdatedAt;
        private System.Windows.Forms.Label lblUpdatedAtValue;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnClose;

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            // Display order details
            lblOrderIdValue.Text = _order.Id.ToString();
            lblUserIdValue.Text = _order.UserId.ToString();
            lblTotalValue.Text = $"${_order.Total:F2}";
            lblStatusValue.Text = _order.Status;
            txtAddress.Text = _order.DeliveryAddress;
            lblCreatedAtValue.Text = _order.CreatedAt.ToString("g");
            lblUpdatedAtValue.Text = _order.UpdatedAt.ToString("g");
            
            // Display order items
            dgvOrderItems.DataSource = _order.OrderItems;
            
            // Hide some columns for better display
            if (dgvOrderItems.Columns.Contains("OrderId"))
                dgvOrderItems.Columns["OrderId"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}