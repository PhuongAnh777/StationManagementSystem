namespace StationManagementSystem.Views.Transactions
{
    partial class InvoiceList
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gridView = new Guna.UI2.WinForms.Guna2DataGridView();
            SupplierName = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Active = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            pnFooter = new Panel();
            lblPage = new Label();
            btnSau = new Guna.UI2.WinForms.Guna2Button();
            btnTruoc = new Guna.UI2.WinForms.Guna2Button();
            labelPageInfo = new Label();
            pnHeader = new Panel();
            btnXuatFile = new Guna.UI2.WinForms.Guna2Button();
            btnImport = new Guna.UI2.WinForms.Guna2Button();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            tbxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblHeader = new Label();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            pnFooter.SuspendLayout();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // gridView
            // 
            gridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            gridView.ColumnHeadersHeight = 24;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridView.Columns.AddRange(new DataGridViewColumn[] { SupplierName, ID, PhoneNumber, Email, Address, Active, Amount });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle7;
            gridView.GridColor = Color.FromArgb(231, 229, 255);
            gridView.Location = new Point(12, 68);
            gridView.Name = "gridView";
            gridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(1338, 739);
            gridView.TabIndex = 12;
            gridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            gridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gridView.ThemeStyle.BackColor = Color.White;
            gridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(192, 192, 255);
            gridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gridView.ThemeStyle.HeaderStyle.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridView.ThemeStyle.HeaderStyle.Height = 24;
            gridView.ThemeStyle.ReadOnly = false;
            gridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            gridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.ThemeStyle.RowsStyle.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gridView.ThemeStyle.RowsStyle.Height = 29;
            gridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // SupplierName
            // 
            SupplierName.DataPropertyName = "Name";
            SupplierName.HeaderText = "Tên nhà cung cấp";
            SupplierName.MinimumWidth = 6;
            SupplierName.Name = "SupplierName";
            SupplierName.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // PhoneNumber
            // 
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.HeaderText = "Điện thoại";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Địa chỉ";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Active
            // 
            Active.DataPropertyName = "Active";
            Active.HeaderText = "Trạng thái";
            Active.MinimumWidth = 6;
            Active.Name = "Active";
            Active.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Amount
            // 
            Amount.DataPropertyName = "Amount";
            Amount.HeaderText = "Tổng mua";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            Amount.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // pnFooter
            // 
            pnFooter.Controls.Add(labelPageInfo);
            pnFooter.Controls.Add(lblPage);
            pnFooter.Controls.Add(btnSau);
            pnFooter.Controls.Add(btnTruoc);
            pnFooter.Location = new Point(12, 813);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(1338, 50);
            pnFooter.TabIndex = 13;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.ForeColor = Color.RoyalBlue;
            lblPage.Location = new Point(185, 12);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(60, 22);
            lblPage.TabIndex = 2;
            lblPage.Text = "label1";
            // 
            // btnSau
            // 
            btnSau.BackColor = SystemColors.Control;
            btnSau.BorderColor = Color.RoyalBlue;
            btnSau.BorderRadius = 20;
            btnSau.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnSau.BorderThickness = 1;
            btnSau.CustomizableEdges = customizableEdges5;
            btnSau.DisabledState.BorderColor = Color.DarkGray;
            btnSau.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSau.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSau.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSau.FillColor = Color.White;
            btnSau.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSau.ForeColor = Color.RoyalBlue;
            btnSau.Location = new Point(295, 3);
            btnSau.Name = "btnSau";
            btnSau.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSau.Size = new Size(81, 44);
            btnSau.TabIndex = 1;
            btnSau.Text = "Sau";
            // 
            // btnTruoc
            // 
            btnTruoc.BackColor = SystemColors.Control;
            btnTruoc.BorderColor = Color.RoyalBlue;
            btnTruoc.BorderRadius = 20;
            btnTruoc.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            btnTruoc.BorderThickness = 1;
            btnTruoc.CustomizableEdges = customizableEdges7;
            btnTruoc.DisabledState.BorderColor = Color.DarkGray;
            btnTruoc.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTruoc.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTruoc.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTruoc.FillColor = Color.White;
            btnTruoc.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTruoc.ForeColor = Color.RoyalBlue;
            btnTruoc.Location = new Point(61, 3);
            btnTruoc.Name = "btnTruoc";
            btnTruoc.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnTruoc.Size = new Size(81, 44);
            btnTruoc.TabIndex = 0;
            btnTruoc.Text = "Trước";
            // 
            // labelPageInfo
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Location = new Point(382, 12);
            labelPageInfo.Name = "labelPageInfo";
            labelPageInfo.Size = new Size(312, 22);
            labelPageInfo.TabIndex = 3;
            labelPageInfo.Text = "Hiển thị 11 - 20 / Tổng số 32 hàng hóa";
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(btnXuatFile);
            pnHeader.Controls.Add(btnImport);
            pnHeader.Controls.Add(btnAdd);
            pnHeader.Controls.Add(tbxSearch);
            pnHeader.Controls.Add(lblHeader);
            pnHeader.Location = new Point(12, 12);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(1337, 50);
            pnHeader.TabIndex = 10;
            // 
            // btnXuatFile
            // 
            btnXuatFile.CustomizableEdges = customizableEdges9;
            btnXuatFile.DisabledState.BorderColor = Color.DarkGray;
            btnXuatFile.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXuatFile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXuatFile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXuatFile.FillColor = Color.FromArgb(78, 169, 90);
            btnXuatFile.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatFile.ForeColor = Color.White;
            btnXuatFile.Location = new Point(1112, 3);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnXuatFile.Size = new Size(177, 42);
            btnXuatFile.TabIndex = 4;
            btnXuatFile.Text = "Xuất file";
            // 
            // btnImport
            // 
            btnImport.CustomizableEdges = customizableEdges11;
            btnImport.DisabledState.BorderColor = Color.DarkGray;
            btnImport.DisabledState.CustomBorderColor = Color.DarkGray;
            btnImport.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnImport.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnImport.FillColor = Color.FromArgb(78, 169, 90);
            btnImport.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(929, 3);
            btnImport.Name = "btnImport";
            btnImport.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnImport.Size = new Size(177, 42);
            btnImport.TabIndex = 3;
            btnImport.Text = "Import";
            // 
            // btnAdd
            // 
            btnAdd.CustomizableEdges = customizableEdges13;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(78, 169, 90);
            btnAdd.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(746, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnAdd.Size = new Size(177, 42);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm mới";
            // 
            // tbxSearch
            // 
            tbxSearch.CustomizableEdges = customizableEdges15;
            tbxSearch.DefaultText = "";
            tbxSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxSearch.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxSearch.Location = new Point(321, 4);
            tbxSearch.Margin = new Padding(4);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.PlaceholderText = "Theo mã, tên, số điện thoại";
            tbxSearch.SelectedText = "";
            tbxSearch.ShadowDecoration.CustomizableEdges = customizableEdges16;
            tbxSearch.Size = new Size(343, 42);
            tbxSearch.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(4, 8);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(119, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Hóa đơn";
            // 
            // InvoiceList
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 867);
            Controls.Add(pnHeader);
            Controls.Add(pnFooter);
            Controls.Add(gridView);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "InvoiceList";
            Text = "InvoiceList";
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            pnFooter.ResumeLayout(false);
            pnFooter.PerformLayout();
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView gridView;
        private DataGridViewTextBoxColumn SupplierName;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Active;
        private DataGridViewTextBoxColumn Amount;
        private Panel pnFooter;
        private Label labelPageInfo;
        private Label lblPage;
        private Guna.UI2.WinForms.Guna2Button btnSau;
        private Guna.UI2.WinForms.Guna2Button btnTruoc;
        private Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnXuatFile;
        private Guna.UI2.WinForms.Guna2Button btnImport;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox tbxSearch;
        private Label lblHeader;
    }
}