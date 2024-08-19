using AutoMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application.Service
{
    public class UserProfileService : BaseService<UserProfile, UserProfileDto, UserProfileCreateDto, UserProfileUpdateDto>, IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper) : base(userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public override UserProfile MapEntityCreateDtoToEntity(UserProfileCreateDto entityCreateDto)
        {
            throw new NotImplementedException();
        }

        public override UserProfile MapEntityDtoToEntity(UserProfileDto userProfileDto)
        {
            var userProfile = _mapper.Map<UserProfile>(userProfileDto);

            return userProfile;
        }

        public override UserProfileDto MapEntityToEntityDto(UserProfile userProfile)
        {
            var userProfileDto = _mapper.Map<UserProfileDto>(userProfile);

            return userProfileDto;
        }

        public override UserProfile MapEntityUpdateDtoToEntity(UserProfileUpdateDto userProfileUpdateDto, UserProfile userProfile)
        {
            var result = _mapper.Map(userProfileUpdateDto, userProfile);

            return result;
        }
    }
}
