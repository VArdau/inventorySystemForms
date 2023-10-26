namespace inventorySystemForms
{
    partial class CreateMB
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
            this.cbxItem = new System.Windows.Forms.ComboBox();
            this.txtbxQuantity = new System.Windows.Forms.TextBox();
            this.bttnAdd = new System.Windows.Forms.Button();
            this.floItemList = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnCreateBox = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxItem
            // 
            this.cbxItem.FormattingEnabled = true;
            this.cbxItem.Location = new System.Drawing.Point(26, 42);
            this.cbxItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxItem.Name = "cbxItem";
            this.cbxItem.Size = new System.Drawing.Size(129, 23);
            this.cbxItem.TabIndex = 0;
            this.cbxItem.SelectedIndexChanged += new System.EventHandler(this.cbxItem_SelectedIndexChanged);
            this.cbxItem.SelectionChangeCommitted += new System.EventHandler(this.cbxItem_SelectionChangeCommitted);
            this.cbxItem.SelectedValueChanged += new System.EventHandler(this.cbxItem_SelectedValueChanged);
            this.cbxItem.TextChanged += new System.EventHandler(this.cbxItem_TextChanged);
            // 
            // txtbxQuantity
            // 
            this.txtbxQuantity.Location = new System.Drawing.Point(168, 42);
            this.txtbxQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxQuantity.Name = "txtbxQuantity";
            this.txtbxQuantity.PlaceholderText = "0";
            this.txtbxQuantity.Size = new System.Drawing.Size(53, 23);
            this.txtbxQuantity.TabIndex = 1;
            // 
            // bttnAdd
            // 
            this.bttnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnAdd.Location = new System.Drawing.Point(234, 42);
            this.bttnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnAdd.Name = "bttnAdd";
            this.bttnAdd.Size = new System.Drawing.Size(38, 24);
            this.bttnAdd.TabIndex = 16;
            this.bttnAdd.Text = "+";
            this.bttnAdd.UseVisualStyleBackColor = false;
            this.bttnAdd.Click += new System.EventHandler(this.bttnAdd_Click);
            // 
            // floItemList
            // 
            this.floItemList.AutoScroll = true;
            this.floItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.floItemList.Location = new System.Drawing.Point(298, 25);
            this.floItemList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.floItemList.Name = "floItemList";
            this.floItemList.Size = new System.Drawing.Size(210, 101);
            this.floItemList.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Item";
            // 
            // bttnCreateBox
            // 
            this.bttnCreateBox.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnCreateBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnCreateBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnCreateBox.Location = new System.Drawing.Point(298, 130);
            this.bttnCreateBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnCreateBox.Name = "bttnCreateBox";
            this.bttnCreateBox.Size = new System.Drawing.Size(68, 24);
            this.bttnCreateBox.TabIndex = 19;
            this.bttnCreateBox.Text = "Create";
            this.bttnCreateBox.UseVisualStyleBackColor = false;
            this.bttnCreateBox.Click += new System.EventHandler(this.bttnCreateBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Box";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(26, 88);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(16, 15);
            this.lblDetails.TabIndex = 21;
            this.lblDetails.Text = "...";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(26, 70);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(16, 15);
            this.lblItemName.TabIndex = 22;
            this.lblItemName.Text = "...";
            // 
            // CreateMB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 159);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bttnCreateBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.floItemList);
            this.Controls.Add(this.bttnAdd);
            this.Controls.Add(this.txtbxQuantity);
            this.Controls.Add(this.cbxItem);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateMB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateMB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbxItem;
        private TextBox txtbxQuantity;
        private Button bttnAdd;
        private FlowLayoutPanel floItemList;
        private Label label1;
        private Button bttnCreateBox;
        private Label label2;
        private Label lblDetails;
        private Label lblItemName;
    }
}