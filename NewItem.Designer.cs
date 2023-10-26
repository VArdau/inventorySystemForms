namespace inventorySystemForms
{
    partial class NewItem
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
            this.bttnConfirm = new System.Windows.Forms.Button();
            this.txtbxSize = new System.Windows.Forms.TextBox();
            this.txtbxColour = new System.Windows.Forms.TextBox();
            this.txtbxItem = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblColour = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bttnConfirm
            // 
            this.bttnConfirm.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnConfirm.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnConfirm.Location = new System.Drawing.Point(90, 258);
            this.bttnConfirm.Name = "bttnConfirm";
            this.bttnConfirm.Size = new System.Drawing.Size(122, 37);
            this.bttnConfirm.TabIndex = 5;
            this.bttnConfirm.Text = "CREATE";
            this.bttnConfirm.UseVisualStyleBackColor = false;
            this.bttnConfirm.Click += new System.EventHandler(this.bttnConfirm_Click);
            // 
            // txtbxSize
            // 
            this.txtbxSize.Location = new System.Drawing.Point(79, 225);
            this.txtbxSize.Name = "txtbxSize";
            this.txtbxSize.Size = new System.Drawing.Size(149, 27);
            this.txtbxSize.TabIndex = 4;
            // 
            // txtbxColour
            // 
            this.txtbxColour.Location = new System.Drawing.Point(79, 143);
            this.txtbxColour.Name = "txtbxColour";
            this.txtbxColour.Size = new System.Drawing.Size(149, 27);
            this.txtbxColour.TabIndex = 3;
            // 
            // txtbxItem
            // 
            this.txtbxItem.Location = new System.Drawing.Point(79, 70);
            this.txtbxItem.Name = "txtbxItem";
            this.txtbxItem.Size = new System.Drawing.Size(149, 27);
            this.txtbxItem.TabIndex = 6;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblItem.Location = new System.Drawing.Point(79, 32);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(65, 35);
            this.lblItem.TabIndex = 7;
            this.lblItem.Text = "Item";
            // 
            // lblColour
            // 
            this.lblColour.AutoSize = true;
            this.lblColour.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblColour.Location = new System.Drawing.Point(79, 104);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(89, 35);
            this.lblColour.TabIndex = 8;
            this.lblColour.Text = "Colour";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSize.Location = new System.Drawing.Point(79, 176);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(58, 35);
            this.lblSize.TabIndex = 9;
            this.lblSize.Text = "Size";
            // 
            // NewItem
            // 
            this.ClientSize = new System.Drawing.Size(324, 346);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblColour);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.txtbxItem);
            this.Controls.Add(this.bttnConfirm);
            this.Controls.Add(this.txtbxSize);
            this.Controls.Add(this.txtbxColour);
            this.Name = "NewItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bttnCreate;
        private TextBox txtbxSize;
        private TextBox txtbxColour;
        private TextBox txtbxItem;
        private Label lblItem;
        private Label lblColour;
        private Label lblSize;
        private Button bttnConfirm;
    }
}