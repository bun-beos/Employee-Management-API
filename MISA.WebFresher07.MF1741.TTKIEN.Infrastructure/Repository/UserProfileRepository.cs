using Dapper;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Infrastructure
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public override async Task<int> UpdateAsync(UserProfile userProfile)
        {
            // Tạo biến đầu vào
            var param = new
            {
                p_UserProfileId = userProfile.ProfileId,
                p_UserProfileDateFormat = userProfile.ProfileDateFormat,
            };

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.ExecuteAsync("Proc_UserProfile_Put", param, commandType: CommandType.StoredProcedure);

            return result;
        }

    }
}
