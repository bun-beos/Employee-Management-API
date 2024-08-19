using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    public class UserProfile : IEntity
    {
        /// <summary>
        /// id của tài khoản
        /// </summary>
        public Guid ProfileId { get; set; }

        /// <summary>
        /// định dạng ngày tháng năm
        /// </summary>
        public DateFormat ProfileDateFormat { get; set; }

        public Guid GetId()
        {
            return ProfileId;
        }

        public void SetId(Guid id)
        {
            ProfileId = id;
        }
    }
}
