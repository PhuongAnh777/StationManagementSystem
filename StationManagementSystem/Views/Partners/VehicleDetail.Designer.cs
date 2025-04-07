namespace StationManagementSystem.Views.Partners
{
    partial class VehicleDetail
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblHeader = new Label();
            pnLine = new Panel();
            lblThongTinChinh = new Label();
            lblThongTinKhac = new Label();
            pnChild = new Panel();
            btnOk = new Guna.UI2.WinForms.Guna2Button();
            btnCancle = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(12, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(165, 32);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Thông tin xe";
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Silver;
            pnLine.Location = new Point(12, 87);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1338, 1);
            pnLine.TabIndex = 2;
            // 
            // lblThongTinChinh
            // 
            lblThongTinChinh.AutoSize = true;
            lblThongTinChinh.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThongTinChinh.ForeColor = SystemColors.ControlDarkDark;
            lblThongTinChinh.Location = new Point(26, 57);
            lblThongTinChinh.Name = "lblThongTinChinh";
            lblThongTinChinh.Size = new Size(171, 25);
            lblThongTinChinh.TabIndex = 6;
            lblThongTinChinh.Text = "Thông tin chính";
            lblThongTinChinh.Click += lblThongTinChinh_Click;
            // 
            // lblThongTinKhac
            // 
            lblThongTinKhac.AutoSize = true;
            lblThongTinKhac.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThongTinKhac.ForeColor = SystemColors.ControlDarkDark;
            lblThongTinKhac.Location = new Point(254, 57);
            lblThongTinKhac.Name = "lblThongTinKhac";
            lblThongTinKhac.Size = new Size(163, 25);
            lblThongTinKhac.TabIndex = 7;
            lblThongTinKhac.Text = "Thông tin khác";
            lblThongTinKhac.Click += lblThongTinKhac_Click;
            // 
            // pnChild
            // 
            pnChild.Location = new Point(12, 94);
            pnChild.Name = "pnChild";
            pnChild.Size = new Size(1338, 710);
            pnChild.TabIndex = 8;
            // 
            // btnOk
            // 
            btnOk.CustomizableEdges = customizableEdges5;
            btnOk.DisabledState.BorderColor = Color.DarkGray;
            btnOk.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOk.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOk.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOk.FillColor = Color.FromArgb(78, 169, 90);
            btnOk.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(817, 813);
            btnOk.Name = "btnOk";
            btnOk.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnOk.Size = new Size(177, 42);
            btnOk.TabIndex = 3;
            btnOk.Text = "Đồng ý";
            // 
            // btnCancle
            // 
            btnCancle.CustomizableEdges = customizableEdges7;
            btnCancle.DisabledState.BorderColor = Color.DarkGray;
            btnCancle.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancle.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancle.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancle.FillColor = Color.FromArgb(202, 88, 103);
            btnCancle.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancle.ForeColor = Color.White;
            btnCancle.Location = new Point(1012, 813);
            btnCancle.Name = "btnCancle";
            btnCancle.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancle.Size = new Size(177, 42);
            btnCancle.TabIndex = 9;
            btnCancle.Text = "Hủy bỏ";
            // 
            // VehicleDetail
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 867);
            Controls.Add(btnCancle);
            Controls.Add(btnOk);
            Controls.Add(pnChild);
            Controls.Add(lblThongTinKhac);
            Controls.Add(lblThongTinChinh);
            Controls.Add(pnLine);
            Controls.Add(lblHeader);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "VehicleDetail";
            Text = "VehicleDetail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private Panel pnLine;
        private Label lblThongTinChinh;
        private Label lblThongTinKhac;
        private Panel pnChild;
        private Guna.UI2.WinForms.Guna2Button btnOk;
        private Guna.UI2.WinForms.Guna2Button btnCancle;
    }
}