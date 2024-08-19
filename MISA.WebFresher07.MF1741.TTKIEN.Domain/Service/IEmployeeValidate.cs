using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    public interface IEmployeeValidate
    {
        /// <summary>
        /// Kiểm tra có tồn tại employeeCode chưa
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <exception cref="ConflictException">Nếu tồn tại</exception>
        /// <returns></returns>
        Task CheckEmployeeExistAsync(Employee employee);

    }
}
