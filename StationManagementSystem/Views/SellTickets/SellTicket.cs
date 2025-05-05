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
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.SellTickets
{
    public partial class SellTicket : Form
    {
        private readonly TicketIssuanceService _ticketIssuanceService;
        private readonly OwnerService _ownerService;
        private readonly VehicleService _vehicleService;
        private readonly RouteService _routeService;
        private readonly ItineraryService _itineraryService;

        public SellTicket()
        {
            InitializeComponent();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            LoadSellTicket();
        }
        private async void LoadSellTicket()
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
            var vehicleTickets = await _ticketIssuanceService.GetCheckedSellTicketVehiclesAsync(selected);

            // Giả sử GetCheckedSellTicketVehiclesAsync trả về danh sách đối tượng có các thông tin cần thiết
            //var displayTickets = vehicleTickets.Select(v => new TicketDisplayItem
            //{
            //    DepartureTime = v.EstimatedDepartureTime,
            //    RemainingSeats = v.SeatTicket,
            //    TotalSeats = v.TotalSeats,
            //    CompanyName = v.CompanyName,
            //    LicensePlate = v.LicensePlate
            //}).ToList();

            //DisplayTickets(displayTickets);
        }
        //private void DisplayTickets(List<TicketDisplayItem> tickets)
        //{
        //    tblTickets.Controls.Clear();
        //    tblTickets.RowStyles.Clear();
        //    tblTickets.RowCount = 0;

        //    int columnCount = tblTickets.ColumnCount;
        //    int row = 0, column = 0;

        //    foreach (var ticket in tickets)
        //    {
        //        var panel = new Panel
        //        {
        //            BorderStyle = BorderStyle.FixedSingle,
        //            Width = 200,
        //            Height = 80,
        //            BackColor = Color.White
        //        };

        //        var label = new Label
        //        {
        //            Text = $"{ticket.DepartureTime:HH:mm}\n{ticket.RemainingSeats}/{ticket.TotalSeats}\n{ticket.CompanyName}\n{ticket.LicensePlate}",
        //            AutoSize = false,
        //            TextAlign = ContentAlignment.MiddleCenter,
        //            Dock = DockStyle.Fill,
        //            Font = new Font("Segoe UI", 10, FontStyle.Regular)
        //        };

        //        panel.Controls.Add(label);

        //        tblTickets.Controls.Add(panel, column, row);

        //        column++;
        //        if (column >= columnCount)
        //        {
        //            column = 0;
        //            row++;
        //            tblTickets.RowCount++;
        //            tblTickets.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        //        }
        //    }
        //}

    }
}
