namespace StationManagementSystem.Views.SellTickets
{
    partial class SellAdd
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnHeader = new Panel();
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            lblHeader = new Label();
            lblLoTrinhV = new Label();
            lblLoTrinh = new Label();
            lblTuyenV = new Label();
            lblTuyen = new Label();
            lblDVVTV = new Label();
            lblDVVT = new Label();
            lblBienSoV = new Label();
            lblBienSo = new Label();
            lblGioXuat = new Label();
            lblGioXuatV = new Label();
            lblLoaiVe = new Label();
            lblGia = new Label();
            lblGiaTienV = new Label();
            lblSoLuong = new Label();
            numSoLuong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            btnIn = new Guna.UI2.WinForms.Guna2Button();
            cbxLoaiVe = new Guna.UI2.WinForms.Guna2ComboBox();
            pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(btnExit);
            pnHeader.Controls.Add(lblHeader);
            pnHeader.Location = new Point(6, 2);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(1093, 78);
            pnHeader.TabIndex = 7;
            // 
            // btnExit
            // 
            btnExit.CustomizableEdges = customizableEdges1;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.White;
            btnExit.FocusedColor = SystemColors.ControlDark;
            btnExit.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.Silver;
            btnExit.Location = new Point(1036, 10);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnExit.Size = new Size(46, 56);
            btnExit.TabIndex = 1;
            btnExit.Text = "X";
            btnExit.Click += btnExit_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(21, 21);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(119, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Chọn vé";
            // 
            // lblLoTrinhV
            // 
            lblLoTrinhV.AutoSize = true;
            lblLoTrinhV.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoTrinhV.ForeColor = Color.Black;
            lblLoTrinhV.Location = new Point(189, 309);
            lblLoTrinhV.Name = "lblLoTrinhV";
            lblLoTrinhV.Size = new Size(30, 23);
            lblLoTrinhV.TabIndex = 59;
            lblLoTrinhV.Text = "15";
            // 
            // lblLoTrinh
            // 
            lblLoTrinh.AutoSize = true;
            lblLoTrinh.Location = new Point(21, 310);
            lblLoTrinh.Name = "lblLoTrinh";
            lblLoTrinh.Size = new Size(72, 22);
            lblLoTrinh.TabIndex = 57;
            lblLoTrinh.Text = "Lộ trình";
            // 
            // lblTuyenV
            // 
            lblTuyenV.AutoSize = true;
            lblTuyenV.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTuyenV.ForeColor = Color.Black;
            lblTuyenV.Location = new Point(189, 240);
            lblTuyenV.Name = "lblTuyenV";
            lblTuyenV.Size = new Size(184, 23);
            lblTuyenV.TabIndex = 55;
            lblTuyenV.Text = "Công ty Phương Anh";
            // 
            // lblTuyen
            // 
            lblTuyen.AutoSize = true;
            lblTuyen.Location = new Point(19, 241);
            lblTuyen.Name = "lblTuyen";
            lblTuyen.Size = new Size(149, 22);
            lblTuyen.TabIndex = 54;
            lblTuyen.Text = "Tuyến vận chuyển";
            // 
            // lblDVVTV
            // 
            lblDVVTV.AutoSize = true;
            lblDVVTV.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDVVTV.ForeColor = Color.Black;
            lblDVVTV.Location = new Point(189, 168);
            lblDVVTV.Name = "lblDVVTV";
            lblDVVTV.Size = new Size(184, 23);
            lblDVVTV.TabIndex = 53;
            lblDVVTV.Text = "Công ty Phương Anh";
            // 
            // lblDVVT
            // 
            lblDVVT.AutoSize = true;
            lblDVVT.Location = new Point(20, 169);
            lblDVVT.Name = "lblDVVT";
            lblDVVT.Size = new Size(123, 22);
            lblDVVT.TabIndex = 52;
            lblDVVT.Text = "Đơn vị vận tải";
            // 
            // lblBienSoV
            // 
            lblBienSoV.AutoSize = true;
            lblBienSoV.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienSoV.ForeColor = Color.IndianRed;
            lblBienSoV.Location = new Point(189, 100);
            lblBienSoV.Name = "lblBienSoV";
            lblBienSoV.Size = new Size(119, 25);
            lblBienSoV.TabIndex = 51;
            lblBienSoV.Text = "11B-01234";
            // 
            // lblBienSo
            // 
            lblBienSo.AutoSize = true;
            lblBienSo.Location = new Point(20, 103);
            lblBienSo.Name = "lblBienSo";
            lblBienSo.Size = new Size(70, 22);
            lblBienSo.TabIndex = 50;
            lblBienSo.Text = "Biển số";
            // 
            // lblGioXuat
            // 
            lblGioXuat.AutoSize = true;
            lblGioXuat.Location = new Point(19, 375);
            lblGioXuat.Name = "lblGioXuat";
            lblGioXuat.Size = new Size(111, 22);
            lblGioXuat.TabIndex = 60;
            lblGioXuat.Text = "Giờ xuất bến";
            // 
            // lblGioXuatV
            // 
            lblGioXuatV.AutoSize = true;
            lblGioXuatV.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGioXuatV.ForeColor = Color.Black;
            lblGioXuatV.Location = new Point(189, 374);
            lblGioXuatV.Name = "lblGioXuatV";
            lblGioXuatV.Size = new Size(155, 23);
            lblGioXuatV.TabIndex = 61;
            lblGioXuatV.Text = "20:59 14-11-2016";
            // 
            // lblLoaiVe
            // 
            lblLoaiVe.AutoSize = true;
            lblLoaiVe.Location = new Point(588, 103);
            lblLoaiVe.Name = "lblLoaiVe";
            lblLoaiVe.Size = new Size(70, 22);
            lblLoaiVe.TabIndex = 67;
            lblLoaiVe.Text = "Loại vé";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(585, 240);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(73, 22);
            lblGia.TabIndex = 68;
            lblGia.Text = "Giá tiền";
            // 
            // lblGiaTienV
            // 
            lblGiaTienV.AutoSize = true;
            lblGiaTienV.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGiaTienV.ForeColor = Color.Black;
            lblGiaTienV.Location = new Point(721, 239);
            lblGiaTienV.Name = "lblGiaTienV";
            lblGiaTienV.Size = new Size(75, 23);
            lblGiaTienV.TabIndex = 69;
            lblGiaTienV.Text = "300.000";
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(588, 169);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(82, 22);
            lblSoLuong.TabIndex = 70;
            lblSoLuong.Text = "Số lượng";
            // 
            // numSoLuong
            // 
            numSoLuong.BackColor = Color.Transparent;
            numSoLuong.CustomizableEdges = customizableEdges3;
            numSoLuong.Font = new Font("Segoe UI", 9F);
            numSoLuong.Location = new Point(721, 164);
            numSoLuong.Margin = new Padding(3, 4, 3, 4);
            numSoLuong.Name = "numSoLuong";
            numSoLuong.ShadowDecoration.CustomizableEdges = customizableEdges4;
            numSoLuong.Size = new Size(119, 27);
            numSoLuong.TabIndex = 71;
            numSoLuong.UpDownButtonFillColor = Color.FromArgb(192, 192, 255);
            // 
            // btnIn
            // 
            btnIn.CustomizableEdges = customizableEdges5;
            btnIn.DisabledState.BorderColor = Color.DarkGray;
            btnIn.DisabledState.CustomBorderColor = Color.DarkGray;
            btnIn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnIn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnIn.FillColor = Color.FromArgb(78, 169, 90);
            btnIn.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIn.ForeColor = Color.White;
            btnIn.Location = new Point(426, 420);
            btnIn.Name = "btnIn";
            btnIn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnIn.Size = new Size(177, 42);
            btnIn.TabIndex = 133;
            btnIn.Text = "In vé";
            btnIn.Click += btnIn_Click;
            // 
            // cbxLoaiVe
            // 
            cbxLoaiVe.BackColor = Color.Transparent;
            cbxLoaiVe.CustomizableEdges = customizableEdges7;
            cbxLoaiVe.DrawMode = DrawMode.OwnerDrawFixed;
            cbxLoaiVe.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxLoaiVe.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxLoaiVe.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxLoaiVe.Font = new Font("Segoe UI", 10F);
            cbxLoaiVe.ForeColor = Color.FromArgb(68, 88, 112);
            cbxLoaiVe.ItemHeight = 30;
            cbxLoaiVe.Location = new Point(721, 89);
            cbxLoaiVe.Name = "cbxLoaiVe";
            cbxLoaiVe.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbxLoaiVe.Size = new Size(264, 36);
            cbxLoaiVe.TabIndex = 66;
            cbxLoaiVe.SelectedIndexChanged += cbxLoaiVe_SelectedIndexChanged;
            // 
            // SellAdd
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 476);
            Controls.Add(btnIn);
            Controls.Add(numSoLuong);
            Controls.Add(lblSoLuong);
            Controls.Add(lblGiaTienV);
            Controls.Add(lblGia);
            Controls.Add(lblLoaiVe);
            Controls.Add(cbxLoaiVe);
            Controls.Add(lblGioXuatV);
            Controls.Add(lblGioXuat);
            Controls.Add(lblLoTrinhV);
            Controls.Add(pnHeader);
            Controls.Add(lblTuyen);
            Controls.Add(lblLoTrinh);
            Controls.Add(lblBienSo);
            Controls.Add(lblBienSoV);
            Controls.Add(lblTuyenV);
            Controls.Add(lblDVVT);
            Controls.Add(lblDVVTV);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "SellAdd";
            Text = "SellAdd";
            Load += SellAdd_Load;
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Label lblHeader;
        private Label lblLoTrinhV;
        private Label lblLoTrinh;
        private Label lblTuyenV;
        private Label lblTuyen;
        private Label lblDVVTV;
        private Label lblDVVT;
        private Label lblBienSoV;
        private Label lblBienSo;
        private Label lblGioXuat;
        private Label lblGioXuatV;
        private Label lblLoaiVe;
        private Label lblGia;
        private Label lblGiaTienV;
        private Label lblSoLuong;
        private Guna.UI2.WinForms.Guna2NumericUpDown numSoLuong;
        private Guna.UI2.WinForms.Guna2Button btnIn;
        private Guna.UI2.WinForms.Guna2ComboBox cbxLoaiVe;
    }
}