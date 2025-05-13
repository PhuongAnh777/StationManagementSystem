using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Ticket;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.SellTickets
{
    public partial class SellAdd : Form
    {
        private readonly TicketService _ticketService;
        private readonly TicketDisplayItem _ticket;
        private string _route;
        private string _itinerary;
        private Guid _ticketIDSeat;
        private Guid _ticketIDSleeper;
        private Employee _employee;
        private TicketDetailCreateDto _ticketDetailCreateDto;
        public SellAdd()
        {
            InitializeComponent();

            _ticketService = new TicketService();
        }
        public SellAdd(TicketDisplayItem ticket, string route, string itinerary, Employee employee)
        {
            InitializeComponent();

            _ticketService = new TicketService();
            _ticket = ticket;
            _route = route;
            _itinerary = itinerary;
            _employee = employee;

            LoadSellAdd();
        }

        private void SellAdd_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Vẽ viền mỏng xung quanh form
            using (Pen borderPen = new Pen(Color.Black, 1)) // Viền màu đen, dày 1px
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            }
        }
        public async Task LoadSellAdd()
        {
            // Lấy thông tin vé từ dịch vụ
            lblBienSoV.Text = _ticket.LicensePlate;
            lblDVVTV.Text = _ticket.CompanyName;
            lblTuyenV.Text = _route;
            lblLoTrinhV.Text = _itinerary;
            lblGioXuatV.Text = _ticket.DepartureTime.ToString("HH:mm");

            var respone = await _ticketService.GetTicketByIdAsync(_ticket.TicketIDs.FirstOrDefault());
            if (respone != null)
            {
                if (respone.TicketType.ToLower() == "sleeper")
                {
                    cbxLoaiVe.Items.Add("Ghế nằm");
                    _ticketIDSleeper = respone.TicketID;
                }
                else if (respone.TicketType.ToLower() == "seat")
                {
                    cbxLoaiVe.Items.Add("Ghế ngồi");
                    _ticketIDSeat = respone.TicketID;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respone1 = await _ticketService.GetTicketByIdAsync(_ticket.TicketIDs.Last());
            if (respone1 != null)
            {
                if (respone1.TicketType.ToLower() == "sleeper")
                {
                    cbxLoaiVe.Items.Add("Ghế nằm");
                    _ticketIDSleeper = respone.TicketID;
                }
                else if (respone1.TicketType.ToLower() == "seat")
                {
                    cbxLoaiVe.Items.Add("Ghế ngồi");
                    _ticketIDSeat = respone.TicketID;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cbxLoaiVe.SelectedIndex = -1; // Chọn loại vé đầu tiên trong danh sách
        }

        private async void btnIn_Click(object sender, EventArgs e)
        {
            if (cbxLoaiVe.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_ticketIDSleeper != Guid.Empty)
            {
                _ticketDetailCreateDto = new TicketDetailCreateDto
                {
                    EmployeeID = _employee.EmployeeID, // Thay thế bằng ID nhân viên thực tế
                    TicketID = _ticketIDSleeper,
                    Status = "Ghế nằm",
                };
            }
            else if (_ticketIDSeat != Guid.Empty)
            {
                _ticketDetailCreateDto = new TicketDetailCreateDto
                {
                    EmployeeID = _employee.EmployeeID, // Thay thế bằng ID nhân viên thực tế
                    TicketID = _ticketIDSeat,
                    Status = "Ghế ngồi",
                };
            }

            if (string.IsNullOrEmpty(numSoLuong.Text))
            {
                MessageBox.Show("Vui lòng chọn số lượng vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < int.Parse(numSoLuong.Text); i++)
            {
                var respone = await _ticketService.CreateTicketDetailAsync(_ticketDetailCreateDto);
            }

            MessageBox.Show($"In vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void cbxLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
