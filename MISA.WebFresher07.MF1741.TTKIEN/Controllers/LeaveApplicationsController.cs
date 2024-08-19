using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher07.MF1741.TTKIEN.Application;

namespace MISA.WebFresher07.MF1741.TTKIEN
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LeaveApplicationsController : BaseController<LeaveApplicationDto, LeaveApplicationCreateDto, LeaveApplicationUpdateDto>
    {
        private readonly ILeaveAppicationService _leaveAppicationService;

        public LeaveApplicationsController(ILeaveAppicationService leaveApplicationService ) : base(leaveApplicationService)
        {
            _leaveAppicationService = leaveApplicationService;
        }

        [HttpGet]
        [Route("Filter")]
        public async Task<dynamic> FilterAsync(int PageSize, int PageNumber, string? FullName = null, string? DepartmentName = null, int? State = null)
        {
            var (leaveApplicationDtos, totalRows) = await _leaveAppicationService.FilterAsync(PageSize, PageNumber, FullName, DepartmentName, State);

            var result = new
            {
                LeaveApplications = leaveApplicationDtos,
                TotalRows = totalRows,
            };
            return result;
        }
    }
}
