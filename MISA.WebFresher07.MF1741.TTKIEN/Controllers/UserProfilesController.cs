using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;

namespace MISA.WebFresher07.MF1741.TTKIEN
{
    public class UserProfilesController : BaseController<UserProfileDto, UserProfileCreateDto, UserProfileUpdateDto>
    {
        public UserProfilesController(IUserProfileService userProfileService) : base(userProfileService)
        {
        }
    }
}
