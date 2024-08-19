using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using OfficeOpenXml;

namespace MISA.WebFresher07.MF1741.TTKIEN
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseReadOnlyController<TEntityDto> : ControllerBase
    {
        protected readonly IBaseReadOnlyService<TEntityDto> BaseReadOnlyService;

        public BaseReadOnlyController(IBaseReadOnlyService<TEntityDto> baseReadOnlyService)
        {
            BaseReadOnlyService = baseReadOnlyService;
        }

        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: ttkien (10/9/2023)
        [HttpGet]
        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var result = await BaseReadOnlyService.GetAllAsync();
            return result;
        }

        /// <summary>
        /// Hàm lấy ra bản ghi theo id
        /// </summary>
        /// <param name="id">Định danh bản ghi</param>
        /// <returns>Bản ghi hoặc exception nếu không tìm thấy</returns>
        /// Created by: ttkien(16/09/2023)
        [HttpGet]
        [Route("{id}")]
        public async Task<TEntityDto> GetAsync(Guid id)
        {
            var result = await BaseReadOnlyService.GetAsync(id);
            return result;
        }

        /// <summary>
        /// Hàm lấy danh sách bản ghi
        /// </summary>
        /// <param name="ids">Danh sách định danh bản ghi</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ttkien (16/09/2023)
        [HttpGet]
        [Route("ids")]
        public async Task<List<TEntityDto>> GetByIdsAsync([FromQuery] List<Guid> ids)
        {
            var result = await BaseReadOnlyService.GetByIdsAsync(ids);

            return result;
        }

        /// <summary>
        /// Hàm lấy mã bản ghi mới
        /// </summary>
        /// <returns>Mã bản ghi mới</returns>
        /// Created by: ttkien(16/09/2023)
        [HttpGet]
        [Route("NewCode")]
        public async Task<string> GetNewCodeAsync()
        {
            var result = await BaseReadOnlyService.GetNewCodeAsync();

            return result;
        }

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
        //[HttpGet]
        //[Route("Filter")]
        //public async Task<dynamic> FilterAsync(int pageSize, int pageNumber, string? name = null, string? code = null, string? phoneNumber = null)
        //{
        //    var (entityDtos, totalRows) = await BaseReadOnlyService.FilterAsync(pageSize, pageNumber, name, code, phoneNumber);
        //    var result = new
        //    {
        //        Employees = entityDtos,
        //        TotalRows = totalRows,
        //    };
        //    return result;
        //}

    }
}
