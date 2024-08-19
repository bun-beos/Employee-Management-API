using AutoMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public class LeaveApplicationProfile : Profile
    {
        public LeaveApplicationProfile() { 
            CreateMap<LeaveApplication, LeaveApplicationDto>();
            CreateMap<LeaveApplicationCreateDto, LeaveApplication>();
            CreateMap<LeaveApplicationUpdateDto, LeaveApplication>();
        }
    }
}
