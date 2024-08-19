using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher07.MF1741.TTKIEN.Application;

namespace MISA.WebFresher07.MF1741.TTKIEN
{
    public class BaseController<TEntityDto, TEntityCreateDto, TentityUpdaetDto> : BaseReadOnlyController<TEntityDto>
    {
        protected readonly IBaseService<TEntityDto, TEntityCreateDto, TentityUpdaetDto> BaseService;

        public BaseController(IBaseService<TEntityDto, TEntityCreateDto, TentityUpdaetDto> baseService) : base(baseService)
        {
            BaseService = baseService;
        }


        /// <summary>
        /// Hàm thêm mới bản ghi
        /// </summary>
        /// <param name="entityCreateDto">Dữ liệu thêm mới</param>
        /// <returns>Dữ liệu thêm mới</returns>
        /// Created by: ttkien(16/09/2023)
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> InsertAsync([FromBody] TEntityCreateDto entityCreateDto)
        {
            var result = await BaseService.InsertAsync(entityCreateDto);
            return StatusCode(201, result);
        }

        /// <summary>
        /// Hàm sửa dữ liệu bản ghi
        /// </summary>
        /// <param name="id">Định danh bản ghi</param>
        /// <param name="entityUpdateDto">Dữ liệu update</param>
        /// <returns>Dữ liệu update</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<TEntityDto> UpdateAsync(Guid id, [FromBody] TentityUpdaetDto entityUpdateDto)
        {
            var result = await BaseService.UpdateAsync(id, entityUpdateDto);

            return result;
        }

        /// <summary>
        /// Hàm xóa một bản ghi
        /// <param name="id">Định danh bản ghi</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// </summary>
        /// Created by: ttkien(16/09/2023)
        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await BaseService.DeleteAsync(id);
            return result;
        }

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách định danh bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi đã xóa</returns>
        /// Created by: ttkien (16/09/2023)
        [HttpDelete]
        public async Task<int> DeleteManyAsync([FromBody] List<Guid> ids)
        {
            var result = await BaseService.DeleteManyAsync(ids);

            return result;
        }
    }
}
