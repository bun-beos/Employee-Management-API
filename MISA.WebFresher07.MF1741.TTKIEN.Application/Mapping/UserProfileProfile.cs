using AutoMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile() { 
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>();
            CreateMap<UserProfileUpdateDto, UserProfile>();
        }
    }
}
