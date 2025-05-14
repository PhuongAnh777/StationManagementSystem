using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Itinerary;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Routes
{
    public partial class ItineraryEdit : Form
    {
        private readonly ItineraryService _itineraryService;
        private readonly RouteService _routeService;

        private Itinerary _itinerary;
        private ItineraryUpdateDto _itineraryDto;

        private string _roleName;
        public ItineraryEdit()
        {
            InitializeComponent();

            _itineraryService = new ItineraryService();
            _routeService = new RouteService();
            _itineraryDto = new ItineraryUpdateDto();

            LoadEmployee();
        }

        public ItineraryEdit(Itinerary itinerary, string roleName)
        {
            InitializeComponent();

            _itineraryService = new ItineraryService();
            _routeService = new RouteService();
            _itineraryDto = new ItineraryUpdateDto();

            _itinerary = itinerary;

            LoadEmployee();
            _roleName = roleName;
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
        private async void LoadEmployee()
        {
            lblTen.Text = _itinerary.ItineraryName;

            var routes = await _routeService.GetActiveRoutesAsync();
            var routeDisplayList = routes.Select(r => new
            {
                r.RouteID,
                DisplayRoute = $"{r.DeparturePoint} - {r.ArrivalPoint}"
            }).ToList();

            cbxTuyen.DisplayMember = "DisplayRoute";
            cbxTuyen.ValueMember = "RouteID";
            cbxTuyen.DataSource = routeDisplayList;
            cbxTuyen.SelectedValue = _itinerary.RouteID;

            flowPanelStops.Controls.Clear(); // Xóa các điểm cũ nếu có

            var stopPoints = await _itineraryService.GetStopPointsByitineraryIdAsync(_itinerary.ItineraryID);

            foreach (var sp in stopPoints)
            {
                AddStopPointPanel(sp.Name, sp.StoppingTime);
            }
        }
        private void AddStopPointPanel(string name, int? time)
        {
            Panel stopPanel = new Panel();
            stopPanel.Width = flowPanelStops.Width - 30;
            stopPanel.Height = 50;
            stopPanel.Padding = new Padding(5);
            stopPanel.BackColor = Color.FromArgb(192, 192, 255);
            stopPanel.Margin = new Padding(5);

            TextBox txtName = new TextBox();
            txtName.PlaceholderText = "Tên điểm dừng";
            txtName.Text = name;
            txtName.Font = new Font("Times New Roman", 12);
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.White;
            txtName.Width = 150;
            txtName.Height = 50;
            txtName.Location = new Point(10, 15);

            TextBox txtTime = new TextBox();
            txtTime.PlaceholderText = "Thời gian dừng (phút)";
            txtTime.Text = time.ToString();
            txtTime.Font = new Font("Times New Roman", 12);
            txtTime.BorderStyle = BorderStyle.None;
            txtTime.BackColor = Color.White;
            txtTime.Width = 170;
            txtTime.Height = 50;
            txtTime.Location = new Point(350, 15);

            Button btnDelete = new Button();
            btnDelete.Text = "X";
            btnDelete.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 35;
            btnDelete.Height = 35;
            btnDelete.Location = new Point(530, 7);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += (s, ev) => flowPanelStops.Controls.Remove(stopPanel);

            stopPanel.Controls.Add(txtName);
            stopPanel.Controls.Add(txtTime);
            stopPanel.Controls.Add(btnDelete);

            flowPanelStops.Controls.Add(stopPanel);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_roleName != "Admin")
            {
                MessageBox.Show("Bạn không có quyền thêm điểm dừng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Panel stopPanel = new Panel();
            stopPanel.Width = flowPanelStops.Width - 30;
            stopPanel.Height = 50;
            stopPanel.Padding = new Padding(5);
            stopPanel.BackColor = Color.FromArgb(192, 192, 255); // Light blue background
            stopPanel.Margin = new Padding(5);

            // TextBox: Tên điểm dừng
            TextBox txtName = new TextBox();
            txtName.PlaceholderText = "Tên điểm dừng";
            txtName.Font = new Font("Times New Roman", 12);
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.White;
            txtName.Width = 150;
            txtName.Height = 50;
            txtName.Location = new Point(10, 15);

            // TextBox: Thời gian dừng
            TextBox txtTime = new TextBox();
            txtTime.PlaceholderText = "Thời gian dừng (phút)";
            txtTime.Font = new Font("Times New Roman", 12);
            txtTime.BorderStyle = BorderStyle.None;
            txtTime.BackColor = Color.White;
            txtTime.Width = 170;
            txtTime.Height = 50;
            txtTime.Location = new Point(350, 15);

            // Nút Xóa
            Button btnDelete = new Button();
            btnDelete.Text = "X";
            btnDelete.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 35;
            btnDelete.Height = 35;
            btnDelete.Location = new Point(530, 7);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += (s, ev) =>
            {
                // Xóa panel khỏi flowPanelStops
                flowPanelStops.Controls.Remove(stopPanel);
                stopPanel.Dispose(); // Giải phóng nếu cần
                UpdateStopPoints();  // Ví dụ cập nhật lại danh sách điểm dừng và giao diện
            };

            // Thêm các control vào panel
            stopPanel.Controls.Add(txtName);
            stopPanel.Controls.Add(txtTime);
            stopPanel.Controls.Add(btnDelete);

            // Thêm panel vào flowLayoutPanel
            flowPanelStops.Controls.Add(stopPanel);
        }
        private void UpdateStopPoints()
        {
            _itineraryDto.StopPoints.Clear();
            foreach (Panel stopPanel in flowPanelStops.Controls.OfType<Panel>())
            {
                var stopPointDto = new StopPoint
                {
                    Name = stopPanel.Controls.OfType<TextBox>().FirstOrDefault(t => t.PlaceholderText == "Tên điểm dừng")?.Text,
                    StoppingTime = int.TryParse(stopPanel.Controls.OfType<TextBox>().FirstOrDefault(t => t.PlaceholderText == "Thời gian dừng (phút)")?.Text, out int duration) ? duration : 0
                };

                // Bỏ qua nếu thiếu TextBox
                if (stopPointDto.Name == null || stopPointDto.StoppingTime == null)
                    continue;
                //if (string.IsNullOrEmpty(stopPointDto.Name))
                //{
                //    MessageBox.Show("Vui lòng nhập tên điểm dừng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (stopPointDto.StoppingTime <= 0)
                //{
                //    MessageBox.Show("Thời gian dừng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                _itineraryDto.StopPoints.Add(stopPointDto);
            }
        }
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_roleName != "Admin")
            {
                MessageBox.Show("Bạn không có quyền xóa lộ trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Hiển thị hộp thoại xác nhận xóa
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn xóa lộ trình này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {

                // Gọi hàm xóa từ service
                var isDeleted = await _itineraryService.DeleteItineraryAsync(_itinerary.ItineraryID);

                if (isDeleted)
                {
                    this.Close();
                    MessageBox.Show("Xóa thành công lộ trình!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (_roleName != "Admin")
            {
                MessageBox.Show("Bạn không có quyền sửa thông tin lộ trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _itineraryDto.StopPoints.Clear();
            foreach (Panel stopPanel in flowPanelStops.Controls.OfType<Panel>())
            {
                var stopPointDto = new StopPoint
                {
                    Name = stopPanel.Controls.OfType<TextBox>().FirstOrDefault(t => t.PlaceholderText == "Tên điểm dừng")?.Text,
                    StoppingTime = int.TryParse(stopPanel.Controls.OfType<TextBox>().FirstOrDefault(t => t.PlaceholderText == "Thời gian dừng (phút)")?.Text, out int duration) ? duration : 0
                };

                if (string.IsNullOrEmpty(stopPointDto.Name))
                {
                    MessageBox.Show("Vui lòng nhập tên điểm dừng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (stopPointDto.StoppingTime <= 0)
                {
                    MessageBox.Show("Thời gian dừng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _itineraryDto.StopPoints.Add(stopPointDto);
            }
            if (_itineraryDto.StopPoints.Count < 2)
            {
                MessageBox.Show("Vui lòng thêm ít nhất hai điểm dừng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lblTen.Text = string.Join(" - ", _itineraryDto.StopPoints.Select(sp => sp.Name));
            _itineraryDto.ItineraryName = string.Join(" - ", _itineraryDto.StopPoints.Select(sp => sp.Name));

            if (cbxTuyen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tuyến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxTuyen.SelectedValue != null)
            {
                _itineraryDto.RouteID = Guid.Parse(cbxTuyen.SelectedValue.ToString());
            }

            var respone = await _itineraryService.UpdateItineraryAsync(_itinerary.ItineraryID, _itineraryDto);

            if (respone != null)
            {
                MessageBox.Show($"Cập nhật thành công! {respone.ItineraryID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
