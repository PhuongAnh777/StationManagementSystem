namespace StationManagementSystem.Views.Routes
{
    partial class ItineraryAdd
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            lblHeader = new Label();
            pnHeader = new Panel();
            cbxTuyen = new Guna.UI2.WinForms.Guna2ComboBox();
            lblTen = new Label();
            lblDangKyXe = new Label();
            lblNhomXe = new Label();
            pnFooter = new Panel();
            btnBoQua = new Guna.UI2.WinForms.Guna2Button();
            btnLuu = new Guna.UI2.WinForms.Guna2Button();
            flowPanelStops = new FlowLayoutPanel();
            label1 = new Label();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            pnHeader.SuspendLayout();
            pnFooter.SuspendLayout();
            SuspendLayout();
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
            btnExit.Location = new Point(764, 3);
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
            lblHeader.Location = new Point(16, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(189, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Thêm lộ trình";
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(btnExit);
            pnHeader.Controls.Add(lblHeader);
            pnHeader.Location = new Point(12, 12);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(820, 66);
            pnHeader.TabIndex = 156;
            // 
            // cbxTuyen
            // 
            cbxTuyen.BackColor = Color.Transparent;
            cbxTuyen.CustomizableEdges = customizableEdges3;
            cbxTuyen.DrawMode = DrawMode.OwnerDrawFixed;
            cbxTuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTuyen.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxTuyen.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxTuyen.Font = new Font("Segoe UI", 10F);
            cbxTuyen.ForeColor = Color.FromArgb(68, 88, 112);
            cbxTuyen.ItemHeight = 30;
            cbxTuyen.Location = new Point(177, 164);
            cbxTuyen.Name = "cbxTuyen";
            cbxTuyen.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbxTuyen.Size = new Size(655, 36);
            cbxTuyen.TabIndex = 143;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(177, 99);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(141, 22);
            lblTen.TabIndex = 138;
            lblTen.Text = "Bảo hiểm TNDS";
            // 
            // lblDangKyXe
            // 
            lblDangKyXe.AutoSize = true;
            lblDangKyXe.Location = new Point(12, 178);
            lblDangKyXe.Name = "lblDangKyXe";
            lblDangKyXe.Size = new Size(112, 22);
            lblDangKyXe.TabIndex = 137;
            lblDangKyXe.Text = "Tuyến đường";
            // 
            // lblNhomXe
            // 
            lblNhomXe.AutoSize = true;
            lblNhomXe.Location = new Point(12, 99);
            lblNhomXe.Name = "lblNhomXe";
            lblNhomXe.Size = new Size(102, 22);
            lblNhomXe.TabIndex = 136;
            lblNhomXe.Text = "Tên lộ trình";
            // 
            // pnFooter
            // 
            pnFooter.Controls.Add(btnBoQua);
            pnFooter.Controls.Add(btnLuu);
            pnFooter.Location = new Point(12, 583);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(820, 68);
            pnFooter.TabIndex = 6;
            // 
            // btnBoQua
            // 
            btnBoQua.CustomizableEdges = customizableEdges5;
            btnBoQua.DisabledState.BorderColor = Color.DarkGray;
            btnBoQua.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBoQua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBoQua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBoQua.FillColor = Color.DarkGray;
            btnBoQua.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBoQua.ForeColor = Color.White;
            btnBoQua.Location = new Point(612, 17);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBoQua.Size = new Size(177, 42);
            btnBoQua.TabIndex = 6;
            btnBoQua.Text = "Bỏ qua";
            // 
            // btnLuu
            // 
            btnLuu.CustomizableEdges = customizableEdges7;
            btnLuu.DisabledState.BorderColor = Color.DarkGray;
            btnLuu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLuu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLuu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLuu.FillColor = Color.FromArgb(78, 169, 90);
            btnLuu.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(374, 17);
            btnLuu.Name = "btnLuu";
            btnLuu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLuu.Size = new Size(177, 42);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.Click += btnLuu_Click;
            // 
            // flowPanelStops
            // 
            flowPanelStops.AutoScroll = true;
            flowPanelStops.BackColor = Color.White;
            flowPanelStops.FlowDirection = FlowDirection.TopDown;
            flowPanelStops.Location = new Point(177, 280);
            flowPanelStops.Name = "flowPanelStops";
            flowPanelStops.Size = new Size(655, 287);
            flowPanelStops.TabIndex = 157;
            flowPanelStops.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 280);
            label1.Name = "label1";
            label1.Size = new Size(129, 22);
            label1.TabIndex = 158;
            label1.Text = "Các điểm dừng";
            // 
            // btnAdd
            // 
            btnAdd.CustomizableEdges = customizableEdges9;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(128, 128, 255);
            btnAdd.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(655, 232);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAdd.Size = new Size(177, 42);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.Click += btnAdd_Click_1;
            // 
            // ItineraryAdd
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(845, 663);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(flowPanelStops);
            Controls.Add(pnFooter);
            Controls.Add(pnHeader);
            Controls.Add(cbxTuyen);
            Controls.Add(lblTen);
            Controls.Add(lblDangKyXe);
            Controls.Add(lblNhomXe);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ItineraryAdd";
            Text = "ItineraryAdd";
            Load += ItineraryAdd_Load;
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            pnFooter.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbxTaiXe;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Label lblHeader;
        private Guna.UI2.WinForms.Guna2NumericUpDown numGheNam;
        private Label lblOwnerId;
        private Guna.UI2.WinForms.Guna2GroupBox grboxVe;
        private Guna.UI2.WinForms.Guna2NumericUpDown numGheNgoi;
        private Label lblGheNam;
        private Label lblGheNgoi;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btnThemChuXe;
        private Guna.UI2.WinForms.Guna2Button btnOk;
        private Guna.UI2.WinForms.Guna2NumericUpDown numNam;
        private Label lblNamSanXuat;
        private Panel pnHeader;
        private Label lblDenNgay2;
        private Label lblNote;
        private Label lblDenNgay1;
        private Label lblTuNgay1;
        private Label lblBienBan;
        private Label lblBienSo;
        private Label lblKiemDinh;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimeToBB;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimeFromBB;
        private Label lblTuNgay;
        private Guna.UI2.WinForms.Guna2TextBox tbxBienSo;
        private Guna.UI2.WinForms.Guna2TextBox tbxDangKyXe;
        private Guna.UI2.WinForms.Guna2ComboBox cbxTuyen;
        private Label lblTaiXe;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimeToKD;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimeFromKD;
        private Label lblTen;
        private Label lblDangKyXe;
        private Label lblNhomXe;
        private Panel pnFooter;
        private Guna.UI2.WinForms.Guna2Button btnBoQua;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private FlowLayoutPanel flowPanelStops;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
    }
}