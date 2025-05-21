using System;
using System.Windows.Forms;
using Admin_Dashboard.Services;
using AdminDashboard.Models;

namespace AdminDashboard.Forms.Orders
{
    public partial class UpdateOrderStatusForm : Form
    {
        private readonly OrderService _orderService;
        private readonly OrderDto _order;

        public UpdateOrderStatusForm(OrderDto order)
        {
            InitializeComponent();
            _orderService = new OrderService();
            _order = order;
        }

        private void InitializeComponent()
        {
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatusMsg = new System.Windows.Forms.Label();
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
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "pending",
            "processing",
            "shipped",
            "delivered",
            "cancelled"});
            this.cboStatus.Location = new System.Drawing.Point(150, 70);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 24);
            this.cboStatus.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(30, 110);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 17);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(150, 110);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(300, 60);
            this.txtAddress.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.AutoSize = true;
            this.lblStatusMsg.ForeColor = System.Drawing.Color.Red;
            this.lblStatusMsg.Location = new System.Drawing.Point(150, 230);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(0, 17);
            this.lblStatusMsg.TabIndex = 8;
            // 
            // UpdateOrderStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 263);
            this.Controls.Add(this.lblStatusMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblOrderIdValue);
            this.Controls.Add(this.lblOrderId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateOrderStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Order Status";
            this.Load += new System.EventHandler(this.UpdateOrderStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderIdValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatusMsg;

        private void UpdateOrderStatusForm_Load(object sender, EventArgs e)
        {
            lblOrderIdValue.Text = _order.Id.ToString();
            cboStatus.SelectedItem = _order.Status;
            txtAddress.Text = _order.DeliveryAddress;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatusMsg.Text = "Updating order...";
                
                var updateOrderDto = new UpdateOrderDto
                {
                    Status = cboStatus.SelectedItem.ToString(),
                    DeliveryAddress = txtAddress.Text
                };
                
                await _orderService.UpdateOrderAsync(_order.Id, updateOrderDto);
                
                lblStatusMsg.Text = "Order updated successfully.";
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = $"Error: {ex.Message}";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}