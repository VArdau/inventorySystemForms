namespace inventorySystemForms
{
    partial class SetAmountEmail
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
            this.bttnSubmit = new System.Windows.Forms.Button();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxReminder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bttnSubmit
            // 
            this.bttnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnSubmit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnSubmit.Location = new System.Drawing.Point(161, 104);
            this.bttnSubmit.Name = "bttnSubmit";
            this.bttnSubmit.Size = new System.Drawing.Size(94, 34);
            this.bttnSubmit.TabIndex = 30;
            this.bttnSubmit.Text = "Submit";
            this.bttnSubmit.UseVisualStyleBackColor = false;
            this.bttnSubmit.Click += new System.EventHandler(this.bttnSubmit_Click);
            // 
            // txtbxID
            // 
            this.txtbxID.Location = new System.Drawing.Point(45, 59);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.ReadOnly = true;
            this.txtbxID.Size = new System.Drawing.Size(38, 27);
            this.txtbxID.TabIndex = 29;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblID.Location = new System.Drawing.Point(43, 21);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(40, 35);
            this.lblID.TabIndex = 28;
            this.lblID.Text = "ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(115, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 35);
            this.lblName.TabIndex = 31;
            this.lblName.Text = "Name";
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(115, 59);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.ReadOnly = true;
            this.txtbxName.Size = new System.Drawing.Size(127, 27);
            this.txtbxName.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(252, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 35);
            this.label1.TabIndex = 33;
            this.label1.Text = "Reminder ";
            // 
            // txtbxReminder
            // 
            this.txtbxReminder.Location = new System.Drawing.Point(271, 59);
            this.txtbxReminder.Name = "txtbxReminder";
            this.txtbxReminder.Size = new System.Drawing.Size(71, 27);
            this.txtbxReminder.TabIndex = 34;
            // 
            // SetAmountEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 166);
            this.Controls.Add(this.txtbxReminder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.bttnSubmit);
            this.Controls.Add(this.txtbxID);
            this.Controls.Add(this.lblID);
            this.Name = "SetAmountEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetAmountEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bttnSubmit;
        private TextBox txtbxID;
        private Label lblID;
        private Label lblName;
        private TextBox txtbxName;
        private Label label1;
        private TextBox txtbxReminder;
    }
}