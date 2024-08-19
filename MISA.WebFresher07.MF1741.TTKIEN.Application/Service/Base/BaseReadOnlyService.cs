using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public abstract class BaseReadOnlyService<TEntity, TEntityDto> : IBaseReadOnlyService<TEntityDto>
    {
        protected readonly IBaseRepository<TEntity> BaseRepository;

        protected BaseReadOnlyService(IBaseRepository<TEntity> baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var entities = await BaseRepository.GetAllAsync();
            
            var result = entities.Select(entity => MapEntityToEntityDto(entity)).ToList();

            return result;
        }

        public async Task<TEntityDto> GetAsync(Guid id)
        {
            var entity = await BaseRepository.GetAsync(id);

            var result = MapEntityToEntityDto(entity);

            return result;
        }

        public async Task<List<TEntityDto>> GetByIdsAsync(List<Guid> ids)
        {
            var entities = await BaseRepository.GetByIdsAsync(ids);

            var result = entities.Select(entity => MapEntityToEntityDto(entity)).ToList();

            return result;
        }

        public async Task<string> GetNewCodeAsync()
        {
            var result = await BaseRepository.GetNewCodeAsync();

            return result;
        }

        //public async Task<(List<TEntityDto>,int)> FilterAsync(int pageSize, int pageNumber, string? name = null, string? code = null, string? phoneNumber = null)
        //{
        //    var (entities, totalRows) = await BaseRepository.FilterAsync(pageSize, pageNumber, name, code, phoneNumber);

        //    var entityDtos = entities.Select(entity => MapEntityToEntityDto(entity)).ToList();

        //    return (entityDtos, totalRows);
        //}

        public abstract TEntityDto MapEntityToEntityDto(TEntity entity);

        public abstract TEntity MapEntityDtoToEntity(TEntityDto entityDto);

        
    }
}
