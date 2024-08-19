using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public class LeaveApplicationDto : BaseEntityDto
    {
        /// <summary>
        /// Định danh đơn xin nghỉ
        /// </summary>
        public Guid LeaveApplicationId { get; set; }

        /// <summary>
        /// Định danh của nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã của nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên của nhân viên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        public string? PositionName { get; set; }

        /// <summary>
        /// Định danh đơn vị
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Ngày nộp đơn
        /// </summary>
        public DateTimeOffset DateOfSubmission { get; set; }

        /// <summary>
        /// Từ ngày
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTimeOffset EndDate { get; set; }

        /// <summary>
        /// Số ngày xin nghỉ
        /// </summary>
        public float? NumberOfDays { get; set; }

        /// <summary>
        /// Số giờ xin nghỉ
        /// </summary>
        public float? NumberOfHours { get; set; }

        /// <summary>
        /// Loại nghỉ
        /// </summary>
        public string TypeOfLeave { get; set; }

        /// <summary>
        /// Tỷ lệ hưởng lương
        /// </summary>
        public float? PercentageOfSalary { get; set; }

        /// <summary>
        /// Lý do nghỉ
        /// </summary>
        public string ReasonOfleave { get; set; }

        /// <summary>
        /// Định danh người duyệt
        /// </summary>
        public Guid ApproverId { get; set; }

        /// <summary>
        /// Định danh người thay thế
        /// </summary>
        public Guid? SubstituteId { get; set; }

        /// <summary>
        /// Danh sách định danh người liên quan
        /// </summary>
        public string? RelatedPersonnel { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public LeaveApplicationState State { get; set; }

        /// <summary>
        /// Danh sách định danh người xin nghỉ cùng
        /// </summary>
        public string? ListEmployeeId { get; set; }
    }
}
