namespace inventorySystemForms
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.bttnStock = new System.Windows.Forms.Button();
            this.bttnBuffer = new System.Windows.Forms.Button();
            this.pcbxAdmin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnStock
            // 
            this.bttnStock.BackColor = System.Drawing.Color.ForestGreen;
            this.bttnStock.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnStock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnStock.Location = new System.Drawing.Point(55, 58);
            this.bttnStock.Name = "bttnStock";
            this.bttnStock.Size = new System.Drawing.Size(150, 45);
            this.bttnStock.TabIndex = 0;
            this.bttnStock.Text = "STOCK";
            this.bttnStock.UseVisualStyleBackColor = false;
            this.bttnStock.Click += new System.EventHandler(this.bttnStock_Click);
            // 
            // bttnBuffer
            // 
            this.bttnBuffer.BackColor = System.Drawing.Color.SaddleBrown;
            this.bttnBuffer.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttnBuffer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnBuffer.Location = new System.Drawing.Point(55, 124);
            this.bttnBuffer.Name = "bttnBuffer";
            this.bttnBuffer.Size = new System.Drawing.Size(150, 45);
            this.bttnBuffer.TabIndex = 2;
            this.bttnBuffer.Text = "BUFFER";
            this.bttnBuffer.UseVisualStyleBackColor = false;
            this.bttnBuffer.Click += new System.EventHandler(this.bttnBuffer_Click);
            // 
            // pcbxAdmin
            // 
            this.pcbxAdmin.Image = ((System.Drawing.Image)(resources.GetObject("pcbxAdmin.Image")));
            this.pcbxAdmin.Location = new System.Drawing.Point(212, 12);
            this.pcbxAdmin.Name = "pcbxAdmin";
            this.pcbxAdmin.Size = new System.Drawing.Size(35, 35);
            this.pcbxAdmin.TabIndex = 3;
            this.pcbxAdmin.TabStop = false;
            this.pcbxAdmin.Click += new System.EventHandler(this.pcbxAdmin_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(260, 224);
            this.Controls.Add(this.pcbxAdmin);
            this.Controls.Add(this.bttnBuffer);
            this.Controls.Add(this.bttnStock);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Option";
            ((System.ComponentModel.ISupportInitialize)(this.pcbxAdmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button bttnStock;
        private Button bttnBuffer;
        private PictureBox pcbxAdmin;
    }
}