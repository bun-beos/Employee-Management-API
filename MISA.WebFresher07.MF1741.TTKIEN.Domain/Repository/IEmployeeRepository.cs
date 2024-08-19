using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    /// <summary>
    /// Interface tương tác với Repository của Employee
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Hàm kiểm tra mã nhân viên trùng lặp
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>true nếu nhân viên đã tồn tại và false nếu ngược lại</returns>
        /// Created by: ttkien (16/09/2023)
        Task<bool> IsExistEmployeeAsync(string employeeCode);

        Task<(List<Employee>, int)> FilterAsync(int pageSize, int pageNumber, string? fullName = null, string? employeeCode = null, string? phoneNumber = null);
    }
}
