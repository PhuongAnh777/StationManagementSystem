using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Route;
using StationManagementSystem.DTO.Ticket;
using StationManagementSystem.Models;
using StationManagementSystem.Services;
using StationManagementSystem.Views.Partners;

namespace StationManagementSystem.Views.SellTickets
{
    public partial class SellTicket : Form
    {
        private readonly TicketIssuanceService _ticketIssuanceService;
        private readonly OwnerService _ownerService;
        private readonly VehicleService _vehicleService;
        private readonly RouteService _routeService;
        private readonly ItineraryService _itineraryService;
        private readonly TicketService _ticketService;
        private readonly Employee _employee;
        public SellTicket()
        {
            InitializeComponent();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();
            _ticketService = new TicketService();

            LoadSellTicket();
        }
        public SellTicket(Employee employee)
        {
            InitializeComponent();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();
            _ticketService = new TicketService();

            _employee = employee;

            LoadSellTicket();
        }
        public void OpenChildForm(Form childForm)
        {
            //Đặt vị trí xuất hiện của form con là chính giữa màn hình
            childForm.StartPosition = FormStartPosition.Manual; // Đặt chế độ thủ công
            var screen = Screen.FromControl(this).WorkingArea; // Lấy kích thước màn hình làm tham chiếu
            childForm.Location = new Point(
                screen.X + (screen.Width - childForm.Width) / 2,
                screen.Y + (screen.Height - childForm.Height) / 2
            );

            //Làm mờ form chính
            this.Opacity = 0.1;

            // Hiển thị form con dưới dạng modal
            childForm.ShowDialog();

            // Khôi phục độ trong suốt của form chính
            this.Opacity = 1.0;
        }
        private async Task LoadSellTicket()
        {
            var routes = await _routeService.GetAllRoutesAsync();

            cbxTuyen.DataSource = routes.Select(r => new RouteDisplayItem
            {
                RouteID = r.RouteID,
                DisplayRoute = $"{r.DeparturePoint} - {r.ArrivalPoint}"
            }).ToList();
            cbxTuyen.DisplayMember = "DisplayRoute";
            cbxTuyen.ValueMember = "RouteID";
            cbxTuyen.SelectedIndex = -1;

            cbxLoTrinh.Enabled = false;
        }

        private async void cbxTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTuyen.SelectedIndex != -1 && cbxTuyen.SelectedValue != null)
            {
                var selectedRoute = cbxTuyen.SelectedItem as RouteDisplayItem;
                if (selectedRoute != null)
                {
                    var selectedRouteID = selectedRoute.RouteID;



                    var allItineraries = await _itineraryService.GetAllItinerariesAsync();
                    // Lọc các lộ trình thuộc tuyến đã chọn
                    var filteredItineraries = allItineraries
                        .Where(i => i.RouteID == selectedRouteID) // RouteID phải tồn tại trong Itinerary
                        .ToList();

                    cbxLoTrinh.DisplayMember = "ItineraryName";
                    cbxLoTrinh.ValueMember = "ItineraryID";
                    cbxLoTrinh.DataSource = filteredItineraries;
                    cbxLoTrinh.SelectedIndex = -1;
                    cbxLoTrinh.Enabled = true; // Cho phép chọn

                }
                else
                {
                    cbxLoTrinh.DataSource = null; // Nếu không có tuyến nào được chọn, đặt DataSource thành null
                    cbxLoTrinh.Enabled = false; // Vô hiệu hóa ComboBox
                }
            }
        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxLoTrinh.SelectedIndex == -1 || cbxLoTrinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lộ trình trước khi tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selected = (Guid)cbxLoTrinh.SelectedValue;
            var ticketissuances = await _ticketIssuanceService.GetCheckedSellTicketVehiclesAsync(selected);

            
            // Giả sử GetCheckedSellTicketVehiclesAsync trả về danh sách đối tượng có các thông tin cần thiết
            var displayTickets = ticketissuances.Select(v => new TicketDisplayItem
            {
                DepartureTime = v.DepartureTime,
                RemainingSeats = v.RemainingSeats,
                TotalSeats = v.TotalSeats,
                CompanyName = v.CompanyName,
                LicensePlate = v.LicensePlate,
                TicketIDs = v.TicketIDs
            }).ToList();

            DisplayTickets(displayTickets);
        }
        private void DisplayTickets(List<TicketDisplayItem> tickets)
        {
            tblTickets.Controls.Clear();
            tblTickets.RowStyles.Clear();
            tblTickets.RowCount = 0;

            int columnCount = tblTickets.ColumnCount;
            int row = 0, column = 0;

            foreach (var ticket in tickets)
            {
                var panel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 200,
                    Height = 120,
                    BackColor = Color.White,

                };
                

                var label = new Label
                {
                    Text = $"{ticket.DepartureTime:HH:mm}\n{ticket.RemainingSeats}/{ticket.TotalSeats}\n{ticket.CompanyName}\n{ticket.LicensePlate}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular)
                };
                // Gắn sự kiện Click cho cả panel và label
                panel.Click += (s, e) => Panel_Click(s, e);
                label.Click += (s, e) => Panel_Click(s, e);

                panel.Controls.Add(label);
                panel.Tag = ticket;

                tblTickets.Controls.Add(panel, column, row);

                column++;
                if (column >= columnCount)
                {
                    column = 0;
                    row++;
                    tblTickets.RowCount++;
                    tblTickets.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
            }
        }
        private async void Panel_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;
            Panel panel = clickedControl as Panel ?? clickedControl.Parent as Panel;

            if (panel != null)
            {
                var ticket = panel.Tag as TicketDisplayItem;
                if (ticket != null)
                {
                    //MessageBox.Show("Panel clicked!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (ticket.RemainingSeats == 0)
                    {
                        MessageBox.Show("Vé đã hết chỗ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    OpenChildForm(new SellAdd(ticket, cbxTuyen.Text, cbxLoTrinh.Text, _employee));
                    await LoadSellTicket();
                }
                else
                {
                    MessageBox.Show("Panel not clicked!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
