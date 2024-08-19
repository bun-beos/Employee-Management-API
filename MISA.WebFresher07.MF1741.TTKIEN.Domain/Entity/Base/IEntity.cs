using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    public interface IEntity
    {
        /// <summary>
        /// Hàm lấy ra id
        /// </summary>
        /// <returns>id của bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        public Guid GetId();

        /// <summary>
        /// Hàm tạo id
        /// </summary>
        /// <param name="id">id mới của bản ghi</param>
        /// Created by: ttkien (16/09/2023)
        public void SetId(Guid id);
    }
}
