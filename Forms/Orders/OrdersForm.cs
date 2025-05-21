using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AdminDashboard.Models;
using Admin_Dashboard.Services;

namespace AdminDashboard.Forms.Orders
{
    public partial class OrdersForm : Form
    {
        private readonly OrderService _orderService;
        private List<OrderDto> _orders;

        public OrdersForm()
        {
            InitializeComponent();
            _orderService = new OrderService();
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 50);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1176, 592);
            this.dgvOrders.TabIndex = 0;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(12, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 30);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View Details";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(118, 12);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateStatus.TabIndex = 2;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(244, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(350, 12);
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
            this.lblStatus.Location = new System.Drawing.Point(470, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 5;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 654);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dgvOrders);
            this.Name = "OrdersForm";
            this.Text = "Orders Management";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;

        private async void OrdersForm_Load(object sender, EventArgs e)
        {
            await LoadOrders();
        }

        private async System.Threading.Tasks.Task LoadOrders()
        {
            try
            {
                lblStatus.Text = "Loading orders...";
                
                _orders = await _orderService.GetOrdersAsync();
                
                dgvOrders.DataSource = null;
                dgvOrders.DataSource = _orders;
                
                // Hide some columns for better display
                if (dgvOrders.Columns.Contains("OrderItems"))
                    dgvOrders.Columns["OrderItems"].Visible = false;
                
                lblStatus.Text = $"{_orders.Count} orders loaded.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedOrder = (OrderDto)dgvOrders.SelectedRows[0].DataBoundItem;
                var orderDetailsForm = new OrderDetailsForm(selectedOrder);
                orderDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedOrder = (OrderDto)dgvOrders.SelectedRows[0].DataBoundItem;
                var updateOrderForm = new UpdateOrderStatusForm(selectedOrder);
                if (updateOrderForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedOrder = (OrderDto)dgvOrders.SelectedRows[0].DataBoundItem;
                
                var result = MessageBox.Show($"Are you sure you want to delete Order #{selectedOrder.Id}?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        lblStatus.Text = "Deleting order...";
                        
                        await _orderService.DeleteOrderAsync(selectedOrder.Id);
                        
                        lblStatus.Text = "Order deleted successfully.";
                        await LoadOrders();
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = $"Error: {ex.Message}";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadOrders();
        }
    }
}