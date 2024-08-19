using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using MISA.WebFresher07.MF1741.TTKIEN.Infrastructure;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Net;
using System.Reflection;

namespace MISA.WebFresher07.MF1741.TTKIEN
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {

        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("Filter")]
        public async Task<dynamic> FilterAsync(int pageSize, int pageNumber, string? fullName = null, string? employeeCode = null, string? phoneNumber = null)
        {
            var (employeeDtos, totalRows) = await _employeeService.FilterAsync(pageSize, pageNumber, fullName, employeeCode, phoneNumber);

            var result = new
            {
                Employees = employeeDtos,
                TotalRows = totalRows,
            };
            return result;
        }

        [HttpGet]
        [Route("Excel")]
        public async Task<IActionResult> ExportToExcel(DateFormat dateFormatValue, string? fullName = null, string? employeeCode = null, string? phoneNumber = null)
        {
            var (employeeDtos, totalRows) = await _employeeService.FilterAsync(1, 1, fullName, employeeCode, phoneNumber);

            (employeeDtos, totalRows) = await _employeeService.FilterAsync(totalRows, 1, fullName, employeeCode, phoneNumber);

            // Sử dụng thư viện EPPlus để tạo và điền dữ liệu vào file Excel
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Danh sách nhân viên");
            worksheet.Name = "Danh sách nhân viên".ToUpper();

            // Setup các cột các hàng
            worksheet.Cells[1, 1, 1, 11].Merge = true;

            worksheet.Cells[1, 1].Value = "Danh sách nhân viên".ToUpper();
            worksheet.Cells[1, 1].Style.Font.Size = 16;
            worksheet.Cells[1, 1].Style.Font.Bold = true;

            worksheet.Cells[3, 1].Value = "STT";
            worksheet.Cells[3, 2].Value = "Mã nhân viên";
            worksheet.Cells[3, 3].Value = "Tên nhân viên";
            worksheet.Cells[3, 4].Value = "Giới tính";
            worksheet.Cells[3, 5].Value = "Ngày sinh";
            worksheet.Cells[3, 6].Value = "Số CMND";
            worksheet.Cells[3, 7].Value = "Chức danh";
            worksheet.Cells[3, 8].Value = "Tên đơn vị";
            worksheet.Cells[3, 9].Value = "Số tài khoản";
            worksheet.Cells[3, 10].Value = "Tên ngân hàng";
            worksheet.Cells[3, 11].Value = "Chi nhánh TK ngân hàng";

            // Căn chỉnh tiêu đề
            var titleCellsStyle = worksheet.Cells[3, 1, 3, 11].Style;
            titleCellsStyle.Font.Bold = true;
            titleCellsStyle.Fill.PatternType = ExcelFillStyle.Solid;
            titleCellsStyle.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

            // Điền dữ liệu vào file excel
            int row = 4;
            foreach (var item in employeeDtos)
            {
                // Chuyển đổi kiểu dữ liệu enum
                var VNGender = "";
                switch (item.Gender)
                {
                    case Gender.Male:
                        VNGender = "Nam";
                        break;
                    case Gender.Female:
                        VNGender = "Nữ";
                        break;
                    case Gender.Other:
                        VNGender = "Khác";
                        break;
                    default:
                        break;
                }

                var dateType = "";
                switch (dateFormatValue)
                {
                    case DateFormat.dayMonthYear:
                        dateType = "dd/MM/yyyy";
                        break;
                    case DateFormat.monthDayYear:
                        dateType = "MM/dd/yyyy";
                        break;
                    case DateFormat.yearDayMonth:
                        dateType = "yyyy/dd/MM";
                        break;
                    case DateFormat.yearMonthDay:
                        dateType = "yyyy/MM/dd";
                        break;
                    case DateFormat.yearOnly:
                        dateType = "yyyy";
                        break;
                    default:
                        break;
                }

                worksheet.Cells[row, 1].Value = row - 3;
                worksheet.Cells[row, 2].Value = item.EmployeeCode;
                worksheet.Cells[row, 3].Value = item.FullName;
                worksheet.Cells[row, 4].Value = VNGender;
                worksheet.Cells[row, 5].Value = item.DateOfBirth.HasValue ? item.DateOfBirth.Value.ToString(dateType) : "";
                worksheet.Cells[row, 6].Value = item.IdentityNumber;
                worksheet.Cells[row, 7].Value = item.PositionName;
                worksheet.Cells[row, 8].Value = item.DepartmentName;
                worksheet.Cells[row, 9].Value = item.BankAccount;
                worksheet.Cells[row, 10].Value = item.BankName;
                worksheet.Cells[row, 11].Value = item.BankBranch;
                row++;
            }

            // Chỉnh kích thước cho ô
            var columns = worksheet.Cells[worksheet.Dimension.Address].Columns;
            for (int i = 1; i <= columns; i++)
            {
                worksheet.Columns[i].AutoFit();
            }

            var tableRange = worksheet.Cells[3, 1, 3 + totalRows, 11];

            // Căn lề cho bảng
            tableRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            worksheet.Cells[1, 1, 3, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Đặt viền cho bảng
            foreach (var cell in tableRange)
            {
                var cellStyle = cell.Style;
                cellStyle.Border.Top.Style = ExcelBorderStyle.Thin;
                cellStyle.Border.Left.Style = ExcelBorderStyle.Thin;
                cellStyle.Border.Right.Style = ExcelBorderStyle.Thin;
                cellStyle.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }

            // Lưu file Excel vào một MemoryStream
            var memoryStream = new MemoryStream();
            package.SaveAs(memoryStream);

            // Đặt kiểu MIME cho phản hồi
            Response.Headers.Add("Content-Disposition", "attachment; filename=Danh_sach_nhan_vien.xlsx");
            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
