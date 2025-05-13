namespace StationManagementSystem.Views.Statistics
{
    partial class StatisticsForm
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
            Guna.Charts.WinForms.ChartFont chartFont9 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont10 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont11 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont12 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid4 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick4 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont13 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid5 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick5 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont14 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid6 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel2 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont15 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick6 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont16 = new Guna.Charts.WinForms.ChartFont();
            guna2Chart1 = new Guna.Charts.WinForms.GunaChart();
            gunaBarDataset = new Guna.Charts.WinForms.GunaBarDataset();
            SuspendLayout();
            // 
            // guna2Chart1
            // 
            guna2Chart1.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { gunaBarDataset });
            chartFont9.FontName = "Arial";
            guna2Chart1.Legend.LabelFont = chartFont9;
            guna2Chart1.Location = new Point(345, 173);
            guna2Chart1.Name = "guna2Chart1";
            guna2Chart1.Size = new Size(710, 495);
            guna2Chart1.TabIndex = 0;
            chartFont10.FontName = "Arial";
            chartFont10.Size = 12;
            chartFont10.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            guna2Chart1.Title.Font = chartFont10;
            chartFont11.FontName = "Arial";
            guna2Chart1.Tooltips.BodyFont = chartFont11;
            chartFont12.FontName = "Arial";
            chartFont12.Size = 9;
            chartFont12.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            guna2Chart1.Tooltips.TitleFont = chartFont12;
            guna2Chart1.XAxes.GridLines = grid4;
            chartFont13.FontName = "Arial";
            tick4.Font = chartFont13;
            guna2Chart1.XAxes.Ticks = tick4;
            guna2Chart1.YAxes.GridLines = grid5;
            chartFont14.FontName = "Arial";
            tick5.Font = chartFont14;
            guna2Chart1.YAxes.Ticks = tick5;
            guna2Chart1.ZAxes.GridLines = grid6;
            chartFont15.FontName = "Arial";
            pointLabel2.Font = chartFont15;
            guna2Chart1.ZAxes.PointLabels = pointLabel2;
            chartFont16.FontName = "Arial";
            tick6.Font = chartFont16;
            guna2Chart1.ZAxes.Ticks = tick6;
            // 
            // gunaBarDataset
            // 
            gunaBarDataset.Label = "Bar1";
            gunaBarDataset.TargetChart = guna2Chart1;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1362, 867);
            Controls.Add(guna2Chart1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "StatisticsForm";
            Text = "StatisticsForm";
            ResumeLayout(false);
        }

        #endregion

        private Guna.Charts.WinForms.GunaChart guna2Chart1;
        private Guna.Charts.WinForms.GunaBarDataset gunaBarDataset;
    }
}