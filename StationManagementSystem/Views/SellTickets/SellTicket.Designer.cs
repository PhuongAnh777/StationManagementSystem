namespace StationManagementSystem.Views.SellTickets
{
    partial class SellTicket
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            btnSearch = new Guna.UI2.WinForms.Guna2Button();
            cbxLoTrinh = new Guna.UI2.WinForms.Guna2ComboBox();
            lblLoTrinh = new Label();
            cbxTuyen = new Guna.UI2.WinForms.Guna2ComboBox();
            lblTuyen = new Label();
            lblHeader = new Label();
            tblTickets = new TableLayoutPanel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(cbxLoTrinh);
            panel1.Controls.Add(lblLoTrinh);
            panel1.Controls.Add(cbxTuyen);
            panel1.Controls.Add(lblTuyen);
            panel1.Controls.Add(lblHeader);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1354, 125);
            panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.CustomizableEdges = customizableEdges7;
            btnSearch.DisabledState.BorderColor = Color.DarkGray;
            btnSearch.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSearch.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSearch.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSearch.FillColor = Color.FromArgb(78, 169, 90);
            btnSearch.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1186, 49);
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSearch.Size = new Size(148, 42);
            btnSearch.TabIndex = 167;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // cbxLoTrinh
            // 
            cbxLoTrinh.BackColor = Color.Transparent;
            cbxLoTrinh.CustomizableEdges = customizableEdges9;
            cbxLoTrinh.DrawMode = DrawMode.OwnerDrawFixed;
            cbxLoTrinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxLoTrinh.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxLoTrinh.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxLoTrinh.Font = new Font("Segoe UI", 10F);
            cbxLoTrinh.ForeColor = Color.FromArgb(68, 88, 112);
            cbxLoTrinh.ItemHeight = 30;
            cbxLoTrinh.Location = new Point(633, 49);
            cbxLoTrinh.Name = "cbxLoTrinh";
            cbxLoTrinh.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cbxLoTrinh.Size = new Size(532, 36);
            cbxLoTrinh.TabIndex = 145;
            // 
            // lblLoTrinh
            // 
            lblLoTrinh.AutoSize = true;
            lblLoTrinh.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoTrinh.ForeColor = Color.Black;
            lblLoTrinh.Location = new Point(536, 62);
            lblLoTrinh.Name = "lblLoTrinh";
            lblLoTrinh.Size = new Size(79, 23);
            lblLoTrinh.TabIndex = 144;
            lblLoTrinh.Text = "Lộ trình";
            // 
            // cbxTuyen
            // 
            cbxTuyen.BackColor = Color.Transparent;
            cbxTuyen.CustomizableEdges = customizableEdges11;
            cbxTuyen.DrawMode = DrawMode.OwnerDrawFixed;
            cbxTuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTuyen.FocusedColor = Color.FromArgb(94, 148, 255);
            cbxTuyen.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbxTuyen.Font = new Font("Segoe UI", 10F);
            cbxTuyen.ForeColor = Color.FromArgb(68, 88, 112);
            cbxTuyen.ItemHeight = 30;
            cbxTuyen.Location = new Point(90, 49);
            cbxTuyen.Name = "cbxTuyen";
            cbxTuyen.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cbxTuyen.Size = new Size(418, 36);
            cbxTuyen.TabIndex = 143;
            cbxTuyen.SelectedIndexChanged += cbxTuyen_SelectedIndexChanged;
            // 
            // lblTuyen
            // 
            lblTuyen.AutoSize = true;
            lblTuyen.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTuyen.ForeColor = Color.Black;
            lblTuyen.Location = new Point(23, 60);
            lblTuyen.Name = "lblTuyen";
            lblTuyen.Size = new Size(61, 23);
            lblTuyen.TabIndex = 112;
            lblTuyen.Text = "Tuyến";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(10, 8);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(97, 32);
            lblHeader.TabIndex = 2;
            lblHeader.Text = "Bán vé";
            // 
            // tblTickets
            // 
            tblTickets.AutoScroll = true;
            tblTickets.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tblTickets.ColumnCount = 2;
            tblTickets.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblTickets.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblTickets.Dock = DockStyle.Fill;
            tblTickets.Location = new Point(0, 0);
            tblTickets.Name = "tblTickets";
            tblTickets.RowCount = 2;
            tblTickets.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblTickets.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblTickets.Size = new Size(1354, 723);
            tblTickets.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(tblTickets);
            panel2.Location = new Point(2, 132);
            panel2.Name = "panel2";
            panel2.Size = new Size(1354, 723);
            panel2.TabIndex = 2;
            // 
            // SellTicket
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1362, 867);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "SellTicket";
            Text = "SellTicket";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblHeader;
        private Label lblTuyen;
        private Guna.UI2.WinForms.Guna2ComboBox cbxTuyen;
        private Guna.UI2.WinForms.Guna2ComboBox cbxLoTrinh;
        private Label lblLoTrinh;
        private TableLayoutPanel tblTickets;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
    }
}