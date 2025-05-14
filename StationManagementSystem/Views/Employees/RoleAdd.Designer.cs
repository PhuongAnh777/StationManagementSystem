namespace StationManagementSystem.Views.Employees
{
    partial class RoleAdd
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
            pnHeader = new Panel();
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            lblHeader = new Label();
            pnContainer = new Panel();
            pnLine2 = new Panel();
            panel1 = new Panel();
            tbxMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            lblMoTa = new Label();
            pnLineA1 = new Panel();
            tbxTen = new Guna.UI2.WinForms.Guna2TextBox();
            lblTen = new Label();
            panel2 = new Panel();
            btnBoQua = new Guna.UI2.WinForms.Guna2Button();
            btnLuu = new Guna.UI2.WinForms.Guna2Button();
            pnHeader.SuspendLayout();
            pnContainer.SuspendLayout();
            pnLine2.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(btnExit);
            pnHeader.Controls.Add(lblHeader);
            pnHeader.Location = new Point(3, 2);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(664, 78);
            pnHeader.TabIndex = 4;
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
            btnExit.Location = new Point(607, 12);
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
            lblHeader.Size = new Size(177, 35);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Thêm vai trò";
            // 
            // pnContainer
            // 
            pnContainer.Controls.Add(pnLine2);
            pnContainer.Controls.Add(tbxMoTa);
            pnContainer.Controls.Add(lblMoTa);
            pnContainer.Controls.Add(pnLineA1);
            pnContainer.Controls.Add(tbxTen);
            pnContainer.Controls.Add(lblTen);
            pnContainer.Location = new Point(4, 84);
            pnContainer.Name = "pnContainer";
            pnContainer.Size = new Size(663, 295);
            pnContainer.TabIndex = 5;
            // 
            // pnLine2
            // 
            pnLine2.BackColor = Color.Silver;
            pnLine2.Controls.Add(panel1);
            pnLine2.Location = new Point(167, 263);
            pnLine2.Name = "pnLine2";
            pnLine2.Size = new Size(485, 1);
            pnLine2.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(375, 1);
            panel1.TabIndex = 7;
            // 
            // tbxMoTa
            // 
            tbxMoTa.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            tbxMoTa.BorderThickness = 0;
            tbxMoTa.CustomizableEdges = customizableEdges3;
            tbxMoTa.DefaultText = "";
            tbxMoTa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxMoTa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxMoTa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxMoTa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxMoTa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxMoTa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxMoTa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxMoTa.Location = new Point(167, 110);
            tbxMoTa.Margin = new Padding(4);
            tbxMoTa.Multiline = true;
            tbxMoTa.Name = "tbxMoTa";
            tbxMoTa.PlaceholderText = "";
            tbxMoTa.SelectedText = "";
            tbxMoTa.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbxMoTa.Size = new Size(485, 155);
            tbxMoTa.TabIndex = 5;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMoTa.Location = new Point(73, 129);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(73, 25);
            lblMoTa.TabIndex = 7;
            lblMoTa.Text = "Mô tả";
            // 
            // pnLineA1
            // 
            pnLineA1.BackColor = Color.Silver;
            pnLineA1.Location = new Point(170, 46);
            pnLineA1.Name = "pnLineA1";
            pnLineA1.Size = new Size(480, 1);
            pnLineA1.TabIndex = 4;
            // 
            // tbxTen
            // 
            tbxTen.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            tbxTen.BorderThickness = 0;
            tbxTen.CustomizableEdges = customizableEdges5;
            tbxTen.DefaultText = "";
            tbxTen.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxTen.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxTen.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxTen.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxTen.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxTen.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxTen.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxTen.Location = new Point(170, 3);
            tbxTen.Margin = new Padding(4);
            tbxTen.Name = "tbxTen";
            tbxTen.PlaceholderText = "";
            tbxTen.SelectedText = "";
            tbxTen.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbxTen.Size = new Size(482, 40);
            tbxTen.TabIndex = 2;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTen.Location = new Point(20, 22);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(120, 25);
            lblTen.TabIndex = 0;
            lblTen.Text = "Tên vai trò";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnBoQua);
            panel2.Controls.Add(btnLuu);
            panel2.Location = new Point(4, 385);
            panel2.Name = "panel2";
            panel2.Size = new Size(663, 70);
            panel2.TabIndex = 6;
            // 
            // btnBoQua
            // 
            btnBoQua.CustomizableEdges = customizableEdges7;
            btnBoQua.DisabledState.BorderColor = Color.DarkGray;
            btnBoQua.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBoQua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBoQua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBoQua.FillColor = Color.DarkGray;
            btnBoQua.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBoQua.ForeColor = Color.White;
            btnBoQua.Location = new Point(470, 12);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnBoQua.Size = new Size(177, 42);
            btnBoQua.TabIndex = 8;
            btnBoQua.Text = "Bỏ qua";
            // 
            // btnLuu
            // 
            btnLuu.CustomizableEdges = customizableEdges9;
            btnLuu.DisabledState.BorderColor = Color.DarkGray;
            btnLuu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLuu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLuu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLuu.FillColor = Color.FromArgb(78, 169, 90);
            btnLuu.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(261, 12);
            btnLuu.Name = "btnLuu";
            btnLuu.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLuu.Size = new Size(177, 42);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu";
            btnLuu.Click += btnLuu_Click;
            // 
            // RoleAdd
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(676, 468);
            Controls.Add(panel2);
            Controls.Add(pnContainer);
            Controls.Add(pnHeader);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "RoleAdd";
            Text = "RoleAdd";
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            pnContainer.ResumeLayout(false);
            pnContainer.PerformLayout();
            pnLine2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Label lblHeader;
        private Panel pnContainer;
        private Panel pnLine2;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox tbxMoTa;
        private Label lblMoTa;
        private Panel pnLineA1;
        private Guna.UI2.WinForms.Guna2TextBox tbxTen;
        private Label lblTen;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnBoQua;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
    }
}