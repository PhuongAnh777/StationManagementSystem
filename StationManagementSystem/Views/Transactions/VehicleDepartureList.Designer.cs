namespace StationManagementSystem.Views.Transactions
{
    partial class VehicleDepartureList
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gridView = new Guna.UI2.WinForms.Guna2DataGridView();
            SupplierName = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Active = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            pnFooter = new Panel();
            labelPageInfo = new Label();
            lblPage = new Label();
            btnSau = new Guna.UI2.WinForms.Guna2Button();
            btnTruoc = new Guna.UI2.WinForms.Guna2Button();
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
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            gridView.ColumnHeadersHeight = 24;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridView.Columns.AddRange(new DataGridViewColumn[] { SupplierName, ID, PhoneNumber, Email, Address, Active, Amount });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle11;
            gridView.GridColor = Color.FromArgb(231, 229, 255);
            gridView.Location = new Point(12, 77);
            gridView.Name = "gridView";
            gridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = Color.White;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(1338, 723);
            gridView.TabIndex = 11;
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
            pnFooter.Location = new Point(12, 806);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(1338, 50);
            pnFooter.TabIndex = 13;
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
            btnSau.CustomizableEdges = customizableEdges17;
            btnSau.DisabledState.BorderColor = Color.DarkGray;
            btnSau.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSau.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSau.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSau.FillColor = Color.White;
            btnSau.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSau.ForeColor = Color.RoyalBlue;
            btnSau.Location = new Point(295, 3);
            btnSau.Name = "btnSau";
            btnSau.ShadowDecoration.CustomizableEdges = customizableEdges18;
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
            btnTruoc.CustomizableEdges = customizableEdges19;
            btnTruoc.DisabledState.BorderColor = Color.DarkGray;
            btnTruoc.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTruoc.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTruoc.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTruoc.FillColor = Color.White;
            btnTruoc.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTruoc.ForeColor = Color.RoyalBlue;
            btnTruoc.Location = new Point(61, 3);
            btnTruoc.Name = "btnTruoc";
            btnTruoc.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnTruoc.Size = new Size(81, 44);
            btnTruoc.TabIndex = 0;
            btnTruoc.Text = "Trước";
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(btnXuatFile);
            pnHeader.Controls.Add(btnImport);
            pnHeader.Controls.Add(btnAdd);
            pnHeader.Controls.Add(tbxSearch);
            pnHeader.Controls.Add(lblHeader);
            pnHeader.Location = new Point(13, 12);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(1337, 50);
            pnHeader.TabIndex = 14;
            // 
            // btnXuatFile
            // 
            btnXuatFile.CustomizableEdges = customizableEdges21;
            btnXuatFile.DisabledState.BorderColor = Color.DarkGray;
            btnXuatFile.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXuatFile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXuatFile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXuatFile.FillColor = Color.FromArgb(78, 169, 90);
            btnXuatFile.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatFile.ForeColor = Color.White;
            btnXuatFile.Location = new Point(1112, 3);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnXuatFile.Size = new Size(177, 42);
            btnXuatFile.TabIndex = 4;
            btnXuatFile.Text = "Xuất file";
            // 
            // btnImport
            // 
            btnImport.CustomizableEdges = customizableEdges23;
            btnImport.DisabledState.BorderColor = Color.DarkGray;
            btnImport.DisabledState.CustomBorderColor = Color.DarkGray;
            btnImport.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnImport.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnImport.FillColor = Color.FromArgb(78, 169, 90);
            btnImport.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(929, 3);
            btnImport.Name = "btnImport";
            btnImport.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnImport.Size = new Size(177, 42);
            btnImport.TabIndex = 3;
            btnImport.Text = "Import";
            // 
            // btnAdd
            // 
            btnAdd.CustomizableEdges = customizableEdges25;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(78, 169, 90);
            btnAdd.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(746, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnAdd.Size = new Size(177, 42);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm mới";
            // 
            // tbxSearch
            // 
            tbxSearch.CustomizableEdges = customizableEdges27;
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
            tbxSearch.ShadowDecoration.CustomizableEdges = customizableEdges28;
            tbxSearch.Size = new Size(343, 42);
            tbxSearch.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(4, 8);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(284, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Danh sách xe xuất bến";
            // 
            // VehicleDepartureList
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1362, 867);
            Controls.Add(pnHeader);
            Controls.Add(pnFooter);
            Controls.Add(gridView);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "VehicleDepartureList";
            Text = "VehicleDepartureList";
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