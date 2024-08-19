using AutoMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public class LeaveApplicationService : BaseService<LeaveApplication, LeaveApplicationDto, LeaveApplicationCreateDto, LeaveApplicationUpdateDto>, ILeaveAppicationService
    {
        private readonly ILeaveApplicationRepository _leaveApplicationRepository;
        private readonly IMapper _mapper;

        public LeaveApplicationService(ILeaveApplicationRepository leaveApplicationRepository, IMapper mapper) : base(leaveApplicationRepository)
        {
            _leaveApplicationRepository = leaveApplicationRepository;
            _mapper = mapper;
        }

        public override LeaveApplication MapEntityCreateDtoToEntity(LeaveApplicationCreateDto leaveApplicationCreateDto)
        {
            var leaveApplication = _mapper.Map<LeaveApplication>(leaveApplicationCreateDto);

            leaveApplication.LeaveApplicationId = Guid.NewGuid();
            leaveApplication.State = 0;
            leaveApplication.CreateDate= DateTime.Now;
            leaveApplication.CreateBy = "TTKIEN";
            leaveApplication.ModifiedDate = DateTime.Now;
            leaveApplication.ModifiedBy = "TTKIEN";

            return leaveApplication;
        }

        public override LeaveApplication MapEntityDtoToEntity(LeaveApplicationDto entityDto)
        {
            throw new NotImplementedException();
        }

        public override LeaveApplicationDto MapEntityToEntityDto(LeaveApplication leaveApplication)
        {
            var leaveApplicationDto = _mapper.Map<LeaveApplicationDto>(leaveApplication);
            return leaveApplicationDto;
        }

        public override LeaveApplication MapEntityUpdateDtoToEntity(LeaveApplicationUpdateDto leaveApplicationUpdateDto, LeaveApplication leaveApplication)
        {
            var newLeaveApplication = _mapper.Map(leaveApplicationUpdateDto,leaveApplication);

            newLeaveApplication.ModifiedDate = DateTime.Now;
            newLeaveApplication.ModifiedBy = "TTKIEN";

            return newLeaveApplication;
        }

        public async Task<(List<LeaveApplicationDto>, int)> FilterAsync(int PageSize, int PageNumber, string? FullName = null, string? DepartmentName = null, int? State = null)
        {
            var (leaveApplications, totalRows) = await _leaveApplicationRepository.FilterAsync(PageSize, PageNumber, FullName, DepartmentName, State);

            var leaveApplicationDtos = leaveApplications.Select(leaveApplication => MapEntityToEntityDto(leaveApplication)).ToList();

            return (leaveApplicationDtos, totalRows);
        }
    }
}
