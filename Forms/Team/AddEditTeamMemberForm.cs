using System;
using System.Windows.Forms;
using Admin_Dashboard.Services;
using AdminDashboard.Models;

namespace AdminDashboard.Forms.Team
{
    public partial class AddEditTeamMemberForm : Form
    {
        private readonly TeamService _teamService;
        private readonly TeamDto _teamMember;
        private readonly bool _isEditMode;

        public AddEditTeamMemberForm(TeamDto teamMember = null)
        {
            InitializeComponent();
            _teamService = new TeamService();
            _teamMember = teamMember;
            _isEditMode = teamMember != null;
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
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
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(30, 70);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(41, 17);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role:";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(30, 110);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(80, 17);
            this.lblPhoto.TabIndex = 2;
            this.lblPhoto.Text = "Photo URL:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 150);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 22);
            this.txtName.TabIndex = 4;
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(130, 70);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(300, 22);
            this.txtRole.TabIndex = 5;
            // 
            // txtPhoto
            // 
            this.txtPhoto.Location = new System.Drawing.Point(130, 110);
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(300, 22);
            this.txtPhoto.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(130, 150);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 100);
            this.txtDescription.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 270);
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
            this.lblStatus.Location = new System.Drawing.Point(130, 310);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 10;
            // 
            // AddEditTeamMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 343);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPhoto);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditTeamMemberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Team Member";
            this.Load += new System.EventHandler(this.AddEditTeamMemberForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtPhoto;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;

        private void AddEditTeamMemberForm_Load(object sender, EventArgs e)
        {
            if (_isEditMode && _teamMember != null)
            {
                this.Text = "Edit Team Member";
                
                txtName.Text = _teamMember.Name;
                txtRole.Text = _teamMember.Role;
                txtPhoto.Text = _teamMember.Photo;
                txtDescription.Text = _teamMember.Description;
            }
            else
            {
                this.Text = "Add New Team Member";
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

                if (string.IsNullOrWhiteSpace(txtRole.Text))
                {
                    lblStatus.Text = "Role is required.";
                    return;
                }

                lblStatus.Text = "Saving...";

                if (_isEditMode)
                {
                    // Update existing team member
                    var updateTeamDto = new UpdateTeamDto
                    {
                        Name = txtName.Text,
                        Role = txtRole.Text,
                        Photo = txtPhoto.Text,
                        Description = txtDescription.Text
                    };

                    await _teamService.UpdateTeamMemberAsync(_teamMember.Id, updateTeamDto);
                }
                else
                {
                    // Create new team member
                    var createTeamDto = new CreateTeamDto
                    {
                        Name = txtName.Text,
                        Role = txtRole.Text,
                        Photo = txtPhoto.Text,
                        Description = txtDescription.Text
                    };

                    await _teamService.CreateTeamMemberAsync(createTeamDto);
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