using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public interface IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IBaseReadOnlyService<TEntityDto>
    {

        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="entityCreateDto">Thông tin bản ghi cần thêm</param>
        /// <returns>Thông tin bản ghi vừa mới thêm</returns>
        /// Created by: ttkien (16/09/2023)
        Task<TEntityDto> InsertAsync(TEntityCreateDto entityCreateDto);

        /// <summary>
        /// Hàm thay đổi thông tin một bản ghi
        /// </summary>
        /// <param name="id">Định danh bản ghi cần sửa</param>
        /// <param name="entityUpdateDto">Thông tin đã sửa của bản ghi</param>
        /// <returns>Thông tin bản ghi đã thay đổi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<TEntityDto> UpdateAsync(Guid id, TEntityUpdateDto entityUpdateDto);

        /// <summary>
        /// Hàm xóa một bản ghi
        /// </summary>
        /// <param name="id">Định danh bản ghi cần xóa</param>
        /// <exception cref="NotFoundException">Khi không tìm thấy bản ghi</exception>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách định danh bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi đã xóa</returns>
        /// Created by: ttkien (16/09/2023)
        Task<int> DeleteManyAsync(List<Guid> ids);
    }
}
