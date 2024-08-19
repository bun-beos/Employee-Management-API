using Dapper;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Infrastructure
{
    public class LeaveApplicationRepository : BaseRepository<LeaveApplication>, ILeaveApplicationRepository
    {
        public LeaveApplicationRepository(IUnitOfWork unitOfWork) : base(unitOfWork){}

        public async Task<(List<LeaveApplication>, int)> FilterAsync(int PageSize, int PageNumber, string? FullName = null, string? DepartmentName = null, int? State = null)
        {
            // Tạo biến đầu vào
            var param = new
            {
                p_PageSize = PageSize,
                p_PageNumber = PageNumber,
                p_FullName = FullName,
                p_DepartmentName = DepartmentName,
                p_State = State,
            };

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.QueryMultipleAsync($"proc_{TableName}_Filter", param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            var leaveApplications = result.Read<LeaveApplication>().ToList();

            var totalRows = result.Read<int>().Single();

            return (leaveApplications, totalRows);
        }
    }
}
