using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    public interface ILeaveApplicationRepository : IBaseRepository<LeaveApplication>
    {
        Task<(List<LeaveApplication>, int)> FilterAsync(int PageSize, int PageNumber, string? FullName = null, string? DepartmentName = null, int? State = null);
    }
}
