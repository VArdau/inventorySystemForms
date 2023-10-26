namespace inventorySystemForms
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttnDeny = new System.Windows.Forms.Button();
            this.floRequests = new System.Windows.Forms.FlowLayoutPanel();
            this.bttnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.lblManager = new System.Windows.Forms.Label();
            this.floUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.bttnManage = new System.Windows.Forms.Button();
            this.bttnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnDeny
            // 
            this.bttnDeny.BackColor = System.Drawing.Color.DarkRed;
            this.bttnDeny.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnDeny.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnDeny.Location = new System.Drawing.Point(646, 391);
            this.bttnDeny.Name = "bttnDeny";
            this.bttnDeny.Size = new System.Drawing.Size(105, 47);
            this.bttnDeny.TabIndex = 19;
            this.bttnDeny.Text = "Deny";
            this.bttnDeny.UseVisualStyleBackColor = false;
            this.bttnDeny.Click += new System.EventHandler(this.bttnDeny_Click);
            // 
            // floRequests
            // 
            this.floRequests.AutoScroll = true;
            this.floRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floRequests.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.floRequests.Location = new System.Drawing.Point(517, 44);
            this.floRequests.Name = "floRequests";
            this.floRequests.Size = new System.Drawing.Size(250, 341);
            this.floRequests.TabIndex = 20;
            // 
            // bttnAccept
            // 
            this.bttnAccept.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnAccept.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnAccept.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnAccept.Location = new System.Drawing.Point(538, 391);
            this.bttnAccept.Name = "bttnAccept";
            this.bttnAccept.Size = new System.Drawing.Size(105, 47);
            this.bttnAccept.TabIndex = 21;
            this.bttnAccept.Text = "Accept";
            this.bttnAccept.UseVisualStyleBackColor = false;
            this.bttnAccept.Click += new System.EventHandler(this.bttnAccept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(578, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 23;
            this.label1.Text = "User requests:";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmployee.Location = new System.Drawing.Point(12, 44);
            this.lblEmployee.MinimumSize = new System.Drawing.Size(158, 29);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(158, 29);
            this.lblEmployee.TabIndex = 25;
            this.lblEmployee.Text = "Employee";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAdmin.Location = new System.Drawing.Point(328, 44);
            this.lblAdmin.MinimumSize = new System.Drawing.Size(158, 29);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(158, 29);
            this.lblAdmin.TabIndex = 26;
            this.lblAdmin.Text = "Admin";
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManager.Location = new System.Drawing.Point(170, 44);
            this.lblManager.MinimumSize = new System.Drawing.Size(158, 29);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(158, 29);
            this.lblManager.TabIndex = 27;
            this.lblManager.Text = "Manager";
            // 
            // floUsers
            // 
            this.floUsers.AutoScroll = true;
            this.floUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floUsers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.floUsers.Location = new System.Drawing.Point(12, 73);
            this.floUsers.MinimumSize = new System.Drawing.Size(470, 0);
            this.floUsers.Name = "floUsers";
            this.floUsers.Size = new System.Drawing.Size(474, 312);
            this.floUsers.TabIndex = 28;
            // 
            // bttnManage
            // 
            this.bttnManage.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnManage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnManage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnManage.Location = new System.Drawing.Point(270, 391);
            this.bttnManage.Name = "bttnManage";
            this.bttnManage.Size = new System.Drawing.Size(105, 47);
            this.bttnManage.TabIndex = 29;
            this.bttnManage.Text = "Manage";
            this.bttnManage.UseVisualStyleBackColor = false;
            this.bttnManage.Click += new System.EventHandler(this.bttnManage_Click);
            // 
            // bttnDelete
            // 
            this.bttnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.bttnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnDelete.Location = new System.Drawing.Point(381, 391);
            this.bttnDelete.Name = "bttnDelete";
            this.bttnDelete.Size = new System.Drawing.Size(105, 47);
            this.bttnDelete.TabIndex = 30;
            this.bttnDelete.Text = "Delete";
            this.bttnDelete.UseVisualStyleBackColor = false;
            this.bttnDelete.Click += new System.EventHandler(this.bttnDelete_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttnDelete);
            this.Controls.Add(this.bttnManage);
            this.Controls.Add(this.floUsers);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnAccept);
            this.Controls.Add(this.floRequests);
            this.Controls.Add(this.bttnDeny);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bttnDeny;
        private FlowLayoutPanel floRequests;
        private Button bttnAccept;
        private Label label1;
        private Label lblEmployee;
        private Label lblAdmin;
        private Label lblManager;
        private FlowLayoutPanel floUsers;
        private Button bttnManage;
        private Button bttnDelete;
    }
}