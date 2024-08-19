using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Hàm tìm kiếm một bản ghi
        /// </summary>
        /// <param name="id">Định danh bản ghi</param>
        /// <returns>Một bản ghi hoặc null nếu không tìm thấy</returns>
        /// Created by: ttkien (16/09/2023)
        Task<TEntity?> FindAsync(Guid id);

        /// <summary>
        /// Hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">Định danh bản ghi</param>
        /// <exception cref="NotFoundException">Khi không tìm thấy bản ghi</exception>
        /// <returns>Một bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        /// Hàm lấy danh sách bản ghi
        /// </summary>
        /// <param name="ids">Danh sách định danh bản ghi</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<List<TEntity>> GetByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Hàm lấy mã code mới
        /// </summary>
        /// <returns>Mã code mới</returns>
        /// Created by: ttkien (16/09/2023)
        Task<string> GetNewCodeAsync();

        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Thông tin bản ghi cần thêm</param>
        /// <returns>Thông tin bản ghi vừa thêm</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> InsertAsync(TEntity entity);

        /// <summary>
        /// Hàm thêm mới nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách thông tin bản ghi cần thêm</param>
        /// <returns>Thông tin bản ghi vừa thêm</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> InsertManyAsync(List<TEntity> entities);

        /// <summary>
        /// Hàm thay đổi thông tin một bản ghi
        /// </summary>
        /// <param name="entity">Thông tin đã sửa của bản ghi</param>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Hàm thay đổi thông tin nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách thông tin đã sửa của bản ghi</param>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> UpdateManyAsync(List<TEntity> entities);

        /// <summary>
        /// Hàm xóa một bản ghi
        /// </summary>
        /// <param name="entity">Thông tin bản ghi cần xóa</param>
        /// <exception cref="NotFoundException">Khi không tìm thấy bản ghi</exception>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi đã xóa</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> DeleteManyAsync(List<TEntity> entities);

        ///// <summary>
        ///// Hàm phân trang và tìm kiếm dữ liệu
        ///// </summary>
        ///// <param name="pageSize">Kích thước một trang</param>
        ///// <param name="pageNumber">Số trang hiện tại</param>
        ///// <param name="name">Tên tìm kiếm</param>
        ///// <param name="code">Mã tìm kiếm</param>
        ///// <param name="phoneNumber">Số điện thoại tìm kiếm</param>
        ///// <returns>Danh sách bản ghi và tổng số bản ghi</returns>
        ///// Created by: ttkien (16/09/2023)
        //Task<(List<TEntity>, int)> FilterAsync(int pageSize, int pageNumber, string? name = null, string? code = null, string? phoneNumber = null);
    }
}
