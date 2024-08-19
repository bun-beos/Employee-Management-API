using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public interface IBaseReadOnlyService<TEntityDto>
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<List<TEntityDto>> GetAllAsync();

        /// <summary>
        /// Hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">Định danh bản ghi</param>
        /// <exception cref="NotFoundException">Khi không tìm thấy bản ghi</exception>
        /// <returns>Một bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<TEntityDto> GetAsync(Guid id);

        /// <summary>
        /// Hàm lấy danh sách bản ghi
        /// </summary>
        /// <param name="ids">Danh sách định danh bản ghi</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<List<TEntityDto>> GetByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Hàm lấy mã code mới
        /// </summary>
        /// <returns>Mã code mới cho bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<string> GetNewCodeAsync();

        /// <summary>
        /// Hàm phân trang và tìm kiếm dữ liệu
        /// </summary>
        /// <param name="pageSize">Kích thước một trang</param>
        /// <param name="pageNumber">Số trang hiện tại</param>
        /// <param name="name">Tên tìm kiếm</param>
        /// <param name="code">Mã tìm kiếm</param>
        /// <param name="phoneNumber">Số điện thoại tìm kiếm</param>
        /// <returns>Danh sách bản ghi và tổng số bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        //Task<(List<TEntityDto>, int)> FilterAsync(int pageSize, int pageNumber, string? name = null, string? code = null, string? phoneNumber = null);
    }
}
