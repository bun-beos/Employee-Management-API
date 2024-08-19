using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public abstract class BaseService<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyService<TEntity, TEntityDto>, IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> where TEntity : IEntity
    {
        protected BaseService(IBaseRepository<TEntity> baseRepository) : base(baseRepository) { }

        public async Task<TEntityDto> InsertAsync(TEntityCreateDto entityCreateDto)
        {
            var entity = MapEntityCreateDtoToEntity(entityCreateDto);

            if (entity.GetId() == Guid.Empty)
            {
                entity.SetId(Guid.NewGuid());
            }

            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreateDate ??= DateTime.Now;
                baseEntity.CreateBy ??= "TTKIEN";
                baseEntity.ModifiedDate ??= DateTime.Now;
                baseEntity.ModifiedBy ??= "TTKIEN";
            }

            await ValidateCreateBusiness(entity);

            await BaseRepository.InsertAsync(entity);

            var result = MapEntityToEntityDto(entity);

            return result;
        }

        public async Task<TEntityDto> UpdateAsync(Guid id, TEntityUpdateDto entityUpdateDto)
        {
            var entity = await BaseRepository.GetAsync(id);

            var newEntity = MapEntityUpdateDtoToEntity(entityUpdateDto, entity);

            if (newEntity is BaseEntity baseEntity)
            {
                baseEntity.ModifiedDate ??= DateTime.Now;
                baseEntity.ModifiedBy ??= "TTKIEN";
            }

            await ValidateUpdateBusiness(newEntity, entity);

            await BaseRepository.UpdateAsync(newEntity);

            var result = MapEntityToEntityDto(newEntity);

            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await BaseRepository.GetAsync(id);

            var result = await BaseRepository.DeleteAsync(entity);

            return result;

        }

        public async Task<int> DeleteManyAsync(List<Guid> ids)
        {
            var entities = await BaseRepository.GetByIdsAsync(ids);

            var result = await BaseRepository.DeleteManyAsync(entities);

            return result;
        }

        public abstract TEntity MapEntityCreateDtoToEntity(TEntityCreateDto entityCreateDto);

        public virtual async Task ValidateCreateBusiness(TEntity entity)
        {
            await Task.CompletedTask;
        }
        
        public abstract TEntity MapEntityUpdateDtoToEntity(TEntityUpdateDto entityUpdateDto, TEntity entity);

        public virtual async Task ValidateUpdateBusiness(TEntity entity, TEntity entityOld)
        {
            await Task.CompletedTask;
        }
    }
}
