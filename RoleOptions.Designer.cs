namespace inventorySystemForms
{
    partial class RoleOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.bttnEmployee = new System.Windows.Forms.Button();
            this.bttnManager = new System.Windows.Forms.Button();
            this.bttnAdmin = new System.Windows.Forms.Button();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(147, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select role:";
            // 
            // bttnEmployee
            // 
            this.bttnEmployee.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnEmployee.Location = new System.Drawing.Point(4, 47);
            this.bttnEmployee.Name = "bttnEmployee";
            this.bttnEmployee.Size = new System.Drawing.Size(94, 39);
            this.bttnEmployee.TabIndex = 1;
            this.bttnEmployee.Text = "Employee";
            this.bttnEmployee.UseVisualStyleBackColor = false;
            this.bttnEmployee.Click += new System.EventHandler(this.bttnEmployee_Click);
            // 
            // bttnManager
            // 
            this.bttnManager.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnManager.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnManager.Location = new System.Drawing.Point(100, 47);
            this.bttnManager.Name = "bttnManager";
            this.bttnManager.Size = new System.Drawing.Size(94, 39);
            this.bttnManager.TabIndex = 2;
            this.bttnManager.Text = "Manager";
            this.bttnManager.UseVisualStyleBackColor = false;
            this.bttnManager.Click += new System.EventHandler(this.bttnManager_Click);
            // 
            // bttnAdmin
            // 
            this.bttnAdmin.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnAdmin.Location = new System.Drawing.Point(194, 47);
            this.bttnAdmin.Name = "bttnAdmin";
            this.bttnAdmin.Size = new System.Drawing.Size(94, 39);
            this.bttnAdmin.TabIndex = 3;
            this.bttnAdmin.Text = "Admin";
            this.bttnAdmin.UseVisualStyleBackColor = false;
            this.bttnAdmin.Click += new System.EventHandler(this.bttnAdmin_Click);
            // 
            // bttnCancel
            // 
            this.bttnCancel.BackColor = System.Drawing.Color.SaddleBrown;
            this.bttnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnCancel.Location = new System.Drawing.Point(290, 47);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(94, 39);
            this.bttnCancel.TabIndex = 4;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = false;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // RoleOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 98);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.bttnAdmin);
            this.Controls.Add(this.bttnManager);
            this.Controls.Add(this.bttnEmployee);
            this.Controls.Add(this.label1);
            this.Name = "RoleOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoleOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button bttnEmployee;
        private Button bttnManager;
        private Button bttnAdmin;
        private Button bttnCancel;
    }
}