using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public interface ILeaveAppicationService : IBaseService<LeaveApplicationDto, LeaveApplicationCreateDto, LeaveApplicationUpdateDto>
    {
        Task<(List<LeaveApplicationDto>, int)> FilterAsync(int PageSize, int PageNumber, string? FullName = null, string? DepartmentName = null, int? State = null);
    }
}
