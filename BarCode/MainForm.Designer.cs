namespace BarCode
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.pn_Right = new System.Windows.Forms.Panel();
            this.btn_CheckPrice = new System.Windows.Forms.Button();
            this.btn_Info = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Input = new System.Windows.Forms.Button();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.pn_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 92);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 92);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạp Hoá Việt";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlItem
            // 
            this.pnlItem.BackColor = System.Drawing.Color.White;
            this.pnlItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItem.Location = new System.Drawing.Point(0, 92);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(800, 295);
            this.pnlItem.TabIndex = 2;
            // 
            // pn_Right
            // 
            this.pn_Right.BackColor = System.Drawing.Color.White;
            this.pn_Right.Controls.Add(this.btn_CheckPrice);
            this.pn_Right.Controls.Add(this.btn_Info);
            this.pn_Right.Controls.Add(this.btn_Exit);
            this.pn_Right.Controls.Add(this.btn_Search);
            this.pn_Right.Controls.Add(this.btn_Input);
            this.pn_Right.Controls.Add(this.btn_Generate);
            this.pn_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.pn_Right.Location = new System.Drawing.Point(425, 92);
            this.pn_Right.Name = "pn_Right";
            this.pn_Right.Size = new System.Drawing.Size(375, 295);
            this.pn_Right.TabIndex = 3;
            // 
            // btn_CheckPrice
            // 
            this.btn_CheckPrice.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CheckPrice.Location = new System.Drawing.Point(0, 260);
            this.btn_CheckPrice.Name = "btn_CheckPrice";
            this.btn_CheckPrice.Size = new System.Drawing.Size(375, 105);
            this.btn_CheckPrice.TabIndex = 5;
            this.btn_CheckPrice.Text = "Xem giá";
            this.btn_CheckPrice.UseVisualStyleBackColor = true;
            this.btn_CheckPrice.Click += new System.EventHandler(this.btn_CheckPrice_Click);
            // 
            // btn_Info
            // 
            this.btn_Info.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Info.Location = new System.Drawing.Point(0, 200);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(375, 105);
            this.btn_Info.TabIndex = 4;
            this.btn_Info.Text = "Danh sách sản phẩm";
            this.btn_Info.UseVisualStyleBackColor = true;
            this.btn_Info.Click += new System.EventHandler(this.btn_Info_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(0, 320);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(375, 105);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(0, 140);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(375, 105);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Tìm kiếm sản phẩm";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btn_Input
            // 
            this.btn_Input.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Input.Location = new System.Drawing.Point(0, 80);
            this.btn_Input.Name = "btn_Input";
            this.btn_Input.Size = new System.Drawing.Size(375, 105);
            this.btn_Input.TabIndex = 1;
            this.btn_Input.Text = "Nhập sản phẩm";
            this.btn_Input.UseVisualStyleBackColor = true;
            this.btn_Input.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btn_Generate
            // 
            this.btn_Generate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generate.Location = new System.Drawing.Point(0, 20);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(375, 105);
            this.btn_Generate.TabIndex = 0;
            this.btn_Generate.Text = "Tạo barcode";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 387);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(800, 63);
            this.panel5.TabIndex = 0;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pn_Right);
            this.Controls.Add(this.pnlItem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.pn_Right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.Panel pn_Right;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Info;
        private System.Windows.Forms.Button btn_CheckPrice;
        private System.Windows.Forms.Panel panel5;
    }
}