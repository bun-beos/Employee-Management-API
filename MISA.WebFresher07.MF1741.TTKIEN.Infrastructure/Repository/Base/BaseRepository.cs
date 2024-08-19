using Dapper;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static Dapper.SqlMapper;

namespace MISA.WebFresher07.MF1741.TTKIEN.Infrastructure
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual string TableName { get; set; } = typeof(TEntity).Name;

        public async Task<List<TEntity>> GetAllAsync()
        {         
            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.QueryAsync<TEntity>($"Proc_{TableName}_GetAll", commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result.ToList();
        }

        public async Task<TEntity?> FindAsync(Guid id)
        {         
            // Tạo biến đầu vào
            var param = new DynamicParameters();
            param.Add($"p_{TableName}Id", id);

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>($"Proc_{TableName}_GetById", param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await FindAsync(id);

            return entity == null ? throw new NotFoundException((int)ErrorCodeEnum.NotFoundExceptionCode) : entity;
        }

        public async Task<List<TEntity>> GetByIdsAsync(List<Guid> ids)
        {
            // Tạo biến đầu vào
            string idList = string.Join(",", ids);

            var param = new DynamicParameters();
            param.Add($"p_{TableName}Ids", idList);

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.QueryAsync<TEntity>($"Proc_{TableName}_GetManyByIds", param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result.ToList();
        }

        public async Task<string> GetNewCodeAsync()
        {
            // Tạo biến kết quả
            var param = new DynamicParameters();
            param.Add($"p_New{TableName}Code", direction: ParameterDirection.Output);

            //Thực hiện truy vấn
            await UnitOfWork.Connection.ExecuteAsync($"Proc_{TableName}_GetNewCode", param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            string result = param.Get<string>($"p_New{TableName}Code");

            return result;
        }

        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            await Task.CompletedTask;
            return 0;
        }

        public Task<int> InsertManyAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            await Task.CompletedTask;
            return 0;
        }

        public Task<int> UpdateManyAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {         
            // Tạo biến đầu vào
            var param = new DynamicParameters();
            param.Add($"p_{TableName}Id", entity.GetId());

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.ExecuteAsync($"Proc_{TableName}_DeleteById", param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result;
        }

        public async Task<int> DeleteManyAsync(List<TEntity> entities)
        {
            // Tạo biến đầu vào
            var ids = new List<Guid>();
            foreach (var entity in entities)
            {
                ids.Add(entity.GetId());
            }

            string idList = string.Join(",", ids);

            var param = new DynamicParameters();
            param.Add($"p_{TableName}Ids", idList);

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.ExecuteAsync($"Proc_{TableName}_DeleteManyByIds", param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            return result;
        }

        //public virtual async Task<(List<TEntity>, int)> FilterAsync(int pageSize, int pageNumber, string? name = null, string? code = null, string? phoneNumber = null)
        //{
        //    await Task.CompletedTask;
        //    var result = new List<TEntity>();
        //    return (result,0);
        //}

    }
}
