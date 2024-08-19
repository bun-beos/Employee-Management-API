using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    public enum LeaveApplicationState
    {
        /// <summary>
        /// Chờ duyệt
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Từ chối
        /// </summary>
        Rejected = 1,

        /// <summary>
        /// Đã duyệt
        /// </summary>
        Approved = 2,
    }
}
