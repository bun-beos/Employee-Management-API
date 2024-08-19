using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public interface IEmployeeService : IBaseService<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        Task<(List<EmployeeDto>, int)> FilterAsync(int pageSize, int pageNumber, string? fullName = null, string? employeeCode = null, string? phoneNumber = null);
    }
}
