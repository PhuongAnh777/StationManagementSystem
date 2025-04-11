using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using StationManagementSystem.Views.Employees;
using StationManagementSystem.Views.Partners;
using StationManagementSystem.Views.SellTickets;
using StationManagementSystem.Views.Transactions;
using Timer = System.Windows.Forms.Timer;

namespace StationManagementSystem.Views
{
    public partial class MainForm : Form
    {
        //private UserAccount _account;
        //private Models.Employee _employee;
        private string _roleName;
        public MainForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen; // Đặt form ở giữa màn hình

            //Show drop down list
            ConfigureHoverEvents(pnHangHoa, btnTaiKhoan);
            ConfigureHoverEvents(pnGiaoDich, btnGiaoDich);
            ConfigureHoverEvents(pnDoiTac, btnDoiTac);
            ConfigureHoverEvents(pnNhanVien, btnNhanVien);
            ConfigureHoverEvents(pnVe, btnVe);
            ConfigureHoverEvents(pnTaiKhoan, btnProFile);
        }
        //public MainForm(UserAccount account, Models.Employee employee, string roleName)
        //{
        //    InitializeComponent();

        //    this.StartPosition = FormStartPosition.CenterScreen; // Đặt form ở giữa màn hình

        //    //Show drop down list
        //    ConfigureHoverEvents(pnHangHoa, btnTaiKhoan);
        //    ConfigureHoverEvents(pnGiaoDich, btnGiaoDich);
        //    ConfigureHoverEvents(pnDoiTac, btnDoiTac);
        //    ConfigureHoverEvents(pnNhanVien, btnNhanVien);
        //    ConfigureHoverEvents(pnTaiKhoan, btnProFile);

        //    _account = account;
        //    _employee = employee;
        //    _roleName = roleName;

        //    btnProFile.Text = _account.Username;
        //}
        // Fill child form
        private void CreateFormChild(Form form)
        {
            // Kiểm tra nếu đã có form nào khác trong pnChild
            foreach (Control ctrl in pnChild.Controls)
            {
                if (ctrl is Form existingForm)
                {
                    existingForm.Close();
                    pnChild.Controls.Remove(existingForm);
                    break;
                }
            }

            form.TopLevel = false;
            pnChild.Controls.Add(form);
            form.Show();
        }

        // Hàm cấu hình sự kiện cho một cặp Button và Panel
        private void ConfigureHoverEvents(Panel panel, Guna2Button button)
        {
            // Đặt panel ban đầu ẩn
            panel.Visible = false;

            // Sử dụng Timer để kiểm tra vị trí chuột
            Timer timer = new Timer { Interval = 100 }; // Kiểm tra mỗi 100ms
            timer.Tick += (s, args) =>
            {
                Point cursorPosition = Cursor.Position;

                // Lấy vị trí và kích thước của Button và Panel trên màn hình
                Rectangle panelBounds = panel.RectangleToScreen(panel.ClientRectangle);
                Rectangle buttonBounds = button.RectangleToScreen(button.ClientRectangle);

                // Tạo vùng bao quanh Button và Panel
                Rectangle hitArea = Rectangle.Union(panelBounds, buttonBounds);

                // Nếu chuột nằm ngoài vùng hit-test, ẩn Panel
                if (!hitArea.Contains(cursorPosition))
                {
                    panel.Visible = false;
                    timer.Stop(); // Dừng Timer
                }
            };

            // Sự kiện chuột cho Button
            button.MouseEnter += (s, args) =>
            {
                panel.Visible = true; // Hiển thị Panel
                timer.Stop();         // Dừng kiểm tra tự động
            };

            button.MouseLeave += (s, args) =>
            {
                if (!panel.Bounds.Contains(button.PointToClient(Cursor.Position))) // Kiểm tra chuột có thật sự rời button
                {
                    timer.Start(); // Bắt đầu kiểm tra tự động
                }
            };

            // Sự kiện chuột cho Panel
            panel.MouseEnter += (s, args) =>
            {
                timer.Stop(); // Dừng kiểm tra tự động khi chuột vào Panel
            };

            panel.MouseLeave += (s, args) =>
            {
                if (!button.Bounds.Contains(panel.PointToClient(Cursor.Position))) // Kiểm tra chuột có thật sự rời panel
                {
                    timer.Start(); // Bắt đầu kiểm tra tự động
                }
            };
        }
        public void OpenChildForm(Form childForm)
        {
            // Đặt vị trí xuất hiện của form con là chính giữa màn hình
            childForm.StartPosition = FormStartPosition.Manual; // Đặt chế độ thủ công
            var screen = Screen.FromControl(this).WorkingArea; // Lấy kích thước màn hình làm tham chiếu
            childForm.Location = new Point(
                screen.X + (screen.Width - childForm.Width) / 2,
                screen.Y + (screen.Height - childForm.Height) / 2
            );

            // Làm mờ form chính
            this.Opacity = 0.1;

            // Hiển thị form con dưới dạng modal
            childForm.ShowDialog();

            // Khôi phục độ trong suốt của form chính
            this.Opacity = 1.0;
        }
        // Hàm kiểm tra và ẩn panel
        //private void CheckPanelVisibility(Guna2Button button, Panel panel)
        //{
        //    if (!mouseStates[button] && !mouseStates[panel])
        //    {
        //        panel.Visible = false; // Ẩn panel nếu chuột không nằm trên cả button và panel
        //    }
        //}



        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            CreateFormChild(new InvoiceList());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {

            //var sellForm = new Sell(_account, _employee, _roleName);
            //sellForm.ShowDialog(); // Hiển thị Sell

            //this.Close();
        }

        private void btnProFile_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new AccountForm());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //var loginform = new LoginForm();
            //loginform.ShowDialog();

            //this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //CreateFormChild(new RevenueReport());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            //CreateFormChild(new RevenueReport());
        }


        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            //CreateFormChild(new RevenueReport());
        }


        private void btnLenhXuatBen_Click(object sender, EventArgs e)
        {
            CreateFormChild(new VehicleDepartureList());
        }

        private void btnPhieuDangTai_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanVien1_Click(object sender, EventArgs e)
        {
            CreateFormChild(new EmloyeeList());
        }

        private void btnDSXe_Click(object sender, EventArgs e)
        {
            CreateFormChild(new SellTicketList());
        }

        private void btnChuXe_Click(object sender, EventArgs e)
        {
            CreateFormChild(new OwnerList());
        }

        private void btnXe_Click(object sender, EventArgs e)
        {
            CreateFormChild(new VehicleList());
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            CreateFormChild(new EmployeeAdd());
        }
    }
}
