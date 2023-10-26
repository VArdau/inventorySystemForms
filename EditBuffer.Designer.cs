namespace inventorySystemForms
{
    partial class EditBuffer
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
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.txtbxItem = new System.Windows.Forms.TextBox();
            this.txtbxColour = new System.Windows.Forms.TextBox();
            this.txtbxBarcode = new System.Windows.Forms.TextBox();
            this.txtbxTotal = new System.Windows.Forms.TextBox();
            this.txtbxUpdate = new System.Windows.Forms.Button();
            this.txtbxSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDetails.Location = new System.Drawing.Point(225, 57);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(90, 35);
            this.lblDetails.TabIndex = 19;
            this.lblDetails.Text = "Details";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblItem.Location = new System.Drawing.Point(93, 57);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(65, 35);
            this.lblItem.TabIndex = 18;
            this.lblItem.Text = "Item";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblID.Location = new System.Drawing.Point(33, 57);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(40, 35);
            this.lblID.TabIndex = 17;
            this.lblID.Text = "ID";
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblT1.Location = new System.Drawing.Point(412, 57);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(106, 35);
            this.lblT1.TabIndex = 20;
            this.lblT1.Text = "Barcode";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(530, 57);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 35);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = "Total";
            // 
            // txtbxID
            // 
            this.txtbxID.Location = new System.Drawing.Point(35, 95);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.ReadOnly = true;
            this.txtbxID.Size = new System.Drawing.Size(38, 27);
            this.txtbxID.TabIndex = 22;
            // 
            // txtbxItem
            // 
            this.txtbxItem.Location = new System.Drawing.Point(93, 95);
            this.txtbxItem.Name = "txtbxItem";
            this.txtbxItem.ReadOnly = true;
            this.txtbxItem.Size = new System.Drawing.Size(107, 27);
            this.txtbxItem.TabIndex = 23;
            // 
            // txtbxColour
            // 
            this.txtbxColour.Location = new System.Drawing.Point(225, 95);
            this.txtbxColour.Name = "txtbxColour";
            this.txtbxColour.ReadOnly = true;
            this.txtbxColour.Size = new System.Drawing.Size(111, 27);
            this.txtbxColour.TabIndex = 24;
            // 
            // txtbxBarcode
            // 
            this.txtbxBarcode.Location = new System.Drawing.Point(412, 95);
            this.txtbxBarcode.Name = "txtbxBarcode";
            this.txtbxBarcode.ReadOnly = true;
            this.txtbxBarcode.Size = new System.Drawing.Size(96, 27);
            this.txtbxBarcode.TabIndex = 25;
            // 
            // txtbxTotal
            // 
            this.txtbxTotal.Location = new System.Drawing.Point(530, 95);
            this.txtbxTotal.Name = "txtbxTotal";
            this.txtbxTotal.Size = new System.Drawing.Size(57, 27);
            this.txtbxTotal.TabIndex = 26;
            // 
            // txtbxUpdate
            // 
            this.txtbxUpdate.BackColor = System.Drawing.Color.ForestGreen;
            this.txtbxUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtbxUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtbxUpdate.Location = new System.Drawing.Point(266, 137);
            this.txtbxUpdate.Name = "txtbxUpdate";
            this.txtbxUpdate.Size = new System.Drawing.Size(94, 34);
            this.txtbxUpdate.TabIndex = 27;
            this.txtbxUpdate.Text = "Update";
            this.txtbxUpdate.UseVisualStyleBackColor = false;
            this.txtbxUpdate.Click += new System.EventHandler(this.txtbxUpdate_Click);
            // 
            // txtbxSize
            // 
            this.txtbxSize.Location = new System.Drawing.Point(342, 95);
            this.txtbxSize.Name = "txtbxSize";
            this.txtbxSize.ReadOnly = true;
            this.txtbxSize.Size = new System.Drawing.Size(47, 27);
            this.txtbxSize.TabIndex = 39;
            // 
            // EditBuffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 186);
            this.Controls.Add(this.txtbxSize);
            this.Controls.Add(this.txtbxUpdate);
            this.Controls.Add(this.txtbxTotal);
            this.Controls.Add(this.txtbxBarcode);
            this.Controls.Add(this.txtbxColour);
            this.Controls.Add(this.txtbxItem);
            this.Controls.Add(this.txtbxID);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblT1);
            this.Controls.Add(this.lblTotal);
            this.Name = "EditBuffer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditBuffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDetails;
        private Label lblItem;
        private Label lblID;
        private Label lblT1;
        private Label lblTotal;
        private TextBox txtbxID;
        private TextBox txtbxItem;
        private TextBox txtbxColour;
        private TextBox txtbxBarcode;
        private TextBox txtbxTotal;
        private Button txtbxUpdate;
        private TextBox txtbxSize;
    }
}