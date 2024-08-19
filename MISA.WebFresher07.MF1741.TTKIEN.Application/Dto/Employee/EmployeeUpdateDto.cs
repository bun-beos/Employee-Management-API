using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public class EmployeeUpdateDto
    {
        /// <summary>
        /// Mã của nhân viên
        /// </summary>
        [MaxLength(20)]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên của nhân viên
        /// </summary>
        [MaxLength(100)]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh của nhân viên
        /// </summary>
        public DateTimeOffset? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính của nhân viên
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Định danh đơn vị
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        public string? PositionName { get; set; }

        /// <summary>
        /// Số căn cước công dân
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp căn cước công dân
        /// </summary>
        public DateTimeOffset? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp căn cước công dân
        /// </summary>
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Điện thoại cố định
        /// </summary>
        public string? TelephoneNumber { get; set; }

        /// <summary>
        /// Điện thoại di động
        /// </summary>
        public string? MobilePhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankBranch { get; set; }

        public float? NumberOfDaysOff { get; set; }

        public string? Avatar { get; set; }
    }
}
