using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AdminDashboard.Models;
using Admin_Dashboard.Services;

namespace AdminDashboard.Forms.Team
{
    public partial class TeamForm : Form
    {
        private readonly TeamService _teamService;
        private List<TeamDto> _teamMembers;

        public TeamForm()
        {
            InitializeComponent();
            _teamService = new TeamService();
        }

        private void InitializeComponent()
        {
            this.dgvTeam = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeam
            // 
            this.dgvTeam.AllowUserToAddRows = false;
            this.dgvTeam.AllowUserToDeleteRows = false;
            this.dgvTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeam.Location = new System.Drawing.Point(12, 50);
            this.dgvTeam.MultiSelect = false;
            this.dgvTeam.Name = "dgvTeam";
            this.dgvTeam.ReadOnly = true;
            this.dgvTeam.RowHeadersWidth = 51;
            this.dgvTeam.RowTemplate.Height = 24;
            this.dgvTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeam.Size = new System.Drawing.Size(1176, 592);
            this.dgvTeam.TabIndex = 0;
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
            // TeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 654);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvTeam);
            this.Name = "TeamForm";
            this.Text = "Team Management";
            this.Load += new System.EventHandler(this.TeamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvTeam;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;

        private async void TeamForm_Load(object sender, EventArgs e)
        {
            await LoadTeamMembers();
        }

        private async System.Threading.Tasks.Task LoadTeamMembers()
        {
            try
            {
                lblStatus.Text = "Loading team members...";
                
                _teamMembers = await _teamService.GetTeamMembersAsync();
                
                dgvTeam.DataSource = null;
                dgvTeam.DataSource = _teamMembers;
                
                // Hide some columns for better display
                if (dgvTeam.Columns.Contains("Description"))
                    dgvTeam.Columns["Description"].Width = 200;
                
                lblStatus.Text = $"{_teamMembers.Count} team members loaded.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addTeamMemberForm = new AddEditTeamMemberForm();
            if (addTeamMemberForm.ShowDialog() == DialogResult.OK)
            {
                LoadTeamMembers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTeam.SelectedRows.Count > 0)
            {
                var selectedTeamMember = (TeamDto)dgvTeam.SelectedRows[0].DataBoundItem;
                var editTeamMemberForm = new AddEditTeamMemberForm(selectedTeamMember);
                if (editTeamMemberForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTeamMembers();
                }
            }
            else
            {
                MessageBox.Show("Please select a team member to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTeam.SelectedRows.Count > 0)
            {
                var selectedTeamMember = (TeamDto)dgvTeam.SelectedRows[0].DataBoundItem;
                
                var result = MessageBox.Show($"Are you sure you want to delete the team member '{selectedTeamMember.Name}'?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        lblStatus.Text = "Deleting team member...";
                        
                        await _teamService.DeleteTeamMemberAsync(selectedTeamMember.Id);
                        
                        lblStatus.Text = "Team member deleted successfully.";
                        await LoadTeamMembers();
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = $"Error: {ex.Message}";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a team member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadTeamMembers();
        }
    }
}